#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIObservableSubViewBase : UISubViewBase, IUIObservable {

        public Action<UIMessage>? OnMessageEvent { get; set; }
        public IUIObservable? Observable { get; set; }

        // Constructor
        public UIObservableSubViewBase(UIWidgetBase widget) : base( widget ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
