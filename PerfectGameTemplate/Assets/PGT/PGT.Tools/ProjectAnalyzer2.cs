#if UNITY_EDITOR
#nullable enable
namespace PGT.Tools {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.Compilation;
    using UnityEditor.Tools_;

    public class ProjectAnalyzer2 : ProjectAnalyzer {

        // Analyze
        public override void Analyze() {
            base.Analyze();
        }
        public override void Analyze(Assembly assembly) {
            base.Analyze( assembly );
        }
        public override void Analyze(Type type) {
            Analyze_Program( type, "PGT" );
            Analyze_UI( type, "PGT" );
            Analyze_App( type, "PGT" );
            Analyze_Game( type, "PGT" );
        }

    }
}
#endif
