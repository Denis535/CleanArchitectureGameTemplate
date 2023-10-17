#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIObservableScreenViewBase : UIScreenViewBase, IUIObservable {

        public Action<UIMessage>? OnMessageEvent { get; set; }
        public IUIObservable? Observable { get; set; }

        // Constructor
        public UIObservableScreenViewBase(UIScreenBase screen) : base( screen ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
