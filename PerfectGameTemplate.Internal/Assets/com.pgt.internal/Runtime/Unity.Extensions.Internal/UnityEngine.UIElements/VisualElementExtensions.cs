#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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

        // IsSubmit
        public static bool IsSubmit(this Button button) {
            return button.name is "submit" or "submission" or "confirm" or "confirmation" or "okey" or "ok" or "yes";
        }
        public static bool IsCancel(this Button button) {
            return button.name is "cancel" or "cancellation" or "back" or "no";
        }
        public static bool IsQuit(this Button button) {
            return button.name is "quit";
        }

        // SetUp
        public static T Text<T>(this T element, string? text) where T : TextElement {
            element.text = text;
            return element;
        }
        public static T Name<T>(this T element, string? name) where T : VisualElement {
            element.name = name;
            return element;
        }
        public static T Classes<T>(this T element, params string[] classes) where T : VisualElement {
            foreach (var @class in classes.SelectMany( i => i.Split( '.' ) )) {
                element.AddToClassList( @class.Trim() );
            }
            return element;
        }
        public static T UserData<T>(this T element, object? userData) where T : VisualElement {
            element.userData = userData;
            return element;
        }
        public static T Children<T>(this T element, params VisualElement?[] children) where T : VisualElement {
            foreach (var child in children) {
                if (child != null) {
                    element.Add( child );
                }
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
        public static void OnFocusIn(this VisualElement element, EventCallback<FocusInEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnFocus(this VisualElement element, EventCallback<FocusEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnFocusOut(this VisualElement element, EventCallback<FocusOutEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnMouse
        public static void OnMouseOver(this VisualElement element, EventCallback<MouseOverEvent> callback) {
            element.RegisterCallback( callback ); // Event sent when the mouse pointer enters an element.
        }
        public static void OnMouseOut(this VisualElement element, EventCallback<MouseOutEvent> callback) {
            element.RegisterCallback( callback ); // Event sent when the mouse pointer exits an element.
        }

        // OnMouse
        public static void OnMouseEnter(this VisualElement element, EventCallback<MouseEnterEvent> callback) {
            element.RegisterCallback( callback ); // Event sent when the mouse pointer enters an element or one of its descendent elements.
        }
        public static void OnMouseLeave(this VisualElement element, EventCallback<MouseLeaveEvent> callback) {
            element.RegisterCallback( callback ); // Event sent when the mouse pointer exits an element and all its descendent elements.
        }

        // OnMouse
        public static void OnMouseDown(this VisualElement element, EventCallback<MouseDownEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnMouseUp(this VisualElement element, EventCallback<MouseUpEvent> callback) {
            element.RegisterCallback( callback );
        }
        public static void OnMouseMove(this VisualElement element, EventCallback<MouseMoveEvent> callback) {
            element.RegisterCallback( callback );
        }

        // OnClick
        public static void OnClick(this VisualElement element, EventCallback<ClickEvent> callback) {
            element.RegisterCallback( callback );
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

    }
}
