#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class RootWidget2 : RootWidget {

        // Constructor
        public RootWidget2() {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            base.OnAttach();
        }
        public override void OnDetach() {
            base.OnDetach();
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            base.OnAfterDescendantDetach( descendant );
        }

        // ShowWidget
        protected override void ShowWidget(UIWidgetBase widget) {
            base.ShowWidget( widget );
        }
        protected override void HideWidget(UIWidgetBase widget) {
            base.HideWidget( widget );
        }

        // OnShowWidget
        protected override void OnShowWidget(UIWidgetBase widget) {
            if (!widget.IsModal()) {
                var covered = View.WidgetSlot.Children.SkipLast( 1 ).LastOrDefault();
                if (covered?.name is not "main-widget" and not "game-widget") covered?.SetDisplayed( false );
            } else {
                View.WidgetSlot.IsEnabled = false;
                var covered = View.ModalWidgetSlot.Children.SkipLast( 1 ).LastOrDefault();
                covered?.SetDisplayed( false );
            }
        }
        protected override void OnHideWidget(UIWidgetBase widget) {
            if (!widget.IsModal()) {
                var uncovered = View.WidgetSlot.Children.SkipLast( 1 ).LastOrDefault();
                if (uncovered?.name is not "main-widget" and not "game-widget") uncovered?.SetDisplayed( true );
            } else {
                View.WidgetSlot.IsEnabled = !View.ModalWidgetSlot.Children.Any( i => i != widget.View!.VisualElement );
                var uncovered = View.ModalWidgetSlot.Children.SkipLast( 1 ).LastOrDefault();
                uncovered?.SetDisplayed( true );
            }
        }

    }
}
