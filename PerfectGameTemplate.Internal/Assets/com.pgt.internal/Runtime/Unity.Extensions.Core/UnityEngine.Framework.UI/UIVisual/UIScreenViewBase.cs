#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class UIScreenViewBase : UIViewBase {

        // Screen
        internal UIScreenBase Screen { get; }

        // Constructor
        public UIScreenViewBase(UIScreenBase screen, IUIObservable? observable) : base( observable ) {
            Screen = screen;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // ShowView
        public abstract void ShowView(UIWidgetViewBase view, UIWidgetViewBase[] shadowed);
        public abstract void HideView(UIWidgetViewBase view, UIWidgetViewBase[] unshadowed);

        // Helpers/CreateViewsContainer
        protected static VisualElement CreateViewsContainer() {
            var viewsContainer = new VisualElement().Name( "views-container" ).Classes( "views-container" );
            viewsContainer.pickingMode = PickingMode.Ignore;
            return viewsContainer;
        }
        protected static VisualElement CreateModalViewsContainer() {
            var modalViewsContainer = new VisualElement().Name( "modal-views-container" ).Classes( "modal-views-container" );
            modalViewsContainer.pickingMode = PickingMode.Ignore;
            return modalViewsContainer;
        }
        // Helpers/AddView
        protected static void AddView(VisualElement container, VisualElement view, VisualElement? shadowed) {
            shadowed?.SetDisplayed( false );
            shadowed?.SetEnabled( false );
            container.Add( view );
        }
        protected static void AddModalView(VisualElement container, VisualElement view, VisualElement? shadowed) {
            shadowed?.SetEnabled( false );
            container.Add( view );
        }
        protected static void RemoveView(VisualElement container, VisualElement view, VisualElement? unshadowed) {
            container.Remove( view );
            unshadowed?.SetEnabled( true );
            unshadowed?.SetDisplayed( true );
        }
        protected static void RemoveModalView(VisualElement container, VisualElement view, VisualElement? unshadowed) {
            container.Remove( view );
            unshadowed?.SetEnabled( true );
        }
        // Helpers/Focus
        protected static void SetFocus(VisualElement view) {
            Assert.Object.Message( $"View {view} must be attached" ).Valid( view.panel != null );
            if (view.focusable) {
                view.Focus();
            } else {
                view.focusable = true;
                view.delegatesFocus = true;
                view.Focus();
                view.delegatesFocus = false;
                view.focusable = false;
            }
        }
        protected static void LoadFocus(VisualElement view) {
            Assert.Object.Message( $"View {view} must be attached" ).Valid( view.panel != null );
            var focusedElement = (VisualElement?) view.userData;
            if (focusedElement != null) {
                focusedElement.Focus();
            }
        }
        protected static void SaveFocus(VisualElement view) {
            Assert.Object.Message( $"View {view} must be attached" ).Valid( view.panel != null );
            var focusedElement = (VisualElement?) view.focusController.focusedElement;
            if (focusedElement != null && (view == focusedElement || view.Contains( focusedElement ))) {
                view.userData = focusedElement;
            } else {
                view.userData = null;
            }
        }

    }
}
