#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.App;
    using UnityEngine.Framework.Game;

    public class Application2 : ApplicationBase {

        public GameState GameState { get; private set; }
        public bool IsGameLoading => GameState == GameState.Loading;
        public bool IsGameRunning => GameState == GameState.Running;
        public bool IsGameRunningAndEnabled => GameState == GameState.RunningAndEnabled;
        public bool IsGameRunningAndDisabled => GameState == GameState.RunningAndDisabled;

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // SetGameLoading
        public void SetGameLoading() {
            Assert.Operation.Message( $"GameState {GameState} must be valid" ).Valid( GameState is GameState.None );
            GameState = GameState.Loading;
        }

        // StartGame
        public void StartGame(GameDesc gameDesc, PlayerDesc playerDesc) {
            Assert.Operation.Message( $"GameState {GameState} must be valid" ).Valid( GameState is GameState.Loading );
            GameState = GameState.Running;
            //var game = GameObject2.RequireAnyObjectByType<GameBase>( FindObjectsInactive.Exclude );
        }
        public void EnableGame() {
            Assert.Operation.Message( $"GameState {GameState} must be valid" ).Valid( GameState is GameState.Running or GameState.RunningAndDisabled );
            GameState = GameState.RunningAndEnabled;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        public void DisableGame() {
            Assert.Operation.Message( $"GameState {GameState} must be valid" ).Valid( GameState is GameState.Running or GameState.RunningAndEnabled );
            GameState = GameState.RunningAndDisabled;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void StopGame() {
            Assert.Operation.Message( $"GameState {GameState} must be valid" ).Valid( GameState is GameState.Running or GameState.RunningAndEnabled or GameState.RunningAndDisabled );
            GameState = GameState.None;
        }

    }
    // GameState
    public enum GameState {
        None,
        Loading,
        Running,
        RunningAndEnabled, // unpaused
        RunningAndDisabled, // paused
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
