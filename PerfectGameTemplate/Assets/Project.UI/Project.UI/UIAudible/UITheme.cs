namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class UITheme : UIAudioThemeBase {

        // Globals
        private UIRouter Router { get; set; } = default!;
        //private MainScreen MainScreen { get; set; } = default!;
        // Theme
        //private AudioClip Theme { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            AudioSource.mute = false;
            AudioSource.volume = 1;
            AudioSource.pitch = 1;
            //MainScreen = gameObject.RequireComponent<MainScreen>();
            //MainScreen.OnBeforeDescendantWidgetAttach<LoadingWidget>( i => Fade( AudioSource, destroyCancellationToken ) );
            //Theme = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.MainScreen.Music.Theme ).GetResult()!;
        }
        public new void OnDestroy() {
            //Addressables2.Release( Theme );
            base.OnDestroy();
        }

        // Start
        public void Start() {
            //Play( Theme );
        }
        public void Update() {
            //if (!IsPlaying && !IsPausing) {
            //    Play( Theme );
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
