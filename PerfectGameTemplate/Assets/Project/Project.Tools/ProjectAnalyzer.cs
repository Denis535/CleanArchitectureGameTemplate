#if UNITY_EDITOR
#nullable enable
namespace Project.Tools {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.Compilation;
    using UnityEditor.Tools_;

    public class ProjectAnalyzer3 : ProjectAnalyzer2 {

        public override void Analyze(Assembly assembly) {
            base.Analyze( assembly );
        }
        public override void Analyze(Type type) {
            base.Analyze( type );
        }

    }
}
#endif
