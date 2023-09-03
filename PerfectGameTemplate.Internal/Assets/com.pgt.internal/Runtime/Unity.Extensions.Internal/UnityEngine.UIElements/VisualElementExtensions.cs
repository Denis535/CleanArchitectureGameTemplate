#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static partial class VisualElementExtensions {

        // IsAttached
        public static bool IsAttached(this VisualElement element) {
            return element.panel != null;
        }

        // IsDisplayed
        public static bool IsDisplayed(this VisualElement element) {
            return element.style.display == DisplayStyle.Flex;
        }
        public static void SetDisplayed(this VisualElement element, bool value) {
            if (value) {
                element.style.display = DisplayStyle.Flex;
            } else {
                element.style.display = DisplayStyle.None;
            }
        }

        // IsValid
        public static bool IsValid(this VisualElement element) {
            return !element.ClassListContains( "invalid" );
        }
        public static void SetValid(this VisualElement element, bool value) {
            if (value) {
                element.RemoveFromClassList( "invalid" );
            } else {
                element.AddToClassList( "invalid" );
            }
        }

        // SetUp
        public static T SetUp<T>(this T element, string? name, params string[] classes) where T : VisualElement {
            element.name = name;
            foreach (var @class in classes) {
                element.AddToClassList( @class );
            }
            return element;
        }
        public static T Text<T>(this T element, string text) where T : TextElement {
            element.text = text;
            return element;
        }
        public static T UserData<T>(this T element, object? userData) where T : VisualElement {
            element.userData = userData;
            return element;
        }
        public static T Children<T>(this T element, params VisualElement[] children) where T : VisualElement {
            foreach (var child in children) {
                element.Add( child );
            }
            return element;
        }

        // OnEvent/TrickleDown
        public static void OnEventTrickleDown<TEvt>(this VisualElement element, EventCallback<TEvt> callback) where TEvt : EventBase<TEvt>, new() {
            element.RegisterCallback( callback, TrickleDown.TrickleDown );
        }
        public static void OnEventTrickleDown<TEvt, TArg>(this VisualElement element, EventCallback<TEvt, TArg> callback, TArg arg) where TEvt : EventBase<TEvt>, new() {
            element.RegisterCallback( callback, arg, TrickleDown.TrickleDown );
        }

        // OnEvent/NoTrickleDown
        public static void OnEvent<TEvt>(this VisualElement element, EventCallback<TEvt> callback) where TEvt : EventBase<TEvt>, new() {
            element.RegisterCallback( callback, TrickleDown.NoTrickleDown );
        }
        public static void OnEvent<TEvt, TArg>(this VisualElement element, EventCallback<TEvt, TArg> callback, TArg arg) where TEvt : EventBase<TEvt>, new() {
            element.RegisterCallback( callback, arg, TrickleDown.NoTrickleDown );
        }

        // OnAttachToPanel
        public static void OnAttachToPanel(this VisualElement element, EventCallback<AttachToPanelEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnDetachFromPanel(this VisualElement element, EventCallback<DetachFromPanelEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnFocus
        public static void OnFocus(this VisualElement element, EventCallback<FocusEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnFocusIn(this VisualElement element, EventCallback<FocusInEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnFocusOut(this VisualElement element, EventCallback<FocusOutEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnMouse
        public static void OnMouseOver(this VisualElement element, EventCallback<MouseOverEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnMouseOut(this VisualElement element, EventCallback<MouseOutEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnMouse
        public static void OnMouseEnter(this VisualElement element, EventCallback<MouseEnterEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnMouseLeave(this VisualElement element, EventCallback<MouseLeaveEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnMouse
        public static void OnMouseDown(this VisualElement element, EventCallback<MouseDownEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnMouseMove(this VisualElement element, EventCallback<MouseMoveEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnMouseUp(this VisualElement element, EventCallback<MouseUpEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnClick
        public static void OnClick(this VisualElement element, EventCallback<ClickEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnClickOrSubmit(this VisualElement element, EventCallback<EventBase> callback) {
            element.RegisterCallback( (EventCallback<ClickEvent>) callback );
            element.RegisterCallback( (EventCallback<NavigationSubmitEvent>) callback );
        }

        // OnChange
        public static void OnChange<T>(this VisualElement element, EventCallback<ChangeEvent<T>> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnChange<T>(this BaseField<T> element, EventCallback<ChangeEvent<T>> callback) {
            element.RegisterCallback( callback );
        }

        // OnSubmit
        public static void OnSubmit(this VisualElement element, EventCallback<NavigationSubmitEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnCancel(this VisualElement element, EventCallback<NavigationCancelEvent> callback) {
            element.RegisterCallback( callback );
        }

        // Focus
        public static bool IsFocused(this VisualElement element) {
            Assert.Internal.Message( $"Element {element} must be attached" ).Valid( element.panel != null );
            return element == element.focusController.focusedElement;
        }
        public static void SetFocus(this VisualElement element) {
            Assert.Internal.Message( $"Element {element} must be attached" ).Valid( element.panel != null );
            if (element.focusable) {
                element.Focus();
            } else {
                element.focusable = true;
                element.delegatesFocus = true;
                element.Focus();
                element.delegatesFocus = false;
                element.focusable = false;
            }
        }
        public static void LoadFocus(this VisualElement element) {
            Assert.Internal.Message( $"Element {element} must be attached" ).Valid( element.panel != null );
            var focusable = (VisualElement?) element.userData;
            if (focusable != null) {
                focusable.Focus();
            }
        }
        public static void SaveFocus(this VisualElement element) {
            Assert.Internal.Message( $"Element {element} must be attached" ).Valid( element.panel != null );
            var focusable = (VisualElement?) element.focusController.focusedElement;
            if (focusable != null && (element == focusable || element.Contains( focusable ))) {
                element.userData = focusable;
            } else {
                element.userData = null;
            }
        }

    }
}
