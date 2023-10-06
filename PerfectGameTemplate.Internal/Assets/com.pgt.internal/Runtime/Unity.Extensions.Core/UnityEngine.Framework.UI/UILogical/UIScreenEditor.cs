#if UNITY_EDITOR
#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UIElements;

    [CustomEditor( typeof( UIScreenBase ), true )]
    public class UIScreenEditor : Editor {

        public UIScreenBase Target => (UIScreenBase) target;

        // OnInspectorGUI
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (EditorApplication.isPlaying) {
                LabelField( "View", GetDisplayString( Target.View ) );
                LabelField( "Widget", GetDisplayString( Target.Widget ) );
            }
        }
        public override bool RequiresConstantRepaint() {
            return EditorApplication.isPlaying;
        }

        // Helpers
        private static void LabelField(string label, string? text) {
            using (new EditorGUILayout.HorizontalScope()) {
                EditorGUILayout.PrefixLabel( label );
                EditorGUI.SelectableLabel( GUILayoutUtility.GetRect( new GUIContent( text ), GUI.skin.textField ), text, GUI.skin.textField );
            }
        }
        private static string? GetDisplayString(UIViewBase? view) {
            if (view == null) return null;
            var builder = new StringBuilder();
            builder.AppendHierarchy( view, i => i.GetType().Name, i => i.GetDescendants( i => i is not UIViewBase ).OfType<UIViewBase>() );
            return builder.ToString();
        }
        private static string? GetDisplayString(UIWidgetBase? widget) {
            if (widget == null) return null;
            var builder = new StringBuilder();
            builder.AppendHierarchy( widget, i => i.GetType().Name, i => i.Children );
            return builder.ToString();
        }

    }
}
#endif
