#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class UITheme : UIAudioThemeBase {

        // Themes
        private static string[] MainThemes = new string[] {
            R.Project.UI.MainScreen.Music.Theme
        };
        private static string[] GameThemes = new string[] {
            R.Project.UI.GameScreen.Music.Theme_1,
            R.Project.UI.GameScreen.Music.Theme_2,
            R.Project.UI.GameScreen.Music.Theme_3,
        };
        // Globals
        private UIScreen Screen { get; set; } = default!;
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            Screen = this.GetDependencyContainer().Resolve<UIScreen>( null );
            //Screen.OnBeforeDescendantWidgetAttach( descendant => {
            //    if (descendant is MainWidget) {
                    
            //    } else
            //    if (descendant is LoadingWidget) {
                    
            //    } else
            //    if (descendant is GameWidget) {
                    
            //    }
            //} );
            //Screen.OnAfterDescendantWidgetDetach( descendant => {
            //} );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
            //if (Router.IsMainSceneLoaded) {

            //} else
            //if (Router.IsGameSceneLoaded) {

            //}
        }

        // Helpers
        private static void Fade(AudioSource audioSource, CancellationToken cancellationToken) {
            UnityUtils.PlayAnimation( audioSource,
                1, -1, 10,
                (i, v) => i.pitch = v,
                null,
                null,
                cancellationToken );
        }

    }
}
