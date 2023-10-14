#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UIElements;

    public abstract class UIViewBase : VisualElement, IUIObservable, IDisposable {
        public class UxmlFactory<T, TTraits> : UnityEngine.UIElements.UxmlFactory<T, TTraits> where T : UIViewBase, new() where TTraits : UxmlTraits, new() {
            public override string uxmlQualifiedName => typeof( T ).IsNested ? base.uxmlQualifiedName.Replace( '+', '.' ) : base.uxmlQualifiedName;
        }

        // System
        public bool IsDisposed { get; private set; }
        public Action<UIMessage>? OnMessageEvent { get; set; }

        // Constructor
        public UIViewBase() {
            AddToClassList( "view" );
        }
        public virtual void Dispose() {
            Assert.Object.Message( $"View {this} must be alive" ).Alive( !IsDisposed );
            Assert.Object.Message( $"View {this} must be non-attached" ).Valid( panel == null );
            IsDisposed = true;
            if (visualTreeAssetSource != null) Addressables2.Release( visualTreeAssetSource );
        }

        // Utils
        public override string ToString() {
            return GetType().ToString();
        }

    }
}
