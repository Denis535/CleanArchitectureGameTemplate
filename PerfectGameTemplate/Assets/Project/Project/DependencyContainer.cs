#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Project.App;
    using Project.Entities.GameScene;
    using Project.UI;
    using Unity.Services.Authentication;
    using Unity.Services.Lobbies;
    using Unity.Services.Qos;
    using UnityEngine;
    using UnityEngine.Framework;

    public class DependencyContainer : MonoBehaviour, IDependencyContainer {

        [SerializeField] private UITheme theme = default!;
        [SerializeField] private UIScreen screen = default!;
        [SerializeField] private UIFactory factory = default!;
        [SerializeField] private UIRouter router = default!;
        [SerializeField] private Application2 application = default!;

        // Globals
        private UITheme Theme => theme;
        private UIScreen Screen => screen;
        private UIFactory Factory => factory;
        private UIRouter Router => router;
        private Application2 Application => application;
        private Globals Globals { get; set; } = default!;
        private Globals.PlayerProfile PlayerProfile { get; set; } = default!;
        private Globals.VideoSettings VideoSettings { get; set; } = default!;
        private Globals.AudioSettings AudioSettings { get; set; } = default!;
        private Globals.Preferences Preferences { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;
        private ILobbyService LobbyService => Unity.Services.Lobbies.LobbyService.Instance;
        private IQosService QosService => Unity.Services.Qos.QosService.Instance;

        // Awake
        public void Awake() {
            Globals = new Globals();
            PlayerProfile = new Globals.PlayerProfile();
            VideoSettings = new Globals.VideoSettings();
            AudioSettings = new Globals.AudioSettings();
            Preferences = new Globals.Preferences();
            IDependencyContainer.Instance = this;
        }
        public void OnDestroy() {
        }

        // GetDependency
        public object? GetDependency(Type type, object? argument) {
            Assert.Object.Message( $"Object {this} must be awakened" ).Valid( didAwake );
            Assert.Object.Message( $"Object {this} must be alive" ).Alive( this );
            // UI
            if (type == typeof( UITheme )) {
                Assert.Object.Message( $"Object {Theme} must be awakened" ).Valid( Theme.didAwake );
                Assert.Object.Message( $"Object {Theme} must be alive" ).Alive( Theme );
                return Theme;
            }
            if (type == typeof( UIScreen )) {
                Assert.Object.Message( $"Object {Screen} must be awakened" ).Valid( Screen.didAwake );
                Assert.Object.Message( $"Object {Screen} must be alive" ).Alive( Screen );
                return Screen;
            }
            if (type == typeof( UIFactory )) {
                Assert.Object.Message( $"Object {Factory} must be awakened" ).Valid( Factory.didAwake );
                Assert.Object.Message( $"Object {Factory} must be alive" ).Alive( Factory );
                return Factory;
            }
            if (type == typeof( UIRouter )) {
                Assert.Object.Message( $"Object {Router} must be awakened" ).Valid( Router.didAwake );
                Assert.Object.Message( $"Object {Router} must be alive" ).Alive( Router );
                return Router;
            }
            // App
            if (type == typeof( Application2 )) {
                Assert.Object.Message( $"Object {Application} must be awakened" ).Valid( Application.didAwake );
                Assert.Object.Message( $"Object {Application} must be alive" ).Alive( Application );
                return Application;
            }
            if (type == typeof( Camera )) {
                return Camera.main;
            }
            if (type == typeof( Globals )) {
                return Globals;
            }
            if (type == typeof( Globals.PlayerProfile )) {
                return PlayerProfile;
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
            if (type == typeof( ILobbyService )) {
                return LobbyService;
            }
            if (type == typeof( IQosService )) {
                return QosService;
            }
            // Game
            if (type == typeof( Game )) {
                Assert.Object.Message( $"Object {Application} must be awakened" ).Valid( Application.didAwake );
                Assert.Object.Message( $"Object {Application} must be alive" ).Alive( Application );
                if (Application.Game != null) {
                    Assert.Object.Message( $"Object {Application.Game} must be awakened" ).Valid( Application.Game.didAwake );
                    Assert.Object.Message( $"Object {Application.Game} must be alive" ).Alive( Application.Game );
                    return Application.Game;
                }
            }
            return null;
        }

    }
}
