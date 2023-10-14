#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UIElements;

    public abstract class UIViewBase : IUIObservable, IDisposable {

        // System
        public bool IsDisposed { get; private set; }
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public IUIObservable? Observable { get; }
        // VisualElement
        public VisualElement VisualElement { get; protected init; } = default!;

        // Constructor
        public UIViewBase(IUIObservable? observable) {
            Observable = observable;
        }
        public virtual void Dispose() {
            Assert.Object.Message( $"View {this} must be alive" ).Alive( !IsDisposed );
            Assert.Object.Message( $"View {this} must be non-attached" ).Valid( VisualElement.panel == null );
            IsDisposed = true;
            if (VisualElement.visualTreeAssetSource != null) Addressables2.Release( VisualElement.visualTreeAssetSource );
        }

    }
}
