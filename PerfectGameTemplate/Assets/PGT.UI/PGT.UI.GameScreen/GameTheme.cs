#nullable enable
namespace PGT.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class GameTheme : UIAudioTheme2 {

        private GameScreen GameScreen { get; set; } = default!;
        private IList<AudioClip> Themes { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            AudioSource.mute = false;
            AudioSource.volume = 1;
            AudioSource.pitch = 1;
            GameScreen = gameObject.RequireComponent<GameScreen>();
            GameScreen.OnBeforeDescendantWidgetAttach<GameMenuWidget>( i => Pause() );
            GameScreen.OnAfterDescendantWidgetDetach<GameMenuWidget>( i => UnPause() );
            Themes = Shuffle( Addressables2.LoadAssetsAsync<AudioClip>( R.PGT.UI.GameScreen.Music.Theme_1, R.PGT.UI.GameScreen.Music.Theme_2, R.PGT.UI.GameScreen.Music.Theme_3 ).GetResult()! );
        }
        public new void OnDestroy() {
            Addressables2.Release( Themes );
            base.OnDestroy();
        }

        // Start
        public void Start() {
            Play( GetNext( Themes, AudioClip ) );
        }
        public void Update() {
            if (!IsPlaying && !IsPausing) {
                Play( GetNext( Themes, AudioClip ) );
            }
        }

    }
}
