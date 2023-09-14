#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIWidgetViewBase : UIViewBase {

        // Widget
        internal UIWidgetBase? Widget { get; set; }

        // Constructor
        public UIWidgetViewBase() {
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
