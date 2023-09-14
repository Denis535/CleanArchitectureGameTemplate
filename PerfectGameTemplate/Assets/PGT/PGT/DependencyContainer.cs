#nullable enable
namespace PGT {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using PGT.App;
    using PGT.UI;
    using PGT.UI.GameScreen;
    using PGT.UI.MainScreen;
    using Unity.Services.Authentication;
    using Unity.Services.Lobbies;
    using Unity.Services.Qos;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class DependencyContainer : MonoBehaviour, IDependencyContainer {

        [SerializeField] private UIDocument document = default!;
        [SerializeField] private AudioSource musicAudioSource = default!;
        [SerializeField] private AudioSource sfxAudioSource = default!;
        [SerializeField] private UIRouter router = default!;
        [SerializeField] private Application2 application = default!;

        // Globals
        private UIDocument Document => document;
        private AudioSource MusicAudioSource => musicAudioSource;
        private AudioSource SfxAudioSource => sfxAudioSource;
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
        object? IDependencyContainer.GetDependency(Type type, object? argument) {
            if (type == typeof( UIScreenBase )) {
                return GameObject.FindAnyObjectByType<UIScreenBase>();
            }
            if (type == typeof( MainScreen )) {
                return GameObject.FindAnyObjectByType<MainScreen>();
            }
            if (type == typeof( GameScreen )) {
                return GameObject.FindAnyObjectByType<GameScreen>();
            }
            if (type == typeof( UIDocument )) {
                return Document;
            }
            if (type == typeof( AudioSource ) && argument is UIAudioThemeBase) {
                return MusicAudioSource;
            }
            if (type == typeof( AudioSource ) && argument is UIScreenBase) {
                return SfxAudioSource;
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
