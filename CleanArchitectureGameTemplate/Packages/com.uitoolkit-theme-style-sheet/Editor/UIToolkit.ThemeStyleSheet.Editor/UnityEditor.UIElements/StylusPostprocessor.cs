﻿#nullable enable
namespace UnityEditor.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    public class StylusPostprocessor : AssetPostprocessor {

        private const string CompileStylusScript = @"
            ""use strict"";
            const Process = require('node:process');
            const FS = require('fs');
            const Path = require('path');
            const Stylus = require( require.resolve('stylus', { paths: [ Path.join(process.env.APPDATA, '/npm/node_modules') ] } ) );

            const src = Process.argv[1];
            const dist = Process.argv[2];
            const source = FS.readFileSync(src, 'utf8');

            Stylus.nodes.Ident = new Proxy(Stylus.nodes.Ident, {
                construct: function(target, args) {
                    args[0] = args[0].replaceAll(/(__)(__*)/g, '__');
                    args[0] = args[0].replaceAll(/(--)(--*)/g, '--');
                    return new target(...args);
                }
            });

            Stylus(source)
                .set('filename',           Path.basename(src)           )
                .set('paths',              [Path.dirname(src)]          )
                .define('eval',            evalEx,                 false)
                .define('raw-eval',        rawEvalEx,              true )
                .define('get-string',      getStringEx,            true )
                .define('get-type',        getTypeEx,              true )
                .define('define',          defineEx,               true )
                .define('is-defined',      isDefinedEx,            true )
                .define('get-definition',  getDefinitionEx,        true )
                .define('get-definitions', getDefinitionsEx,       true )
                //.define('url',             urlEx,                false) // bug: Stylus adds extra .styl extension (failed to locate @import file url(""***.uss"").styl)
                .render(onComplete);

            // onCallback
            function onComplete(error, result) {
                if (error) {
                    console.error(error);
                    FS.writeFile(dist, '', onError);
                } else {
                    FS.writeFile(dist, result, onError);
                }
            }
            function onError(error) {
                if (error) {
                    console.error(error);
                }
            }
            
            // extensions
            function evalEx(script, arg, arg2, arg3, arg4, arg5, arg6) {
                return eval(script.val);
            }
            function rawEvalEx(script, arg, arg2, arg3, arg4, arg5, arg6) {
                return eval(script.nodes[0].val);
            }

            // extensions
            function getStringEx(expr) {
                expr = Stylus.utils.unwrap(expr);
                if (expr.nodes.length == 0) {
                    return new Stylus.nodes.Null();
                }
                if (expr.nodes.length == 1) {
                    const value = expr.nodes[0];
                    if (value.constructor.name == 'String')   return new Stylus.nodes.String(value.string ?? value.toString());
                    if (value.constructor.name == 'Literal')  return new Stylus.nodes.String(value.string ?? value.toString());
                    if (value.constructor.name == 'Ident')    return new Stylus.nodes.String(value.string ?? value.toString());
                    if (value.constructor.name == 'Unit')     return new Stylus.nodes.String(value.string ?? value.toString());
                    if (value.constructor.name == 'RGBA')     return new Stylus.nodes.String(value.name                      );
                    if (value.constructor.name == 'Function') return new Stylus.nodes.String(value.name                      );
                    if (value.constructor.name == 'Null')     return new Stylus.nodes.Null();
                    throw new Error( ""Argument is invalid: "" + value );
                }
                throw new Error( ""Argument is invalid: "" + expr );
            }
            function getTypeEx(expr) {
                expr = Stylus.utils.unwrap(expr);
                if (expr.nodes.length == 0) {
                    return new Stylus.nodes.Null();
                }
                if (expr.nodes.length == 1) {
                    const value = expr.nodes[0];
                    return new Stylus.nodes.String(value.constructor.name);
                }
                {
                    return new Stylus.nodes.String(expr.constructor.name);
                }
            }

