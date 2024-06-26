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
    using UnityEngine.Framework.UI;

    public class UIRouter : UIRouterBase {

        private readonly Lock @lock = new Lock();
        private UIRouterState state;

        // Globals
        private Application2 Application { get; set; } = default!;

        // State
        public UIRouterState State {
            get {
                return state;
            }
            private set {
                switch (value) {
                    // MainScene
                    case UIRouterState.MainSceneLoading:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIRouterState.None or UIRouterState.GameSceneLoaded );
                        state = value;
                        break;
                    case UIRouterState.MainSceneLoaded:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIRouterState.MainSceneLoading );
                        state = value;
                        break;
                    // GameScene
                    case UIRouterState.GameSceneLoading:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIRouterState.None or UIRouterState.MainSceneLoaded );
                        state = value;
                        break;
                    case UIRouterState.GameSceneLoaded:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIRouterState.GameSceneLoading );
                        state = value;
                        break;
                    // Quit
                    case UIRouterState.Quitting:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIRouterState.MainSceneLoaded or UIRouterState.GameSceneLoaded );
                        state = value;
                        break;
                    case UIRouterState.Quited:
                        Assert.Operation.Message( $"State {state} is invalid" ).Valid( state is UIRouterState.Quitting );
                        state = value;
                        break;
                    // Misc
                    default:
                        throw Exceptions.Internal.NotSupported( $"Value {value} is not supported" );
                }
            }
        }
        // State/MainScene
        public bool IsMainSceneLoading => state == UIRouterState.MainSceneLoading;
        public bool IsMainSceneLoaded => state == UIRouterState.MainSceneLoaded;
        // State/GameScene
        public bool IsGameSceneLoading => state == UIRouterState.GameSceneLoading;
        public bool IsGameSceneLoaded => state == UIRouterState.GameSceneLoaded;
        // State/Quit
        public bool IsQuitting => state == UIRouterState.Quitting;
        public bool IsQuited => state == UIRouterState.Quited;

        // Awake
        public new void Awake() {
            base.Awake();
            Application = Utils.Container.RequireDependency<Application2>( null );
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
                await UIRouterHelper.LoadProgramAsync();
            }
        }
        public async Task LoadMainSceneAsync() {
            Release.LogFormat( "Load: MainScene" );
            if (Application.IsGameRunning) {
                Application.StopGame();
            }
            State = UIRouterState.MainSceneLoading;
            using (@lock.Enter()) {
                if (UIRouterHelper.IsGameSceneLoaded) {
                    // UnloadGameScene
                    await UIRouterHelper.UnloadGameSceneAsync();
                    await UIRouterHelper.UnloadWorldSceneAsync();
                }
                {
                    // LoadMainScene
                    await UIRouterHelper.LoadMainSceneAsync();
                }
            }
            State = UIRouterState.MainSceneLoaded;
        }
        public async Task LoadGameSceneAsync(GameDesc gameDesc, WorldDesc worldDesc, PlayerDesc playerDesc) {
            Release.LogFormat( "Load: GameScene: {0}, {1}, {2}", gameDesc, worldDesc, playerDesc );
            State = UIRouterState.GameSceneLoading;
            using (@lock.Enter()) {
                if (UIRouterHelper.IsMainSceneLoaded) {
                    // UnloadMainScene
                    await UIRouterHelper.UnloadMainSceneAsync();
                }
                {
                    // LoadGameScene
                    await Task.Delay( 3_000 );
                    await UIRouterHelper.LoadWorldSceneAsync( GetWorldAddress( worldDesc.World ) );
                    await UIRouterHelper.LoadGameSceneAsync();
                }
            }
            State = UIRouterState.GameSceneLoaded;
            Application.StartGame( gameDesc, worldDesc, playerDesc );
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
            if (!IsQuited) {
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
            State = UIRouterState.Quitting;
            using (@lock.Enter()) {
                if (UIRouterHelper.IsMainSceneLoaded) {
                    // UnloadMainScene
                    await UIRouterHelper.UnloadMainSceneAsync();
                }
                if (UIRouterHelper.IsGameSceneLoaded) {
                    // UnloadGameScene
                    await UIRouterHelper.UnloadGameSceneAsync();
                    await UIRouterHelper.UnloadWorldSceneAsync();
                }
            }
            State = UIRouterState.Quited;
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }

        // Helpers
        private static string GetWorldAddress(GameWorld world) {
            return world switch {
                GameWorld.World1 => R.Project.Entities.Worlds.World_01_Value,
                GameWorld.World2 => R.Project.Entities.Worlds.World_02_Value,
                _ => throw Exceptions.Internal.NotSupported( $"World {world} is not supported" ),
            };
        }

    }
    // UIRouterState
    public enum UIRouterState {
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
