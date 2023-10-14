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

        private readonly Tracker<UIThemeState> stateTracker = new Tracker<UIThemeState>();
        private AsyncOperationHandle<AudioClip> themeOperationHandle;

        // Globals
        private Application2 Application { get; set; } = default!;
        // State
        public UIThemeState State => GetState( Application.State );
        public bool IsMainTheme => State == UIThemeState.MainTheme;
        public bool IsGameTheme => State == UIThemeState.GameTheme;
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
            if (stateTracker.IsChanged( State )) {
                if (IsMainTheme) {
                    StopTheme();
                    (Themes, Index) = (MainThemes, 0);
                    PlayTheme( Themes[ Index ] );
                } else if (IsGameTheme) {
                    StopTheme();
                    (Themes, Index) = (GameThemes, 0);
                    PlayTheme( Themes[ Index ] );
                } else {
                    StopTheme();
                    (Themes, Index) = (null, 0);
                }
            }
            if (IsPlaying && IsUnPausing && !AudioSource.isPlaying) {
                StopTheme();
                if (Themes != null) {
                    Index = (Index + 1) % Themes!.Length;
                    PlayTheme( Themes[ Index ] );
                }
            }
            if (IsMainTheme) {
                if (Application.IsMainSceneUnloading || Application.IsGameSceneLoading) {
                    Volume = Mathf.MoveTowards( Volume, 0, Volume * 0.5f * UnityEngine.Time.deltaTime );
                }
            } else if (IsGameTheme) {
                if (Application.Game!.IsPaused) {
                    Pause();
                } else if (Application.Game!.IsUnPaused) {
                    UnPause();
                }
            }
        }

        // PlayTheme
        private async void PlayTheme(string theme) {
            Assert.Operation.Message( $"ThemeOperationHandle {themeOperationHandle} must not exist" ).Valid( !themeOperationHandle.IsValid() );
            themeOperationHandle = Addressables2.LoadAssetAsync<AudioClip>( theme );
            Play( await themeOperationHandle.GetResultAsync( default ) );
            Volume = 1;
        }
        private void StopTheme() {
            Stop();
            if (themeOperationHandle.IsValid()) {
                Addressables2.Release( themeOperationHandle );
                themeOperationHandle = default;
            }
        }

        // Helpers
        private static UIThemeState GetState(AppState state) {
            if (state is AppState.MainSceneLoading or AppState.MainSceneLoaded or AppState.MainSceneUnloading or AppState.GameSceneLoading or AppState.GameSceneUnloading) {
                return UIThemeState.MainTheme;
            }
            if (state is AppState.GameSceneLoaded) {
                return UIThemeState.GameTheme;
            }
            if (state is AppState.Quitting or AppState.Quited) {
                return UIThemeState.None;
            }
            return UIThemeState.None;
        }

    }
    // UIThemeState
    public enum UIThemeState {
        None,
        MainTheme,
        GameTheme,
    }
}
