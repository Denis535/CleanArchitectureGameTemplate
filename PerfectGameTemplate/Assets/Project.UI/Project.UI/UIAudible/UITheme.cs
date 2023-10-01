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
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class UITheme : UIAudioThemeBase {

        private static readonly string[] MainThemes = GetShuffled( new string[] {
            R.Project.UI.MainScreen.Music.Theme,
        } );
        private static readonly string[] GameThemes = GetShuffled( new string[] {
            R.Project.UI.GameScreen.Music.Theme_1,
            R.Project.UI.GameScreen.Music.Theme_2,
            R.Project.UI.GameScreen.Music.Theme_3,
        } );

        private AsyncOperationHandle<AudioClip> themeOperationHandle;

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
        // Themes
        private string[]? Themes { get; set; }
        private int Index { get; set; }

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            StopTheme();
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
            if (StateTracker.IsChanged( this, out var state )) {
                switch (state) {
                    case UIThemeState.MainTheme:
                        PlayThemes( MainThemes );
                        break;
                    case UIThemeState.GameTheme:
                        PlayThemes( GameThemes );
                        break;
                    case UIThemeState.None:
                        PlayThemes( null );
                        break;
                }
            }
        }

        // PlayThemes
        private void PlayThemes(string[]? themes) {
            Themes = themes;
            Index = 0;
            if (Themes != null) {
                StopTheme();
                PlayTheme( Themes[ Index ] );
            } else {
                StopTheme();
            }
        }

        // PlayTheme
        private async void PlayTheme(string theme) {
            Assert.Operation.Message( $"ThemeOperationHandle {themeOperationHandle} must not exist" ).Valid( !themeOperationHandle.IsValid() );
            themeOperationHandle = Addressables2.LoadAssetAsync<AudioClip>( theme );
            Play( await themeOperationHandle.GetResultAsync( default ) );
        }
        private void StopTheme() {
            Stop();
            if (themeOperationHandle.IsValid()) {
                Addressables2.Release( themeOperationHandle );
                themeOperationHandle = default;
            }
        }

    }
    internal enum UIThemeState {
        None,
        MainTheme,
        GameTheme,
    }
}
