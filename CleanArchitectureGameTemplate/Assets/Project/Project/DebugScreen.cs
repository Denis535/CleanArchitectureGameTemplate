#if DEBUG
#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.Entities.GameScene;
    using Project.UI;
    using UnityEngine;
    using UnityEngine.Framework;

    [DefaultExecutionOrder( ScriptExecutionOrders.Program )]
    public class DebugScreen : MonoBehaviour {

        // Globals
        private UITheme Theme { get; set; } = default!;
        private UIScreen Screen { get; set; } = default!;
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;
        private Game? Game => GameObject.FindAnyObjectByType<Game>( FindObjectsInactive.Exclude );

        // Awake
        public void Awake() {
            Theme = this.GetDependencyContainer().Resolve<UITheme>( null );
            Screen = this.GetDependencyContainer().Resolve<UIScreen>( null );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
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
                GUILayout.Label( "Router: " + Router.State );
                GUILayout.Label( "IsGameRunning: " + Application.IsGameRunning );
                if (Application.IsGameRunning) {
                    GUILayout.Label( "IsGamePlaying: " + Application.IsGamePlaying );
                    GUILayout.Label( "IsGamePaused: " + Application.IsGamePaused );
                }
                //GUILayout.Space( 2 );
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
