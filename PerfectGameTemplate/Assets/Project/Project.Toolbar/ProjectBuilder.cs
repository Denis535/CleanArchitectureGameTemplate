#if UNITY_EDITOR
#nullable enable
namespace Project.Toolbar {
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
            new AssetsSourceGenerator().Generate( "Assets/Project.Core/UnityEngine/R.cs", "UnityEngine", "R", AddressableAssetSettingsDefaultObject.Settings );
            new LabelsSourceGenerator().Generate( "Assets/Project.Core/UnityEngine/L.cs", "UnityEngine", "L", AddressableAssetSettingsDefaultObject.Settings );
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
