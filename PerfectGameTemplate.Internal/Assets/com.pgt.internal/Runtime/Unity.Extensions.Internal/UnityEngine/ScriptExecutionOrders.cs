#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class ScriptExecutionOrders {

        public const int Program = 10_500;
        public const int UI = 10_400;
        public const int App = 10_300;
        public const int Game = 10_200;
        public const int World = 10_100;
        public const int Entity = 10_000;

    }
}
