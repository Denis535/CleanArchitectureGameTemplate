#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIWidgetView : UIView {

        // Widget
        internal UIWidget? Widget { get; set; }

        // Constructor
        public UIWidgetView() {
            AddToClassList( "widget-view" );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
