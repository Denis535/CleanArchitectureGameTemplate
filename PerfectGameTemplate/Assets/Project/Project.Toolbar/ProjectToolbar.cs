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
    using System.Threading;
    using Project.Tools;
    using Project.UI;
    using Project.UI.Common;
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEditorInternal;
    using UnityEngine;
    using UnityEngine.Framework.UI;
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
        [MenuItem( "Project/Launcher", priority = 0 )]
        internal static void LoadLauncher() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/Launcher.unity" );
        }
        [MenuItem( "Project/Program", priority = 1 )]
        internal static void LoadProgram() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/Program.unity" );
        }
        [MenuItem( "Project/Main Scene", priority = 2 )]
        internal static void LoadMainScene() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/MainScene.unity" );
        }
        [MenuItem( "Project/Game Scene", priority = 3 )]
        internal static void LoadGameScene() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/GameScene.unity" );
        }

        // LoadScene
        [MenuItem( "Project/Test World Scene 1", priority = 100 )]
        internal static void LoadTestWorldScene_1() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/TestWorldScene_1.unity" );
        }
        [MenuItem( "Project/Test World Scene 2", priority = 101 )]
        internal static void LoadTestWorldScene_2() {
            EditorSceneManager.OpenScene( "Assets/Project/Assets.Project/TestWorldScene_2.unity" );
        }

        // Build
        [MenuItem( "Project/Pre Build", priority = 200 )]
        internal static void PreBuild() {
            new ProjectBuilder2().PreBuild();
        }
        [MenuItem( "Project/Build Development", priority = 201 )]
        internal static void BuildDevelopment() {
            new ProjectBuilder2().BuildDevelopment();
        }
        [MenuItem( "Project/Build Production", priority = 202 )]
        internal static void BuildProduction() {
            new ProjectBuilder2().BuildProduction();
        }

        // TakeScreenshot
        [MenuItem( "Project/Take Screenshot (Game) _F12", priority = 300 )]
        internal static void TakeScreenshot_Game() {
            ScreenCapture.CaptureScreenshot( $"Screenshots/Screenshot-{DateTime.UtcNow.Ticks}.png", 1 );
            EditorApplication.Beep();
        }
        [MenuItem( "Project/Take Screenshot (Editor) &F12", priority = 301 )]
        internal static void TakeScreenshot_Editor() {
            var position = EditorGUIUtility.GetMainWindowPosition();
            var texture = new Texture2D( (int) position.width, (int) position.height );
            texture.SetPixels( InternalEditorUtility.ReadScreenPixel( position.position, (int) position.width, (int) position.height ) );
            var png = texture.EncodeToPNG();
            Object.DestroyImmediate( texture );

            var path = $"Screenshots/Screenshot-{DateTime.UtcNow.Ticks}.png";
            Directory.CreateDirectory( Path.GetDirectoryName( path ) );
            File.WriteAllBytes( path, png );
            EditorApplication.Beep();
        }

        // OpenAssets
        [MenuItem( "Project/Open Assets (UIAudioTheme)", priority = 1000 )]
        internal static void OpenAssets_UIAudioTheme() {
            OpenAssetsReverse(
                "Assets/Project.UI/Project.UI/           (*Theme.cs)",
                "Assets/Project.UI/Project.UI.MainScreen/(*Theme.cs)",
                "Assets/Project.UI/Project.UI.GameScreen/(*Theme.cs)"
                );
        }
        [MenuItem( "Project/Open Assets (UIScreen)", priority = 1001 )]
        internal static void OpenAssets_UIScreen() {
            OpenAssetsReverse(
                "Assets/Project.UI/Project.UI/           (*Screen.cs)",
                "Assets/Project.UI/Project.UI.MainScreen/(*Screen.cs)",
                "Assets/Project.UI/Project.UI.GameScreen/(*Screen.cs)"
                );
        }
        [MenuItem( "Project/Open Assets (UIWidget)", priority = 1002 )]
        internal static void OpenAssets_UIWidget() {
            OpenAssetsReverse(
                "Assets/Project.UI/Project.UI/           (*WidgetBase.cs|*Widget.cs)",
                "Assets/Project.UI/Project.UI.Common/    (*WidgetBase.cs|*Widget.cs)",
                "Assets/Project.UI/Project.UI.MainScreen/(*WidgetBase.cs|*Widget.cs)",
                "Assets/Project.UI/Project.UI.GameScreen/(*WidgetBase.cs|*Widget.cs)"
                );
        }
        [MenuItem( "Project/Open Assets (UIView)", priority = 1003 )]
        internal static void OpenAssets_UIView() {
            OpenAssetsReverse(
                "Assets/Project.UI/Project.UI/           (*ViewBase.cs|*View.cs)",
                "Assets/Project.UI/Project.UI.Common/    (*ViewBase.cs|*View.cs)",
                "Assets/Project.UI/Project.UI.MainScreen/(*ViewBase.cs|*View.cs)",
                "Assets/Project.UI/Project.UI.GameScreen/(*ViewBase.cs|*View.cs)"
                );
        }
        [MenuItem( "Project/Open Assets (StyleSheet)", priority = 1004 )]
        internal static void OpenAssets_StyleSheet() {
            OpenAssets( "Assets/(*.stylus|*.styl)" );
            OpenAssets( "Packages/(*.stylus|*.styl)" );
        }

        // OpenDialog
        [MenuItem( "Project/Open Dialog", priority = 1100 )]
        internal static void OpenDialog() {
            if (Application.isPlaying) {
                GetScreen().Widget!.AttachChild( new DialogWidget( "Dialog", "This is dialog example." ).OnSubmit( "Ok", null ).OnCancel( "Cancel", null ) );
            }
        }
        [MenuItem( "Project/Open Info Dialog", priority = 1101 )]
        internal static void OpenInfoDialog() {
            if (Application.isPlaying) {
                GetScreen().Widget!.AttachChild( new InfoDialogWidget( "Info Dialog", "This is info dialog example." ).OnSubmit( "Ok", null ).OnCancel( "Cancel", null ) );
            }
        }
        [MenuItem( "Project/Open Warning Dialog", priority = 1102 )]
        internal static void OpenWarningDialog() {
            if (Application.isPlaying) {
                GetScreen().Widget!.AttachChild( new WarningDialogWidget( "Warning Dialog", "This is warning dialog example." ).OnSubmit( "Ok", null ).OnCancel( "Cancel", null ) );
            }
        }
        [MenuItem( "Project/Open Error Dialog", priority = 1103 )]
        internal static void OpenErrorDialog() {
            if (Application.isPlaying) {
                GetScreen().Widget!.AttachChild( new ErrorDialogWidget( "Error Dialog", "This is error dialog example." ).OnSubmit( "Ok", null ).OnCancel( "Cancel", null ) );
            }
        }

        // Helpers
        private static UIScreen GetScreen() {
            return GameObject2.RequireAnyObjectByType<UIScreen>( FindObjectsInactive.Exclude );
        }
        // Helpers
        private static void OpenAssets(params string[] patterns) {
            foreach (var path in GetMatches( GetPaths(), patterns )) {
                if (!Path.GetFileName( path ).StartsWith( "_" )) {
                    AssetDatabase.OpenAsset( AssetDatabase.LoadAssetAtPath<Object>( path ) );
                    Thread.Sleep( 500 );
                }
            }
        }
        private static void OpenAssetsReverse(params string[] patterns) {
            foreach (var path in GetMatches( GetPaths(), patterns ).Reverse()) {
                if (!Path.GetFileName( path ).StartsWith( "_" )) {
                    AssetDatabase.OpenAsset( AssetDatabase.LoadAssetAtPath<Object>( path ) );
                    Thread.Sleep( 500 );
                }
            }
        }
        // Helpers
        private static IEnumerable<string> GetPaths() {
            var path = Directory.GetCurrentDirectory();
            return GetPaths( path )
                .Select( i => Path.GetRelativePath( path, i ) )
                .Select( i => i.Replace( '\\', '/' ) );
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
        // Helpers
        private static IEnumerable<string> GetMatches(IEnumerable<string> paths, string[] patterns) {
            paths = paths.ToList();
            foreach (var pattern in patterns) {
                var regex = new Regex( "^" + pattern.Replace( " ", "" ).Replace( "*", "(.*?)" ) + "$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace );
                foreach (var path in paths.Where( path => regex.IsMatch( path ) )) {
                    yield return path;
                }
            }
        }

    }
}
#endif
