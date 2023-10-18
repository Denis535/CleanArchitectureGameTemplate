#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public class MainWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }

        // Constructor
        public MainWidgetView(MainWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view );
            View = view.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetEffect
        public void SetEffect(int value) {
            var t = Easing.OutPower( Mathf.InverseLerp( 1, 8, value ), 2 );
            VisualElement.transform.scale = Vector3.LerpUnclamped( new Vector3( 1, 1, 1 ), new Vector3( 2, 2, 1 ), t );
            VisualElement.style.unityBackgroundImageTintColor = Color.LerpUnclamped( new Color( 1, 1, 1, 1 ), new Color( 0, 0, 0, 1 ), t );
        }

        // Helpers
        private static View CreateVisualElement(out View view) {
            return view = UIFactory.Widget( "main-widget-view" );
        }

    }
}
