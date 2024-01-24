#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class RootWidget2 : RootWidgetBase<RootWidgetView> {

        // View
        public override RootWidgetView View { get; }

        // Constructor
        public RootWidget2() {
            View = new RootWidgetView();
            View.Widget.OnEventTrickleDown<NavigationSubmitEvent>( evt => {
                if (evt.target is Button button) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            } );
            View.Widget.OnEventTrickleDown<NavigationCancelEvent>( evt => {
                var widget = ((VisualElement) evt.target).GetAncestorsAndSelf().OfType<Widget>().FirstOrDefault();
                var button = widget?.Query<Button>().Where( i => i.name is "resume" or "cancel" or "cancellation" or "back" or "no" or "quit" ).First();
                if (button != null) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            } );
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
            // cover last widget
            if (!widget.IsModal()) {
                // cover last normal widget
                var last = (VisualElement?) View.WidgetSlot.Children.LastOrDefault();
                if (last != null) {
                    SaveFocus( last );
                    if (last.name is not "main-widget" and not "game-widget") last.SetDisplayed( false );
                }
            } else {
                // if you have any modal widget
                // then cover last modal widget
                // otherwise cover last normal widget
                if (View.ModalWidgetSlot.Children.Any()) {
                    var last = (VisualElement?) View.ModalWidgetSlot.Children.LastOrDefault();
                    if (last != null) {
                        SaveFocus( last );
                        last.SetDisplayed( false );
                    }
                } else {
                    var last = (VisualElement?) View.WidgetSlot.Children.LastOrDefault();
                    if (last != null) {
                        SaveFocus( last );
                        if (last.name is not "main-widget" and not "game-widget") last.SetEnabled( false );
                    }
                }
            }
            // show widget
            if (!widget.IsModal()) {
                View.WidgetSlot.Add( widget.View!.VisualElement );
                SetFocus( widget.View!.VisualElement );
            } else {
                View.ModalWidgetSlot.Add( widget.View!.VisualElement );
                SetFocus( widget.View!.VisualElement );
            }
        }
        protected override void HideWidget(UIWidgetBase widget) {
            // hide widget
            if (!widget.IsModal()) {
                Assert.Operation.Message( $"You can remove only last widget in widget slot" ).Valid( View.WidgetSlot.Children.LastOrDefault() == widget.View!.VisualElement );
                View.WidgetSlot.Remove( widget.View.VisualElement );
            } else {
                Assert.Operation.Message( $"You can remove only last widget in modal widget slot" ).Valid( View.ModalWidgetSlot.Children.LastOrDefault() == widget.View!.VisualElement );
                View.ModalWidgetSlot.Remove( widget.View.VisualElement );
            }
            // uncover last widget
            if (!widget.IsModal()) {
                // uncover last normal widget
                var last = (VisualElement?) View.WidgetSlot.Children.LastOrDefault();
                if (last != null) {
                    if (last.name is not "main-widget" and not "game-widget") last.SetDisplayed( true );
                    LoadFocus( last );
                }
            } else {
                // if you have any modal widget
                // then uncover last modal widget
                // otherwise uncover last normal widget
                if (View.ModalWidgetSlot.Children.Any()) {
                    var last = (VisualElement?) View.ModalWidgetSlot.Children.LastOrDefault();
                    if (last != null) {
                        last.SetDisplayed( true );
                        LoadFocus( last );
                    }
                } else {
                    var last = (VisualElement?) View.WidgetSlot.Children.LastOrDefault();
                    if (last != null) {
                        if (last.name is not "main-widget" and not "game-widget") last.SetEnabled( true );
                        LoadFocus( last );
                    }
                }
            }
        }

    }
}
