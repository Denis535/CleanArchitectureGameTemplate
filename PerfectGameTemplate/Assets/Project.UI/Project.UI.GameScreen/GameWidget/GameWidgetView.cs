#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class GameWidgetView : UIWidgetViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }

        // Constructor
        public GameWidgetView(GameWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.GameWidgetView( out var view );
            View = view.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
