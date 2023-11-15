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

    public class LoadingWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Loading { get; }

        // Constructor
        public LoadingWidgetView(LoadingWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var loading );
            VisualElement.OnAttachToPanel( i => PlayLoadingAnimation( loading ) );
            View = view.Wrap();
            Loading = loading.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label loading) {
            view = UIFactory.Widget( "loading-widget-view" );
            view.Children( UIFactory.ColumnScope().Classes( "padding-2pc", "grow-1", "justify-content-end", "align-items-center" ).Children(
                    loading = UIFactory.Label( "Loading..." ).Name( "loading" ).Classes( "color-light", "font-size-200pc", "font-style-bold" )
            ) );
            return view;
        }
        // Helpers
        private static void PlayLoadingAnimation(Label label) {
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
