#if UNITY_EDITOR
#nullable enable
namespace UnityEditor {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class AssetPostprocessor2 : AssetPostprocessor {

        // OnGeneratedSlnSolution
        public static string OnGeneratedSlnSolution(string path, string content) {
            return content;
        }

        // OnGeneratedCSProject
        public static string OnGeneratedCSProject(string path, string content) {
            return content;
        }

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

        // OnAssetImported
        private static void OnAssetImported(string path) {
            if (IsPug( path ) && IsSupported( path )) {
                CompilePug( path, Path.ChangeExtension( path, ".uxml" ) );
                AssetDatabase.ImportAsset( Path.ChangeExtension( path, ".uxml" ) );
            }
            if (IsCss( path ) && IsSupported( path )) {
                CompilePostCss( path, Path.ChangeExtension( path, ".uss" ) );
                AssetDatabase.ImportAsset( Path.ChangeExtension( path, ".uss" ) );
            }
            if (IsStylus( path ) && IsSupported( path )) {
                CompileStylus( path, Path.ChangeExtension( path, ".uss" ) );
                AssetDatabase.ImportAsset( Path.ChangeExtension( path, ".uss" ) );
            }
        }

        // OnAssetDeleted
        private static void OnAssetDeleted(string path) {
            if (IsPug( path )) {
                AssetDatabase.DeleteAsset( Path.ChangeExtension( path, ".uxml" ) );
            }
            if (IsCss( path )) {
                AssetDatabase.DeleteAsset( Path.ChangeExtension( path, ".uss" ) );
            }
            if (IsStylus( path )) {
                AssetDatabase.DeleteAsset( Path.ChangeExtension( path, ".uss" ) );
            }
        }

        // OnAssetMoved
        private static void OnAssetMoved(string newPath, string oldPath) {
            if (IsPug( oldPath )) {
                AssetDatabase.MoveAsset( Path.ChangeExtension( oldPath, ".uxml" ), Path.ChangeExtension( newPath, ".uxml" ) );
            }
            if (IsCss( oldPath )) {
                AssetDatabase.MoveAsset( Path.ChangeExtension( oldPath, ".uss" ), Path.ChangeExtension( newPath, ".uss" ) );
            }
            if (IsStylus( oldPath )) {
                AssetDatabase.MoveAsset( Path.ChangeExtension( oldPath, ".uss" ), Path.ChangeExtension( newPath, ".uss" ) );
            }
        }

