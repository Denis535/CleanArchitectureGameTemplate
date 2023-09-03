#nullable enable
namespace PGT.UI.GameScreen {
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
        public override void ShowView(UIWidgetView view, UIWidgetView[] shadowed) {
            base.ShowView( view, shadowed );
        }
        public override void HideView(UIWidgetView view, UIWidgetView[] unshadowed) {
            base.HideView( view, unshadowed );
        }

    }
}
