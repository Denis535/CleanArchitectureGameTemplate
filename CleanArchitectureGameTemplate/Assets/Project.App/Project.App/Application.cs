#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework.App;

    public class Application2 : ApplicationBase {

        // State
        public AppState State { get; private set; } = AppState.None;
        // State/MainScene
        public bool IsMainSceneLoading => State == AppState.MainSceneLoading;
        public bool IsMainSceneLoaded => State == AppState.MainSceneLoaded;
        public bool IsMainSceneUnloading => State == AppState.MainSceneUnloading;
        public bool IsMainSceneUnloaded => State == AppState.MainSceneUnloaded;
        // State/GameScene
        public bool IsGameSceneLoading => State == AppState.GameSceneLoading;
        public bool IsGameSceneLoaded => State == AppState.GameSceneLoaded;
        public bool IsGameSceneUnloading => State == AppState.GameSceneUnloading;
        public bool IsGameSceneUnloaded => State == AppState.GameSceneUnloaded;
        // State/Quit
        public bool IsQuitting => State == AppState.Quitting;
        public bool IsQuited => State == AppState.Quited;
        // Game
        public Game? Game { get; private set; }

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // SetState
        public void SetState(AppState state) {
            switch (state) {
                // MainScene
                case AppState.MainSceneLoading:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.None or AppState.GameSceneUnloaded );
                    State = state;
                    break;
                case AppState.MainSceneLoaded:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneLoading );
                    State = state;
                    break;
                case AppState.MainSceneUnloading:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneLoaded );
                    State = state;
                    break;
                case AppState.MainSceneUnloaded:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneUnloading );
                    State = state;
                    break;
                // GameScene
                case AppState.GameSceneLoading:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneUnloaded );
                    State = state;
                    break;
                case AppState.GameSceneLoaded:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.GameSceneLoading );
                    State = state;
                    Game = GameObject2.RequireAnyObjectByType<Game>( FindObjectsInactive.Exclude );
                    break;
                case AppState.GameSceneUnloading:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.GameSceneLoaded );
                    State = state;
                    Game = null;
                    break;
                case AppState.GameSceneUnloaded:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.GameSceneUnloading );
                    State = state;
                    break;
                // Quit
                case AppState.Quitting:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneLoaded or AppState.GameSceneLoaded );
                    State = state;
                    Game = null;
                    break;
                case AppState.Quited:
                    Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.Quitting );
                    State = state;
                    break;
                // Misc
                default:
                    throw Exceptions.Internal.NotSupported( $"State {state} is not supported" );
            }
        }

    }
    // AppState
    public enum AppState {
        None,
        // MainScene
        MainSceneLoading,
        MainSceneLoaded,
        MainSceneUnloading,
        MainSceneUnloaded,
        // GameScene
        GameSceneLoading,
        GameSceneLoaded,
        GameSceneUnloading,
        GameSceneUnloaded,
        // Quit
        Quitting,
        Quited,
    }
}
