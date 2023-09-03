#if UNITY_EDITOR
#nullable enable
namespace UnityEditor.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public class ProjectBuilder {

        // Build/Pre
        public virtual void PreBuild() {
        }

        // Build/Development
        public virtual void BuildDevelopment() {
            PreBuild();
            BuildPipeline.BuildPlayer(
                EditorBuildSettings.scenes,
                $"Build/Development/{PlayerSettings.productName}.exe",
                BuildTarget.StandaloneWindows64,
                BuildOptions.Development |
                BuildOptions.AllowDebugging |
                BuildOptions.ShowBuiltPlayer
                );
        }

        // Build/Production
        public virtual void BuildProduction() {
            PreBuild();
            BuildPipeline.BuildPlayer(
                EditorBuildSettings.scenes,
                $"Build/Production/{PlayerSettings.productName}.exe",
                BuildTarget.StandaloneWindows64,
                BuildOptions.CleanBuildCache |
                BuildOptions.ShowBuiltPlayer
                );
        }

    }
}
#endif
