#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UISubViewBase : UIViewBase {

        // View
        internal UIWidgetViewBase View { get; }

        // Constructor
        public UISubViewBase(UIWidgetViewBase view) : base( view ) {
            View = view;
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
