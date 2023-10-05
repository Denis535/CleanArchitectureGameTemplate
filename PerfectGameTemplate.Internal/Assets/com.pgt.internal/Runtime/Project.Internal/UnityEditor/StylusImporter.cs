#if UNITY_EDITOR
namespace UnityEditor {
    using System;
    using System.Collections;
    using System.Collections.Generic;
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
}
#endif
