#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class UIRootWidget2 : UIRootWidget {

        // Constructor
        public UIRootWidget2() {
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
            base.ShowDescendantWidget( widget );
        }
        protected override void HideDescendantWidget(UIWidgetBase widget) {
            base.HideDescendantWidget( widget );
        }

        // ShowDescendantWidget
        protected override void ShowDescendantWidget(WidgetListSlotWrapper<UIWidgetBase> slot, UIWidgetBase widget) {
            var covered = slot.Widgets.LastOrDefault();
            if (covered != null && covered is not MainWidget and not GameWidget) {
                slot.__GetVisualElement__().Remove( covered.__GetView__()!.__GetVisualElement__() );
            }
            slot.Add( widget );
        }
        protected override void HideDescendantWidget(WidgetListSlotWrapper<UIWidgetBase> slot, UIWidgetBase widget) {
            Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == slot.Widgets.LastOrDefault() );
            slot.Remove( widget );
            var uncovered = slot.Widgets.LastOrDefault();
            if (uncovered != null && uncovered is not MainWidget and not GameWidget) {
                slot.__GetVisualElement__().Add( uncovered.__GetView__()!.__GetVisualElement__() );
            }
        }

        // Update
        public void Update() {
            foreach (var child in Children) {
                (child as MainWidget)?.Update();
                (child as GameWidget)?.Update();
            }
        }

    }
}
