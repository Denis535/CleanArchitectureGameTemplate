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
        private TrackableSource<AppState> AppStateSource { get; } = new TrackableSource<AppState>();
        public Trackable<AppState> AppState => AppStateSource.Trackable;
        public bool IsMainSceneLoading => AppState.Value == App.AppState.MainSceneLoading;
        public bool IsMainSceneLoaded => AppState.Value == App.AppState.MainSceneLoaded;
        public bool IsMainSceneUnloading => AppState.Value == App.AppState.MainSceneUnloading;
        public bool IsGameSceneLoading => AppState.Value == App.AppState.GameSceneLoading;
        public bool IsGameSceneLoaded => AppState.Value == App.AppState.GameSceneLoaded;
        public bool IsGameSceneUnloading => AppState.Value == App.AppState.GameSceneUnloading;
        public bool IsQuitting => AppState.Value == App.AppState.Quitting;
        public bool IsQuited => AppState.Value == App.AppState.Quited;
        // GameState
        private TrackableSource<GameState> GameStateSource { get; } = new TrackableSource<GameState>();
        public Trackable<GameState> GameState => GameStateSource.Trackable;
        public bool IsGameRunning => GameState.Value == App.GameState.Running;
        public bool IsGameRunningAndPaused => GameState.Value == App.GameState.RunningAndPaused;

        // Awake
        public new void Awake() {
            base.Awake();
            AppStateSource.SetValue( App.AppState.None );
            GameStateSource.SetValue( App.GameState.None );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // AppState
        public void SetMainSceneLoading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.None or App.AppState.GameSceneUnloading );
            AppStateSource.SetValue( App.AppState.MainSceneLoading );
        }
        public void SetMainSceneLoaded() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.MainSceneLoading );
            AppStateSource.SetValue( App.AppState.MainSceneLoaded );
        }
        public void SetMainSceneUnloading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.MainSceneLoaded );
            AppStateSource.SetValue( App.AppState.MainSceneUnloading );
        }
        // AppState
        public void SetGameSceneLoading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.None or App.AppState.MainSceneUnloading );
            AppStateSource.SetValue( App.AppState.GameSceneLoading );
        }
        public void SetGameSceneLoaded() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.GameSceneLoading );
            AppStateSource.SetValue( App.AppState.GameSceneLoaded );
        }
        public void SetGameSceneUnloading() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.GameSceneLoaded );
            AppStateSource.SetValue( App.AppState.GameSceneUnloading );
        }
        // AppState
        public void SetQuitting() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.MainSceneLoaded );
            AppStateSource.SetValue( App.AppState.Quitting );
        }
        public void SetQuited() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.Quitting );
            AppStateSource.SetValue( App.AppState.Quited );
        }

        // GameState
        public void StartGame(GameDesc gameDesc, PlayerDesc playerDesc) {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState.Value is App.GameState.None );
            GameStateSource.SetValue( App.GameState.Running );
            {
                Cursor.lockState = CursorLockMode.Locked;
                //var game = GameObject2.RequireAnyObjectByType<GameBase>( FindObjectsInactive.Exclude );
            }
        }
        public void PauseGame() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState.Value is App.GameState.Running );
            GameStateSource.SetValue( App.GameState.RunningAndPaused );
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        public void UnPauseGame() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState.Value is App.GameState.RunningAndPaused );
            GameStateSource.SetValue( App.GameState.Running );
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        public void StopGame() {
            Assert.Operation.Message( $"AppState {AppState} is invalid" ).Valid( AppState.Value is App.AppState.GameSceneLoaded );
            Assert.Operation.Message( $"GameState {GameState} is invalid" ).Valid( GameState.Value is App.GameState.Running or App.GameState.RunningAndPaused );
            GameStateSource.SetValue( App.GameState.None );
            {
                Cursor.lockState = CursorLockMode.None;
            }
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
