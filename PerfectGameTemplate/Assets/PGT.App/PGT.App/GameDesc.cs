﻿#nullable enable
namespace PGT.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

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
    public enum PlayerRole {
        Master,
        Gamer,
    }
}
