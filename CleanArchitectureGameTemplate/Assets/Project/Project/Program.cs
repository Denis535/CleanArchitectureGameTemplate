#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Framework;

    public class Program : ProgramBase {

        // Globals
        private UITheme Theme { get; set; } = default!;
        private UIScreen Screen { get; set; } = default!;
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;

#if UNITY_EDITOR
        // OnEnterPlaymode
        //[InitializeOnEnterPlayMode]
        //public static void OnEnterPlaymode() {
        //    var scene = SceneManager.GetActiveScene();
        //    if (scene.name == "Launcher") {
        //    } else
        //    if (scene.name == "Program") {
        //    } else
        //    if (scene.name == "MainScene") {
        //    } else
        //    if (scene.name == "GameScene") {
        //    }
        //}
#endif

#if UNITY_EDITOR
        // OnLoad
        [InitializeOnLoadMethod]
        internal static void OnLoad() {
            if (!EditorApplication.isPlaying) {
                //UnityEditor.SceneManagement.EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>( "Assets/Project/Assets.Project/Launcher.unity" );
                //EditorSceneManager.playModeStartScene = null;
            }
        }
#endif

        // OnLoad
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        internal static void OnLoad2() {
            UnityEngine.Application.logMessageReceived += OnLog;
            UIFactory.StringSelector = GetDisplayString;
        }

        // Awake
        public new void Awake() {
            base.Awake();
            Theme = Utils.Container.RequireDependency<UITheme>( null );
            Screen = Utils.Container.RequireDependency<UIScreen>( null );
            Router = Utils.Container.RequireDependency<UIRouter>( null );
            Application = Utils.Container.RequireDependency<Application2>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public async void Start() {
            await Router.LoadMainSceneAsync();
        }
        public void Update() {
        }

        // OnLog
        private static void OnLog(string message, string stackTrace, LogType type) {
#if RELEASE
            if (type is LogType.Error or LogType.Assert or LogType.Exception) {
                UnityEngine.Application.Quit( 1 );
            }
#endif
        }

        // Helpers/GetDisplayString
        private static string GetDisplayString<T>(T value) {
            if (value is Resolution resolution) return GetDisplayString( resolution );
            if (value is GameMode gameMode) return GetDisplayString( gameMode );
            if (value is GameWorld gameWorld) return GetDisplayString( gameWorld );
            if (value is PlayerRole playerRole) return GetDisplayString( playerRole );
            return value?.ToString() ?? "Null";
        }
        // Helpers/GetDisplayString/GameDesc
        private static string GetDisplayString(GameMode value) {
            return value switch {
                // 1x...
                GameMode._1x1 => "1 x 1",
                GameMode._1x2 => "1 x 2",
                GameMode._1x3 => "1 x 3",
                GameMode._1x4 => "1 x 4",
                // 2x
                GameMode._2x1 => "2 x 1",
                GameMode._2x2 => "2 x 2",
                GameMode._2x3 => "2 x 3",
                GameMode._2x4 => "2 x 4",
                // 3x
                GameMode._3x1 => "3 x 1",
                GameMode._3x2 => "3 x 2",
                GameMode._3x3 => "3 x 3",
                GameMode._3x4 => "3 x 4",
                // 4x
                GameMode._4x1 => "4 x 1",
                GameMode._4x2 => "4 x 2",
                GameMode._4x3 => "4 x 3",
                GameMode._4x4 => "4 x 4",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} is not supported" ),
            };
        }
        private static string GetDisplayString(GameWorld value) {
            return value switch {
                GameWorld.World1 => "World 1",
                GameWorld.World2 => "World 2",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} is not supported" ),
            };
        }
        // Helpers/GetDisplayString/PlayerDesc
        private static string GetDisplayString(PlayerRole value) {
            return value switch {
                PlayerRole.Human => "Human",
                PlayerRole.Monster => "Monster",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} is not supported" ),
            };
        }
        // Helpers/GetDisplayString/Misc
        private static string GetDisplayString(Resolution value) {
            return $"{value.width} x {value.height}";
        }

    }
}
