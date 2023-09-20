#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class GameWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<GameWidgetView, UxmlTraits> { }
    }
    public partial class GameWidgetView : UIWidgetViewBase {

        // Constructor
        public GameWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
