#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UnityEngine;

    public static class UIWidgetExtensions {

        // AttachChild
        public static void AttachChild(this UIWidgetBase widget, UIWidgetBase child) {
            Assert.Argument.Message( $"Argument 'child' must be non-null" ).NotNull( child != null );
            Assert.Object.Message( $"Widget {widget} must have no child {child} widget" ).Valid( !widget.Children.Contains( child ) );
            widget.__AttachChild__( child );
        }

        // DetachSelf
        public static void DetachSelf(this UIWidgetBase widget) {
            Assert.Object.Message( $"Widget {widget} must have parent or must be attached" ).Valid( widget.Parent != null || widget.IsAttached );
            if (widget.Parent != null) {
                widget.Parent.DetachChild( widget );
            } else {
                widget.Screen!.DetachWidget( widget );
            }
        }

        // DetachChild
        public static void DetachChild<T>(this UIWidgetBase widget) where T : UIWidgetBase {
            Assert.Object.Message( $"Widget {widget} must have child {typeof( T )} widget" ).Valid( widget.Children.OfType<T>().Any() );
            widget.__DetachChild__( widget.Children.OfType<T>().Last() );
        }
        public static void DetachChild(this UIWidgetBase widget, UIWidgetBase child) {
            Assert.Argument.Message( $"Argument 'child' must be non-null" ).NotNull( child != null );
            Assert.Object.Message( $"Widget {widget} must have child {child} widget" ).Valid( widget.Children.Contains( child ) );
            widget.__DetachChild__( child );
        }

        // DetachChildren
        public static void DetachChildren(this UIWidgetBase widget) {
            foreach (var child in widget.Children.Reverse()) {
                widget.__DetachChild__( child );
            }
        }

        // OnAttach
        public static void OnAttach(this UIWidgetBase widget, Action callback) {
            widget.OnAttachEvent += callback;
        }
        public static void OnDetach(this UIWidgetBase widget, Action callback) {
            widget.OnDetachEvent += callback;
        }

        // OnDescendantAttach
        public static void OnBeforeDescendantAttach(this UIWidgetBase widget, Action<UIWidgetBase> callback) {
            widget.OnBeforeDescendantAttachEvent += callback;
        }
        public static void OnAfterDescendantAttach(this UIWidgetBase widget, Action<UIWidgetBase> callback) {
            widget.OnAfterDescendantAttachEvent += callback;
        }
        public static void OnBeforeDescendantDetach(this UIWidgetBase widget, Action<UIWidgetBase> callback) {
            widget.OnBeforeDescendantDetachEvent += callback;
        }
        public static void OnAfterDescendantDetach(this UIWidgetBase widget, Action<UIWidgetBase> callback) {
            widget.OnAfterDescendantDetachEvent += callback;
        }

        // OnDescendantAttach
        public static void OnBeforeDescendantAttach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) where TWidget : UIWidgetBase {
            widget.OnBeforeDescendantAttachEvent += descendant => {
                if (descendant is TWidget descendant_) callback( descendant_ );
            };
        }
        public static void OnAfterDescendantAttach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) where TWidget : UIWidgetBase {
            widget.OnAfterDescendantAttachEvent += descendant => {
                if (descendant is TWidget descendant_) callback( descendant_ );
            };
        }
        public static void OnBeforeDescendantDetach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) where TWidget : UIWidgetBase {
            widget.OnBeforeDescendantDetachEvent += descendant => {
                if (descendant is TWidget descendant_) callback( descendant_ );
            };
        }
        public static void OnAfterDescendantDetach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) where TWidget : UIWidgetBase {
            widget.OnAfterDescendantDetachEvent += descendant => {
                if (descendant is TWidget descendant_) callback( descendant_ );
            };
        }

        // WhenAttach
        public static Task WhenAttach(this UIWidgetBase widget) {
            var tcs = new TaskCompletionSource<object?>();
            widget.OnAttachEvent += OnAttach;
            return tcs.Task;
            void OnAttach() {
                widget.OnAttachEvent -= OnAttach;
                tcs.SetResult( null );
            }
        }
        public static Task WhenDetach(this UIWidgetBase widget) {
            var tcs = new TaskCompletionSource<object?>();
            widget.OnDetachEvent += OnDetach;
            return tcs.Task;
            void OnDetach() {
                widget.OnDetachEvent -= OnDetach;
                tcs.SetResult( null );
            }
        }

        // WhenDescendantAttach
        public static Task<UIWidgetBase> WhenBeforeDescendantAttach(this UIWidgetBase widget, Func<UIWidgetBase, bool> predicate) {
            var tcs = new TaskCompletionSource<UIWidgetBase>();
            widget.OnBeforeDescendantAttachEvent += OnBeforeDescendantAttach;
            return tcs.Task;
            void OnBeforeDescendantAttach(UIWidgetBase descendant) {
                if (predicate( descendant )) {
                    widget.OnBeforeDescendantAttachEvent -= OnBeforeDescendantAttach;
                    tcs.SetResult( descendant );
                }
            }
        }
        public static Task<UIWidgetBase> WhenAfterDescendantAttach(this UIWidgetBase widget, Func<UIWidgetBase, bool> predicate) {
            var tcs = new TaskCompletionSource<UIWidgetBase>();
            widget.OnAfterDescendantAttachEvent += OnAfterDescendantAttach;
            return tcs.Task;
            void OnAfterDescendantAttach(UIWidgetBase descendant) {
                if (predicate( descendant )) {
                    widget.OnAfterDescendantAttachEvent -= OnAfterDescendantAttach;
                    tcs.SetResult( descendant );
                }
            }
        }
        public static Task<UIWidgetBase> WhenBeforeDescendantDetach(this UIWidgetBase widget, Func<UIWidgetBase, bool> predicate) {
            var tcs = new TaskCompletionSource<UIWidgetBase>();
            widget.OnBeforeDescendantDetachEvent += OnBeforeDescendantDetach;
            void OnBeforeDescendantDetach(UIWidgetBase descendant) {
                if (predicate( descendant )) {
                    widget.OnBeforeDescendantDetachEvent -= OnBeforeDescendantDetach;
                    tcs.SetResult( descendant );
                }
            }
            return tcs.Task;
        }
        public static Task<UIWidgetBase> WhenAfterDescendantDetach(this UIWidgetBase widget, Func<UIWidgetBase, bool> predicate) {
            var tcs = new TaskCompletionSource<UIWidgetBase>();
            widget.OnAfterDescendantDetachEvent += OnAfterDescendantDetach;
            void OnAfterDescendantDetach(UIWidgetBase descendant) {
                if (predicate( descendant )) {
                    widget.OnAfterDescendantDetachEvent -= OnAfterDescendantDetach;
                    tcs.SetResult( descendant );
                }
            }
            return tcs.Task;
        }

        // WhenDescendantAttach
        public static Task<TWidget> WhenBeforeDescendantAttach<TWidget>(this UIWidgetBase widget) where TWidget : UIWidgetBase {
            var tcs = new TaskCompletionSource<TWidget>();
            widget.OnBeforeDescendantAttachEvent += OnBeforeDescendantAttach;
            return tcs.Task;
            void OnBeforeDescendantAttach(UIWidgetBase descendant) {
                if (descendant is TWidget descendant_) {
                    widget.OnBeforeDescendantAttachEvent -= OnBeforeDescendantAttach;
                    tcs.SetResult( descendant_ );
                }
            }
        }
        public static Task<TWidget> WhenAfterDescendantAttach<TWidget>(this UIWidgetBase widget) where TWidget : UIWidgetBase {
            var tcs = new TaskCompletionSource<TWidget>();
            widget.OnAfterDescendantAttachEvent += OnAfterDescendantAttach;
            return tcs.Task;
            void OnAfterDescendantAttach(UIWidgetBase descendant) {
                if (descendant is TWidget descendant_) {
                    widget.OnAfterDescendantAttachEvent -= OnAfterDescendantAttach;
                    tcs.SetResult( descendant_ );
                }
            }
        }
        public static Task<TWidget> WhenBeforeDescendantDetach<TWidget>(this UIWidgetBase widget) where TWidget : UIWidgetBase {
            var tcs = new TaskCompletionSource<TWidget>();
            widget.OnBeforeDescendantDetachEvent += OnBeforeDescendantDetach;
            void OnBeforeDescendantDetach(UIWidgetBase descendant) {
                if (descendant is TWidget descendant_) {
                    widget.OnBeforeDescendantDetachEvent -= OnBeforeDescendantDetach;
                    tcs.SetResult( descendant_ );
                }
            }
            return tcs.Task;
        }
        public static Task<TWidget> WhenAfterDescendantDetach<TWidget>(this UIWidgetBase widget) where TWidget : UIWidgetBase {
            var tcs = new TaskCompletionSource<TWidget>();
            widget.OnAfterDescendantDetachEvent += OnAfterDescendantDetach;
            void OnAfterDescendantDetach(UIWidgetBase descendant) {
                if (descendant is TWidget descendant_) {
                    widget.OnAfterDescendantDetachEvent -= OnAfterDescendantDetach;
                    tcs.SetResult( descendant_ );
                }
            }
            return tcs.Task;
        }

    }
}
