#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public partial class MainWidgetView {
    }
    public partial class MainWidgetView : UIWidgetViewBase {

        // View
        private readonly VisualElement visualElement;
        // View
        public override VisualElement VisualElement => visualElement;

        // Constructor
        public MainWidgetView(MainWidget widget) : base( widget ) {
            visualElement = CreateVisualElement();
            // View
            visualElement.OnAttachToPanel( evt => {
            } );
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
        private static View CreateVisualElement() {
            return UIFactory.Widget( "main-widget-view" );
        }

    }
}
