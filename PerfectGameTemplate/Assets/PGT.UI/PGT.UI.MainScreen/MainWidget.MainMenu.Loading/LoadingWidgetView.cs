#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public partial class LoadingWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<LoadingWidgetView, UxmlTraits> { }
        public record SubmitCommand() : UICommand<LoadingWidgetView>;
        public record CancelCommand() : UICommand<LoadingWidgetView>;
    }
    public partial class LoadingWidgetView : UIWidgetView2 {

        // Content
        private Label loading = default!;
        // Props
        public TextWrapper Loading => loading;

        // Constructor
        public LoadingWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            loading = this.RequireElement<Label>( null );
            // OnEvent
            this.OnAttachToPanel( evt => {
                PlayLoading( loading );
            } );
            this.OnSubmit( evt => {
                new SubmitCommand().Execute( this );
            } );
            this.OnCancel( evt => {
                new CancelCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static void PlayLoading(Label label) {
            var animation = ValueAnimation<float>.Create( label, Mathf.Lerp );
            animation.easingCurve = Easing.Linear;
            animation.valueUpdated = (label, t) => ((Label) label).text = GetLoadingText( t );
            animation.from = 0;
            animation.to = 60 * 60;
            animation.durationMs = 60 * 60 * 1000;
            animation.Start();
        }
        private static string GetLoadingText(float t) {
            var builder = new StringBuilder();
            var text = "Loading";
            for (var i = 0; i < text.Length; i++) {
                var a = Mathf.LerpUnclamped( 0f, 0.03f, i + t * 30f );
                a = Mathf.PingPong( a, 1 );
                a = Mathf.Pow( a, 3f );
                var color = ColorUtility.ToHtmlStringRGBA( new Color( 1, 1, 1, a ) );
                var @char = text[ i ];
                builder.Append( $"<color=#{color}>{@char}</color>" );
            }
            return builder.ToString();
        }

    }
}
