#if UNITY_EDITOR
namespace UnityEditor {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor.AssetImporters;
    using UnityEngine;

    [ScriptedImporter( 1, "css" )]
    public class CssImporter : ScriptedImporter {

        [MenuItem( "Assets/Create/UI Toolkit/Css" )]
        public static void CreateAsset() {
            ProjectWindowUtil.CreateAssetWithContent( "New Style Sheet.css", "" );
        }

        public override void OnImportAsset(AssetImportContext context) {
        }

    }
}
#endif
