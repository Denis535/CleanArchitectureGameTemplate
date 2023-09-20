#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Project.App;
    using Project.UI;
    using Unity.Services.Authentication;
    using Unity.Services.Lobbies;
    using Unity.Services.Qos;
    using UnityEngine;
    using UnityEngine.Framework;

    public class DependencyContainer : MonoBehaviour, IDependencyContainer {

        [SerializeField] private UIScreen screen = default!;
        [SerializeField] private UIRouter router = default!;
        [SerializeField] private Application2 application = default!;

        // Globals
        private UIScreen Screen => screen;
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
            if (type == typeof( UIScreen )) {
                return Screen;
            }
            if (type == typeof( UIRouter )) {
                return Router;
            }
            if (type == typeof( Application2 )) {
                return Application;
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
            return null;
        }

    }
}
