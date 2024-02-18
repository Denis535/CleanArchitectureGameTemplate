#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.App;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class UITheme : UIAudioThemeBase {

        private static readonly string[] MainThemes = GetShuffled( new[] {
            R.Project.UI.MainScreen.Music.Theme,
        } );
        private static readonly string[] GameThemes = GetShuffled( new[] {
            R.Project.UI.GameScreen.Music.Theme_1,
            R.Project.UI.GameScreen.Music.Theme_2,
            R.Project.UI.GameScreen.Music.Theme_3,
        } );

        private readonly Tracker<UIThemeState> stateTracker = new Tracker<UIThemeState>();

        // Globals
        private Application2 Application { get; set; } = default!;
        // State
        public UIThemeState State => GetState( Application.State );
        public bool IsMainTheme => State == UIThemeState.MainTheme;
        public bool IsGameTheme => State == UIThemeState.GameTheme;

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
                    PlayTheme( MainThemes.First() );
                } else
                if (IsGameTheme) {
                    PlayTheme( GameThemes.First() );
                } else {
                    StopTheme();
                }
            }
            if (IsMainTheme) {
                if (!AudioSource.isPlaying && IsPlaying && IsUnPaused) {
                    PlayNextTheme( MainThemes );
                }
                if (Application.IsMainSceneUnloading || Application.IsGameSceneLoading) {
                    Volume = Mathf.MoveTowards( Volume, 0, Volume * UnityEngine.Time.deltaTime * 0.5f );
                }
            } else if (IsGameTheme) {
                if (!AudioSource.isPlaying && IsPlaying && IsUnPaused) {
                    PlayNextTheme( GameThemes );
                }
                SetPaused( Application.Game!.IsPaused );
            }
        }

        // PlayTheme
        private async void PlayTheme(string theme) {
            StopTheme();
            var clip = await Addressables2.LoadAssetAsync<AudioClip>( theme ).GetResultAsync( destroyCancellationToken, null, Addressables2.Release );
            clip.name = theme;
            Play( clip );
            Volume = 1;
        }
        private void PlayNextTheme(string[] themes) {
            PlayTheme( GetNextValue( themes, AudioSource.clip?.name ) );
        }
        private void StopTheme() {
            if (AudioSource.clip != null) {
                var clip = AudioSource.clip;
                Stop();
                Addressables2.Release( clip );
            }
        }

        // Helpers
        private static UIThemeState GetState(AppState state) {
            if (state is AppState.MainSceneLoading or AppState.MainSceneLoaded or AppState.MainSceneUnloading or AppState.MainSceneUnloaded or AppState.GameSceneLoading or AppState.GameSceneUnloading or AppState.GameSceneUnloaded) {
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
