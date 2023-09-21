#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class UIWidgetBase : IUILogicalElement, IUIObservable, IDisposable {

        // System
        private Lock Lock { get; } = new Lock();
        public bool IsDisposed { get; private set; }
        private CancellationTokenSource DisposeCancellationTokenSource { get; } = new CancellationTokenSource();
        public CancellationToken DisposeCancellationToken => DisposeCancellationTokenSource.Token;
        public virtual bool DisposeAutomatically => true;
        public Action<UIMessage>? OnMessageEvent { get; set; }
        // View
        [MemberNotNullWhen( true, "View" )] public bool IsViewable => this is IUIViewable;
        public UIWidgetViewBase? View => (UIWidgetViewBase?) (this as IUIViewable)?.View;
        // Owner
        internal IUILogicalElement? Owner => (IUILogicalElement?) Parent ?? Screen;
        // Screen
        public UIWidgetState State { get; private set; } = UIWidgetState.Unattached;
        [MemberNotNullWhen( true, "Screen" )] public bool IsAttached => State is UIWidgetState.Attached;
        [MemberNotNullWhen( true, "Screen" )] public bool IsAttaching => State is UIWidgetState.Attaching;
        [MemberNotNullWhen( true, "Screen" )] public bool IsDetaching => State is UIWidgetState.Detaching;
        [MemberNotNullWhen( false, "Screen" )] public bool IsNonAttached => State is UIWidgetState.Unattached or UIWidgetState.Detached;
        public UIScreenBase? Screen { get; private set; }
        // Parent
        [MemberNotNullWhen( false, "Parent" )] public bool IsRoot => Parent == null;
        public UIWidgetBase? Parent { get; private set; }
        public IReadOnlyList<UIWidgetBase> Ancestors => this.GetAncestors();
        public IReadOnlyList<UIWidgetBase> AncestorsAndSelf => this.GetAncestorsAndSelf();
        // Children
        public bool HasChildren => Children_.Any();
        private List<UIWidgetBase> Children_ { get; } = new List<UIWidgetBase>();
        public IReadOnlyList<UIWidgetBase> Children => Children_;
        public IReadOnlyList<UIWidgetBase> Descendants => this.GetDescendants();
        public IReadOnlyList<UIWidgetBase> DescendantsAndSelf => this.GetDescendantsAndSelf();
        // OnAttach
        public Action? OnAttachEvent { get; set; }
        public Action? OnDetachEvent { get; set; }
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
            DisposeCancellationTokenSource.Cancel();
            DisposeCancellationTokenSource.Dispose();
        }

        // Attach
        internal void Attach(UIScreenBase screen) {
            Assert.Argument.Message( $"Argument 'screen' must be non-null" ).NotNull( screen );
            Assert.Object.Message( $"Widget {this} must be non-attached" ).Valid( IsNonAttached );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen == null );
            State = UIWidgetState.Attaching;
            Screen = screen;
            OnBeforeDescendantAttach( Owner!, this );
            {
                OnAttachEvent?.Invoke();
                OnAttach();
                Screen!.ShowWidget( this );
                OnShow();
                foreach (var child in Children) {
                    child.Attach( Screen );
                }
            }
            OnAfterDescendantAttach( Owner!, this );
            State = UIWidgetState.Attached;
        }
        internal void Detach(UIScreenBase screen) {
            Assert.Argument.Message( $"Argument 'screen' must be non-null" ).NotNull( screen );
            Assert.Object.Message( $"Widget {this} must be attached" ).Valid( IsAttached );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen != null );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen == screen );
            State = UIWidgetState.Detaching;
            OnBeforeDescendantDetach( Owner!, this );
            {
                foreach (var child in Children.Reverse()) {
                    child.Detach( Screen );
                }
                OnHide();
                Screen!.HideWidget( this );
                OnDetach();
                OnDetachEvent?.Invoke();
            }
            OnAfterDescendantDetach( Owner!, this );
            Screen = null;
            State = UIWidgetState.Detached;
        }

        // Attach
        private void Attach(UIWidgetBase parent) {
            Assert.Argument.Message( $"Argument 'parent' must be non-null" ).NotNull( parent != null );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Parent == null );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( IsNonAttached );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen == null );
            Parent = parent;
            if (Parent.IsAttached) {
                Attach( Parent.Screen );
            }
        }
        private void Detach(UIWidgetBase parent) {
            Assert.Argument.Message( $"Argument 'parent' must be non-null" ).NotNull( parent != null );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Parent != null );
            Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Parent == parent );
            if (Parent.IsAttached) {
                //Assert.Object.Message( $"Widget {this} must be valid" ).Valid( IsAttached );
                //Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen != null );
                //Assert.Object.Message( $"Widget {this} must be valid" ).Valid( Screen == Parent.Screen );
                Detach( Parent.Screen );
            }
            Parent = null;
        }

        // OnAttach
        public abstract void OnAttach();
        public abstract void OnShow();
        public abstract void OnHide();
        public abstract void OnDetach();

        // AttachChild
        protected internal virtual void __AttachChild__(UIWidgetBase child) {
            Assert.Argument.Message( $"Argument 'child' must be non-null" ).NotNull( child != null );
            Assert.Object.Message( $"Widget {this} must have no child {child} widget" ).Valid( !Children.Contains( child ) );
            using (Lock.Enter()) {
                Children_.Add( child );
                child.Attach( this );
            }
        }
        protected internal virtual void __DetachChild__(UIWidgetBase child) {
            Assert.Argument.Message( $"Argument 'child' must be non-null" ).NotNull( child != null );
            Assert.Object.Message( $"Widget {this} must have child {child} widget" ).Valid( Children.Contains( child ) );
            using (Lock.Enter()) {
                child.Detach( this );
                if (child.DisposeAutomatically) {
                    child.Dispose();
                }
                Children_.Remove( child );
            }
        }

        // OnDescendantAttach
        public virtual void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            OnBeforeDescendantAttach( Owner!, descendant );
        }
        public virtual void OnAfterDescendantAttach(UIWidgetBase descendant) {
            OnAfterDescendantAttach( Owner!, descendant );
        }
        public virtual void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            OnBeforeDescendantDetach( Owner!, descendant );
        }
        public virtual void OnAfterDescendantDetach(UIWidgetBase descendant) {
            OnAfterDescendantDetach( Owner!, descendant );
        }

        // Helpers/OnDescendantAttach
        private static void OnBeforeDescendantAttach(IUILogicalElement element, UIWidgetBase descendant) {
            if (element is UIWidgetBase parent) {
                parent.OnBeforeDescendantAttachEvent?.Invoke( descendant );
                parent.OnBeforeDescendantAttach( descendant );
            } else
            if (element is UIScreenBase screen) {
                screen.OnBeforeDescendantWidgetAttachEvent?.Invoke( descendant );
                screen.OnBeforeDescendantWidgetAttach( descendant );
            }
        }
        private static void OnAfterDescendantAttach(IUILogicalElement element, UIWidgetBase descendant) {
            if (element is UIWidgetBase parent) {
                parent.OnAfterDescendantAttach( descendant );
                parent.OnAfterDescendantAttachEvent?.Invoke( descendant );
            } else
            if (element is UIScreenBase screen) {
                screen.OnAfterDescendantWidgetAttach( descendant );
                screen.OnAfterDescendantWidgetAttachEvent?.Invoke( descendant );
            }
        }
        private static void OnBeforeDescendantDetach(IUILogicalElement element, UIWidgetBase descendant) {
            if (element is UIWidgetBase parent) {
                parent.OnBeforeDescendantDetachEvent?.Invoke( descendant );
                parent.OnBeforeDescendantDetach( descendant );
            } else
            if (element is UIScreenBase screen) {
                screen.OnBeforeDescendantWidgetDetachEvent?.Invoke( descendant );
                screen.OnBeforeDescendantWidgetDetach( descendant );
            }
        }
        private static void OnAfterDescendantDetach(IUILogicalElement element, UIWidgetBase descendant) {
            if (element is UIWidgetBase parent) {
                parent.OnAfterDescendantDetach( descendant );
                parent.OnAfterDescendantDetachEvent?.Invoke( descendant );
            } else
            if (element is UIScreenBase screen) {
                screen.OnAfterDescendantWidgetDetach( descendant );
                screen.OnAfterDescendantWidgetDetachEvent?.Invoke( descendant );
            }
        }

    }
    public abstract class UIWidgetBase<TView> : UIWidgetBase, IUIViewable where TView : notnull, UIWidgetViewBase {

        private TView view = default!;

        // View
        public new TView View {
            get => view;
            protected init {
                view = value;
                view.Widget = this;
            }
        }
        UIViewBase IUIViewable.View => View;
        public bool IsEnabled { get => View.enabledSelf; set => View.SetEnabled( value ); }
        public bool IsDisplayed { get => View.IsDisplayed(); set => View.SetDisplayed( value ); }

        // Constructor
        public UIWidgetBase() {
        }
        public override void Dispose() {
            Assert.Object.Message( $"Widget {this} must be alive" ).Alive( !IsDisposed );
            Assert.Object.Message( $"Widget {this} must be non-attached" ).Valid( IsNonAttached );
            View.Dispose();
            base.Dispose();
        }

        // AttachChild
        protected internal override void __AttachChild__(UIWidgetBase child) {
            base.__AttachChild__( child );
        }
        protected internal override void __DetachChild__(UIWidgetBase child) {
            base.__DetachChild__( child );
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            base.OnAfterDescendantDetach( descendant );
        }

    }
}
