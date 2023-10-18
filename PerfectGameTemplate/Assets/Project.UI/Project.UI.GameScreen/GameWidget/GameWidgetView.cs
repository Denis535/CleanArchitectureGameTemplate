#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class GameWidgetView : UIWidgetViewBase {

        // View
        private readonly VisualElement visualElement;
        // View
        public override VisualElement VisualElement => visualElement;
        // View
        public ElementWrapper View => visualElement.Wrap();

        // Constructor
        public GameWidgetView(GameWidget widget) : base( widget ) {
            visualElement = CreateVisualElement();
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
