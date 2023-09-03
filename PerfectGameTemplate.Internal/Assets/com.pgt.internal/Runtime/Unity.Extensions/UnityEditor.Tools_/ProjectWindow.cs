#if UNITY_EDITOR
#nullable enable
namespace UnityEditor.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEngine;

    public class ProjectWindow {

        public Regex Regex { get; }

        // Constructor
        public ProjectWindow() {
            EditorApplication.projectWindowItemOnGUI = OnProjectItemGUI;
            Regex = CreateRegex( PlayerSettings.productName );
        }
        public ProjectWindow(params string[] modules) {
            EditorApplication.projectWindowItemOnGUI = OnProjectItemGUI;
            Regex = CreateRegex( modules );
        }

        // OnProjectItemGUI
        public void OnProjectItemGUI(string guid, Rect rect) {
            var path = AssetDatabase.GUIDToAssetPath( guid );
            DrawItem( rect, path );
        }

        // DrawItem
        public virtual void DrawItem(Rect rect, string path) {
            if (Match( path, out var module, out var content )) {
                if (content == null) {
                    DrawModule( rect, path, module );
                } else {
                    if (content.Equals( "Assets" ) || content.StartsWith( "Assets." ) || content.Equals( "Resources" ) || content.StartsWith( "Resources." )) {
                        DrawAssets( rect, path, module, content );
                    } else
                    if (content.Contains( '/' ) || AssetDatabase.IsValidFolder( path )) {
                        DrawSources( rect, path, module, content );
                    }
                }
            }
        }
        public virtual void DrawModule(Rect rect, string path, string module) {
            var color = HSVA( 0, 1, 1, 0.3f );
            DrawItem( rect, path, color );
        }
        public virtual void DrawAssets(Rect rect, string path, string module, string content) {
            var depth = content.Count( i => i is '/' );
            var color = depth switch {
                0 => HSVA( 060f / 360f, 1f, 1f / 1.0f, 0.3f ),
                _ => HSVA( 060f / 360f, 1f, 1f / 2.5f, 0.3f ),
            };
            DrawItem( rect, path, color );
        }
        public virtual void DrawSources(Rect rect, string path, string module, string content) {
            var depth = content.Count( i => i is '/' );
            var color = depth switch {
                0 => HSVA( 120f / 360f, 1f, 1f / 1.0f, 0.3f ),
                _ => HSVA( 120f / 360f, 1f, 1f / 2.5f, 0.3f ),
            };
            DrawItem( rect, path, color );
        }
        public virtual void DrawItem(Rect rect, string path, Color color) {
            rect.x -= 16;
            rect.width = 16;
            DrawRect( rect, color );
        }

        // Match
        public virtual bool Match(string path, [NotNullWhen( true )] out string? module, out string? content) {
            var match = Regex.Match( path );
            if (match.Success) {
                module = match.Groups[ "module" ].Value;
                content = match.Groups[ "content" ].Value.NullIfEmpty();
                return true;
            } else {
                module = null;
                content = null;
                return false;
            }
        }

        // Helpers
        protected static Regex CreateRegex(params string[] modules) {
            // ^     - begin of line
            // $     - end of line
            // ?     - zerp / one
            // *     - zero / more
            // +     - one  / more
            // (.*)  - match zero / more of any
            // (.*?) - match zero / more of any (non-greedy)
            // (.+)  - match one / more of any
            // (.+?) - match one / more of any (non-greedy)
            var builder = new StringBuilder();
            builder.Append( @"(?<base> ^(.*?)/)" ).AppendLine();
            builder.Append( @"(?<module> (" ).AppendJoin( "|", modules.Select( Regex.Escape ) ).Append( @") (/|$))" ).AppendLine();
            builder.Append( @"(?<content> (.*))" );
            return new Regex( builder.ToString(), RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace );
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
        // Helpers
        protected static void DrawRect(Rect rect, Color color) {
            var prev = GUI.color;
            GUI.color = color;
            GUI.DrawTexture( rect, Texture2D.whiteTexture );
            GUI.color = prev;
        }

    }
}
#endif
