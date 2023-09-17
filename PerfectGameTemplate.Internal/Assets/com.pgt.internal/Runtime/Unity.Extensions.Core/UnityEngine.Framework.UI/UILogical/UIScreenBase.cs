#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class UIScreenBase : MonoBehaviour, IUILogicalElement, IUIObservable {

        private UIScreenViewBase view = default!;

        // System
        private Lock Lock { get; } = new Lock();
        // Globals
        public UIDocument Document { get; protected set; } = default!;
        public AudioSource AudioSource { get; protected set; } = default!;
        // Observable
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public UIMessageDispatcher Dispatcher => new UIMessageDispatcher( this );
        // View
        public UIScreenViewBase View {
            get => view;
            protected set {
                view = value;
                view.Screen = this;
                Document.rootVisualElement.Add( View );
            }
        }
        // Widget
        public UIWidgetBase? Widget { get; private set; }
        // OnDescendantWidgetAttach
        public Action<UIWidgetBase>? OnBeforeDescendantWidgetAttachEvent { get; set; }
        public Action<UIWidgetBase>? OnAfterDescendantWidgetAttachEvent { get; set; }
        public Action<UIWidgetBase>? OnBeforeDescendantWidgetDetachEvent { get; set; }
        public Action<UIWidgetBase>? OnAfterDescendantWidgetDetachEvent { get; set; }

        // Awake
        public void Awake() {
            Document = this.GetDependencyContainer().GetDependency<UIDocument>( this ) ?? gameObject.RequireComponentInChildren<UIDocument>();
            AudioSource = this.GetDependencyContainer().GetDependency<AudioSource>( this ) ?? gameObject.RequireComponentInChildren<AudioSource>();
        }
        public void OnDestroy() {
            if (Widget != null) this.DetachWidget();
            View.RemoveFromHierarchy();
            View.Dispose();
        }

        // AttachWidget
        protected internal virtual void __AttachWidget__(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be non-attached" ).Valid( widget.IsNonAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == null );
            Assert.Object.Message( $"Screen {this} must have no widget" ).Valid( Widget == null );
            using (Lock.Enter()) {
                Widget = widget;
                Widget.Parent = null;
                Widget.Attach( this );
            }
        }
        protected internal virtual void __DetachWidget__(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == null );
            Assert.Object.Message( $"Screen {this} must have widget" ).Valid( Widget != null );
            Assert.Object.Message( $"Screen {this} must have widget {widget} widget" ).Valid( Widget == widget );
            using (Lock.Enter()) {
                Widget.Detach( this );
                Widget.Parent = null;
                Widget = null;
            }
        }

        // ShowWidget
        public virtual void ShowWidget(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            if (widget.IsViewable) {
                var shadowed = Widget!.DescendantsAndSelf.Where( i => i.IsViewable ).TakeWhile( i => i != widget ).Select( i => i.View! ).ToArray();
                View.ShowView( widget.View, shadowed );
            }
        }
        public virtual void HideWidget(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            if (widget.IsViewable) {
                var unshadowed = Widget!.DescendantsAndSelf.Where( i => i.IsViewable ).TakeWhile( i => i != widget ).Select( i => i.View! ).ToArray();
                View.HideView( widget.View, unshadowed );
            }
        }

        // OnDescendantWidgetAttach
        public virtual void OnBeforeDescendantWidgetAttach(UIWidgetBase descendant) {
        }
        public virtual void OnAfterDescendantWidgetAttach(UIWidgetBase descendant) {
        }
        public virtual void OnBeforeDescendantWidgetDetach(UIWidgetBase descendant) {
        }
        public virtual void OnAfterDescendantWidgetDetach(UIWidgetBase descendant) {
        }

        // Helpers
        protected static void AddView(UIDocument document, UIScreenViewBase view) {
            document.rootVisualElement.Add( view );
        }
        protected static void AddViewIfNeeded(UIDocument document, UIScreenViewBase view) {
            if (!document.rootVisualElement.Contains( view )) {
                document.rootVisualElement.Add( view );
            }
        }
        protected static void RemoveView(UIDocument document, UIScreenViewBase view) {
            document.rootVisualElement.Remove( view );
        }

    }
    public abstract class UIScreenBase<TView> : UIScreenBase where TView : UIScreenViewBase {

        // View
        public new TView View {
            get => (TView) base.View;
            protected set => base.View = value;
        }

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

    }
}
