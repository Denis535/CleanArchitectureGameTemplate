#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;

    internal static class UIRouterHelper {

        private static AsyncOperationHandle<SceneInstance>? programHandle;
        private static AsyncOperationHandle<SceneInstance>? mainSceneHandle;
        private static AsyncOperationHandle<SceneInstance>? gameSceneHandle;
        private static AsyncOperationHandle<SceneInstance>? worldSceneHandle;

        public static bool IsProgramLoaded => programHandle != null;
        public static bool IsMainSceneLoaded => mainSceneHandle != null;
        public static bool IsGameSceneLoaded => gameSceneHandle != null;
        public static bool IsWorldSceneLoaded => worldSceneHandle != null;

        // LoadScene
        public static async Task LoadProgramAsync() {
            Assert.Operation.Message( $"ProgramHandle {programHandle} must be null" ).Valid( programHandle == null );
            programHandle = Addressables.LoadSceneAsync( R.Project.Scenes.Program_Value, LoadSceneMode.Single, true );
            var program = await programHandle.Value.GetResultAsync( default );
            SceneManager.SetActiveScene( program.Scene );
        }
        public static async Task LoadMainSceneAsync() {
            Assert.Operation.Message( $"MainSceneHandle {mainSceneHandle} must be null" ).Valid( mainSceneHandle == null );
            mainSceneHandle = Addressables.LoadSceneAsync( R.Project.Scenes.MainScene_Value, LoadSceneMode.Additive, false );
            var mainScene = await mainSceneHandle.Value.GetResultAsync( default );
            await mainScene.ActivateAsync();
            SceneManager.SetActiveScene( mainScene.Scene );
        }
        public static async Task LoadGameSceneAsync() {
            Assert.Operation.Message( $"GameSceneHandle {gameSceneHandle} must be null" ).Valid( gameSceneHandle == null );
            gameSceneHandle = Addressables.LoadSceneAsync( R.Project.Scenes.GameScene_Value, LoadSceneMode.Additive, false );
            var gameScene = await gameSceneHandle.Value.GetResultAsync( default );
            await gameScene.ActivateAsync();
            SceneManager.SetActiveScene( gameScene.Scene );
        }
        public static async Task LoadWorldSceneAsync(string key) {
            Assert.Operation.Message( $"WorldSceneHandle {worldSceneHandle} must be null" ).Valid( worldSceneHandle == null );
            worldSceneHandle = Addressables.LoadSceneAsync( key, LoadSceneMode.Additive, false );
            var worldScene = await worldSceneHandle.Value.GetResultAsync( default );
            await worldScene.ActivateAsync();
            SceneManager.SetActiveScene( worldScene.Scene );
        }

        // UnloadScene
        public static async Task UnloadMainSceneAsync() {
            Assert.Operation.Message( $"MainSceneHandle {mainSceneHandle} must be non-null" ).Valid( mainSceneHandle != null );
            Assert.Operation.Message( $"MainSceneHandle {mainSceneHandle} must be valid" ).Valid( mainSceneHandle.Value.IsValid() );
            await Addressables.UnloadSceneAsync( mainSceneHandle.Value ).WaitAsync( default );
            mainSceneHandle = null;
        }
        public static async Task UnloadGameSceneAsync() {
            Assert.Operation.Message( $"GameSceneHandle {gameSceneHandle} must be non-null" ).Valid( gameSceneHandle != null );
            Assert.Operation.Message( $"GameSceneHandle {gameSceneHandle} must be valid" ).Valid( gameSceneHandle.Value.IsValid() );
            await Addressables.UnloadSceneAsync( gameSceneHandle.Value ).WaitAsync( default );
            gameSceneHandle = null;
        }
        public static async Task UnloadWorldSceneAsync() {
            Assert.Operation.Message( $"WorldSceneHandle {worldSceneHandle} must be non-null" ).Valid( worldSceneHandle != null );
            Assert.Operation.Message( $"WorldSceneHandle {worldSceneHandle} must be valid" ).Valid( worldSceneHandle.Value.IsValid() );
            await Addressables.UnloadSceneAsync( worldSceneHandle.Value ).WaitAsync( default );
            worldSceneHandle = null;
        }

    }
}
