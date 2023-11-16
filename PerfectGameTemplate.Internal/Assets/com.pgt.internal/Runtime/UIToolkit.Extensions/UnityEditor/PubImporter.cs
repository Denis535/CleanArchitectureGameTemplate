#if UNITY_EDITOR
namespace UnityEditor {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor.AssetImporters;
    using UnityEngine;

    [ScriptedImporter( 1, "pug" )]
    public class PugImporter : ScriptedImporter {

        [MenuItem( "Assets/Create/UI Toolkit/Pug" )]
        public static void CreateAsset() {
            ProjectWindowUtil.CreateAssetWithContent( "New Document.pug", "" );
        }

        public override void OnImportAsset(AssetImportContext context) {
        }

    }
}
#endif
