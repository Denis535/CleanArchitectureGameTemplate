#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIAudioThemeBase : MonoBehaviour {

        // Globals
        protected internal AudioSource AudioSource { get; set; } = default!;
        // AudioSource
        public bool IsPlaying => AudioSource.isPlaying;
        public bool IsPausing { get; private set; }
        public float Time { get => AudioSource.time; set => AudioSource.time = value; }
        public float Volume { get => AudioSource.volume; set => AudioSource.volume = value; }
        public bool Mute { get => AudioSource.mute; set => AudioSource.mute = value; }
        // AudioClip
        public AudioClip? AudioClip => AudioSource.clip;

        // Awake
        public void Awake() {
            AudioSource = gameObject.RequireComponentInChildren<AudioSource>();
        }
        public void OnDestroy() {
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
            IsPausing = true;
            AudioSource.Pause();
        }
        public void UnPause() {
            IsPausing = false;
            AudioSource.UnPause();
        }

        // Helpers
        protected static T GetNextValue<T>(T[] array, T? value) {
            var ind = array.IndexOf( value );
            ind = (ind + 1) % array.Length;
            return array[ ind ];
        }
        protected static T GetRandomValue<T>(T[] array, T? value) {
            var ind = UnityEngine.Random.Range( 0, array.Length );
            if (ReferenceEquals( array[ ind ], value ) && array.Length >= 2) return GetRandomValue( array, value );
            return array[ ind ];
        }
        protected static T[] Shuffle<T>(T[] array) {
            for (var i = 0; i < array.Length; i++) {
                var i2 = i + UnityEngine.Random.Range( 0, array.Length - i );
                (array[ i ], array[ i2 ]) = (array[ i2 ], array[ i ]);
            }
            return array;
        }

    }
}
