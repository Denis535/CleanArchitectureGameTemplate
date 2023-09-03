#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class UIScreenView : UIView {

        // Screen
        internal UIScreen? Screen { get; set; }

        // Constructor
        public UIScreenView() {
            AddToClassList( "screen-view" );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // ShowView
        public abstract void ShowView(UIWidgetView view, UIWidgetView[] shadowed);
        public abstract void HideView(UIWidgetView view, UIWidgetView[] unshadowed);

        // Helpers
        protected static VisualElement CreateViewsContainer() {
            var viewsContainer = new VisualElement().SetUp( "views-container", "views-container" );
            viewsContainer.pickingMode = PickingMode.Ignore;
            return viewsContainer;
        }
        protected static VisualElement CreateModalViewsContainer() {
            var modalViewsContainer = new VisualElement().SetUp( "modal-views-container", "modal-views-container" );
            modalViewsContainer.pickingMode = PickingMode.Ignore;
            return modalViewsContainer;
        }
        // Helpers
        protected static void AddView(VisualElement container, UIWidgetView view, UIWidgetView? shadowed) {
            shadowed?.SetDisplayed( false );
            shadowed?.SetEnabled( false );
            container.Add( view );
        }
        protected static void RemoveView(VisualElement container, UIWidgetView view, UIWidgetView? unshadowed) {
            container.Remove( view );
            unshadowed?.SetEnabled( true );
            unshadowed?.SetDisplayed( true );
        }
        protected static void AddModalView(VisualElement container, UIWidgetView view, UIWidgetView? shadowed) {
            shadowed?.SetEnabled( false );
            container.Add( view );
        }
        protected static void RemoveModalView(VisualElement container, UIWidgetView view, UIWidgetView? unshadowed) {
            container.Remove( view );
            unshadowed?.SetEnabled( true );
        }

    }
}
