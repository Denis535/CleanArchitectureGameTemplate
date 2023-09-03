#if UNITY_EDITOR
#nullable enable
namespace PGT.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor( typeof( AppManager ), true )]
    public class AppManagerEditor : Editor {

        public AppManager Target => (AppManager) target;

        // Awake
        public void Awake() {
        }
        public void OnDestroy() {
        }

        // OnInspectorGUI
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
        }
        public override bool RequiresConstantRepaint() {
            return true;
        }

    }
}
#endif