            // extensions
            function defineEx(name, expr, global) {
                name = Stylus.utils.unwrap(name).nodes[0].string;
                expr = Stylus.utils.unwrap(expr);
                global = global && global.toBoolean().isTrue;
                if (global === true) {
                    const node = new Stylus.nodes.Ident(name, expr);
                    this.global.scope.add(node);
                    return;
                }
                if (global === false || global === undefined) {
                    const node = new Stylus.nodes.Ident(name, expr);
                    this.currentScope.add(node);
                    return;
                }
            }
            function isDefinedEx(name, global) {
                name = Stylus.utils.unwrap(name).nodes[0].string;
                global = global && global.toBoolean().isTrue;
                if (global === true) {
                    return new Stylus.nodes.Boolean(this.global.scope.locals[name]);
                }
                if (global === false) {
                    return new Stylus.nodes.Boolean(this.currentScope.locals[name]);
                }
                return new Stylus.nodes.Boolean(this.lookup(name));
            }
            function getDefinitionEx(name, global) {
                name = Stylus.utils.unwrap(name).nodes[0].string;
                global = global && global.toBoolean().isTrue;
                if (global === true) {
                    return this.global.scope.locals[name];
                }
                if (global === false) {
                    return this.currentScope.locals[name];
                }
                return this.lookup(name);
            }
            function getDefinitionsEx(global) {
                global = global && global.toBoolean().isTrue;
                if (global === true) {
                    const result = new Stylus.nodes.Object();
                    for (const [key, value] of Object.entries(this.global.scope.locals)) {
                        result.setValue(key, value);
                    }
                    return result;
                }
                if (global === false) {
                    const result = new Stylus.nodes.Object();
                    for (const [key, value] of Object.entries(this.currentScope.locals)) {
                        result.setValue(key, value);
                    }
                    return result;
                }
                console.error('Not implemented');
            }

            // extensions
            function urlEx(url) {
                return new Stylus.nodes.Literal('url(' + url + ')');
            }";

        // OnPostprocessAllAssets
        public static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFrom) {
            foreach (var imported_ in imported) {
                OnAssetImported( imported_ );
            }
            foreach (var deleted_ in deleted) {
                OnAssetDeleted( deleted_ );
            }
            foreach (var (moved_, movedFrom_) in moved.Zip( movedFrom, (a, b) => (a, b) )) {
                OnAssetMoved( moved_, movedFrom_ );
            }
        }
        private static void OnAssetImported(string path) {
            if (IsStylus( path ) && IsSupported( path )) {
                CompileStylus( path, Path.ChangeExtension( path, ".uss" ) );
                AssetDatabase.ImportAsset( Path.ChangeExtension( path, ".uss" ) );
            }
        }
        private static void OnAssetDeleted(string path) {
            if (IsStylus( path )) {
                AssetDatabase.DeleteAsset( Path.ChangeExtension( path, ".uss" ) );
            }
        }
        private static void OnAssetMoved(string newPath, string oldPath) {
            if (IsStylus( oldPath )) {
                AssetDatabase.MoveAsset( Path.ChangeExtension( oldPath, ".uss" ), Path.ChangeExtension( newPath, ".uss" ) );
            }
        }

        // Helpers
        private static void CompileStylus(string src, string dist) {
            NodeJS.EvaluateJavaScript( CompileStylusScript, src, dist );
        }
        //private static async Task<(string Name, string Path, string ResolvedPath)[]> GetPackages() {
        //    var request = PackageManager.Client.List( true, true );
        //    while (!request.IsCompleted) await Task.Yield();
        //    return request.Result.Select( i => (Name: i.name, Path: i.assetPath, ResolvedPath: i.resolvedPath) ).ToArray();
        //}
        private static bool IsStylus(string path) {
            return Path.GetExtension( path ) == ".styl";
        }
        private static bool IsSupported(string path) {
            return !Path.GetFileName( path ).StartsWith( "_" );
        }

    }
}
