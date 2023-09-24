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
            var color = HSVA( 000, 1, 1, 0.3f );
            DrawItem( rect, path, color );
        }
        public virtual void DrawAssets(Rect rect, string path, string module, string content) {
            var depth = content.Count( i => i is '/' );
            var color = depth switch {
                0 => HSVA( 060, 1f, 1.0f, 0.3f ),
                _ => HSVA( 060, 1f, 0.4f, 0.3f ),
            };
            DrawItem( rect, path, color );
        }
        public virtual void DrawSources(Rect rect, string path, string module, string content) {
            var depth = content.Count( i => i is '/' );
            var color = depth switch {
                0 => HSVA( 120, 1f, 1.0f, 0.3f ),
                _ => HSVA( 120, 1f, 0.4f, 0.3f ),
            };
            DrawItem( rect, path, color );
        }
        public virtual void DrawItem(Rect rect, string path, Color color) {
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
            return path.StartsWith( "Project" );
        }
        public virtual bool IsAssets(string path) {
            return path.StartsWith( "Assets" ) || path.StartsWith( "Resources" );
        }
        public virtual bool IsSources(string path) {
            return Path.GetExtension( path ) is not ".asmdef" and not ".asmref" and not ".rsp";
        }

        // Helpers
        protected static Color HSVA(int h, float s, float v, float a) {
            var color = Color.HSVToRGB( h / 360f, s, v );
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
