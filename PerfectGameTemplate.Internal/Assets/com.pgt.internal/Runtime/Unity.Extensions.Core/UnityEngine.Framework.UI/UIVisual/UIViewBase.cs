#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UIElements;

    public abstract class UIViewBase : VisualElement, IUIObservable, IDisposable {
        public class UxmlFactory<T, TTraits> : UnityEngine.UIElements.UxmlFactory<T, TTraits> where T : UIViewBase, new() where TTraits : UxmlTraits, new() {
            public override string uxmlQualifiedName => typeof( T ).IsNested ? base.uxmlQualifiedName.Replace( '+', '.' ) : base.uxmlQualifiedName;
        }

        // System
        public bool IsDisposed { get; private set; }
        // Observable
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public UIMessageDispatcher Dispatcher => new UIMessageDispatcher( this );

        // Create
        public static T Create<T>() where T : UIViewBase, new() {
            var view = new T();
            view.Initialize();
            return view;
        }
        public static T Create<T>(VisualTreeAsset asset) where T : UIViewBase, new() {
            var view = asset.Instantiate().Children().OfType<T>().FirstOrDefault();
            Assert.Operation.Message( $"View {typeof( T )} ({asset.name}) could not be instantiated" ).Valid( view != null );
            view.Initialize();
            return view;
        }

        // Constructor
        internal UIViewBase() {
            AddToClassList( "view" );
        }
        public virtual void Initialize() {
            foreach (var child in this.GetDescendants( i => i is not UIViewBase ).OfType<UIViewBase>()) {
                child.Initialize();
            }
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
