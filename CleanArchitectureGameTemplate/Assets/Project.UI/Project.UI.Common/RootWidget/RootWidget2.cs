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
        public override void OnAttach() {
            base.OnAttach();
        }
        public override void OnDetach() {
            base.OnDetach();
        }

        // ShowWidget
        protected override void ShowWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                OnShowWidget( widget );
                OnChanged();
            }
        }
        protected override void HideWidget(UIWidgetBase widget) {
            if (widget.IsViewable) {
                OnHideWidget( widget );
                OnChanged();
            }
        }

        // OnShowWidget
        private void OnShowWidget(UIWidgetBase widget) {
            if (widget.IsModal()) {
                ModalWidgets_.Add( widget );
                View.ModalWidgetSlot.Add( widget.GetVisualElement()! );
            } else {
                Widgets_.Add( widget );
                View.WidgetSlot.Add( widget.GetVisualElement()! );
            }
        }
        private void OnHideWidget(UIWidgetBase widget) {
            if (widget.IsModal()) {
                Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == ModalWidgets.LastOrDefault() );
                ModalWidgets_.Remove( widget );
                View.ModalWidgetSlot.Remove( widget.GetVisualElement()! );
            } else {
                Assert.Operation.Message( $"Widget {widget} must be last" ).Valid( widget == Widgets.LastOrDefault() );
                Widgets_.Remove( widget );
                View.WidgetSlot.Remove( widget.GetVisualElement()! );
            }
        }

        // OnChanged
        private void OnChanged() {
            foreach (var widget in Widgets) {
                if (widget is not MainWidget and not GameWidget) {
                    widget.GetVisualElement()!.SetEnabled( !ModalWidgets.Any() );
                    widget.GetVisualElement()!.SetDisplayed( widget == Widgets.LastOrDefault() );
                }
            }
            foreach (var widget in ModalWidgets) {
                widget.GetVisualElement()!.SetDisplayed( widget == ModalWidgets.LastOrDefault() );
            }
        }

        // Helpers
        private static RootWidgetView CreateView() {
            var view = new RootWidgetView();
            view.Widget.OnEventTrickleDown<NavigationSubmitEvent>( evt => {
                if (evt.target is Button button) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            } );
            view.Widget.OnEventTrickleDown<NavigationCancelEvent>( evt => {
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
            return view;
        }

    }
}
