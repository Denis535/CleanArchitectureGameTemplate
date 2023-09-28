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

    public class ProjectBuilder2 : ProjectBuilder {

        // Build/Pre
        public override void PreBuild() {
            new ResourcesSourceGenerator().Generate( "Assets/Project.Core/UnityEngine.AddressableAssets/R.cs", "UnityEngine.AddressableAssets", "R", AddressableAssetSettingsDefaultObject.Settings );
            new LabelsSourceGenerator().Generate( "Assets/Project.Core/UnityEngine.AddressableAssets/L.cs", "UnityEngine.AddressableAssets", "L", AddressableAssetSettingsDefaultObject.Settings );
            new ProjectConfigurator2().Configure();
            new ProjectAnalyzer2().Analyze();
        }

        // Build/Development
        public override void BuildDevelopment() {
            base.BuildDevelopment();
        }

        // Build/Production
        public override void BuildProduction() {
            base.BuildProduction();
        }

    }
}
#endif
