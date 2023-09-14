#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using UnityEngine;

    public abstract class UIWidgetBase : IUILogicalElement, IUIObservable, IDisposable {

        // System
        private Lock Lock { get; } = new Lock();
        public bool IsDisposed { get; private protected set; }
        public virtual bool DisposeAutomatically => true;
        // Observable
        public Action<UIMessage>? OnMessageEvent { get; set; }
        public UIMessageDispatcher Dispatcher => new UIMessageDispatcher( this );
        // View
        [MemberNotNullWhen( true, "View" )] public bool IsViewable => IsViewableInternal;
        public UIWidgetViewBase? View => ViewInternal;
        // View/Internal
        [MemberNotNullWhen( true, "ViewInternal" )] protected private virtual bool IsViewableInternal => false;
        protected private virtual UIWidgetViewBase? ViewInternal => null;
        // State
        public UIWidgetState State { get; private set; } = UIWidgetState.Unattached;
        [MemberNotNullWhen( true, "Screen" )] public bool IsAttached => State is UIWidgetState.Attaching or UIWidgetState.Attached or UIWidgetState.Detaching;
        [MemberNotNullWhen( true, "Screen" )] public bool IsAttachedStrict => State is UIWidgetState.Attached;
        [MemberNotNullWhen( false, "Screen" )] public bool IsNonAttached => State is UIWidgetState.Unattached or UIWidgetState.Detached;
        // Owner
        internal IUILogicalElement? Owner => (IUILogicalElement?) Parent ?? Screen;
        // Screen
        public UIScreenBase? Screen { get; private set; }
        // Parent
        [MemberNotNullWhen( false, "Parent" )] public bool IsRoot => Parent == null;
        public UIWidgetBase? Parent { get; internal set; }
        public IReadOnlyList<UIWidgetBase> Ancestors => this.GetAncestors();
        public IReadOnlyList<UIWidgetBase> AncestorsAndSelf => this.GetAncestorsAndSelf();
        // Children
        public bool HasChildren => Children_.Any();
        private List<UIWidgetBase> Children_ { get; } = new List<UIWidgetBase>();
        public IReadOnlyList<UIWidgetBase> Children => Children_;
        public IReadOnlyList<UIWidgetBase> Descendants => this.GetDescendants();
        public IReadOnlyList<UIWidgetBase> DescendantsAndSelf => this.GetDescendantsAndSelf();
        // OnDescendantAttach
        public Action<UIWidgetBase>? OnBeforeDescendantAttachEvent { get; set; }
        public Action<UIWidgetBase>? OnAfterDescendantAttachEvent { get; set; }
        public Action<UIWidgetBase>? OnBeforeDescendantDetachEvent { get; set; }
        public Action<UIWidgetBase>? OnAfterDescendantDetachEvent { get; set; }

        // Constructor
        public UIWidgetBase() {
        }
        public virtual void Dispose() {
            Assert.Object.Message( $"Widget {this} must be alive" ).Alive( !IsDisposed );
            Assert.Object.Message( $"Widget {this} must be non-attached" ).Valid( IsNonAttached );
            IsDisposed = true;
        }

        // Attach
        internal void Attach(UIScreenBase screen) {
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
        internal void Detach(UIScreenBase screen) {
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
        protected internal virtual void __AttachChild__(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be non-attached" ).Valid( widget.IsNonAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == null );
            Assert.Object.Message( $"Widget {this} must have no child {widget} widget" ).Valid( !Children.Contains( widget ) );
            using (Lock.Enter()) {
                Children_.Add( widget );
                widget.Parent = this;
                if (IsAttached) {
                    widget.Attach( Screen );
                }
            }
        }
        protected internal virtual void __DetachChild__(UIWidgetBase widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget != null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be attached or non-attached" ).Valid( widget.IsAttached || widget.IsNonAttached );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Screen == Screen || widget.Screen == null );
            Assert.Argument.Message( $"Argument 'widget' ({widget}) must be valid" ).Valid( widget.Parent == this );
            Assert.Object.Message( $"Widget {this} must have child {widget} widget" ).Valid( Children.Contains( widget ) );
            using (Lock.Enter()) {
                if (IsAttached) {
                    widget.Detach( Screen );
                }
                widget.Parent = null;
                Children_.Remove( widget );
            }
        }

        // OnDescendantAttach
        public virtual void OnBeforeDescendantAttach(UIWidgetBase widget) {
            Owner!.OnBeforeDescendantAttach( widget );
        }
        public virtual void OnAfterDescendantAttach(UIWidgetBase widget) {
            Owner!.OnAfterDescendantAttach( widget );
        }
        public virtual void OnBeforeDescendantDetach(UIWidgetBase widget) {
            Owner!.OnBeforeDescendantDetach( widget );
        }
        public virtual void OnAfterDescendantDetach(UIWidgetBase widget) {
            Owner!.OnAfterDescendantDetach( widget );
        }

    }
    public abstract class UIWidgetBase<TView> : UIWidgetBase where TView : notnull, UIWidgetViewBase {

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
        protected private override UIWidgetViewBase? ViewInternal => view;

        // Constructor
        public UIWidgetBase() {
        }
        public override void Dispose() {
            Assert.Object.Message( $"Widget {this} must be alive" ).Alive( !IsDisposed );
            Assert.Object.Message( $"Widget {this} must be non-attached" ).Valid( IsNonAttached );
            IsDisposed = true;
            View.Dispose();
        }

        // AttachChild
        protected internal override void __AttachChild__(UIWidgetBase widget) {
            base.__AttachChild__( widget );
        }
        protected internal override void __DetachChild__(UIWidgetBase widget) {
            base.__DetachChild__( widget );
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase widget) {
            base.OnBeforeDescendantAttach( widget );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase widget) {
            base.OnAfterDescendantAttach( widget );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase widget) {
            base.OnBeforeDescendantDetach( widget );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase widget) {
            base.OnAfterDescendantDetach( widget );
        }

    }
}
