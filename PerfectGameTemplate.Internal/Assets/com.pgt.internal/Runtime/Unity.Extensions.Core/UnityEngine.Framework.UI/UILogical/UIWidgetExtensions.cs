#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class UIWidgetExtensions {

        // AttachChild
        public static void AttachChild(this UIWidgetBase widget, UIWidgetBase child) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( child != null );
            Assert.Object.Message( $"Widget {widget} must have no child {child} widget" ).Valid( !widget.Children.Contains( child ) );
            widget.__AttachChild__( child );
        }

        // DetachSelf
        public static void DetachSelf(this UIWidgetBase widget) {
            Assert.Object.Message( $"Widget {widget} must have parent or must be be attached" ).Valid( widget.Parent != null || widget.IsAttached );
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
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( child != null );
            Assert.Object.Message( $"Widget {widget} must have child {child} widget" ).Valid( widget.Children.Contains( child ) );
            widget.__DetachChild__( child );
        }

        // DetachChildren
        public static void DetachChildren(this UIWidgetBase widget) {
            foreach (var child in widget.Children.Reverse()) {
                widget.__DetachChild__( child );
            }
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
        public static void OnBeforeDescendantAttach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) {
            widget.OnBeforeDescendantAttachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnAfterDescendantAttach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) {
            widget.OnAfterDescendantAttachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnBeforeDescendantDetach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) {
            widget.OnBeforeDescendantDetachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnAfterDescendantDetach<TWidget>(this UIWidgetBase widget, Action<TWidget> callback) {
            widget.OnAfterDescendantDetachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }

    }
}