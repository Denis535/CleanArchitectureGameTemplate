#nullable enable
namespace PGT {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PGT.App;
    using PGT.UI;
    using PGT.UI.MainScreen;
    using Unity.Services.Authentication;
    using Unity.Services.Core;
    using Unity.Services.Qos;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class Program : ProgramBase {

        // Globals
        private UIScreenBase Screen => this.GetDependencyContainer().Resolve<UIScreenBase>();
        private UIRouter Router { get; set; } = default!;
        private IAuthenticationService AuthenticationService => this.GetDependencyContainer().Resolve<IAuthenticationService>();
        private IQosService QosService => this.GetDependencyContainer().Resolve<IQosService>();

        // OnLoad
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        internal static void OnLoad() {
            //if (Debug.isDebugBuild) {
            //    Screen.fullScreen = false;
            //    Screen.SetResolution( 1280, 720, false );
            //}
            DropdownField2.Formatter = GetDisplayString;
        }

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public async void Start() {
            // LoadScene
            await Router.LoadMainSceneAsync();
            destroyCancellationToken.ThrowIfCancellationRequested();

            // Initialize
            Screen.Widget!.Children.OfType<MainMenuWidget>().First().View.SetEnabled( false );
            {
                // UnityServices
                try {
                    var options = new InitializationOptions();
                    await UnityServices.InitializeAsync( options );
                    destroyCancellationToken.ThrowIfCancellationRequested();
                } catch (Exception ex) {
                    var dialog = UILogicalFactory.ErrorDialogWidget( "Error", ex.Message ).Submit( "Ok", null ).Cancel( "Cancel", () => Router.Quit() );
                    Screen.Widget!.AttachChild( dialog );
                }
                // AuthenticationService
                try {
                    await AuthenticationService.SignInAnonymouslyAsync();
                    destroyCancellationToken.ThrowIfCancellationRequested();
                    Debug.LogFormat( "Player: {0}", AuthenticationService.PlayerInfo?.Username );
                    Debug.LogFormat( "Player Id: {0}", AuthenticationService.PlayerInfo?.Id );
                } catch (Exception ex) {
                    var dialog = UILogicalFactory.ErrorDialogWidget( "Error", ex.Message ).Submit( "Ok", null ).Cancel( "Cancel", () => Router.Quit() );
                    Screen.Widget!.AttachChild( dialog );
                }
            }
            Screen.Widget!.Children.OfType<MainMenuWidget>().First().View.SetEnabled( true );

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
