#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class UIScreen : MonoBehaviour, IUILogicalElement, IUIMessageObservable, ILockable {

        private UIScreenView view = default!;

        // System
        bool ILockable.IsLocked { get; set; }
        // Observable
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public UIMessageDispatcher Dispatcher => new UIMessageDispatcher( this );
        // Document
        public virtual UIDocument Document => Singleton.GetInstance<UIInfrastructure>().Document;
        // AudioSource
        public virtual AudioSource AudioSource => Singleton.GetInstance<UIInfrastructure>().SfxAudioSource;
        // View
        public UIScreenView View {
            get => view;
            protected set {
                view = value;
                view.Screen = this;
                Document.rootVisualElement.Add( View );
            }
        }
        // Widget
        public UIWidget? Widget { get; private set; }
        // Router
        public UIScreenRouter Router => new UIScreenRouter( this );
        // OnDescendantWidgetAttach
        public Action<UIWidget>? OnBeforeDescendantWidgetAttachEvent { get; set; }
        public Action<UIWidget>? OnAfterDescendantWidgetAttachEvent { get; set; }
        public Action<UIWidget>? OnBeforeDescendantWidgetDetachEvent { get; set; }
        public Action<UIWidget>? OnAfterDescendantWidgetDetachEvent { get; set; }

        // Awake
        public void Awake() {
            Singleton.Register( this );
        }
        public void OnDestroy() {
            if (Widget != null) Router.DetachWidget();
            View.RemoveFromHierarchy();
            View.Dispose();
            Singleton.Unregister( this );
        }

        // AttachWidget
        protected internal virtual void __AttachWidget__(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be non-attached" ).Valid( widget.IsNonAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == null );
            Assert.Object.Message( $"Screen {this} must have no widget" ).Valid( Widget == null );
            using (this.Lock()) {
                Widget = widget;
                Widget.Parent = null;
                Widget.Attach( this );
            }
        }
        protected internal virtual void __DetachWidget__(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == null );
            Assert.Object.Message( $"Screen {this} must have widget" ).Valid( Widget != null );
            Assert.Object.Message( $"Screen {this} must have widget {widget} widget" ).Valid( Widget == widget );
            using (this.Lock()) {
                Widget.Detach( this );
                Widget.Parent = null;
                Widget = null;
            }
        }

        // ShowWidget
        public virtual void ShowWidget(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            if (widget.IsViewable) {
                var shadowed = Widget!.DescendantsAndSelf.Where( i => i.IsViewable ).TakeWhile( i => i != widget ).Select( i => i.View! ).ToArray();
                View.ShowView( widget.View, shadowed );
            }
        }
        public virtual void HideWidget(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached" ).Valid( widget.IsAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == this );
            if (widget.IsViewable) {
                var unshadowed = Widget!.DescendantsAndSelf.Where( i => i.IsViewable ).TakeWhile( i => i != widget ).Select( i => i.View! ).ToArray();
                View.HideView( widget.View, unshadowed );
            }
        }

        // OnDescendantWidgetAttach
        public virtual void OnBeforeDescendantWidgetAttach(UIWidget widget) {
        }
        public virtual void OnAfterDescendantWidgetAttach(UIWidget widget) {
        }
        public virtual void OnBeforeDescendantWidgetDetach(UIWidget widget) {
        }
        public virtual void OnAfterDescendantWidgetDetach(UIWidget widget) {
        }

        // Helpers
        protected static void AddView(UIDocument document, UIScreenView view) {
            document.rootVisualElement.Add( view );
        }
        protected static void AddViewIfNeeded(UIDocument document, UIScreenView view) {
            if (!document.rootVisualElement.Contains( view )) {
                document.rootVisualElement.Add( view );
            }
        }
        protected static void RemoveView(UIDocument document, UIScreenView view) {
            document.rootVisualElement.Remove( view );
        }

    }
    public abstract class UIScreen<TView> : UIScreen where TView : UIScreenView {

        // View
        public new TView View {
            get => (TView) base.View;
            protected set => base.View = value;
        }

    }
}
