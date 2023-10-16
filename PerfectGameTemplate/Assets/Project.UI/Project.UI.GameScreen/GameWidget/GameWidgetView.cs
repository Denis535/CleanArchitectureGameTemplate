#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class GameWidgetView {
    }
    public partial class GameWidgetView : UIWidgetViewBase {

        // View
        private readonly VisualElement visualElement;
        // View
        public override VisualElement VisualElement => visualElement;

        // Constructor
        public GameWidgetView(GameWidget widget) : base( widget ) {
            visualElement = CreateVisualElement();
            // View
            visualElement.OnAttachToPanel( evt => {
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement() {
            return UIFactory.Widget( "game-widget-view" );
        }

    }
}
