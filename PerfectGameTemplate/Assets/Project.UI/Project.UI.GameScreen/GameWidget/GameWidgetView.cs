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

        // Constructor
        public GameWidgetView(GameWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement();
            // OnEvent
            VisualElement.OnAttachToPanel( evt => {
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement() {
            return UIFactory.Widget(
                i => i.Name( "game-widget-view" )
            );
        }

    }
}
