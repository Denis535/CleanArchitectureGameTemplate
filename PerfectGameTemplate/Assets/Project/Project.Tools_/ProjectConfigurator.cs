#if UNITY_EDITOR
#nullable enable
namespace Project.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.Compilation;
    using UnityEditor.Tools_;
    using UnityEngine;

    public class ProjectConfigurator3 : ProjectConfigurator2 {

        public override void Configure(Assembly assembly) {
            base.Configure( assembly );
        }
        public override void Configure(MonoScript script) {
            base.Configure( script );
        }

    }
}
#endif
