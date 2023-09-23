#if UNITY_EDITOR
#nullable enable
namespace Project.Toolbar {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Object = UnityEngine.Object;

    public static class ProjectToolbar {

        // OnLoad
        [InitializeOnLoadMethod]
        internal static void OnLoad() {
            if (!EditorApplication.isPlaying) {
                EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>( "Assets/Project/Assets.Project/Program.unity" );
                //EditorSceneManager.playModeStartScene = null;
            }
        }

        // OnEnterPlaymode
        [InitializeOnEnterPlayMode]
        internal static void OnEnterPlaymode() {
            var scene = SceneManager.GetActiveScene();
            if (scene.name == "Launcher") {
            } else
            if (scene.name == "Program") {
            } else
            if (scene.name == "MainScene") {
            } else
            if (scene.name == "GameScene") {
            }
        }

        // LoadScene
        [MenuItem( "Project/Launcher", priority = 100 )]
        internal static void LoadLauncher() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/Launcher.unity" );
        }
        [MenuItem( "Project/Program", priority = 101 )]
        internal static void LoadProgram() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/Program.unity" );
        }
        [MenuItem( "Project/Main Scene", priority = 102 )]
        internal static void LoadMainScene() {
            EditorSceneManager.OpenScene( "Assets/Project.Entities.MainScene/Assets.Project.Entities.MainScene/MainScene.unity" );
        }
        [MenuItem( "Project/Game Scene", priority = 103 )]
        internal static void LoadGameScene() {
            EditorSceneManager.OpenScene( "Assets/Project.Entities.GameScene/Assets.Project.Entities.GameScene/GameScene.unity" );
        }

        // LoadWorld
        [MenuItem( "Project/Test World 1", priority = 200 )]
        internal static void LoadTestLevel1() {
            EditorSceneManager.OpenScene( "Assets/Project.Entities.WorldScene/Assets.Project.Entities.WorldScene/TestWorld_1.unity" );
        }
        [MenuItem( "Project/Test World 2", priority = 201 )]
        internal static void LoadTestLevel2() {
            EditorSceneManager.OpenScene( "Assets/Project.Entities.WorldScene/Assets.Project.Entities.WorldScene/TestWorld_2.unity" );
        }

        // Build
        [MenuItem( "Project/Pre Build", priority = 300 )]
        internal static void PreBuild() {
            new ProjectBuilder2().PreBuild();
        }
        [MenuItem( "Project/Build Development", priority = 301 )]
        internal static void BuildDevelopment() {
            new ProjectBuilder2().BuildDevelopment();
        }
        [MenuItem( "Project/Build Production", priority = 302 )]
        internal static void BuildProduction() {
            new ProjectBuilder2().BuildProduction();
        }

        // OpenAssets
        [MenuItem( "Project/Open Assets (UIAudioTheme)", priority = 1000 )]
        internal static void OpenAssets_UIAudioTheme() {
            OpenAssets( GetPatterns(
                // MainScreen
                "Assets/*/Project.UI.MainScreen/*Theme.cs",
                // GameScreen
                "Assets/*/Project.UI.GameScreen/*Theme.cs"
                ) );
        }
        [MenuItem( "Project/Open Assets (UIScreen)", priority = 1001 )]
        internal static void OpenAssets_UIScreen() {
            OpenAssets( GetPatterns(
                // MainScreen
                "Assets/*/Project.UI.MainScreen/*Screen.cs",
                // GameScreen
                "Assets/*/Project.UI.GameScreen/*Screen.cs"
                ) );
        }
        [MenuItem( "Project/Open Assets (UIWidget)", priority = 1002 )]
        internal static void OpenAssets_UIWidget() {
            OpenAssets( GetPatterns(
                // MainScreen
                "Assets/*/Project.UI.MainScreen/*WidgetBase.cs",
                "Assets/*/Project.UI.MainScreen/*Widget.cs",
                "Assets/*/Project.UI.MainScreen/*Widget2.cs",
                // GameScreen
                "Assets/*/Project.UI.GameScreen/*WidgetBase.cs",
                "Assets/*/Project.UI.GameScreen/*Widget.cs",
                "Assets/*/Project.UI.GameScreen/*Widget2.cs",
                // Common
                "Assets/*/Project.UI.Common/*WidgetBase.cs",
                "Assets/*/Project.UI.Common/*Widget.cs",
                "Assets/*/Project.UI.Common/*Widget2.cs"
                ) );
        }
        [MenuItem( "Project/Open Assets (UIView)", priority = 1003 )]
        internal static void OpenAssets_UIView() {
            OpenAssets( GetPatterns(
                // MainScreen
                "Assets/*/Project.UI.MainScreen/*ViewBase.cs",
                "Assets/*/Project.UI.MainScreen/*View.cs",
                "Assets/*/Project.UI.MainScreen/*View2.cs",
                // GameScreen
                "Assets/*/Project.UI.GameScreen/*ViewBase.cs",
                "Assets/*/Project.UI.GameScreen/*View.cs",
                "Assets/*/Project.UI.GameScreen/*View2.cs",
                // Common
                "Assets/*/Project.UI.Common/*ViewBase.cs",
                "Assets/*/Project.UI.Common/*View.cs",
                "Assets/*/Project.UI.Common/*View2.cs"
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
