﻿#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.Framework.App;

    public partial class Storage {
        public class AudioSettings : StorageBase {

            private float masterVolume;
            private float musicVolume;
            private float sfxVolume;
            private float gameVolume;

            // AudioMixer
            private AudioMixer AudioMixer { get; }
            // Volume
            public float MasterVolume {
                get => masterVolume;
                set {
                    masterVolume = value;
                    SetVolume( AudioMixer, "MasterVolume", value );
                }
            }
            public float MusicVolume {
                get => musicVolume;
                set {
                    musicVolume = value;
                    SetVolume( AudioMixer, "MusicVolume", value );
                }
            }
            public float SfxVolume {
                get => sfxVolume;
                set {
                    sfxVolume = value;
                    SetVolume( AudioMixer, "SfxVolume", value );
                }
            }
            public float GameVolume {
                get => gameVolume;
                set {
                    gameVolume = value;
                    SetVolume( AudioMixer, "GameVolume", value );
                }
            }

            // Constructor
            public AudioSettings(AudioMixer audioMixer) {
                AudioMixer = audioMixer;
                Load();
            }

            // Save
            public void Save() {
                Save( "AudioSettings.MasterVolume", MasterVolume );
                Save( "AudioSettings.MusicVolume", MusicVolume );
                Save( "AudioSettings.SfxVolume", SfxVolume );
                Save( "AudioSettings.GameVolume", GameVolume );
            }
            public void Load() {
                MasterVolume = Load( "AudioSettings.MasterVolume", 0.5f );
                MusicVolume = Load( "AudioSettings.MusicVolume", 0.5f );
                SfxVolume = Load( "AudioSettings.SfxVolume", 0.5f );
                GameVolume = Load( "AudioSettings.GameVolume", 0.5f );
            }

            // Helpers
            private static void SetVolume(AudioMixer mixer, string name, float value) {
                Debug.Assert( value >= 0 && value <= 1, $"Volume '{value}' is invalid" );
                var isSucceeded = mixer.SetFloat( name, ToDecibels( value ) );
                if (!isSucceeded) throw Exceptions.Internal.Exception( $"Volume {name} was not set" );
            }
            private static float ToDecibels(float value) {
                value = Mathf.Clamp( value, 0.0001f, 1 );
                return Mathf.Log10( value ) * 20f;
            }

        }
    }
}
