#if UNITY_EDITOR
#nullable enable
namespace PGT.Tools {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.Tools_;
    using UnityEngine;

    public class ProjectWindow2 : ProjectWindow {

        // OnLoad
        [InitializeOnLoadMethod]
        internal static void OnLoad() {
            new ProjectWindow2();
        }

        // Constructor
        public ProjectWindow2() : base( "PGT", "PGT.UI", "PGT.App", "PGT.Game", "PGT.Core", "PGT.Internal", "PGT.Tests", "Unity.Extensions", "Unity.Extensions.Core", "Unity.Extensions.Internal" ) {
        }

    }
}
#endif
