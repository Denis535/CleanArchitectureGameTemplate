#nullable enable
namespace Project.Entities.GameScene {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.Game;

    public class Game : GameBase {

        // State
        public GameState State { get; private set; } = GameState.None;
        public bool IsRunning => State == GameState.Running;
        public bool IsRunningAndPaused => State == GameState.RunningAndPaused;

        // Awake
        public void Awake() {
        }
        public void OnDestroy() {
        }

        // Start
        public void Start() {
        }
        public void Update() {
        }

        // SetState
        public void StartGame(GameDesc gameDesc, PlayerDesc playerDesc) {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is GameState.None );
            State = GameState.Running;
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        public void PauseGame() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is GameState.Running );
            State = GameState.RunningAndPaused;
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        public void UnPauseGame() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is GameState.RunningAndPaused );
            State = GameState.Running;
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        public void StopGame() {
            Assert.Operation.Message( $"State {State} is invalid" ).Valid( State is GameState.Running or GameState.RunningAndPaused );
            State = GameState.None;
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
    // GameState
    public enum GameState {
        None,
        Running,
        RunningAndPaused,
        //Win
        //Lose,
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
        // 1 man against ... monsters
        _1x1,
        _1x2,
        _1x3,
        _1x4,
        // 2 man against ... monsters
        _2x1,
        _2x2,
        _2x3,
        _2x4,
        // 3 man against ... monsters
        _3x1,
        _3x2,
        _3x3,
        _3x4,
        // 4 man against ... monsters
        _4x1,
        _4x2,
        _4x3,
        _4x4,
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
        Human,
        Monster,
    }
}
