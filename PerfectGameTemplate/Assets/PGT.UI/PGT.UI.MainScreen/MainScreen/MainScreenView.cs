#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;

    public partial class MainScreenView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<MainScreenView, UxmlTraits> { }
    }
    public partial class MainScreenView : UIScreenView2 {

        // Constructor
        public MainScreenView() {
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
