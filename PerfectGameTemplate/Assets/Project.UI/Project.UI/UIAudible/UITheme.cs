#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class UITheme : UIAudioThemeBase {

        private static readonly string[] MainThemes = GetShuffled( new string[] {
            R.Project.UI.MainScreen.Music.Theme,
        } );
        private static readonly string[] GameThemes = GetShuffled( new string[] {
            R.Project.UI.GameScreen.Music.Theme_1,
            R.Project.UI.GameScreen.Music.Theme_2,
            R.Project.UI.GameScreen.Music.Theme_3,
        } );

        // Globals
        private Application2 Application { get; set; } = default!;
        // State
        private UIThemeState State {
            get {
                if (Application.AppState is AppState.MainSceneLoading or AppState.MainSceneLoaded or AppState.MainSceneUnloading or AppState.GameSceneLoading or AppState.GameSceneUnloading) {
                    return UIThemeState.MainTheme;
                }
                if (Application.AppState is AppState.GameSceneLoaded) {
                    return UIThemeState.GameTheme;
                }
                if (Application.AppState is AppState.Quitting or AppState.Quited) {
                    return UIThemeState.None;
                }
                return UIThemeState.None;
            }
        }
        private Tracker<UIThemeState, UITheme> StateTracker { get; } = new Tracker<UIThemeState, UITheme>( i => i.State );

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
            //if (StateTracker.IsChanged( this, out var state )) {
            //    switch (state) {
            //        case UIThemeState.MainTheme:
            //            var theme = await Addressables2.LoadAssetAsync<AudioClip>( GetNextValue( MainThemes, null ) ).GetResultAsync( default );
            //            Play( theme );
            //            break;
            //        case UIThemeState.GameTheme:
            //            break;
            //        case UIThemeState.None:
            //            break;
            //    }
            //}
        }

        // Helpers
        //private static void Fade(AudioSource audioSource, CancellationToken cancellationToken) {
        //    UnityUtils.PlayAnimation( audioSource,
        //        1, -1, 10,
        //        (i, v) => i.pitch = v,
        //        null,
        //        null,
        //        cancellationToken );
        //}

    }
    internal enum UIThemeState {
        None,
        MainTheme,
        GameTheme,
    }
}
