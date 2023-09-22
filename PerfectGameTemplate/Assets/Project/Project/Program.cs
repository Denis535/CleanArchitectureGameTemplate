#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.UIElements;

    public class Program : ProgramBase {

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
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public void Start() {
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