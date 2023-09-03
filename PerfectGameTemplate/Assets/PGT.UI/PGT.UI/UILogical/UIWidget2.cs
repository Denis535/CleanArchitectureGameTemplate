#nullable enable
namespace PGT.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public abstract class UIWidget2 : UIWidget {

        // Constructor
        public UIWidget2() {
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    public abstract class UIWidget2<TView> : UIWidget<TView> where TView : UIWidgetView2 {

        // Constructor
        public UIWidget2() {
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
