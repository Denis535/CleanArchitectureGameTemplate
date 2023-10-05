#if UNITY_EDITOR
#nullable enable
namespace Project.Windows {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.Windows;
    using UnityEngine;

    public class ProjectWindow2 : ProjectWindow {

        // OnLoad
        [InitializeOnLoadMethod]
        internal static void OnLoad() {
            new ProjectWindow2();
        }

        // Constructor
        public ProjectWindow2() {
        }

        // OnGUI
        public override void OnGUI(string guid, Rect rect) {
            base.OnGUI( guid, rect );
        }

        // GetModule
        public override string? GetModule(string path) {
            return base.GetModule( path );
        }
        public override string? GetContent(string path) {
            return base.GetContent( path );
        }

        // IsModule
        public override bool IsModule(string path) {
            return base.IsModule( path );
        }
        public override bool IsAssets(string path) {
            return base.IsAssets( path );
        }
        public override bool IsSources(string path) {
            return base.IsSources( path );
        }

        // DrawModule
        public override void DrawModule(Rect rect, string path, string module) {
            base.DrawModule( rect, path, module );
        }
        public override void DrawAssets(Rect rect, string path, string module, string content) {
            base.DrawAssets( rect, path, module, content );
        }
        public override void DrawSources(Rect rect, string path, string module, string content) {
            base.DrawSources( rect, path, module, content );
        }
        public override void DrawItem(Rect rect, string path, Color color) {
            base.DrawItem( rect, path, color );
        }

    }
}
#endif
