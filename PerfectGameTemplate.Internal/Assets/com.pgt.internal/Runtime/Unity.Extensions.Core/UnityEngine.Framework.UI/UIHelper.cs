#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    internal static class UIHelper {

        // GetAncestors
        public static List<UIWidgetBase> GetAncestors(this UIWidgetBase widget, List<UIWidgetBase>? result = null) {
            result ??= new List<UIWidgetBase>();
            while (widget.Parent != null) {
                result.Add( widget.Parent );
                widget = widget.Parent;
            }
            return result;
        }
        public static List<UIWidgetBase> GetAncestorsAndSelf(this UIWidgetBase widget, List<UIWidgetBase>? result = null) {
            result ??= new List<UIWidgetBase>();
            result.Add( widget );
            GetAncestors( widget, result );
            return result;
        }

        // GetDescendants
        public static List<UIWidgetBase> GetDescendants(this UIWidgetBase widget, List<UIWidgetBase>? result = null) {
            result ??= new List<UIWidgetBase>();
            foreach (var child in widget.Children) {
                result.Add( child );
                GetDescendants( child, result );
            }
            return result;
        }
        public static List<UIWidgetBase> GetDescendantsAndSelf(this UIWidgetBase widget, List<UIWidgetBase>? result = null) {
            result ??= new List<UIWidgetBase>();
            result.Add( widget );
            GetDescendants( widget, result );
            return result;
        }

        // OnBeforeDescendantAttach
        public static void OnBeforeDescendantAttach(this IUILogicalElement element, UIWidgetBase widget) {
            if (element is UIWidgetBase parent) {
                parent.OnBeforeDescendantAttachEvent?.Invoke( widget );
                parent.OnBeforeDescendantAttach( widget );
            } else
            if (element is UIScreenBase screen) {
                screen.OnBeforeDescendantWidgetAttachEvent?.Invoke( widget );
                screen.OnBeforeDescendantWidgetAttach( widget );
            }
        }
        public static void OnAfterDescendantAttach(this IUILogicalElement element, UIWidgetBase widget) {
            if (element is UIWidgetBase parent) {
                parent.OnAfterDescendantAttach( widget );
                parent.OnAfterDescendantAttachEvent?.Invoke( widget );
            } else
            if (element is UIScreenBase screen) {
                screen.OnAfterDescendantWidgetAttach( widget );
                screen.OnAfterDescendantWidgetAttachEvent?.Invoke( widget );
            }
        }
        public static void OnBeforeDescendantDetach(this IUILogicalElement element, UIWidgetBase widget) {
            if (element is UIWidgetBase parent) {
                parent.OnBeforeDescendantDetachEvent?.Invoke( widget );
                parent.OnBeforeDescendantDetach( widget );
            } else
            if (element is UIScreenBase screen) {
                screen.OnBeforeDescendantWidgetDetachEvent?.Invoke( widget );
                screen.OnBeforeDescendantWidgetDetach( widget );
            }
        }
        public static void OnAfterDescendantDetach(this IUILogicalElement element, UIWidgetBase widget) {
            if (element is UIWidgetBase parent) {
                parent.OnAfterDescendantDetach( widget );
                parent.OnAfterDescendantDetachEvent?.Invoke( widget );
            } else
            if (element is UIScreenBase screen) {
                screen.OnAfterDescendantWidgetDetach( widget );
                screen.OnAfterDescendantWidgetDetachEvent?.Invoke( widget );
            }
        }

    }
}
