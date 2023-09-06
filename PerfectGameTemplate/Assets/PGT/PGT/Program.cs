#nullable enable
namespace PGT {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PGT.App;
    using PGT.UI;
    using Unity.Services.Authentication;
    using Unity.Services.Core;
    using Unity.Services.Qos;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.UIElements;

    public class Program : ProgramBase {

        private UIRouter Router => Singleton.GetInstance<UIRouter>();
        private AppManager AppManager => Singleton.GetInstance<AppManager>();
        private IAuthenticationService AuthenticationService => AppManager.AuthenticationService;
        private IQosService QosService => AppManager.QosService;
#if UNITY_EDITOR
        public static Func<Task>? Starter { get; set; }
#endif

        // OnLoad
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        internal static void OnLoad() {
            DropdownField2.Formatter = GetDisplayString;
            _ = new Globals();
            _ = new Globals.PlayerProfile();
            _ = new Globals.VideoSettings();
            _ = new Globals.AudioSettings();
            _ = new Globals.Preferences();
            //if (Debug.isDebugBuild) {
            //    Screen.fullScreen = false;
            //    Screen.SetResolution( 1280, 720, false );
            //}
#if UNITY_EDITOR
            //Debug.LogFormat( "Organization: {0}, {1}", CloudProjectSettings.organizationName, CloudProjectSettings.organizationId );
            //Debug.LogFormat( "Project: {0}, {1}", CloudProjectSettings.projectName, CloudProjectSettings.projectId );
#endif
        }

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public async void Start() {
#if UNITY_EDITOR
            if (Starter != null) {
                await Starter();
            }
#else
            await Router.LoadMainSceneAsync();
#endif

            // UnityServices
            var options = new InitializationOptions();
            await UnityServices.InitializeAsync( options );
            destroyCancellationToken.ThrowIfCancellationRequested();

            // AuthenticationService
            await AuthenticationService.SignInAnonymouslyAsync();
            destroyCancellationToken.ThrowIfCancellationRequested();
            Debug.LogFormat( "Player: {0}", AuthenticationService.PlayerInfo?.Username );
            Debug.LogFormat( "Player Id: {0}", AuthenticationService.PlayerInfo?.Id );

            // QosService
            //var results = await QosService.GetSortedQosResultsAsync( "multiplay", null );
            //destroyCancellationToken.ThrowIfCancellationRequested();
            //foreach (var result in results) {
            //    Debug.LogFormat( "Qos: Region={0}, AverageLatencyMs={1}, PacketLossPercent={2}", result.Region, result.AverageLatencyMs, result.PacketLossPercent );
            //}
        }
        public void Update() {
        }

        // Helpers
        private static string GetDisplayString(object? obj) {
            if (obj is Resolution resolution) return GetDisplayString( resolution );
            if (obj is GameMode gameMode) return GetDisplayString( gameMode );
            if (obj is GameWorld gameWorld) return GetDisplayString( gameWorld );
            if (obj is PlayerRole playerRole) return GetDisplayString( playerRole );
            return obj?.ToString() ?? "Null";
        }
        private static string GetDisplayString(Resolution value) {
            return $"{value.width} x {value.height}";
        }
        private static string GetDisplayString(GameMode value) {
            return value switch {
                GameMode._1x1 => "1 x 1",
                GameMode._1x2 => "1 x 2",
                GameMode._1x3 => "1 x 3",
                GameMode._1x4 => "1 x 4",
                GameMode._1x5 => "1 x 5",
                GameMode._1x6 => "1 x 6",
                GameMode._1x7 => "1 x 7",
                GameMode._1x8 => "1 x 8",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} not supported" ),
            };
        }
        private static string GetDisplayString(GameWorld value) {
            return value switch {
                GameWorld.TestWorld1 => "Test World 1",
                GameWorld.TestWorld2 => "Test World 2",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} not supported" ),
            };
        }
        private static string GetDisplayString(PlayerRole value) {
            return value switch {
                PlayerRole.Master => "Master",
                PlayerRole.Gamer => "Gamer",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} not supported" ),
            };
        }

    }
}
