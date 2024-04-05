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
            R.Project.UI.MainScreen.Music.Theme_Value,
        } );
        private static readonly string[] GameThemes = GetShuffled( new[] {
            R.Project.UI.GameScreen.Music.Theme_1_Value,
            R.Project.UI.GameScreen.Music.Theme_2_Value,
        } );

        // Globals
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;
        private AudioSource AudioSource { get; set; } = default!;
        // State
        public UIThemeState State => GetState( Router.State );
        private ValueTracker2<UIThemeState, UITheme> StateTracker { get; } = new ValueTracker2<UIThemeState, UITheme>( i => i.State );
        public bool IsMainTheme => State == UIThemeState.MainTheme;
        public bool IsGameTheme => State == UIThemeState.GameTheme;

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().RequireDependency<UIRouter>( null );
            Application = this.GetDependencyContainer().RequireDependency<Application2>( null );
            AudioSource = gameObject.RequireComponentInChildren<AudioSource>();
        }
        public new void OnDestroy() {
            Stop( AudioSource );
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
            if (StateTracker.IsChanged( this )) {
                if (IsMainTheme) {
                    Stop( AudioSource );
                    Play( AudioSource, MainThemes.First() );
                } else
                if (IsGameTheme) {
                    Stop( AudioSource );
                    Play( AudioSource, GameThemes.First() );
                } else {
                    Stop( AudioSource );
                }
            }
            if (IsMainTheme) {
                if (!IsPlaying( AudioSource )) {
                    Stop( AudioSource );
                    PlayNext( AudioSource, MainThemes );
                }
                if (Router.IsGameSceneLoading) {
                    AudioSource.volume = Mathf.MoveTowards( AudioSource.volume, 0, AudioSource.volume * UnityEngine.Time.deltaTime * 0.5f );
                }
            } else if (IsGameTheme) {
                if (!IsPlaying( AudioSource )) {
                    Stop( AudioSource );
                    PlayNext( AudioSource, GameThemes );
                }
                if (Application.IsGamePaused) {
                    AudioSource.Pause();
                } else {
                    AudioSource.UnPause();
                }
            }
        }

        // Helpers
        private static UIThemeState GetState(UIRouterState state) {
            if (state is UIRouterState.MainSceneLoading or UIRouterState.MainSceneLoaded or UIRouterState.GameSceneLoading) {
                return UIThemeState.MainTheme;
            }
            if (state is UIRouterState.GameSceneLoaded) {
                return UIThemeState.GameTheme;
            }
            return UIThemeState.None;
        }
        // Helpers
        private static bool IsPlaying(AudioSource source) {
            return source.clip is not null && !Mathf.Approximately( source.time, source.clip.length );
        }
        private static void Play(AudioSource source, string key) {
            Assert.Operation.Message( $"You are trying to play clip {key} but first you must release old clip" );
            source.clip = Addressables2.LoadAssetAsync<AudioClip>( key ).GetResult( null, null );
            source.clip.name = key;
            source.volume = 1;
            source.Play();
        }
        private static void PlayNext(AudioSource source, string[] keys) {
            Play( source, GetNextValue( keys, source.clip?.name ) );
        }
        private static void Stop(AudioSource source) {
            if (source.clip != null) {
                var clip = source.clip;
                source.Stop();
                source.clip = null;
                Addressables2.Release( clip );
            }
        }

    }
    // UIThemeState
    public enum UIThemeState {
        None,
        MainTheme,
        GameTheme,
    }
}
