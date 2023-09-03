#if UNITY_EDITOR
#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor( typeof( UIScreen<> ), true )]
    public class UIScreenEditor : Editor {

        public UIScreen Target => (UIScreen) target;

        // Awake
        public void Awake() {
        }
        public void OnDestroy() {
        }

        // OnInspectorGUI
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            LabelField( "View", GetString( Target.View ) );
            LabelField( "Widget", GetString( Target.Widget ) );
        }
        public override bool RequiresConstantRepaint() {
            return true;
        }

        // Helpers
        private static void LabelField(string? text) {
            using (new EditorGUILayout.HorizontalScope()) {
                EditorGUI.SelectableLabel( GUILayoutUtility.GetRect( new GUIContent( text ), GUI.skin.textField ), text, GUI.skin.textField );
            }
        }
        private static void LabelField(string label, string? text) {
            using (new EditorGUILayout.HorizontalScope()) {
                EditorGUILayout.PrefixLabel( label );
                EditorGUI.SelectableLabel( GUILayoutUtility.GetRect( new GUIContent( text ), GUI.skin.textField ), text, GUI.skin.textField );
            }
        }
        // Helpers
        private static string? GetString(UIScreenView? view) {
            return view?.GetType().Name;
        }
        private static string? GetString(UIWidget? widget) {
            if (widget == null) return null;
            var builder = new StringBuilder();
            GetString( widget, 0, builder );
            return builder.ToString();
        }
        private static void GetString(UIWidget widget, int indent, StringBuilder builder) {
            if (widget.View == null) {
                builder.Append( ' ', indent * 4 ).Append( string.Format( "{0}", widget.GetType().Name ) );
            } else {
                builder.Append( ' ', indent * 4 ).Append( string.Format( "{0} ({1})", widget.GetType().Name, widget.View.GetType().Name ) );
            }
            foreach (var child in widget.Children) {
                builder.AppendLine();
                GetString( child, indent + 1, builder );
            }
        }

    }
}
#endif
