#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
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
        public override void OnAttach(object? argument) {
            base.OnAttach( argument );
        }
        public override void OnDetach(object? argument) {
            base.OnDetach( argument );
        }

        // OnBeforeDescendantAttach
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

        // AttachChild
        protected override void __AttachChild__(UIWidgetBase child, object? argument) {
            base.__AttachChild__( child, argument );
        }
        protected override void __DetachChild__(UIWidgetBase child, object? argument) {
            base.__DetachChild__( child, argument );
        }

        // ShowDescendantWidget
        protected override void ShowDescendantWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                var covered = (UIWidgetBase?) View.WidgetSlot.Widgets.Concat( View.ModalWidgetSlot.Widgets ).LastOrDefault();
                if (covered != null) covered.__GetView__()!.__GetVisualElement__().SaveFocus();

                if (widget.IsModal()) {
                    Add( View.ModalWidgetSlot, widget );
                } else {
                    Add( View.WidgetSlot, widget );
                }

                var @new = (UIWidgetBase?) View.WidgetSlot.Widgets.Concat( View.ModalWidgetSlot.Widgets ).LastOrDefault();
                if (@new != null) @new.__GetView__()!.__GetVisualElement__().Focus2();
            }
        }
        protected override void HideDescendantWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                if (widget.IsModal()) {
                    Remove( View.ModalWidgetSlot, widget );
                } else {
                    Remove( View.WidgetSlot, widget );
                }

                var uncovered = (UIWidgetBase?) View.WidgetSlot.Widgets.Concat( View.ModalWidgetSlot.Widgets ).LastOrDefault();
                if (uncovered != null) uncovered.__GetView__()!.__GetVisualElement__().LoadFocus();
            }
        }

        // Helpers
        private static void Add(WidgetListSlotWrapper<UIWidgetBase> slot, UIWidgetBase widget) {
            var last = slot.Widgets.LastOrDefault();
            if (last != null && last is not MainWidget and not GameWidget) slot.__GetVisualElement__().Remove( last.__GetView__()!.__GetVisualElement__() );
            slot.Add( widget );
        }
        private static void Remove(WidgetListSlotWrapper<UIWidgetBase> slot, UIWidgetBase widget) {
            Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == slot.Widgets.LastOrDefault() );
            slot.Remove( widget );
            var last = slot.Widgets.LastOrDefault();
            if (last != null && last is not MainWidget and not GameWidget) slot.__GetVisualElement__().Add( last.__GetView__()!.__GetVisualElement__() );
        }

    }
}
