#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.App;
    using Project.Entities.GameScene;
    using Project.UI;
    using Unity.Services.Authentication;
    using Unity.Services.Core;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.UIElements;

    // Ideally leave this blank
    public class Program : ProgramBase {

        // Globals
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;
        private Globals Globals { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;

        // OnLoad
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        internal static void OnLoad() {
            UnityEngine.Application.logMessageReceived += OnLog;
            //if (Debug.isDebugBuild) {
            //    Screen.fullScreen = false;
            //    Screen.SetResolution( 1280, 720, false );
            //}
            DropdownField2.Formatter = GetDisplayString;
        }

        // OnLog
        private static void OnLog(string message, string stackTrace, LogType type) {
#if RELEASE
            if (type is LogType.Error or LogType.Assert or LogType.Exception) {
                UnityEngine.Application.Quit( 1 );
            }
#endif
        }

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            Globals = this.GetDependencyContainer().Resolve<Globals>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public async void Start() {
            await Router.LoadMainSceneAsync( default );
            {
                // UnityServices
                var options = new InitializationOptions();
                if (Globals.Profile != null) options.SetProfile( Globals.Profile );
                await UnityServices.InitializeAsync( options );
            }
            {
                // AuthenticationService
                var options = new SignInOptions();
                options.CreateAccount = true;
                await AuthenticationService.SignInAnonymouslyAsync( options );
            }
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
