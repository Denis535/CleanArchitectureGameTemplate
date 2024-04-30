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
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant, object? argument) {
            base.OnBeforeDescendantAttach( descendant, argument );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant, object? argument) {
            base.OnAfterDescendantAttach( descendant, argument );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant, object? argument) {
            base.OnBeforeDescendantDetach( descendant, argument );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant, object? argument) {
            base.OnAfterDescendantDetach( descendant, argument );
        }

        // AttachChild
        public override void AttachChild(UIWidgetBase child, object? argument = null) {
            base.AttachChild( child, argument );
        }
        public override void DetachChild(UIWidgetBase child, object? argument = null) {
            base.DetachChild( child, argument );
        }

        // ShowWidget
        public override void ShowWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                if (widget.IsModal()) {
                    View.WidgetSlot.SetEnabled( false );
                    Push( View.ModalWidgetSlot, widget, i => i is not MainWidget and not GameWidget );
                } else {
                    Push( View.WidgetSlot, widget, i => true );
                }
            }
        }
        public override void HideWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                if (widget.IsModal()) {
                    Pop( View.ModalWidgetSlot, widget, i => i is not MainWidget and not GameWidget );
                    View.WidgetSlot.SetEnabled( !View.ModalWidgetSlot.Children.Any() );
                } else {
                    Pop( View.WidgetSlot, widget, i => true );
                }
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
