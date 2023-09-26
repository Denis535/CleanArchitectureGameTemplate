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

        private static AsyncOperationHandle<SceneInstance> programHandle;
        private AsyncOperationHandle<SceneInstance> mainSceneHandle;
        private AsyncOperationHandle<SceneInstance> gameSceneHandle;
        private AsyncOperationHandle<SceneInstance> worldSceneHandle;

        // System
        private Lock Lock { get; } = new Lock();
        // Globals
        private Application2 Application { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // LoadScene
        public static async Task LoadProgramAsync(CancellationToken cancellationToken) {
            Release.LogFormat( "Load: Program" );
            {
                await LoadProgramInternalAsync( cancellationToken );
            }
        }
        public async Task LoadMainSceneAsync(CancellationToken cancellationToken) {
            Release.LogFormat( "Load: MainScene" );
            using (Lock.Enter()) {
                if (Application.IsGameSceneLoaded) {
                    Application.StopGame();
                    Application.SetGameSceneUnloading();
                    await UnloadGameSceneInternalAsync( cancellationToken );
                    await UnloadWorldSceneInternalAsync( cancellationToken );
                }
                {
                    Application.SetMainSceneLoading();
                    await LoadMainSceneInternalAsync( cancellationToken );
                    Application.SetMainSceneLoaded();
                }
            }
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, PlayerDesc playerDesc, CancellationToken cancellationToken) {
            Release.LogFormat( "Load: GameScene" );
            using (Lock.Enter()) {
                if (Application.IsMainSceneLoaded) {
                    Application.SetMainSceneUnloading();
                    await UnloadMainSceneInternalAsync( cancellationToken );
                }
                {
                    Application.SetGameSceneLoading();
                    await Task.Delay( 3_000 );
                    await LoadWorldSceneInternalAsync( gameDesc.World, cancellationToken );
                    await LoadGameSceneInternalAsync( gameDesc, playerDesc, cancellationToken );
                    Application.SetGameSceneLoaded();
                    Application.StartGame( gameDesc, playerDesc );
                }
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
            if (!Application.IsQuited) {
                OnQuitAsync();
                return false;
            }
            return true;
        }
        private async void OnQuitAsync() {
            using (Lock.Enter()) {
                Application.SetQuitting();
                {
                    if (Application.IsMainSceneLoaded) {
                        await UnloadMainSceneInternalAsync( default );
                    }
                    if (Application.IsGameSceneLoaded) {
                        Application.StopGame();
                        await UnloadGameSceneInternalAsync( default );
                        await UnloadWorldSceneInternalAsync( default );
                    }
                }
                Application.SetQuited();
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#else
                UnityEngine.Application.Quit();
#endif
            }
        }

        // Helpers/LoadScene
        private static async Task LoadProgramInternalAsync(CancellationToken cancellationToken) {
            programHandle = Addressables2.LoadSceneAsync( R.Project.Program, LoadSceneMode.Single, true );
            _ = await programHandle.GetResultAsync( cancellationToken );
        }
        private async Task LoadMainSceneInternalAsync(CancellationToken cancellationToken) {
            mainSceneHandle = Addressables2.LoadSceneAsync( R.Project.MainScene, LoadSceneMode.Additive, true );
            var mainScene = await mainSceneHandle.GetResultAsync( cancellationToken );
            SceneManager.SetActiveScene( mainScene.Scene );
        }
        private async Task LoadGameSceneInternalAsync(GameDesc gameDesc, PlayerDesc playerDesc, CancellationToken cancellationToken) {
            gameSceneHandle = Addressables2.LoadSceneAsync( R.Project.GameScene, LoadSceneMode.Additive, true );
            var gameScene = await gameSceneHandle.GetResultAsync( cancellationToken );
            SceneManager.SetActiveScene( gameScene.Scene );
        }
        private async Task LoadWorldSceneInternalAsync(GameWorld world, CancellationToken cancellationToken) {
            worldSceneHandle = Addressables2.LoadSceneAsync( GetWorldSceneAddress( world ), LoadSceneMode.Additive, true );
            _ = await worldSceneHandle.GetResultAsync( cancellationToken );
        }
        // Helpers/UnloadScene
        private async Task UnloadMainSceneInternalAsync(CancellationToken cancellationToken) {
            if (mainSceneHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( mainSceneHandle ).WaitAsync( cancellationToken );
                mainSceneHandle = default;
            }
        }
        private async Task UnloadGameSceneInternalAsync(CancellationToken cancellationToken) {
            if (gameSceneHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( gameSceneHandle ).WaitAsync( cancellationToken );
                gameSceneHandle = default;
            }
        }
        private async Task UnloadWorldSceneInternalAsync(CancellationToken cancellationToken) {
            if (worldSceneHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( worldSceneHandle ).WaitAsync( cancellationToken );
                worldSceneHandle = default;
            }
        }
        // Helpers/Misc
        private static string GetWorldSceneAddress(GameWorld world) {
            return world switch {
                GameWorld.TestWorld1 => R.Project.TestWorldScene_1,
                GameWorld.TestWorld2 => R.Project.TestWorldScene_2,
                _ => throw Exceptions.Internal.NotSupported( $"WorldScene {world} not supported" ),
            };
        }

    }
}
