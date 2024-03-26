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
                if (widget.IsModal()) {
                    View.ModalWidgetSlot.Add( widget );
                } else {
                    View.WidgetSlot.Add( widget );
                }
                {
                    var prev = (UIWidgetBase?) View.WidgetSlot.Widgets.Concat( View.ModalWidgetSlot.Widgets ).SkipLast( 1 ).LastOrDefault();
                    if (prev != null) prev.__GetView__()!.__GetVisualElement__().SaveFocus();
                    RecalcVisibility( View );
                    var last = (UIWidgetBase?) View.WidgetSlot.Widgets.Concat( View.ModalWidgetSlot.Widgets ).LastOrDefault();
                    if (last != null) last.__GetView__()!.__GetVisualElement__().Focus2();
                }
            }
        }
        protected override void HideDescendantWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                if (widget.IsModal()) {
                    Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == View.ModalWidgetSlot.Widgets.LastOrDefault() );
                    View.ModalWidgetSlot.Remove( widget );
                } else {
                    Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == View.WidgetSlot.Widgets.LastOrDefault() );
                    View.WidgetSlot.Remove( widget );
                }
                {
                    RecalcVisibility( View );
                    var last = (UIWidgetBase?) View.WidgetSlot.Widgets.Concat( View.ModalWidgetSlot.Widgets ).LastOrDefault();
                    if (last != null) last.__GetView__()!.__GetVisualElement__().LoadFocus();
                }
            }
        }

        // Helpers
        //private static void Init(UIWidgetBase widget) {
        //    widget.__GetView__()!.__GetVisualElement__().OnAttachToPanel( evt => {
        //        widget.__GetView__()!.__GetVisualElement__().Focus2();
        //    } );
        //    widget.__GetView__()!.__GetVisualElement__().OnGeometryChanged( evt => {
        //        // this is not called when isEnabled becomes true !!!
        //        if (widget.IsEnabledInHierarchy()) {
        //            if (!widget.__GetView__()!.__GetVisualElement__().HasFocusedElement()) {
        //                widget.__GetView__()!.__GetVisualElement__().LoadFocus();
        //            }
        //        }
        //    }, TrickleDown.TrickleDown );
        //    widget.__GetView__()!.__GetVisualElement__().OnFocus( evt => {
        //        widget.__GetView__()!.__GetVisualElement__().SaveFocus();
        //    }, TrickleDown.TrickleDown );
        //}
        private static new void RecalcVisibility(RootWidgetViewBase view) {
            foreach (var widget in view.WidgetSlot.Widgets) {
                if (widget is not MainWidget and not GameWidget) {
                    RecalcWidgetVisibility( widget, widget == view.WidgetSlot.Widgets.Last(), view.ModalWidgetSlot.Widgets.Any() );
                }
            }
            foreach (var widget in view.ModalWidgetSlot.Widgets) {
                RecalcModalWidgetVisibility( widget, widget == view.ModalWidgetSlot.Widgets.Last() );
            }
        }

    }
}
