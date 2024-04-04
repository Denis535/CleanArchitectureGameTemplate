#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Project.Entities;
    using UnityEngine;
    using UnityEngine.Framework.App;

    public class Application2 : ApplicationBase {

        // Game
        private Game? Game { get; set; }
        [MemberNotNullWhen( true, "Game" )]
        public bool IsGameRunning => Game != null;
        // Game/State
        public bool IsGamePlaying {
            get {
                Assert.Operation.Message( $"Game must be non-null" ).Valid( Game != null );
                return Game.IsPlaying;
            }
        }
        public bool IsGamePaused {
            get {
                Assert.Operation.Message( $"Game must be non-null" ).Valid( Game != null );
                return Game.IsPaused;
            }
        }
        public bool IsGameUnPaused {
            get {
                Assert.Operation.Message( $"Game must be non-null" ).Valid( Game != null );
                return Game.IsUnPaused;
            }
        }

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // StartGame
        public void StartGame(GameDesc gameDesc, WorldDesc worldDesc, PlayerDesc playerDesc) {
            Assert.Operation.Message( $"Game must be null" ).Valid( Game == null );
            Game = Object2.RequireAnyObjectByType<Game>( FindObjectsInactive.Exclude );
            Game.StartGame();
            Cursor.lockState = CursorLockMode.Locked;
        }
        public void StopGame() {
            Assert.Operation.Message( $"Game must be non-null" ).Valid( Game != null );
            Game.StopGame();
            Game = null;
            Cursor.lockState = CursorLockMode.None;
        }

        // Pause
        public void Pause() {
            Assert.Operation.Message( $"Game must be non-null" ).Valid( Game != null );
            Game.Pause();
            Cursor.lockState = CursorLockMode.None;
        }
        public void UnPause() {
            Assert.Operation.Message( $"Game must be non-null" ).Valid( Game != null );
            Game.UnPause();
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    // GameDesc
    public class GameDesc {

        public string Name { get; set; }
        public GameMode Mode { get; set; }

        public GameDesc(string name, GameMode mode) {
            Name = name;
            Mode = mode;
        }

        public override string ToString() {
            return "GameDesc: Name={0}, Mode={1}".Format( Name, Mode );
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
    // WorldDesc
    public class WorldDesc {

        public GameWorld World { get; set; }

        public WorldDesc(GameWorld world) {
            World = world;
        }

        public override string ToString() {
            return "WorldDesc: World={0}".Format( World );
        }

    }
    public enum GameWorld {
        World1,
        World2,
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
