#if UNITY_EDITOR
#nullable enable
namespace Project.Tools {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.AddressableAssets;
    using UnityEditor.Tools_;
    using UnityEngine;

    public class ProjectBuilder2 {

        // Build/Pre
        public void PreBuild() {
            new ResourcesSourceGenerator().Generate( AddressableAssetSettingsDefaultObject.Settings, "Assets/Project.Core/UnityEngine.AddressableAssets/R.cs", "UnityEngine.AddressableAssets", "R" );
            new LabelsSourceGenerator().Generate( AddressableAssetSettingsDefaultObject.Settings, "Assets/Project.Core/UnityEngine.AddressableAssets/L.cs", "UnityEngine.AddressableAssets", "L" );
            new ProjectConfigurator2().Configure();
            new ProjectAnalyzer2().Analyze();
        }

        // Build/Development
        public void BuildDevelopment(string path) {
            PreBuild();
            BuildPipeline.BuildPlayer(
                EditorBuildSettings.scenes,
                path,
                BuildTarget.StandaloneWindows64,
                BuildOptions.Development |
                BuildOptions.AllowDebugging |
                BuildOptions.ShowBuiltPlayer
                );
        }

        // Build/Production
        public void BuildProduction(string path) {
            PreBuild();
            BuildPipeline.BuildPlayer(
                EditorBuildSettings.scenes,
                path,
                BuildTarget.StandaloneWindows64,
                BuildOptions.CleanBuildCache |
                BuildOptions.ShowBuiltPlayer
                );
        }

    }
}
#endif
