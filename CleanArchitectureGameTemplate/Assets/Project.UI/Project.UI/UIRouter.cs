#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Project.App;
    using Project.Entities.GameScene;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;

    public class UIRouter : UIRouterBase {

        private static readonly Lock @lock = new Lock();

        private static AsyncOperationHandle<SceneInstance> programOperationHandle;
        private AsyncOperationHandle<SceneInstance> mainSceneOperationHandle;
        private AsyncOperationHandle<SceneInstance> gameSceneOperationHandle;
        private AsyncOperationHandle<SceneInstance> worldSceneOperationHandle;

        // Globals
        private Application2 Application { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
#if !UNITY_EDITOR
            UnityEngine.Application.wantsToQuit += OnQuit;
#endif
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
            using (@lock.Enter()) {
                // StopGame
                if (Application.Game != null) {
                    Application.Game.StopGame();
                }
                // UnloadGameScene
                if (Application.IsGameSceneLoaded) {
                    Application.SetState( AppState.GameSceneUnloading );
                    await UnloadGameSceneInternalAsync( cancellationToken );
                    await UnloadWorldSceneInternalAsync( cancellationToken );
                    Application.SetState( AppState.GameSceneUnloaded );
                }
                // LoadMainScene
                {
                    Application.SetState( AppState.MainSceneLoading );
                    await LoadMainSceneInternalAsync( cancellationToken );
                    Application.SetState( AppState.MainSceneLoaded );
                }
            }
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, PlayerDesc playerDesc, CancellationToken cancellationToken) {
            Release.LogFormat( "Load: GameScene: {0}, {1}", gameDesc, playerDesc );
            using (@lock.Enter()) {
                // UnloadMainScene
                if (Application.IsMainSceneLoaded) {
                    Application.SetState( AppState.MainSceneUnloading );
                    await UnloadMainSceneInternalAsync( cancellationToken );
                    Application.SetState( AppState.MainSceneUnloaded );
                }
                // LoadGameScene
                {
                    Application.SetState( AppState.GameSceneLoading );
                    await Task.Delay( 3_000 );
                    await LoadWorldSceneInternalAsync( GetWorldAddress( gameDesc.World ), cancellationToken );
                    await LoadGameSceneInternalAsync( cancellationToken );
                    Application.SetState( AppState.GameSceneLoaded );
                }
                // StartGame
                {
                    Application.Game!.StartGame( gameDesc, playerDesc );
                }
            }
        }

        // Quit
        public void Quit() {
#if UNITY_EDITOR
            Release.Log( "Quit" );
            OnQuitAsync();
#else
            Release.Log( "Quit" );
            UnityEngine.Application.Quit();
#endif
        }
        private bool OnQuit() {
            if (!Application.IsQuited) {
                OnQuitAsync();
                return false;
            }
            return true;
        }
        private async void OnQuitAsync() {
            using (@lock.Enter()) {
                Application.SetState( AppState.Quitting );
                // StopGame
                if (Application.Game != null) {
                    Application.Game.StopGame();
                }
                // UnloadGameScene
                if (Application.IsGameSceneLoaded) {
                    await UnloadGameSceneInternalAsync( default );
                    await UnloadWorldSceneInternalAsync( default );
                }
                // UnloadMainScene
                if (Application.IsMainSceneLoaded) {
                    await UnloadMainSceneInternalAsync( default );
                }
                // UnloadProgram
                {
                    await UnloadProgramInternalAsync( default );
                }
                Application.SetState( AppState.Quited );
            }
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }

        // Helpers/LoadScene
        private static async Task LoadProgramInternalAsync(CancellationToken cancellationToken) {
            programOperationHandle = Addressables2.LoadSceneAsync( R.Project.Program, LoadSceneMode.Single, true );
            _ = await programOperationHandle.GetResultAsync( cancellationToken );
        }
        private async Task LoadMainSceneInternalAsync(CancellationToken cancellationToken) {
            mainSceneOperationHandle = Addressables2.LoadSceneAsync( R.Project.MainScene, LoadSceneMode.Additive, true );
            var mainScene = await mainSceneOperationHandle.GetResultAsync( cancellationToken );
            SceneManager.SetActiveScene( mainScene.Scene );
        }
        private async Task LoadGameSceneInternalAsync(CancellationToken cancellationToken) {
            gameSceneOperationHandle = Addressables2.LoadSceneAsync( R.Project.GameScene, LoadSceneMode.Additive, true );
            var gameScene = await gameSceneOperationHandle.GetResultAsync( cancellationToken );
            SceneManager.SetActiveScene( gameScene.Scene );
        }
        private async Task LoadWorldSceneInternalAsync(string key, CancellationToken cancellationToken) {
            worldSceneOperationHandle = Addressables2.LoadSceneAsync( key, LoadSceneMode.Additive, true );
            _ = await worldSceneOperationHandle.GetResultAsync( cancellationToken );
        }
        // Helpers/UnloadScene
        private static async Task UnloadProgramInternalAsync(CancellationToken cancellationToken) {
            if (programOperationHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( programOperationHandle ).WaitAsync( cancellationToken );
                programOperationHandle = default;
            }
        }
        private async Task UnloadMainSceneInternalAsync(CancellationToken cancellationToken) {
            if (mainSceneOperationHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( mainSceneOperationHandle ).WaitAsync( cancellationToken );
                mainSceneOperationHandle = default;
            }
        }
        private async Task UnloadGameSceneInternalAsync(CancellationToken cancellationToken) {
            if (gameSceneOperationHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( gameSceneOperationHandle ).WaitAsync( cancellationToken );
                gameSceneOperationHandle = default;
            }
        }
        private async Task UnloadWorldSceneInternalAsync(CancellationToken cancellationToken) {
            if (worldSceneOperationHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( worldSceneOperationHandle ).WaitAsync( cancellationToken );
                worldSceneOperationHandle = default;
            }
        }
        // Helpers/Misc
        private static string GetWorldAddress(GameWorld world) {
            return world switch {
                GameWorld.TestWorld1 => R.Project.TestWorldScene_1,
                GameWorld.TestWorld2 => R.Project.TestWorldScene_2,
                _ => throw Exceptions.Internal.NotSupported( $"World {world} not supported" ),
            };
        }

    }
}
