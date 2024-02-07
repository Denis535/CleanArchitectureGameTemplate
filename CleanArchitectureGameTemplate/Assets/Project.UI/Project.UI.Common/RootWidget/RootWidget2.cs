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

    public class RootWidget2 : RootWidgetBase<RootWidgetView> {

        // View
        protected override RootWidgetView View { get; }
        private List<UIWidgetBase> Widgets_ { get; } = new List<UIWidgetBase>();
        private List<UIWidgetBase> ModalWidgets_ { get; } = new List<UIWidgetBase>();
        public IReadOnlyList<UIWidgetBase> Widgets => Widgets_;
        public IReadOnlyList<UIWidgetBase> ModalWidgets => ModalWidgets_;

        // Constructor
        public RootWidget2() {
            View = CreateView();
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

        // ShowWidget
        protected override void ShowWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                if (widget.IsModal()) {
                    ModalWidgets_.Add( widget );
                    View.ModalWidgetSlot.Add( widget.GetVisualElement()! );
                } else {
                    Widgets_.Add( widget );
                    View.WidgetSlot.Add( widget.GetVisualElement()! );
                }
                {
                    var covered = (UIWidgetBase?) Widgets.Concat( ModalWidgets ).SkipLast( 1 ).LastOrDefault();
                    if (covered != null) SaveFocus( covered.GetVisualElement()! );
                    RecalcVisibility();
                    var newWidget = (UIWidgetBase?) Widgets.Concat( ModalWidgets ).LastOrDefault();
                    if (newWidget != null) Focus( newWidget.GetVisualElement()! );
                }
            }
        }
        protected override void HideWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                if (widget.IsModal()) {
                    Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == ModalWidgets.LastOrDefault() );
                    ModalWidgets_.Remove( widget );
                    View.ModalWidgetSlot.Remove( widget.GetVisualElement()! );
                } else {
                    Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == Widgets.LastOrDefault() );
                    Widgets_.Remove( widget );
                    View.WidgetSlot.Remove( widget.GetVisualElement()! );
                }
                {
                    RecalcVisibility();
                    var uncovered = (UIWidgetBase?) Widgets.Concat( ModalWidgets ).LastOrDefault();
                    if (uncovered != null) Focus( uncovered.GetVisualElement()! );
                }
            }
        }

        // RecalcVisibility
        private void RecalcVisibility() {
            foreach (var widget in Widgets.SkipLast( 1 )) {
                // hide covered widgets
                widget.GetVisualElement()!.SetEnabled( true );
                if (widget is not MainWidget and not GameWidget) widget.GetVisualElement()!.SetDisplayed( false );
            }
            if (Widgets.Any()) {
                // show new widget or unhide uncover widget
                var widget = Widgets.Last();
                widget.GetVisualElement()!.SetEnabled( !ModalWidgets.Any() );
                if (widget is not MainWidget and not GameWidget) widget.GetVisualElement()!.SetDisplayed( true );
            }
            foreach (var widget in ModalWidgets.SkipLast( 1 )) {
                // hide covered widgets
                widget.GetVisualElement()!.SetEnabled( true );
                widget.GetVisualElement()!.SetDisplayed( false );
            }
            if (ModalWidgets.Any()) {
                // show new widget or unhide uncover widget
                var widget = ModalWidgets.Last();
                widget.GetVisualElement()!.SetEnabled( true );
                widget.GetVisualElement()!.SetDisplayed( true );
            }
        }

        // Helpers
        private static RootWidgetView CreateView() {
            var view = new RootWidgetView();
            view.Widget.OnEvent<NavigationSubmitEvent>( evt => {
                if (evt.target is Button button) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            }, TrickleDown.NoTrickleDown );
            view.Widget.OnEvent<NavigationCancelEvent>( evt => {
                var widget = ((VisualElement) evt.target).GetAncestorsAndSelf().OfType<Widget>().FirstOrDefault();
                var button = widget?.Query<Button>().Where( i => i.name is "resume" or "cancel" or "cancellation" or "back" or "no" or "quit" ).First();
                if (button != null) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            }, TrickleDown.NoTrickleDown );
            return view;
        }

    }
}
