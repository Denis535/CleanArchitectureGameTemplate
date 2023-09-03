#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIScreenExtensions {

        // OnDescendantWidgetAttach
        public static void OnBeforeDescendantWidgetAttach(this UIScreen screen, Action<UIWidget> callback) {
            screen.OnBeforeDescendantWidgetAttachEvent += callback;
        }
        public static void OnAfterDescendantWidgetAttach(this UIScreen screen, Action<UIWidget> callback) {
            screen.OnAfterDescendantWidgetAttachEvent += callback;
        }
        public static void OnBeforeDescendantWidgetDetach(this UIScreen screen, Action<UIWidget> callback) {
            screen.OnBeforeDescendantWidgetDetachEvent += callback;
        }
        public static void OnAfterDescendantWidgetDetach(this UIScreen screen, Action<UIWidget> callback) {
            screen.OnAfterDescendantWidgetDetachEvent += callback;
        }

        // OnDescendantWidgetAttach
        public static void OnBeforeDescendantWidgetAttach<TWidget>(this UIScreen screen, Action<TWidget> callback) where TWidget : UIWidget {
            screen.OnBeforeDescendantWidgetAttachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnAfterDescendantWidgetAttach<TWidget>(this UIScreen screen, Action<TWidget> callback) where TWidget : UIWidget {
            screen.OnAfterDescendantWidgetAttachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnBeforeDescendantWidgetDetach<TWidget>(this UIScreen screen, Action<TWidget> callback) where TWidget : UIWidget {
            screen.OnBeforeDescendantWidgetDetachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }
        public static void OnAfterDescendantWidgetDetach<TWidget>(this UIScreen screen, Action<TWidget> callback) where TWidget : UIWidget {
            screen.OnAfterDescendantWidgetDetachEvent += widget => {
                if (widget is TWidget widget_) callback( widget_ );
            };
        }

    }
}
