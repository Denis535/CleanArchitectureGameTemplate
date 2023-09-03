#nullable enable
namespace PGT.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PGT.App;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;

    public class UIRouter : UIRouterBase {

        private static AsyncOperationHandle<SceneInstance> programHandle;
        private AsyncOperationHandle<SceneInstance> mainSceneHandle;
        private AsyncOperationHandle<SceneInstance> gameSceneHandle;
        private AsyncOperationHandle<SceneInstance> gameWorldHandle;

        private GameManager GameManager => Singleton.GetInstance<GameManager>();
        public static bool IsProgramLoaded => programHandle.IsValid();
        public bool IsMainSceneLoaded => mainSceneHandle.IsValid();
        public bool IsGameSceneLoaded => gameSceneHandle.IsValid();
        public bool IsGameWorldLoaded => gameWorldHandle.IsValid();

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Load
        public static async Task LoadProgramAsync() {
            Release.LogFormat( "Load: Program" );
            await Activate( programHandle = Addressables2.LoadSceneAsync( R.PGT.Program, LoadSceneMode.Single, true ) );
        }
        public async Task LoadMainSceneAsync() {
            Release.LogFormat( "Load: MainScene" );
            if (IsGameSceneLoaded) {
                GameManager.Deinitialize();
            }
            await UnloadSceneAsync( gameSceneHandle );
            await UnloadSceneAsync( gameWorldHandle );
            await Activate( mainSceneHandle = LoadSceneAsync( R.PGT.MainScene, LoadSceneMode.Additive, true ) );
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, PlayerDesc playerDesc) {
            Release.LogFormat( "Load: GameScene, {0}, {1}", gameDesc, playerDesc );
            await Task.Delay( 3_000 );
            await Activate( gameWorldHandle = LoadSceneAsync( GetAddress( gameDesc.World ), LoadSceneMode.Additive, true ) );
            await UnloadSceneAsync( mainSceneHandle );
            await Activate( gameSceneHandle = LoadSceneAsync( R.PGT.GameScene, LoadSceneMode.Additive, true ) );
            {
                GameManager.Initialize( gameDesc );
            }
        }

        // Quit
        public void Quit() {
#if UNITY_EDITOR
            OnQuit();
#else
            Release.Log( "Quit" );
            Application.wantsToQuit -= OnQuit;
            Application.wantsToQuit += OnQuit;
            Application.Quit();
#endif
        }
        private bool OnQuit() {
            Release.Log( "OnQuit" );
            if (IsMainSceneLoaded || IsGameSceneLoaded || IsGameWorldLoaded) {
                OnQuitAsync();
                return false;
            }
            return true;
        }
        private async void OnQuitAsync() {
            if (Singleton.HasInstance<GameManager>()) {
                Singleton.GetInstance<GameManager>().Deinitialize();
            }
            if (mainSceneHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( mainSceneHandle ).Task;
            }
            if (gameWorldHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( gameWorldHandle ).Task;
            }
            if (gameSceneHandle.IsValid()) {
                await Addressables2.UnloadSceneAsync( gameSceneHandle ).Task;
            }
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }

        // Helpers
        private static AsyncOperationHandle<SceneInstance> LoadSceneAsync(string key, LoadSceneMode mode, bool activateOnLoad) {
            return Addressables2.LoadSceneAsync( key, mode, activateOnLoad );
        }
        private static Task UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle) {
            if (handle.IsValid()) return Addressables2.UnloadSceneAsync( handle ).Task;
            return Task.CompletedTask;
        }
        private static async Task Activate(AsyncOperationHandle<SceneInstance> handle) {
            var instance = await handle.Task;
            if (instance.Scene.IsValid()) SceneManager.SetActiveScene( instance.Scene );
        }
        // Helpers
        private static string GetAddress(GameWorld world) {
            return world switch {
                GameWorld.TestWorld1 => R.PGT.Game.World.TestWorld_1,
                GameWorld.TestWorld2 => R.PGT.Game.World.TestWorld_2,
                _ => throw Exceptions.Internal.NotSupported( $"World {world} not supported" ),
            };
        }

    }
}
