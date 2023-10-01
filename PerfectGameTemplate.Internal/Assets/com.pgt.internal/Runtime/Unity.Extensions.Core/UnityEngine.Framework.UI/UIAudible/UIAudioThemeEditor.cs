#if UNITY_EDITOR
#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor( typeof( UIAudioThemeBase ), true )]
    public class UIAudioThemeEditor : Editor {

        public UIAudioThemeBase Target => (UIAudioThemeBase) target;

        // OnInspectorGUI
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (EditorApplication.isPlaying) {
                EditorGUILayout.LabelField( "Clip", $"{Target.Clip?.name ?? "Null"} ({Target.Clip?.length ?? 0})" );
                EditorGUILayout.LabelField( "IsPlaying", Target.IsPlaying.ToString() );
                EditorGUILayout.LabelField( "Time", Target.Time.ToString() );
                EditorGUILayout.LabelField( "Volume", Target.Volume.ToString() );
                EditorGUILayout.LabelField( "Mute", Target.Mute.ToString() );
            }
        }
        public override bool RequiresConstantRepaint() {
            return EditorApplication.isPlaying;
        }

    }
}
#endif
