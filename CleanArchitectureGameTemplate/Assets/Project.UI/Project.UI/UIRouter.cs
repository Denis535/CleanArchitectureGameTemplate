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

        private static AsyncOperationHandle<SceneInstance>? programOperationHandle;
        private AsyncOperationHandle<SceneInstance>? mainSceneOperationHandle;
        private AsyncOperationHandle<SceneInstance>? gameSceneOperationHandle;
        private AsyncOperationHandle<SceneInstance>? worldSceneOperationHandle;

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
        public static async Task LoadProgramAsync() {
            Release.LogFormat( "Load: Program" );
            {
                await LoadProgramInternalAsync();
            }
        }
        public async Task LoadMainSceneAsync() {
            Release.LogFormat( "Load: MainScene" );
            using (@lock.Enter()) {
                // UnloadGameScene
                if (Application.IsGameSceneLoaded) {
                    Application.Game!.StopGame();
                    Application.SetState( AppState.GameSceneUnloading );
                    await UnloadGameSceneInternalAsync();
                    await UnloadWorldSceneInternalAsync();
                    Application.SetState( AppState.GameSceneUnloaded );
                }
                // LoadMainScene
                {
                    Application.SetState( AppState.MainSceneLoading );
                    await LoadMainSceneInternalAsync();
                    Application.SetState( AppState.MainSceneLoaded );
                }
            }
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, PlayerDesc playerDesc) {
            Release.LogFormat( "Load: GameScene: {0}, {1}", gameDesc, playerDesc );
            using (@lock.Enter()) {
                // UnloadMainScene
                if (Application.IsMainSceneLoaded) {
                    Application.SetState( AppState.MainSceneUnloading );
                    await UnloadMainSceneInternalAsync();
                    Application.SetState( AppState.MainSceneUnloaded );
                }
                // LoadGameScene
                {
                    Application.SetState( AppState.GameSceneLoading );
                    await Task.Delay( 3_000 );
                    await LoadWorldSceneInternalAsync( GetWorldAddress( gameDesc.World ) );
                    await LoadGameSceneInternalAsync();
                    Application.SetState( AppState.GameSceneLoaded );
                    Application.Game!.StartGame( gameDesc, playerDesc );
                }
            }
        }

#if UNITY_EDITOR
        // Quit
        public void Quit() {
            Release.Log( "Quit" );
            OnQuitAsync();
        }
#else
        // Quit
        public void Quit() {
            Release.Log( "Quit" );
            UnityEngine.Application.Quit();
        }
        private bool OnQuit() {
            if (!Application.IsQuited) {
                OnQuitAsync();
                return false;
            }
            return true;
        }
#endif
        private async void OnQuitAsync() {
            using (@lock.Enter()) {
                // UnloadMainScene
                if (Application.IsMainSceneLoaded) {
                    Application.SetState( AppState.MainSceneUnloading );
                    await UnloadMainSceneInternalAsync();
                    Application.SetState( AppState.MainSceneUnloaded );
                }
                // UnloadGameScene
                if (Application.IsGameSceneLoaded) {
                    Application.Game!.StopGame();
                    Application.SetState( AppState.GameSceneUnloading );
                    await UnloadGameSceneInternalAsync();
                    await UnloadWorldSceneInternalAsync();
                    Application.SetState( AppState.GameSceneUnloaded );
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
        private static async Task LoadProgramInternalAsync() {
            Assert.Operation.Message( $"ProgramOperationHandle {programOperationHandle} must be null" ).Valid( programOperationHandle == null );
            programOperationHandle = Addressables2.LoadSceneAsync( R.Project.Program, LoadSceneMode.Single, true );
            var program = await programOperationHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( program.Scene );
        }
        private async Task LoadMainSceneInternalAsync() {
            Assert.Operation.Message( $"MainSceneOperationHandle {mainSceneOperationHandle} must be null" ).Valid( mainSceneOperationHandle == null );
            mainSceneOperationHandle = Addressables2.LoadSceneAsync( R.Project.MainScene, LoadSceneMode.Additive, true );
            var mainScene = await mainSceneOperationHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( mainScene.Scene );
        }
        private async Task LoadGameSceneInternalAsync() {
            Assert.Operation.Message( $"GameSceneOperationHandle {gameSceneOperationHandle} must be null" ).Valid( gameSceneOperationHandle == null );
            gameSceneOperationHandle = Addressables2.LoadSceneAsync( R.Project.GameScene, LoadSceneMode.Additive, true );
            var gameScene = await gameSceneOperationHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( gameScene.Scene );
        }
        private async Task LoadWorldSceneInternalAsync(string key) {
            Assert.Operation.Message( $"WorldSceneOperationHandle {worldSceneOperationHandle} must be null" ).Valid( worldSceneOperationHandle == null );
            worldSceneOperationHandle = Addressables2.LoadSceneAsync( key, LoadSceneMode.Additive, true );
            _ = await worldSceneOperationHandle.Value.GetResultAsync( default );
        }
        // Helpers/UnloadScene
        private async Task UnloadMainSceneInternalAsync() {
            Assert.Operation.Message( $"MainSceneOperationHandle {mainSceneOperationHandle} must be non-null" ).Valid( mainSceneOperationHandle != null );
            Assert.Operation.Message( $"MainSceneOperationHandle {mainSceneOperationHandle} must be valid" ).Valid( mainSceneOperationHandle.Value.IsValid() );
            await Addressables2.UnloadSceneAsync( mainSceneOperationHandle.Value ).WaitAsync( default );
            mainSceneOperationHandle = null;
        }
        private async Task UnloadGameSceneInternalAsync() {
            Assert.Operation.Message( $"GameSceneOperationHandle {gameSceneOperationHandle} must be non-null" ).Valid( gameSceneOperationHandle != null );
            Assert.Operation.Message( $"GameSceneOperationHandle {gameSceneOperationHandle} must be valid" ).Valid( gameSceneOperationHandle.Value.IsValid() );
            await Addressables2.UnloadSceneAsync( gameSceneOperationHandle.Value ).WaitAsync( default );
            gameSceneOperationHandle = null;
        }
        private async Task UnloadWorldSceneInternalAsync() {
            Assert.Operation.Message( $"WorldSceneOperationHandle {worldSceneOperationHandle} must be non-null" ).Valid( worldSceneOperationHandle != null );
            Assert.Operation.Message( $"WorldSceneOperationHandle {worldSceneOperationHandle} must be valid" ).Valid( worldSceneOperationHandle.Value.IsValid() );
            await Addressables2.UnloadSceneAsync( worldSceneOperationHandle.Value ).WaitAsync( default );
            worldSceneOperationHandle = null;
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
