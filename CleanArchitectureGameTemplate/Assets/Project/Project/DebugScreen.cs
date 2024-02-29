#if DEBUG
#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI;
    using UnityEngine;
    using UnityEngine.Framework;

    [DefaultExecutionOrder( ScriptExecutionOrders.Program )]
    public class DebugScreen : MonoBehaviour {

        // Globals
        private UITheme Theme { get; set; } = default!;
        private UIScreen Screen { get; set; } = default!;
        private Application2 Application { get; set; } = default!;

        // Awake
        public void Awake() {
            Theme = this.GetDependencyContainer().Resolve<UITheme>( null );
            Screen = this.GetDependencyContainer().Resolve<UIScreen>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public void OnDestroy() {
        }

        // OnGUI
        public void OnGUI() {
            using (new GUILayout.VerticalScope( GUI.skin.box )) {
                GUILayout.Label( "Fps: " + (1f / Time.smoothDeltaTime).ToString( "000." ) );
                GUILayout.Label( "Theme: " + Theme.State );
                GUILayout.Label( "Screen: " + Screen.State );
                GUILayout.Label( "App: " + Application.State );
                GUILayout.Label( "Game: " + Application.Game?.State );
                //GUILayout.Label( "IsPaused: " + Application.Game?.IsPaused );
                //GUILayout.Label( "IsFocused: " + UnityEngine.Application.isFocused );
                //GUILayout.Label( "Focused Element: " + GetFocusedElement()?.Convert( GetDisplayString ) );
            }
        }

        // Heleprs
        //private static Focusable? GetFocusedElement() {
        //    return EventSystem.current.currentSelectedGameObject?.GetComponent<PanelEventHandler>()?.panel.focusController.focusedElement;
        //}
        //private static string GetDisplayString(Focusable focusable) {
        //    var element = (VisualElement) focusable;
        //    return element.name.NullIfEmpty() ?? focusable.GetType().Name;
        //}

    }
}
#endif
