#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;

    public partial class GameScreenView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<GameScreenView, UxmlTraits> { }
    }
    public partial class GameScreenView : UIScreenView2 {

        // Constructor
        public GameScreenView() {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // ShowView
        public override void ShowView(UIWidgetViewBase view, UIWidgetViewBase[] shadowed) {
            base.ShowView( view, shadowed );
        }
        public override void HideView(UIWidgetViewBase view, UIWidgetViewBase[] unshadowed) {
            base.HideView( view, unshadowed );
        }

    }
}
