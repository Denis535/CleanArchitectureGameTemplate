#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
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

        private readonly Lock @lock = new Lock();

        private static AsyncOperationHandle<SceneInstance>? programHandle;
        private AsyncOperationHandle<SceneInstance>? mainSceneHandle;
        private AsyncOperationHandle<SceneInstance>? gameSceneHandle;
        private AsyncOperationHandle<SceneInstance>? worldSceneHandle;
        private UIState state;

        // Globals
        private Application2 Application { get; set; } = default!;

        // State
        public UIState State {
            get {
                return state;
            }
            private set {
                switch (state) {
                    // MainScene
                    case UIState.MainSceneLoading:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIState.None or UIState.GameSceneLoaded );
                        state = value;
                        break;
                    case UIState.MainSceneLoaded:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIState.MainSceneLoading );
                        state = value;
                        break;
                    // GameScene
                    case UIState.GameSceneLoading:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIState.None or UIState.MainSceneLoaded );
                        state = value;
                        break;
                    case UIState.GameSceneLoaded:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIState.GameSceneLoading );
                        state = value;
                        break;
                    // Quit
                    case UIState.Quitting:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIState.MainSceneLoaded or UIState.GameSceneLoaded );
                        state = value;
                        break;
                    case UIState.Quited:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIState.Quitting );
                        state = value;
                        break;
                    // Misc
                    default:
                        throw Exceptions.Internal.NotSupported( $"State {state} is not supported" );
                }
            }
        }
        // State/MainScene
        public bool IsMainSceneLoading => state == UIState.MainSceneLoading;
        public bool IsMainSceneLoaded => state == UIState.MainSceneLoaded;
        // State/GameScene
        public bool IsGameSceneLoading => state == UIState.GameSceneLoading;
        public bool IsGameSceneLoaded => state == UIState.GameSceneLoaded;
        // State/Quit
        public bool IsQuitting => state == UIState.Quitting;
        public bool IsQuited => state == UIState.Quited;

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
            if (Application.IsGameRunning) {
                Application.StopGame();
            }
            State = UIState.MainSceneLoading;
            using (@lock.Enter()) {
                if (gameSceneHandle != null) {
                    // UnloadGameScene
                    await UnloadGameSceneInternalAsync();
                    await UnloadWorldSceneInternalAsync();
                }
                {
                    // LoadMainScene
                    await LoadMainSceneInternalAsync();
                }
            }
            State = UIState.MainSceneLoaded;
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, PlayerDesc playerDesc) {
            Release.LogFormat( "Load: GameScene: {0}, {1}", gameDesc, playerDesc );
            State = UIState.GameSceneLoading;
            using (@lock.Enter()) {
                if (mainSceneHandle != null) {
                    // UnloadMainScene
                    await UnloadMainSceneInternalAsync();
                }
                {
                    // LoadGameScene
                    await Task.Delay( 3_000 );
                    await LoadWorldSceneInternalAsync( GetWorldAddress( gameDesc.World ) );
                    await LoadGameSceneInternalAsync();
                }
            }
            State = UIState.GameSceneLoaded;
            Application.StartGame( gameDesc, playerDesc );
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
            if (Application.IsGameRunning) {
                Application.StopGame();
            }
            State = UIState.Quitting;
            using (@lock.Enter()) {
                if (mainSceneHandle != null) {
                    // UnloadMainScene
                    await UnloadMainSceneInternalAsync();
                }
                if (gameSceneHandle != null) {
                    // UnloadGameScene
                    await UnloadGameSceneInternalAsync();
                    await UnloadWorldSceneInternalAsync();
                }
            }
            State = UIState.Quited;
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }

        // Helpers/LoadScene
        private static async Task LoadProgramInternalAsync() {
            Assert.Operation.Message( $"ProgramOperationHandle {programHandle} must be null" ).Valid( programHandle == null );
            programHandle = Addressables2.LoadSceneAsync( R.Project.Program, LoadSceneMode.Single, true );
            var program = await programHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( program.Scene );
        }
        private async Task LoadMainSceneInternalAsync() {
            Assert.Operation.Message( $"MainSceneOperationHandle {mainSceneHandle} must be null" ).Valid( mainSceneHandle == null );
            mainSceneHandle = Addressables2.LoadSceneAsync( R.Project.MainScene, LoadSceneMode.Additive, true );
            var mainScene = await mainSceneHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( mainScene.Scene );
        }
        private async Task LoadGameSceneInternalAsync() {
            Assert.Operation.Message( $"GameSceneOperationHandle {gameSceneHandle} must be null" ).Valid( gameSceneHandle == null );
            gameSceneHandle = Addressables2.LoadSceneAsync( R.Project.GameScene, LoadSceneMode.Additive, true );
            var gameScene = await gameSceneHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( gameScene.Scene );
        }
        private async Task LoadWorldSceneInternalAsync(string key) {
            Assert.Operation.Message( $"WorldSceneOperationHandle {worldSceneHandle} must be null" ).Valid( worldSceneHandle == null );
            worldSceneHandle = Addressables2.LoadSceneAsync( key, LoadSceneMode.Additive, true );
            _ = await worldSceneHandle.Value.GetResultAsync( default );
        }
        // Helpers/UnloadScene
        private async Task UnloadMainSceneInternalAsync() {
            Assert.Operation.Message( $"MainSceneOperationHandle {mainSceneHandle} must be non-null" ).Valid( mainSceneHandle != null );
            Assert.Operation.Message( $"MainSceneOperationHandle {mainSceneHandle} must be valid" ).Valid( mainSceneHandle.Value.IsValid() );
            await Addressables2.UnloadSceneAsync( mainSceneHandle.Value ).WaitAsync( default );
            mainSceneHandle = null;
        }
        private async Task UnloadGameSceneInternalAsync() {
            Assert.Operation.Message( $"GameSceneOperationHandle {gameSceneHandle} must be non-null" ).Valid( gameSceneHandle != null );
            Assert.Operation.Message( $"GameSceneOperationHandle {gameSceneHandle} must be valid" ).Valid( gameSceneHandle.Value.IsValid() );
            await Addressables2.UnloadSceneAsync( gameSceneHandle.Value ).WaitAsync( default );
            gameSceneHandle = null;
        }
        private async Task UnloadWorldSceneInternalAsync() {
            Assert.Operation.Message( $"WorldSceneOperationHandle {worldSceneHandle} must be non-null" ).Valid( worldSceneHandle != null );
            Assert.Operation.Message( $"WorldSceneOperationHandle {worldSceneHandle} must be valid" ).Valid( worldSceneHandle.Value.IsValid() );
            await Addressables2.UnloadSceneAsync( worldSceneHandle.Value ).WaitAsync( default );
            worldSceneHandle = null;
        }
        // Helpers/Misc
        private static string GetWorldAddress(GameWorld world) {
            return world switch {
                GameWorld.TestWorld1 => R.Project.TestWorldScene_1,
                GameWorld.TestWorld2 => R.Project.TestWorldScene_2,
                _ => throw Exceptions.Internal.NotSupported( $"World {world} is not supported" ),
            };
        }

    }
    // UIState
    public enum UIState {
        None,
        // MainScene
        MainSceneLoading,
        MainSceneLoaded,
        // GameScene
        GameSceneLoading,
        GameSceneLoaded,
        // Quit
        Quitting,
        Quited,
    }
}
