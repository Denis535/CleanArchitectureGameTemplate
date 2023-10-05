#if UNITY_EDITOR
namespace UnityEditor {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor.AssetImporters;
    using UnityEngine;

    [ScriptedImporter( 1, "pug" )]
    public class PugImporter : ScriptedImporter {

        [MenuItem( "Assets/Create/UI Toolkit/Pug" )]
        public static void CreateAsset() {
            ProjectWindowUtil.CreateAssetWithContent( "New Pug.pug", "" );
        }

        public override void OnImportAsset(AssetImportContext context) {
        }

        // Helpers
        private static string GetActiveFolder() {
            var path = AssetDatabase.GetAssetPath( Selection.activeObject ) ?? "Assets/";
            return AssetDatabase.IsValidFolder( path ) ? path : Path.GetDirectoryName( path );
        }

    }
}
#endif
