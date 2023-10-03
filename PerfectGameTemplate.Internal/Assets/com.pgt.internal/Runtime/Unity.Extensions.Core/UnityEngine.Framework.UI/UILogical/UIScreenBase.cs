#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class UIScreenBase : MonoBehaviour, IUILogicalElement, IUIViewable, IUIObservable {

        private UIScreenViewBase view = default!;

        // System
        private Lock Lock { get; } = new Lock();
        public Action<UIMessage>? OnMessageEvent { get; set; }
        // Globals
        protected internal UIDocument Document { get; set; } = default!;
        protected internal AudioSource AudioSource { get; set; } = default!;
        // View
        public UIScreenViewBase View {
            get => view;
            protected set {
                view = value;
                view.Screen = this;
                Document.rootVisualElement.Add( View );
            }
        }
        UIViewBase IUIViewable.View => View;
        // Widget
        public UIWidgetBase? Widget { get; private set; }
        // OnDescendantWidgetAttach
        public Action<UIWidgetBase>? OnBeforeDescendantWidgetAttachEvent { get; set; }
        public Action<UIWidgetBase>? OnAfterDescendantWidgetAttachEvent { get; set; }
        public Action<UIWidgetBase>? OnBeforeDescendantWidgetDetachEvent { get; set; }
        public Action<UIWidgetBase>? OnAfterDescendantWidgetDetachEvent { get; set; }

        // Awake
        public void Awake() {
            Document = gameObject.RequireComponentInChildren<UIDocument>();
            AudioSource = gameObject.RequireComponentInChildren<AudioSource>();
        }
        public void OnDestroy() {
            if (Widget != null) this.DetachWidget();
            View.RemoveFromHierarchy();
            View.Dispose();
        }

        // AttachWidget
        protected internal virtual void __AttachWidget__(UIWidgetBase widget) {
            // You can override it but you should not directly call this method
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Object.Message( $"Screen {this} must have no widget" ).Valid( Widget == null );
            using (Lock.Enter()) {
                Widget = widget;
                Widget.Attach( this );
            }
        }
        protected internal virtual void __DetachWidget__(UIWidgetBase widget) {
            // You can override it but you should not directly call this method
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Object.Message( $"Screen {this} must have widget" ).Valid( Widget != null );
            Assert.Object.Message( $"Screen {this} must have widget {widget} widget" ).Valid( Widget == widget );
            using (Lock.Enter()) {
                Widget.Detach( this );
                Widget = null;
                if (widget.DisposeAutomatically) {
                    widget.Dispose();
                }
            }
        }

        // ShowWidget
        public virtual void ShowWidget(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached || widget.IsAttaching );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            if (widget.IsViewable) {
                var shadowed = Widget!.DescendantsAndSelf.TakeWhile( i => i != widget ).Where( i => i.IsViewable ).Select( i => i.View! ).ToArray();
                View.ShowView( widget.View, shadowed );
            }
        }
        public virtual void HideWidget(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached || widget.IsDetaching );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            if (widget.IsViewable) {
                var unshadowed = Widget!.DescendantsAndSelf.TakeWhile( i => i != widget ).Where( i => i.IsViewable ).Select( i => i.View! ).ToArray();
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
    public abstract class UIScreenBase<TView> : UIScreenBase where TView : notnull, UIScreenViewBase {

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
