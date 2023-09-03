#if UNITY_EDITOR
#nullable enable
namespace PGT.Tools {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using PGT.App;
    using PGT.UI;
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Object = UnityEngine.Object;

    public static class Toolbar {

        private static Action? Launcher { get; set; }

        // OnLoad
        [InitializeOnLoadMethod]
        internal static void OnLoad() {
            if (!EditorApplication.isPlaying) {
                EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>( "Assets/PGT/Assets.PGT/Program.unity" );
                //EditorSceneManager.playModeStartScene = null;
                EditorApplication.playModeStateChanged += i => {
                    if (i == PlayModeStateChange.EnteredPlayMode) {
                        Launcher?.Invoke();
                        Launcher = null;
                    }
                };
            }
        }

        // OnEnterPlaymode
        [InitializeOnEnterPlayMode]
        internal static void OnEnterPlaymode() {
            var scene = SceneManager.GetActiveScene();
            if (scene.name == "Launcher") {
                Launcher = async () => {
                    await Singleton.GetInstance<UIRouter>().LoadMainSceneAsync();
                };
            }
            if (scene.name == "Program") {
                Launcher = async () => {
                    await Singleton.GetInstance<UIRouter>().LoadMainSceneAsync();
                };
            }
            if (scene.name == "MainScene") {
                Launcher = async () => {
                    await Singleton.GetInstance<UIRouter>().LoadMainSceneAsync();
                };
            }
            if (scene.name == "GameScene") {
                Launcher = async () => {
                    var gameDesc = new GameDesc( "Game", GameMode._1x1, GameWorld.TestWorld1, false );
                    var playerDesc = new PlayerDesc( "Anonymous", PlayerRole.Master );
                    await Singleton.GetInstance<UIRouter>().LoadGameSceneAsync( gameDesc, playerDesc );
                };
            }
        }

        // LoadScene
        [MenuItem( "PGT/Launcher", priority = 100 )]
        internal static void LoadLauncher() {
            EditorSceneManager.OpenScene( "Assets/PGT/Assets.PGT/Launcher.unity" );
        }
        [MenuItem( "PGT/Program", priority = 101 )]
        internal static void LoadProgram() {
            EditorSceneManager.OpenScene( "Assets/PGT/Assets.PGT/Program.unity" );
        }
        [MenuItem( "PGT/Main Scene", priority = 102 )]
        internal static void LoadMainScene() {
            EditorSceneManager.OpenScene( "Assets/PGT/Assets.PGT/MainScene.unity" );
        }
        [MenuItem( "PGT/Game Scene", priority = 103 )]
        internal static void LoadGameScene() {
            EditorSceneManager.OpenScene( "Assets/PGT/Assets.PGT/GameScene.unity" );
        }

        // LoadWorld
        [MenuItem( "PGT/Test World 1", priority = 200 )]
        internal static void LoadTestLevel1() {
            EditorSceneManager.OpenScene( "Assets/PGT.Game/Assets.PGT.Game.World/TestWorld_1.unity" );
        }
        [MenuItem( "PGT/Test World 2", priority = 201 )]
        internal static void LoadTestLevel2() {
            EditorSceneManager.OpenScene( "Assets/PGT.Game/Assets.PGT.Game.World/TestWorld_2.unity" );
        }

        // Build
        [MenuItem( "PGT/Pre Build", priority = 300 )]
        internal static void PreBuild() {
            new ProjectBuilder2().PreBuild();
        }
        [MenuItem( "PGT/Build Development", priority = 301 )]
        internal static void BuildDevelopment() {
            new ProjectBuilder2().BuildDevelopment();
        }
        [MenuItem( "PGT/Build Production", priority = 302 )]
        internal static void BuildProduction() {
            new ProjectBuilder2().BuildProduction();
        }

        // OpenAssets
        [MenuItem( "PGT/Open Assets (UIAudioTheme)", priority = 1000 )]
        internal static void OpenAssets_UIAudioTheme() {
            OpenAssets( GetPatterns(
                // MainScreen
                "Assets/*/PGT.UI.MainScreen/*Theme.cs",
                // GameScreen
                "Assets/*/PGT.UI.GameScreen/*Theme.cs"
                ) );
        }
        [MenuItem( "PGT/Open Assets (UIScreen)", priority = 1001 )]
        internal static void OpenAssets_UIScreen() {
            OpenAssets( GetPatterns(
                // MainScene
                "Assets/*/PGT.UI.MainScreen/*Screen.cs",
                // GameScene
                "Assets/*/PGT.UI.GameScreen/*Screen.cs"
                ) );
        }
        [MenuItem( "PGT/Open Assets (UIWidget)", priority = 1002 )]
        internal static void OpenAssets_UIWidget() {
            OpenAssets( GetPatterns(
                // MainScene
                "Assets/*/PGT.UI.MainScreen/*WidgetBase.cs",
                "Assets/*/PGT.UI.MainScreen/*Widget.cs",
                "Assets/*/PGT.UI.MainScreen/*Widget2.cs",
                // GameScene
                "Assets/*/PGT.UI.GameScreen/*WidgetBase.cs",
                "Assets/*/PGT.UI.GameScreen/*Widget.cs",
                "Assets/*/PGT.UI.GameScreen/*Widget2.cs",
                // Common
                "Assets/*/PGT.UI.Common/*WidgetBase.cs",
                "Assets/*/PGT.UI.Common/*Widget.cs",
                "Assets/*/PGT.UI.Common/*Widget2.cs"
                ) );
        }
        [MenuItem( "PGT/Open Assets (UIView)", priority = 1003 )]
        internal static void OpenAssets_UIView() {
            OpenAssets( GetPatterns(
                // MainScene
                "Assets/*/PGT.UI.MainScreen/*ViewBase.cs",
                "Assets/*/PGT.UI.MainScreen/*View.cs",
                "Assets/*/PGT.UI.MainScreen/*View2.cs",
                // GameScene
                "Assets/*/PGT.UI.GameScreen/*ViewBase.cs",
                "Assets/*/PGT.UI.GameScreen/*View.cs",
                "Assets/*/PGT.UI.GameScreen/*View2.cs",
                // Common
                "Assets/*/PGT.UI.Common/*ViewBase.cs",
                "Assets/*/PGT.UI.Common/*View.cs",
                "Assets/*/PGT.UI.Common/*View2.cs"
                ) );
        }

        // Helpers
        private static void OpenAssets(params Regex[] patterns) {
            foreach (var path in GetPaths().Reverse()) {
                if (patterns.Any( i => i.IsMatch( path ) )) {
                    AssetDatabase.OpenAsset( AssetDatabase.LoadAssetAtPath<Object>( path ) );
                }
            }
        }
        private static Regex[] GetPatterns(params string[] patterns) {
            return patterns.Select( GetPattern ).ToArray();
        }
        private static Regex GetPattern(string pattern) {
            pattern = "^" + pattern.Replace( "*", "(.*?)" ) + "$";
            return new Regex( pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace );
        }
        private static string[] GetPaths() {
            var path = Directory.GetCurrentDirectory();
            return GetPaths( path )
                .Select( i => Path.GetRelativePath( path, i ) )
                .Select( i => i.Replace( '\\', '/' ) )
                .ToArray();
        }
        private static IEnumerable<string> GetPaths(string path) {
            foreach (var file in Directory.EnumerateFiles( path ).OrderBy( i => i )) {
                yield return file;
            }
            foreach (var dir in Directory.EnumerateDirectories( path ).OrderBy( i => i )) {
                yield return dir;
                foreach (var i in GetPaths( dir )) yield return i;
            }
        }

    }
}
#endif
