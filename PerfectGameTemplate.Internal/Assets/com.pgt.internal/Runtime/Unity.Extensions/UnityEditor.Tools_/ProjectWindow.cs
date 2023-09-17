#if UNITY_EDITOR
#nullable enable
namespace UnityEditor.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;
    using UnityEditor;
    using UnityEngine;

    public class ProjectWindow {

        // Constructor
        public ProjectWindow() {
            EditorApplication.projectWindowItemOnGUI = OnGUI;
        }

        // OnGUI
        public virtual void OnGUI(string guid, Rect rect) {
            var path = AssetDatabase.GUIDToAssetPath( guid );
            if (IsModule( path, out var module, out var content )) {
                if (content == null) {
                    DrawModule( rect, path, module );
                } else {
                    if (IsAssets( content )) {
                        DrawAssets( rect, path, module, content );
                    } else if (IsSources( content )) {
                        DrawSources( rect, path, module, content );
                    }
                }
            }
        }

        // DrawItem
        public virtual void DrawModule(Rect rect, string path, string module) {
            var color = HSVA( 0, 1, 1, 0.3f );
            DrawItem( rect, color, path );
        }
        public virtual void DrawAssets(Rect rect, string path, string module, string content) {
            var depth = content.Count( i => i is '/' );
            var color = depth switch {
                0 => HSVA( 060f / 360f, 1f, 1f / 1.0f, 0.3f ),
                _ => HSVA( 060f / 360f, 1f, 1f / 2.5f, 0.3f ),
            };
            DrawItem( rect, color, path );
        }
        public virtual void DrawSources(Rect rect, string path, string module, string content) {
            var depth = content.Count( i => i is '/' );
            var color = depth switch {
                0 => HSVA( 120f / 360f, 1f, 1f / 1.0f, 0.3f ),
                _ => HSVA( 120f / 360f, 1f, 1f / 2.5f, 0.3f ),
            };
            DrawItem( rect, color, path );
        }
        public virtual void DrawItem(Rect rect, Color color, string path) {
            rect.x -= 16;
            rect.width = 16;
            DrawRect( rect, color );
        }

        // IsModule
        public virtual bool IsModule(string path, [NotNullWhen( true )] out string? module, out string? content) {
            if (path.StartsWith( "Assets/" )) {
                var path2 = path.TakeRightOf( '/' );
                if (path2 != null && IsModule( path2 )) {
                    module = path2.TakeLeftOf( '/' ) ?? path2;
                    content = path2.TakeRightOf( '/' );
                    return true;
                }
            }
            module = null;
            content = null;
            return false;
        }
        public virtual bool IsModule(string path) {
            return path.Equals( "Project" ) || path.StartsWith( "Project/" ) ||
                    path.Equals( "Project.UI" ) || path.StartsWith( "Project.UI/" ) ||
                    path.Equals( "Project.App" ) || path.StartsWith( "Project.App/" ) ||
                    path.Equals( "Project.App" ) || path.StartsWith( "Project.App/" ) ||
                    path.Equals( "Project.Game" ) || path.StartsWith( "Project.Game/" ) ||
                    path.Equals( "Project.Core" ) || path.StartsWith( "Project.Core/" ) ||
                    path.Equals( "Project.Internal" ) || path.StartsWith( "Project.Internal/" ) ||
                    path.Equals( "Project.Tests" ) || path.StartsWith( "Project.Tests/" );
        }
        public virtual bool IsAssets(string path) {
            return path.StartsWith( "Assets" ) || path.StartsWith( "Resources" );
        }
        public virtual bool IsSources(string path) {
            return Path.GetExtension( path ) is not ".asmdef" and not ".asmref" and not ".rsp";
        }

        // Helpers
        protected static Color RGBA(float r, float g, float b, float a) {
            return new Color( r, g, b, a );
        }
        protected static Color HSVA(float h, float s, float v, float a) {
            var color = Color.HSVToRGB( h, s, v );
            color.a = a;
            return color;
        }
        protected static void DrawRect(Rect rect, Color color) {
            var prev = GUI.color;
            GUI.color = color;
            GUI.DrawTexture( rect, Texture2D.whiteTexture );
            GUI.color = prev;
        }

    }
}
#endif
