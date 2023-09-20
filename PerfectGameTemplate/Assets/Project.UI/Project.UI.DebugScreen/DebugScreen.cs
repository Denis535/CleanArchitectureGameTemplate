#if DEBUG
#nullable enable
namespace Project.UI.DebugScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UIElements;

    [DefaultExecutionOrder( ScriptExecutionOrders.UIScreen )]
    public class DebugScreen : MonoBehaviour {

        // Awake
        public void Awake() {
        }
        public void OnDestroy() {
        }

        // OnGUI
        public void OnGUI() {
            using (new GUILayout.VerticalScope( GUI.skin.box )) {
                GUILayout.Label( "Fps: " + (1f / Time.smoothDeltaTime).ToString( "000." ), EditorStyles.label );
                GUILayout.Label( "Focused: " + Application.isFocused, EditorStyles.label );
                GUILayout.Label( "Focused Element: " + GetFocusedElement()?.Convert( GetDisplayString ), EditorStyles.label );
            }
        }

        // Heleprs
        private static Focusable? GetFocusedElement() {
            return EventSystem.current.currentSelectedGameObject?.GetComponent<PanelEventHandler>()?.panel.focusController.focusedElement;
        }
        private static string GetDisplayString(Focusable focusable) {
            var element = (VisualElement) focusable;
            return element.name.NullIfEmpty() ?? focusable.GetType().Name;
        }

    }
}
#endif
