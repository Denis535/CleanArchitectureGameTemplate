#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIWidgetExtensions {

        // IsModal
        public static bool IsModal(this UIWidget widget) {
            return widget is IUIModalWidget;
        }

        // OnDescendantAttach
        public static void OnBeforeDescendantAttach(this UIWidget widget, Action<UIWidget> callback) {
            widget.OnBeforeDescendantAttachEvent += callback;
        }
        public static void OnAfterDescendantAttach(this UIWidget widget, Action<UIWidget> callback) {
            widget.OnAfterDescendantAttachEvent += callback;
        }
        public static void OnBeforeDescendantDetach(this UIWidget widget, Action<UIWidget> callback) {
            widget.OnBeforeDescendantDetachEvent += callback;
        }
        public static void OnAfterDescendantDetach(this UIWidget widget, Action<UIWidget> callback) {
            widget.OnAfterDescendantDetachEvent += callback;
        }

        // OnDescendantAttach
        public static void OnBeforeDescendantAttach<TWidget>(this UIWidget widget, Action<TWidget> callback) {
            widget.OnBeforeDescendantAttachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnAfterDescendantAttach<TWidget>(this UIWidget widget, Action<TWidget> callback) {
            widget.OnAfterDescendantAttachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnBeforeDescendantDetach<TWidget>(this UIWidget widget, Action<TWidget> callback) {
            widget.OnBeforeDescendantDetachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnAfterDescendantDetach<TWidget>(this UIWidget widget, Action<TWidget> callback) {
            widget.OnAfterDescendantDetachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }

    }
}
