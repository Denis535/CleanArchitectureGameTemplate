#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using UnityEngine;

    public abstract class UIWidget : IUILogicalElement, IUIMessageObservable, ILockable, IDisposable {

        // System
        public bool IsDisposed { get; private set; }
        bool ILockable.IsLocked { get; set; }
        public virtual bool DisposeAutomatically => true;
        // Observable
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public UIMessageDispatcher Dispatcher => new UIMessageDispatcher( this );
        // State
        public UIWidgetState State { get; private set; } = UIWidgetState.Unattached;
        [MemberNotNullWhen( true, "Screen" )] public bool IsAttached => State is UIWidgetState.Attaching or UIWidgetState.Attached or UIWidgetState.Detaching;
        [MemberNotNullWhen( true, "Screen" )] public bool IsAttachedStrict => State is UIWidgetState.Attached;
        [MemberNotNullWhen( false, "Screen" )] public bool IsNonAttached => State is UIWidgetState.Unattached or UIWidgetState.Detached;
        // View
        [MemberNotNullWhen( true, "View" )] public bool IsViewable => IsViewableInternal;
        public UIWidgetView? View => ViewInternal;
        // View/Internal
        [MemberNotNullWhen( true, "ViewInternal" )] protected private virtual bool IsViewableInternal => false;
        protected private virtual UIWidgetView? ViewInternal => null;
        // Owner
        internal IUILogicalElement? Owner => (IUILogicalElement?) Parent ?? Screen;
        // Screen
        public UIScreen? Screen { get; private set; }
        // Parent
        [MemberNotNullWhen( false, "Parent" )] public bool IsRoot => Parent == null;
        public UIWidget? Parent { get; internal set; }
        public IReadOnlyList<UIWidget> Ancestors => this.GetAncestors();
        public IReadOnlyList<UIWidget> AncestorsAndSelf => this.GetAncestorsAndSelf();
        // Children
        public bool HasChildren => Children_.Any();
        private List<UIWidget> Children_ { get; } = new List<UIWidget>();
        public IReadOnlyList<UIWidget> Children => Children_;
        public IReadOnlyList<UIWidget> Descendants => this.GetDescendants();
        public IReadOnlyList<UIWidget> DescendantsAndSelf => this.GetDescendantsAndSelf();
        // Router
        public UIWidgetRouter Router => new UIWidgetRouter( this );
        // OnDescendantAttach
        public Action<UIWidget>? OnBeforeDescendantAttachEvent { get; set; }
        public Action<UIWidget>? OnAfterDescendantAttachEvent { get; set; }
        public Action<UIWidget>? OnBeforeDescendantDetachEvent { get; set; }
        public Action<UIWidget>? OnAfterDescendantDetachEvent { get; set; }

        // Constructor
        public UIWidget() {
        }
        public virtual void Dispose() {
            Assert.Object.Message( $"Widget {this} must be alive" ).Alive( !IsDisposed );
            Assert.Object.Message( $"Widget {this} must be non-attached" ).Valid( IsNonAttached );
            IsDisposed = true;
        }

        // Attach
        internal void Attach(UIScreen screen) {
            Assert.Argument.Message( $"Argument 'screen' must be non-null" ).NotNull( screen );
            Assert.Object.Message( $"Widget {this} must be non-attached" ).Valid( IsNonAttached );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen == null );
            State = UIWidgetState.Attaching;
            Screen = screen;
            Owner!.OnBeforeDescendantAttach( this );
            {
                OnAttach();
                Screen!.ShowWidget( this );
                OnShow();
                foreach (var child in Children) {
                    child.Attach( Screen );
                }
            }
            Owner!.OnAfterDescendantAttach( this );
            State = UIWidgetState.Attached;
        }
        internal void Detach(UIScreen screen) {
            Assert.Argument.Message( $"Argument 'screen' must be non-null" ).NotNull( screen );
            Assert.Object.Message( $"Widget {this} must be attached" ).Valid( IsAttached );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen == screen );
            State = UIWidgetState.Detaching;
            Owner!.OnBeforeDescendantDetach( this );
            {
                foreach (var child in Children.Reverse()) {
                    child.Detach( Screen );
                }
                OnHide();
                Screen!.HideWidget( this );
                OnDetach();
            }
            Owner!.OnAfterDescendantDetach( this );
            Screen = null;
            State = UIWidgetState.Detached;
            if (DisposeAutomatically) {
                Dispose();
            }
        }

        // OnAttach
        public abstract void OnAttach();
        public abstract void OnDetach();

        // OnShow
        public abstract void OnShow();
        public abstract void OnHide();

        // AttachChild
        protected internal virtual void __AttachChild__(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be non-attached" ).Valid( widget.IsNonAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == null );
            Assert.Object.Message( $"Widget {this} must have no child {widget} widget" ).Valid( !Children.Contains( widget ) );
            using (this.Lock()) {
                Children_.Add( widget );
                widget.Parent = this;
                if (IsAttached) {
                    widget.Attach( Screen );
                }
            }
        }
        protected internal virtual void __DetachChild__(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached or non-attached" ).Valid( widget.IsAttached || widget.IsNonAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == Screen || widget.Screen == null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == this );
            Assert.Object.Message( $"Widget {this} must have child {widget} widget" ).Valid( Children.Contains( widget ) );
            using (this.Lock()) {
                if (IsAttached) {
                    widget.Detach( Screen );
                }
                widget.Parent = null;
                Children_.Remove( widget );
            }
        }

        // OnDescendantAttach
        public virtual void OnBeforeDescendantAttach(UIWidget widget) {
            Owner!.OnBeforeDescendantAttach( this );
        }
        public virtual void OnAfterDescendantAttach(UIWidget widget) {
            Owner!.OnAfterDescendantAttach( this );
        }
        public virtual void OnBeforeDescendantDetach(UIWidget widget) {
            Owner!.OnBeforeDescendantDetach( this );
        }
        public virtual void OnAfterDescendantDetach(UIWidget widget) {
            Owner!.OnAfterDescendantDetach( this );
        }

    }
    public abstract class UIWidget<TView> : UIWidget where TView : UIWidgetView {

        private TView view = default!;

        // View
        public new bool IsViewable => base.IsViewable;
        public new TView View {
            get => (TView) base.View!;
            protected init {
                view = value;
                view.Widget = this;
            }
        }
        // View/Internal
        protected private override bool IsViewableInternal => true;
        protected private override UIWidgetView? ViewInternal => view;

        // Constructor
        public UIWidget() {
        }
        public override void Dispose() {
            base.Dispose();
            View.Dispose();
        }

        // AttachChild
        protected internal override void __AttachChild__(UIWidget widget) {
            base.__AttachChild__( widget );
        }
        protected internal override void __DetachChild__(UIWidget widget) {
            base.__DetachChild__( widget );
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidget widget) {
            base.OnBeforeDescendantAttach( widget );
        }
        public override void OnAfterDescendantAttach(UIWidget widget) {
            base.OnAfterDescendantAttach( widget );
        }
        public override void OnBeforeDescendantDetach(UIWidget widget) {
            base.OnBeforeDescendantDetach( widget );
        }
        public override void OnAfterDescendantDetach(UIWidget widget) {
            base.OnAfterDescendantDetach( widget );
        }

    }
}
