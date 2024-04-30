#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI;
    using Unity.Services.Authentication;
    using UnityEngine;
    using UnityEngine.Audio;

    public class DependencyContainer : MonoBehaviour, IDependencyContainer {

        [SerializeField] private UITheme uiTheme = default!;
        [SerializeField] private UIScreen uiScreen = default!;
        [SerializeField] private UIFactory uiFactory = default!;
        [SerializeField] private UIRouter uiRouter = default!;
        [SerializeField] private Application2 application = default!;
        [SerializeField] private AudioMixer audioMixer = default!;

        // Values
        private UITheme UITheme => uiTheme;
        private UIScreen UIScreen => uiScreen;
        private UIFactory UIFactory => uiFactory;
        private UIRouter UIRouter => uiRouter;
        private Application2 Application => application;
        // Values
        private AudioMixer AudioMixer => audioMixer;
        // Values
        private Storage Storage { get; set; } = default!;
        private Storage.ProfileSettings ProfileSettings { get; set; } = default!;
        private Storage.VideoSettings VideoSettings { get; set; } = default!;
        private Storage.AudioSettings AudioSettings { get; set; } = default!;
        private Storage.Preferences Preferences { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;

        // Awake
        public void Awake() {
            Utils.Container = this;
            Storage = new Storage();
            ProfileSettings = new Storage.ProfileSettings();
            VideoSettings = new Storage.VideoSettings();
            AudioSettings = new Storage.AudioSettings( AudioMixer );
            Preferences = new Storage.Preferences();
        }
        public void OnDestroy() {
        }

        // GetObject
        Option<object?> IDependencyContainer.GetValue(Type type, object? argument) {
            this.Assert_IsValid();
            // UI
            if (type == typeof( UITheme )) {
                return (Option<object?>) UITheme;
            }
            if (type == typeof( UIScreen )) {
                return (Option<object?>) UIScreen;
            }
            if (type == typeof( UIFactory )) {
                return (Option<object?>) UIFactory;
            }
            if (type == typeof( UIRouter )) {
                return (Option<object?>) UIRouter;
            }
            // App
            if (type == typeof( Application2 )) {
                return (Option<object?>) Application;
            }
            if (type == typeof( Camera )) {
                return (Option<object?>) Camera.main;
            }
            if (type == typeof( Storage )) {
                return (Option<object?>) Storage;
            }
            if (type == typeof( Storage.ProfileSettings )) {
                return (Option<object?>) ProfileSettings;
            }
            if (type == typeof( Storage.VideoSettings )) {
                return (Option<object?>) VideoSettings;
            }
            if (type == typeof( Storage.AudioSettings )) {
                return (Option<object?>) AudioSettings;
            }
            if (type == typeof( Storage.Preferences )) {
                return (Option<object?>) Preferences;
            }
            if (type == typeof( IAuthenticationService )) {
                return new Option<object?>( AuthenticationService );
            }
            return default;
        }

    }
}
