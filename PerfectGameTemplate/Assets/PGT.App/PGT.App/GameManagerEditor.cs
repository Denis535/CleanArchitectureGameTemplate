#if UNITY_EDITOR
#nullable enable
namespace PGT.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor( typeof( GameManager ), true )]
    public class GameManagerEditor : Editor {

        public GameManager Target => (GameManager) target;

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
