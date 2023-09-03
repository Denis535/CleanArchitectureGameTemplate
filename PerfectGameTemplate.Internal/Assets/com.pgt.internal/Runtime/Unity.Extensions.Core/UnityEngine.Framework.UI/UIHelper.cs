#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    internal static class UIHelper {

        // GetAncestors
        public static List<UIWidget> GetAncestors(this UIWidget widget, List<UIWidget>? result = null) {
            result ??= new List<UIWidget>();
            while (widget.Parent != null) {
                result.Add( widget.Parent );
                widget = widget.Parent;
            }
            return result;
        }
        public static List<UIWidget> GetAncestorsAndSelf(this UIWidget widget, List<UIWidget>? result = null) {
            result ??= new List<UIWidget>();
            result.Add( widget );
            GetAncestors( widget, result );
            return result;
        }

        // GetDescendants
        public static List<UIWidget> GetDescendants(this UIWidget widget, List<UIWidget>? result = null) {
            result ??= new List<UIWidget>();
            foreach (var child in widget.Children) {
                result.Add( child );
                GetDescendants( child, result );
            }
            return result;
        }
        public static List<UIWidget> GetDescendantsAndSelf(this UIWidget widget, List<UIWidget>? result = null) {
            result ??= new List<UIWidget>();
            result.Add( widget );
            GetDescendants( widget, result );
            return result;
        }

        // OnBeforeDescendantAttach
        public static void OnBeforeDescendantAttach(this IUILogicalElement element, UIWidget widget) {
            if (element is UIWidget parent) {
                parent.OnBeforeDescendantAttachEvent?.Invoke( widget );
                parent.OnBeforeDescendantAttach( widget );
            } else
            if (element is UIScreen screen) {
                screen.OnBeforeDescendantWidgetAttachEvent?.Invoke( widget );
                screen.OnBeforeDescendantWidgetAttach( widget );
            }
        }
        public static void OnAfterDescendantAttach(this IUILogicalElement element, UIWidget widget) {
            if (element is UIWidget parent) {
                parent.OnAfterDescendantAttach( widget );
                parent.OnAfterDescendantAttachEvent?.Invoke( widget );
            } else
            if (element is UIScreen screen) {
                screen.OnAfterDescendantWidgetAttach( widget );
                screen.OnAfterDescendantWidgetAttachEvent?.Invoke( widget );
            }
        }
        public static void OnBeforeDescendantDetach(this IUILogicalElement element, UIWidget widget) {
            if (element is UIWidget parent) {
                parent.OnBeforeDescendantDetachEvent?.Invoke( widget );
                parent.OnBeforeDescendantDetach( widget );
            } else
            if (element is UIScreen screen) {
                screen.OnBeforeDescendantWidgetDetachEvent?.Invoke( widget );
                screen.OnBeforeDescendantWidgetDetach( widget );
            }
        }
        public static void OnAfterDescendantDetach(this IUILogicalElement element, UIWidget widget) {
            if (element is UIWidget parent) {
                parent.OnAfterDescendantDetach( widget );
                parent.OnAfterDescendantDetachEvent?.Invoke( widget );
            } else
            if (element is UIScreen screen) {
                screen.OnAfterDescendantWidgetDetach( widget );
                screen.OnAfterDescendantWidgetDetachEvent?.Invoke( widget );
            }
        }

    }
}
