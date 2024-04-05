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
    using UnityEngine.Framework;

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
        private AudioMixer AudioMixer => audioMixer;
        // Values
        private Storage Globals { get; set; } = default!;
        private Storage.ProfileSettings ProfileSettings { get; set; } = default!;
        private Storage.VideoSettings VideoSettings { get; set; } = default!;
        private Storage.AudioSettings AudioSettings { get; set; } = default!;
        private Storage.Preferences Preferences { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;

        // Awake
        public void Awake() {
            IDependencyContainer.Instance = this;
            Globals = new Storage();
            ProfileSettings = new Storage.ProfileSettings();
            VideoSettings = new Storage.VideoSettings();
            AudioSettings = new Storage.AudioSettings( AudioMixer );
            Preferences = new Storage.Preferences();
        }
        public void OnDestroy() {
        }

        // GetObject
        object? IDependencyContainer.GetObject(Type type, object? argument) {
            this.Check();
            // UI
            if (type == typeof( UITheme )) {
                return UITheme;
            }
            if (type == typeof( UIScreen )) {
                return UIScreen;
            }
            if (type == typeof( UIFactory )) {
                return UIFactory;
            }
            if (type == typeof( UIRouter )) {
                return UIRouter;
            }
            // App
            if (type == typeof( Application2 )) {
                return Application;
            }
            if (type == typeof( Camera )) {
                return Camera.main;
            }
            if (type == typeof( Storage )) {
                return Globals;
            }
            if (type == typeof( Storage.ProfileSettings )) {
                return ProfileSettings;
            }
            if (type == typeof( Storage.VideoSettings )) {
                return VideoSettings;
            }
            if (type == typeof( Storage.AudioSettings )) {
                return AudioSettings;
            }
            if (type == typeof( Storage.Preferences )) {
                return Preferences;
            }
            if (type == typeof( IAuthenticationService )) {
                return AuthenticationService;
            }
            return null;
        }

    }
}