        // CompilePug
        private static void CompilePug(string src, string dist) {
            EvaluateJavaScript( $@"
            const FS = require('fs');
            const Path = require('path');
            const Pug = require( require.resolve('pug', {{ paths: [ Path.join(process.env.APPDATA, '/npm/node_modules') ] }} ) );

            const src = '{src}';
            const dist = '{dist}';
            const source = FS.readFileSync(src, 'utf8');
            const options = {{
                doctype: 'xml',
                pretty: true
            }};

            Pug.render(source, options, onComplete);

            // onCallback
            function onComplete(error, result) {{
                if (error) {{
                    console.error(error);
                    FS.writeFile(dist, '', onError);
                }} else {{
                    FS.writeFile(dist, result.replaceAll('::', '.'), onError);
                }}
            }}
            function onError(error) {{
                if (error) {{
                    console.error(error);
                }}
            }}
            " );
        }

        // CompilePostCss
        private static void CompilePostCss(string src, string dist) {
            EvaluateJavaScript( $@"
            const FS = require('fs');
            const Path = require('path');
            const PostCss = require( require.resolve('postcss', {{ paths: [ Path.join(process.env.APPDATA, '/npm/node_modules') ] }} ) );
            const PostCss_Use = require( require.resolve('postcss-use', {{ paths: [ Path.join(process.env.APPDATA, '/npm/node_modules') ] }} ) );

            const src = '{src}';
            const dist = '{dist}';
            const source = FS.readFileSync(src, 'utf8');
            const plugins = [PostCss_Use({{modules: '*'}})];
            const options = {{
                from: src,
                to: dist
            }};

            PostCss(plugins)
                .process(source, options)
                .then(onComplete);

            // onCallback
            function onComplete(result) {{
                for (const warning of result.warnings()) {{
                    console.warn(warning.toString());
                }}
                FS.writeFile(dist, result.css, onError);
            }}
            function onError(error) {{
                if (error) {{
                    console.error(error);
                }}
            }}
            " );
        }

        // CompileStylus
        private static void CompileStylus(string src, string dist) {
            EvaluateJavaScript( $@"
            const FS = require('fs');
            const Path = require('path');
            const Stylus = require( require.resolve('stylus', {{ paths: [ Path.join(process.env.APPDATA, '/npm/node_modules') ] }} ) );

            const src = '{src}';
            const dist = '{dist}';
            const source = FS.readFileSync(src, 'utf8');

            Stylus(source)
                .set('filename',      Path.basename(src)      )
                .set('paths',         [Path.dirname(src)]     )
                .define('eval',       evalEx,      raw = false)
                .define('raw-eval',   rawEvalEx,   raw = true )
                .define('get-type',   getTypeEx,   raw = true )
                .define('get-string', getStringEx, raw = true )
                .render(onComplete);

            // onCallback
            function onComplete(error, result) {{
                if (error) {{
                    console.error(error);
                    FS.writeFile(dist, '', onError);
                }} else {{
                    FS.writeFile(dist, result, onError);
                }}
            }}
            function onError(error) {{
                if (error) {{
                    console.error(error);
                }}
            }}
            
            // extensions
            function evalEx(script, arg, arg2, arg3, arg4, arg5, arg6) {{
                return eval(script.val);
            }}
            function rawEvalEx(script, arg, arg2, arg3, arg4, arg5, arg6) {{
                return eval(script.nodes[0].val);
            }}
            function getTypeEx(expr) {{
                expr = Stylus.utils.unwrap(expr);
                if (expr.nodes.length == 0) return new Stylus.nodes.Null();
                if (expr.nodes.length == 1) return new Stylus.nodes.String(expr.nodes[0].constructor.name);
                return new Stylus.nodes.Literal(expr.constructor.name);
            }}
            function getStringEx(expr) {{
                expr = Stylus.utils.unwrap(expr);
                if (expr.nodes.length == 0) {{
                    return new Stylus.nodes.Null();
                }}
                if (expr.nodes.length == 1) {{
                    const expr2 = expr.nodes[0];
                    if (expr2.constructor.name == 'String')   return new Stylus.nodes.String(expr2.string ?? expr2.toString());
                    if (expr2.constructor.name == 'Literal')  return new Stylus.nodes.String(expr2.string ?? expr2.toString());
                    if (expr2.constructor.name == 'Ident')    return new Stylus.nodes.String(expr2.string ?? expr2.toString());
                    if (expr2.constructor.name == 'Unit')     return new Stylus.nodes.String(expr2.string ?? expr2.toString());
                    if (expr2.constructor.name == 'RGBA')     return new Stylus.nodes.String(expr2.name);
                    if (expr2.constructor.name == 'Function') return new Stylus.nodes.String(expr2.name);
                    if (expr2.constructor.name == 'Null')     return new Stylus.nodes.Null();
                    throw new Error( 'Expression is not supported: ' + expr2 );
                }}
                throw new Error( 'Expression is invalid: ' + expr );
            }}
            " );
        }

        // Helpers
        private static void EvaluateJavaScript(string script) {
            script = script.Replace( @"""", @"\""" );
            using var process = System.Diagnostics.Process.Start( new System.Diagnostics.ProcessStartInfo() {
                FileName = "node",
                Arguments = $@"--eval ""{script}""",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            } );
            {
                var outputTask = process.StandardOutput.ReadToEndAsync();
                var errorTask = process.StandardError.ReadToEndAsync();

                if (!string.IsNullOrEmpty( outputTask.Result )) Debug.Log( outputTask.Result ); // todo: it can freeze (when buffer is overloaded) due to sync nature
                if (!string.IsNullOrEmpty( errorTask.Result )) Debug.LogError( errorTask.Result );

                process.StandardInput.Close();
                process.StandardOutput.Close();
                process.StandardError.Close();
            }
            process.WaitForExit( 10_000 );
        }
        // Helpers
        private static bool IsPug(string path) {
            return Path.GetExtension( path ) == ".pug";
        }
        private static bool IsCss(string path) {
            return Path.GetExtension( path ) == ".css";
        }
        private static bool IsStylus(string path) {
            return Path.GetExtension( path ) == ".styl";
        }
        private static bool IsSupported(string path) {
            var name = Path.GetFileName( path );
            return !name.Contains( "__" );
        }

    }
}
#endif
