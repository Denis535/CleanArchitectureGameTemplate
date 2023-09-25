#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class ScriptExecutionOrders {

        public const int Program = 10_000 + 800;
        public const int UIAudioTheme = 10_000 + 700;
        public const int UIScreen = 10_000 + 600;
        public const int UIRouter = 10_000 + 500;
        public const int App = 10_000 + 400;
        public const int Game = 10_000 + 300;
        public const int Player = 10_000 + 200;
        public const int World = 10_000 + 100;
        public const int Entity = 10_000 + 000;

    }
}
