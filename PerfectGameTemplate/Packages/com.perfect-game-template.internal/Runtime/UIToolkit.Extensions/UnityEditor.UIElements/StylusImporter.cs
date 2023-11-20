#if UNITY_EDITOR
namespace UnityEditor.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnityEditor.AssetImporters;
    using UnityEngine;

    [ScriptedImporter( 1, "styl" )]
    public class StylusImporter : ScriptedImporter {

        [MenuItem( "Assets/Create/UI Toolkit/Stylus" )]
        public static void CreateAsset() {
            ProjectWindowUtil.CreateAssetWithContent( "New Style Sheet.styl", "" );
        }

        public override void OnImportAsset(AssetImportContext context) {
        }

    }
    public class StylusPostprocessor : AssetPostprocessor {

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
            if (IsStylus( path ) && IsSupported( path )) {
                CompileStylus( path, Path.ChangeExtension( path, ".uss" ) );
                AssetDatabase.ImportAsset( Path.ChangeExtension( path, ".uss" ) );
            }
        }

        // OnAssetDeleted
        private static void OnAssetDeleted(string path) {
            if (IsStylus( path )) {
                AssetDatabase.DeleteAsset( Path.ChangeExtension( path, ".uss" ) );
            }
        }

        // OnAssetMoved
        private static void OnAssetMoved(string newPath, string oldPath) {
            if (IsStylus( oldPath )) {
                AssetDatabase.MoveAsset( Path.ChangeExtension( oldPath, ".uss" ), Path.ChangeExtension( newPath, ".uss" ) );
            }
        }

        // CompileStylus
        private static void CompileStylus(string src, string dist) {
            NodeJS.EvaluateJavaScript( $@"
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
                .define('get-string', getStringEx, raw = true )
                .define('get-type',   getTypeEx,   raw = true )
                .define('is-defined', isDefinedEx, raw = true )
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
                    throw new Error( ""Argument 'expr' is not supported: "" + expr2 );
                }}
                throw new Error( ""Argument 'expr' is invalid: "" + expr );
            }}
            function getTypeEx(expr) {{
                expr = Stylus.utils.unwrap(expr);
                if (expr.nodes.length == 0) return new Stylus.nodes.Null();
                if (expr.nodes.length == 1) return new Stylus.nodes.String(expr.nodes[0].constructor.name);
                return new Stylus.nodes.Literal(expr.constructor.name);
            }}
            function isDefinedEx(expr) {{
                expr = Stylus.utils.unwrap(expr);
                if (expr.nodes.length == 0) {{
                    return new Stylus.nodes.Null();
                }}
                if (expr.nodes.length == 1) {{
                    const expr2 = expr.nodes[0];
                    if (expr2.constructor.name == 'String')  return new Stylus.nodes.Boolean(this.lookup(expr2.string ?? expr2.toString()));
                    if (expr2.constructor.name == 'Literal') return new Stylus.nodes.Boolean(this.lookup(expr2.string ?? expr2.toString()));
                    if (expr2.constructor.name == 'Ident')   return new Stylus.nodes.Boolean(this.lookup(expr2.string ?? expr2.toString()));
                    if (expr2.constructor.name == 'Null')    return new Stylus.nodes.Null();
                    throw new Error( ""Argument 'expr' is not supported: "" + expr2 );
                }}
                throw new Error( ""Argument 'expr' is invalid: "" + expr );
            }}
            " );
        }

        // Helpers
        private static bool IsStylus(string path) {
            return Path.GetExtension( path ) == ".styl";
        }
        private static bool IsSupported(string path) {
            return !Path.GetFileName( path ).StartsWith( "_" );
        }

    }
}
#endif
