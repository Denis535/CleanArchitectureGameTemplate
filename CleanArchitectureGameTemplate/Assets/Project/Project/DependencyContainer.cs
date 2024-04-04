#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI;
    using Unity.Services.Authentication;
    using UnityEngine;
    using UnityEngine.Framework;

    public class DependencyContainer : MonoBehaviour, IDependencyContainer {

        [SerializeField] private UITheme uiTheme = default!;
        [SerializeField] private UIScreen uiScreen = default!;
        [SerializeField] private UIFactory uiFactory = default!;
        [SerializeField] private UIRouter uiRouter = default!;
        [SerializeField] private Application2 application = default!;

        // Globals
        private UITheme UITheme => uiTheme;
        private UIScreen UIScreen => uiScreen;
        private UIFactory UIFactory => uiFactory;
        private UIRouter UIRouter => uiRouter;
        private Application2 Application => application;
        private Globals Globals { get; set; } = default!;
        private Globals.ProfileSettings ProfileSettings { get; set; } = default!;
        private Globals.VideoSettings VideoSettings { get; set; } = default!;
        private Globals.AudioSettings AudioSettings { get; set; } = default!;
        private Globals.Preferences Preferences { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;

        // Awake
        public void Awake() {
            IDependencyContainer.Instance = this;
            Globals = new Globals();
            ProfileSettings = new Globals.ProfileSettings();
            VideoSettings = new Globals.VideoSettings();
            AudioSettings = new Globals.AudioSettings();
            Preferences = new Globals.Preferences();
        }
        public void OnDestroy() {
        }

        // GetDependency
        public object? GetDependency(Type type, object? argument) {
            this.Validate();
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
            if (type == typeof( Globals )) {
                return Globals;
            }
            if (type == typeof( Globals.ProfileSettings )) {
                return ProfileSettings;
            }
            if (type == typeof( Globals.VideoSettings )) {
                return VideoSettings;
            }
            if (type == typeof( Globals.AudioSettings )) {
                return AudioSettings;
            }
            if (type == typeof( Globals.Preferences )) {
                return Preferences;
            }
            if (type == typeof( IAuthenticationService )) {
                return AuthenticationService;
            }
            return null;
        }

    }
}
