#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class UIInfrastructure : MonoBehaviour {

        // Document
        public UIDocument Document { get; set; } = default!;
        // AudioSource
        public AudioSource MusicAudioSource { get; set; } = default!;
        public AudioSource SfxAudioSource { get; set; } = default!;

        // Awake
        public void Awake() {
            Singleton.Register( this );
            Document = gameObject.RequireComponentInChildren<UIDocument>();
            MusicAudioSource = gameObject.RequireComponentsInChildren<AudioSource>().First( i => i.outputAudioMixerGroup.name == "Music" );
            MusicAudioSource.ignoreListenerPause = false;
            SfxAudioSource = gameObject.RequireComponentsInChildren<AudioSource>().First( i => i.outputAudioMixerGroup.name == "Sfx" );
            SfxAudioSource.ignoreListenerPause = true;
        }
        public void OnDestroy() {
            Singleton.Unregister( this );
        }

        // OnEnable
        public void OnEnable() {
            Document.enabled = true;
            MusicAudioSource.enabled = true;
            SfxAudioSource.enabled = true;
        }
        public void OnDisable() {
            Document.enabled = false;
            MusicAudioSource.enabled = false;
            SfxAudioSource.enabled = false;
        }

    }
}
