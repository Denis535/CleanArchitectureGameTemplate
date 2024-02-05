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
        private Globals.AccountSettings PlayerProfile { get; set; } = default!;
        private Globals.VideoSettings VideoSettings { get; set; } = default!;
        private Globals.AudioSettings AudioSettings { get; set; } = default!;
        private Globals.Preferences Preferences { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;
        private ILobbyService LobbyService => Unity.Services.Lobbies.LobbyService.Instance;
        private IQosService QosService => Unity.Services.Qos.QosService.Instance;

        // Awake
        public void Awake() {
            Globals = new Globals();
            PlayerProfile = new Globals.AccountSettings();
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
                Assert.Object.Message( $"Object {UITheme} must be awakened" ).Valid( UITheme.didAwake );
                Assert.Object.Message( $"Object {UITheme} must be alive" ).Alive( UITheme );
                return UITheme;
            }
            if (type == typeof( UIScreen )) {
                Assert.Object.Message( $"Object {UIScreen} must be awakened" ).Valid( UIScreen.didAwake );
                Assert.Object.Message( $"Object {UIScreen} must be alive" ).Alive( UIScreen );
                return UIScreen;
            }
            if (type == typeof( UIFactory )) {
                Assert.Object.Message( $"Object {UIFactory} must be awakened" ).Valid( UIFactory.didAwake );
                Assert.Object.Message( $"Object {UIFactory} must be alive" ).Alive( UIFactory );
                return UIFactory;
            }
            if (type == typeof( UIRouter )) {
                Assert.Object.Message( $"Object {UIRouter} must be awakened" ).Valid( UIRouter.didAwake );
                Assert.Object.Message( $"Object {UIRouter} must be alive" ).Alive( UIRouter );
                return UIRouter;
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
            if (type == typeof( Globals.AccountSettings )) {
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
