#nullable enable
namespace PGT {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using PGT.UI;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class Launcher : MonoBehaviour {

        private UIRouter Router => Singleton.GetInstance<UIRouter>();

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
        public void Awake() {
        }
        public void OnDestroy() {
        }

        // Start
        public async void Start() {
            await UIRouter.LoadProgramAsync();
            await Router.LoadMainSceneAsync();
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
