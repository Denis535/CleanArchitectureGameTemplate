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

        // Globals
        private Application2 Application { get; set; } = default!;
        // State
        private ValueTracker2<UIThemeState, UITheme> StateTracker { get; } = new ValueTracker2<UIThemeState, UITheme>( i => i.State );
        public UIThemeState State => GetState( Application.State );
        public bool IsMainTheme => State == UIThemeState.MainTheme;
        public bool IsGameTheme => State == UIThemeState.GameTheme;

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            Stop();
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
            if (StateTracker.IsChanged( this )) {
                if (IsMainTheme) {
                    Play( MainThemes.First() );
                } else
                if (IsGameTheme) {
                    Play( GameThemes.First() );
                } else {
                    Stop();
                }
            }
            if (IsMainTheme) {
                if (!AudioSource.isPlaying && IsPlaying && IsUnPaused) {
                    PlayNext( MainThemes );
                }
                if (Application.IsMainSceneUnloading || Application.IsGameSceneLoading) {
                    Volume = Mathf.MoveTowards( Volume, 0, Volume * UnityEngine.Time.deltaTime * 0.5f );
                }
            } else if (IsGameTheme) {
                if (!AudioSource.isPlaying && IsPlaying && IsUnPaused) {
                    PlayNext( GameThemes );
                }
                SetPaused( Application.Game!.IsPaused );
            }
        }

        // Play
        private async void Play(string theme) {
            Stop();
            var clip = await Addressables2.LoadAssetAsync<AudioClip>( theme ).GetResultAsync( destroyCancellationToken, null, Addressables2.Release );
            clip.name = theme;
            Play( clip );
            Volume = 1;
        }
        private void PlayNext(string[] themes) {
            Play( GetNextValue( themes, Clip?.name ) );
        }
        private new void Stop() {
            if (AudioSource.clip != null) {
                var clip = AudioSource.clip;
                base.Stop();
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
