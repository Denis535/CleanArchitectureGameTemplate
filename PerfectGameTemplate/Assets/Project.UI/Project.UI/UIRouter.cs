#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Project.App;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;

    public class UIRouter : UIRouterBase {

        private static SceneInstance program;
        private SceneInstance mainScene;
        private SceneInstance gameScene;
        private SceneInstance worldScene;

        // System
        private Lock Lock { get; } = new Lock();
        // Globals
        private Application2 Application { get; set; } = default!;
        // IsSceneLoaded
        public static bool IsProgramLoaded => program.Scene.IsValid();
        public bool IsMainSceneLoaded => mainScene.Scene.IsValid();
        public bool IsGameSceneLoaded => gameScene.Scene.IsValid();
        public bool IsWorldSceneLoaded => worldScene.Scene.IsValid();

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // LoadScene
        public static async Task LoadProgramAsync() {
            Release.LogFormat( "Load: Program" );
            program = await LoadSceneAsync( R.Project.Program, LoadSceneMode.Single, true, default );
        }
        public async Task LoadMainSceneAsync() {
            Release.LogFormat( "Load: MainScene" );
            using (Lock.Enter()) {
                await UnloadGameSceneInternalAsync( destroyCancellationToken );
                await UnloadWorldSceneInternalAsync( destroyCancellationToken );
                await LoadMainSceneInternalAsync( destroyCancellationToken );
            }
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, PlayerDesc playerDesc) {
            Release.LogFormat( "Load: GameScene" );
            using (Lock.Enter()) {
                await Task.Delay( 3_000 );
                await LoadWorldSceneInternalAsync( gameDesc.World, destroyCancellationToken );
                await UnloadMainSceneInternalAsync( destroyCancellationToken );
                await LoadGameSceneInternalAsync( gameDesc, playerDesc, destroyCancellationToken );
            }
        }

        // Quit
        public void Quit() {
#if UNITY_EDITOR
            OnQuit();
#else
            Release.Log( "Quit" );
            UnityEngine.Application.wantsToQuit -= OnQuit;
            UnityEngine.Application.wantsToQuit += OnQuit;
            UnityEngine.Application.Quit();
#endif
        }
        private bool OnQuit() {
            Release.Log( "OnQuit" );
            if (IsMainSceneLoaded || IsGameSceneLoaded || IsWorldSceneLoaded) {
                OnQuitAsync();
                return false;
            }
            return true;
        }
        private async void OnQuitAsync() {
            using (Lock.Enter()) {
                await UnloadMainSceneInternalAsync( default );
                await UnloadGameSceneInternalAsync( default );
                await UnloadWorldSceneInternalAsync( default );
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#else
                UnityEngine.Application.Quit();
#endif
            }
        }

        // LoadScene
        private async Task LoadMainSceneInternalAsync(CancellationToken cancellationToken) {
            mainScene = await LoadSceneAsync( R.Project.MainScene, LoadSceneMode.Additive, true, cancellationToken );
        }
        private async Task LoadGameSceneInternalAsync(GameDesc gameDesc, PlayerDesc playerDesc, CancellationToken cancellationToken) {
            gameScene = await LoadSceneAsync( R.Project.GameScene, LoadSceneMode.Additive, true, cancellationToken );
            Application.StartGame( gameDesc, playerDesc );
        }
        private async Task LoadWorldSceneInternalAsync(GameWorld world, CancellationToken cancellationToken) {
            worldScene = await LoadSceneAsync( GetAddress( world ), LoadSceneMode.Additive, true, cancellationToken );
        }

        // UnloadScene
        private async Task UnloadMainSceneInternalAsync(CancellationToken cancellationToken) {
            if (mainScene.Scene.IsValid()) {
                await UnloadSceneAsync( mainScene, cancellationToken );
            }
        }
        private async Task UnloadGameSceneInternalAsync(CancellationToken cancellationToken) {
            if (gameScene.Scene.IsValid()) {
                Application.StopGame();
                await UnloadSceneAsync( gameScene, cancellationToken );
            }
        }
        private async Task UnloadWorldSceneInternalAsync(CancellationToken cancellationToken) {
            if (worldScene.Scene.IsValid()) {
                await UnloadSceneAsync( worldScene, cancellationToken );
            }
        }

        // Helpers
        private static async Task<SceneInstance> LoadSceneAsync(string key, LoadSceneMode mode, bool activateOnLoad, CancellationToken cancellationToken) {
            var instance = await Addressables2.LoadSceneAsync( key, mode, activateOnLoad ).GetResultAsync( cancellationToken );
            SceneManager.SetActiveScene( instance.Scene );
            return instance;
        }
        private static Task UnloadSceneAsync(SceneInstance instance, CancellationToken cancellationToken) {
            return Addressables2.UnloadSceneAsync( instance ).GetResultAsync( cancellationToken );
        }
        private static string GetAddress(GameWorld world) {
            return world switch {
                GameWorld.TestWorld1 => R.Project.Game.World.TestWorld_1,
                GameWorld.TestWorld2 => R.Project.Game.World.TestWorld_2,
                _ => throw Exceptions.Internal.NotSupported( $"World {world} not supported" ),
            };
        }

    }
}
