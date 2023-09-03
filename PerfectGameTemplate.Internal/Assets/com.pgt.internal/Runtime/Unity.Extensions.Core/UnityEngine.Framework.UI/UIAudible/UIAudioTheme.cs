#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIAudioTheme : MonoBehaviour {

        // AudioSource
        public virtual AudioSource AudioSource => Singleton.GetInstance<UIInfrastructure>().MusicAudioSource;
        public AudioClip? AudioClip => AudioSource.clip;
        public bool IsPlaying => AudioSource.isPlaying;
        public bool IsPausing { get; private set; }
        public bool Mute { get => AudioSource.mute; set => AudioSource.mute = value; }
        public float Volume { get => AudioSource.volume; set => AudioSource.volume = value; }

        // Awake
        public void Awake() {
            Singleton.Register( this );
        }
        public void OnDestroy() {
            Singleton.Unregister( this );
        }

        // Play
        public void Play(AudioClip clip) {
            AudioSource.clip = clip;
            AudioSource.Play();
        }
        public void Stop() {
            AudioSource.Stop();
            AudioSource.clip = null;
        }

        // Pause
        public void Pause() {
            AudioSource.Pause();
            IsPausing = true;
        }
        public void UnPause() {
            IsPausing = false;
            AudioSource.UnPause();
        }

        // Utils
        public static AudioClip GetNext(IList<AudioClip> themes, AudioClip? theme) {
            var ind = themes.IndexOf( theme! );
            ind = (ind + 1) % themes.Count;
            return themes[ ind ];
        }
        public static AudioClip GetRandom(IList<AudioClip> themes, AudioClip? theme) {
            var ind = UnityEngine.Random.Range( 0, themes.Count );
            if (themes[ ind ] != theme) return themes[ ind ];
            return GetRandom( themes, theme );
        }
        public static IList<AudioClip> Shuffle(IList<AudioClip> themes) {
            for (var i = 0; i < themes.Count; i++) {
                var i2 = i + UnityEngine.Random.Range( 0, themes.Count - i );
                (themes[ i ], themes[ i2 ]) = (themes[ i2 ], themes[ i ]);
            }
            return themes;
        }

    }
}
