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
        public GameWidgetView() {
            AddToClassList( "widget-view" );
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
