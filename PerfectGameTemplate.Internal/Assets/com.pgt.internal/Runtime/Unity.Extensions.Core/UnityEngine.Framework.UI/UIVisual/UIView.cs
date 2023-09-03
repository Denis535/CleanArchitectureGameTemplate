#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UIElements;

    public abstract class UIView : VisualElement, IUIMessageObservable, IDisposable {
        public class UxmlFactory<T, TTraits> : UnityEngine.UIElements.UxmlFactory<T, TTraits> where T : UIView, new() where TTraits : UxmlTraits, new() {
            public override string uxmlQualifiedName => typeof( T ).IsNested ? base.uxmlQualifiedName.Replace( '+', '.' ) : base.uxmlQualifiedName;
        }

        // System
        public bool IsDisposed { get; private set; }
        // Observable
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public UIMessageDispatcher Dispatcher => new UIMessageDispatcher( this );

        // Create
        public static T Create<T>() where T : UIView, new() {
            var view = new T();
            view.Initialize();
            return view;
        }
        public static T Create<T>(VisualTreeAsset asset) where T : UIView, new() {
            var view = asset.Instantiate().Children().OfType<T>().FirstOrDefault() ?? throw Exceptions.Internal.Exception( $"Element {typeof( T )} was not found" );
            view.Initialize();
            return view;
        }

        // Constructor
        internal UIView() {
            AddToClassList( "view" );
        }
        public virtual void Initialize() {
            foreach (var view in this.GetDescendants( i => i is not UIView ).OfType<UIView>()) {
                view.Initialize();
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
