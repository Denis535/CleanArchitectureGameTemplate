#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIObservableWidgetBase : UIWidgetBase, IUIObservable {

        public Action<UIMessage>? OnMessageEvent { get; set; }
        public IUIObservable? Observable { get; set; }

        // Constructor
        public UIObservableWidgetBase() {
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    public abstract class UIObservableWidgetBase<TView> : UIWidgetBase<TView>, IUIObservable where TView : notnull, UIWidgetViewBase {

        public Action<UIMessage>? OnMessageEvent { get; set; }
        public IUIObservable? Observable { get; set; }

        // Constructor
        public UIObservableWidgetBase() {
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
