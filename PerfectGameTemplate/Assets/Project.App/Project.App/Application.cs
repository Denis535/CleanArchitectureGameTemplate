#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.App;
    using UnityEngine.Framework.Game;

    public class Application2 : ApplicationBase {

        // AppState
        public AppState AppState { get; private set; }
        public bool IsMainSceneLoading => AppState == AppState.MainSceneLoading;
        public bool IsMainSceneLoaded => AppState == AppState.MainSceneLoaded;
        public bool IsMainSceneUnloading => AppState == AppState.MainSceneUnloading;
        public bool IsGameSceneLoading => AppState == AppState.GameSceneLoading;
        public bool IsGameSceneLoaded => AppState == AppState.GameSceneLoaded;
        public bool IsGameSceneUnloading => AppState == AppState.GameSceneUnloading;
        public bool IsQuitting => AppState == AppState.Quitting;
        public bool IsQuited => AppState == AppState.Quited;
        // GameState
        public GameState GameState { get; private set; }
        public bool IsGameRunning => GameState == GameState.Running;
        public bool IsGameRunningAndPaused => GameState == GameState.RunningAndPaused;
        // OnEvent
        public event Action<AppState>? OnAppStateChangeEvent;
        public event Action<GameState>? OnGameStateChangeEvent;

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // AppState
        public void SetMainSceneLoading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.None or AppState.GameSceneUnloading );
            AppState = AppState.MainSceneLoading;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        public void SetMainSceneLoaded() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.MainSceneLoading );
            AppState = AppState.MainSceneLoaded;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        public void SetMainSceneUnloading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.MainSceneLoaded );
            AppState = AppState.MainSceneUnloading;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        // AppState
        public void SetGameSceneLoading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.None or AppState.MainSceneUnloading );
            AppState = AppState.GameSceneLoading;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        public void SetGameSceneLoaded() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.GameSceneLoading );
            AppState = AppState.GameSceneLoaded;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        public void SetGameSceneUnloading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.GameSceneLoaded );
            AppState = AppState.GameSceneUnloading;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        // AppState
        public void SetQuitting() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.MainSceneLoaded );
            AppState = AppState.Quitting;
            OnAppStateChangeEvent?.Invoke( AppState );
        }
        public void SetQuited() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.Quitting );
            AppState = AppState.Quited;
            OnAppStateChangeEvent?.Invoke( AppState );
        }

        // GameState
        public void StartGame(GameDesc gameDesc, PlayerDesc playerDesc) {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState is GameState.None );
            Cursor.lockState = CursorLockMode.Locked;
            //var game = GameObject2.RequireAnyObjectByType<GameBase>( FindObjectsInactive.Exclude );
            GameState = GameState.Running;
            OnGameStateChangeEvent?.Invoke( GameState );
        }
        public void PauseGame() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState is GameState.Running );
            Cursor.lockState = CursorLockMode.None;
            GameState = GameState.RunningAndPaused;
            OnGameStateChangeEvent?.Invoke( GameState );
        }
        public void UnPauseGame() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState is GameState.RunningAndPaused );
            Cursor.lockState = CursorLockMode.Locked;
            GameState = GameState.Running;
            OnGameStateChangeEvent?.Invoke( GameState );
        }
        public void StopGame() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState is AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState is GameState.Running or GameState.RunningAndPaused );
            Cursor.lockState = CursorLockMode.None;
            GameState = GameState.None;
            OnGameStateChangeEvent?.Invoke( GameState );
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
    // GameState
    public enum GameState {
        None,
        Running,
        RunningAndPaused,
    }
    // GameDesc
    public class GameDesc {

        public string Name { get; set; }
        public GameMode Mode { get; set; }
        public GameWorld World { get; set; }
        public bool IsPrivate { get; set; }

        public GameDesc(string name, GameMode mode, GameWorld world, bool isPrivate) {
            Name = name;
            Mode = mode;
            World = world;
            IsPrivate = isPrivate;
        }

        public override string ToString() {
            return "GameDesc: Name={0}, Mode={1}, World={2}, IsPrivate={3}".Format( Name, Mode, World, IsPrivate );
        }

    }
    public enum GameMode {
        _1x1,
        _1x2,
        _1x3,
        _1x4,
        _1x5,
        _1x6,
        _1x7,
        _1x8,
    }
    public enum GameWorld {
        TestWorld1,
        TestWorld2,
    }
    // PlayerDesc
    public class PlayerDesc {

        public string Name { get; set; }
        public PlayerRole Role { get; set; }

        public PlayerDesc(string name, PlayerRole role) {
            Name = name;
            Role = role;
        }

        public override string ToString() {
            return "PlayerDesc: Name={0}, Role={1}".Format( Name, Role );
        }

    }
    public enum PlayerRole {
        Master,
        Gamer,
    }
}
