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
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }

        // Constructor
        public GameWidgetView(GameWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view );
            View = view.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view) {
            view = UIFactory.Widget( "game-widget-view" );
            return view;
        }

    }
}
