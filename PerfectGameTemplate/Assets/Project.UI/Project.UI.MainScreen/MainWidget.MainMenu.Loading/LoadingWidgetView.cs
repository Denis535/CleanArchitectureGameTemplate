#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public partial class LoadingWidgetView {
    }
    public partial class LoadingWidgetView : UIWidgetViewBase {

        // Content
        private readonly Label loading;
        // Props
        public TextElementWrapper Loading => loading.Wrap();

        // Constructor
        public LoadingWidgetView() {
            AddToClassList( "widget-view" );
            // Content
            Add( GetContent( out loading ) );
            // OnEvent
            this.OnAttachToPanel( evt => {
                PlayLoading( loading );
            } );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnScope GetContent(out Label loading) {
            return UIFactory.ColumnScope(
                i => i.SetUp( null, "padding-2", "grow-1", "justify-content-end", "align-items-center" ),
                loading = UIFactory.Label( "Loading...", "loading", "color-light", "font-size-200", "font-style-bold" )
            );
        }
        // Helpers
        private static void PlayLoading(Label label) {
            var animation = ValueAnimation<float>.Create( label, Mathf.Lerp );
            animation.easingCurve = Easing.Linear;
            animation.valueUpdated = (label, t) => ((Label) label).text = GetLoadingText( t );
            animation.from = 0;
            animation.to = 60;
            animation.durationMs = 60 * 1000; // 60 seconds
            animation.Start();
        }
        private static string GetLoadingText(float t) {
            var builder = new StringBuilder();
            var text = "Loading...";
            for (var i = 0; i < text.Length; i++) {
                var i01 = (float) i / (text.Length - 1);
                var a = Mathf.LerpUnclamped( 0f, 0.75f, i01 - t * 1.5f );
                a = Mathf.PingPong( a, 1 );
                a = Mathf.Pow( a, 3 );
                a = Mathf.LerpUnclamped( 0.05f, 1f, a );
                var color = ColorUtility.ToHtmlStringRGBA( new Color( 0.9f, 0.9f, 0.9f, a ) );
                var @char = text[ i ];
                builder.Append( $"<color=#{color}>{@char}</color>" );
            }
            return builder.ToString();
        }

    }
}
