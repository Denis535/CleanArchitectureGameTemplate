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
        public bool IsMainSceneLoading => State == AppState.MainSceneLoading;
        public bool IsMainSceneLoaded => State == AppState.MainSceneLoaded;
        public bool IsMainSceneUnloading => State == AppState.MainSceneUnloading;
        public bool IsGameSceneLoading => State == AppState.GameSceneLoading;
        public bool IsGameSceneLoaded => State == AppState.GameSceneLoaded;
        public bool IsGameSceneUnloading => State == AppState.GameSceneUnloading;
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
        public void SetMainSceneLoading() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.None or AppState.GameSceneUnloading );
            State = AppState.MainSceneLoading;
        }
        public void SetMainSceneLoaded() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneLoading );
            State = AppState.MainSceneLoaded;
        }
        public void SetMainSceneUnloading() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneLoaded );
            State = AppState.MainSceneUnloading;
        }
        public void SetGameSceneLoading() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.None or AppState.MainSceneUnloading );
            State = AppState.GameSceneLoading;
        }
        public void SetGameSceneLoaded() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.GameSceneLoading );
            State = AppState.GameSceneLoaded;
            Game = GameObject2.RequireAnyObjectByType<Game>( FindObjectsInactive.Exclude );
        }
        public void SetGameSceneUnloading() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.GameSceneLoaded );
            State = AppState.GameSceneUnloading;
            Game = null;
        }
        public void SetQuitting() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.MainSceneLoaded );
            State = AppState.Quitting;
        }
        public void SetQuited() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is AppState.Quitting );
            State = AppState.Quited;
        }

    }
    // AppState
    public enum AppState {
        None,
        MainSceneLoading,
        MainSceneLoaded,
        MainSceneUnloading,
        GameSceneLoading,
        GameSceneLoaded,
        GameSceneUnloading,
        Quitting,
        Quited,
    }
}
