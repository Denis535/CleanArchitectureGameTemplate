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
    using UnityEngine.UIElements;

    public class UIScreenView : UIScreenViewBase {

        // VisualElement
        public override VisualElement VisualElement { get; }
        public ElementWrapper Screen { get; }
        public ElementWrapper Container { get; }
        public ElementWrapper ModalContainer { get; }

        // Constructor
        public UIScreenView(UIFactory factory) {
            VisualElement = factory.Screen( out var screen, out var container, out var modalContainer );
            Screen = screen.Wrap();
            Container = container.Wrap();
            ModalContainer = modalContainer.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // ShowWidget
        public override void ShowWidget(UIWidgetViewBase widget, UIWidgetViewBase[] shadowed) {
            var shadowed_ = shadowed.LastOrDefault();
            if (shadowed_ is MainWidgetView or GameWidgetView || shadowed_.IsModal()) {
                ShowWidget( widget, null );
            } else {
                ShowWidget( widget, shadowed_ );
            }
        }
        public override void HideWidget(UIWidgetViewBase widget, UIWidgetViewBase[] unshadowed) {
            var unshadowed_ = unshadowed.LastOrDefault();
            if (unshadowed_ is MainWidgetView or GameWidgetView || unshadowed_.IsModal()) {
                HideWidget( widget, null );
            } else {
                HideWidget( widget, unshadowed_ );
            }
        }

        // ShowWidget
        private void ShowWidget(UIWidgetViewBase widget, UIWidgetViewBase? shadowed) {
            if (shadowed != null) {
                SaveFocus( shadowed.VisualElement );
            }
            if (!widget.IsModal()) {
                AddWidget( Container.VisualElement, widget.VisualElement, shadowed?.VisualElement );
            } else {
                AddModalWidget( ModalContainer.VisualElement, widget.VisualElement, shadowed?.VisualElement );
            }
            SetFocus( widget.VisualElement );
        }
        private void HideWidget(UIWidgetViewBase widget, UIWidgetViewBase? unshadowed) {
            if (!widget.IsModal()) {
                RemoveWidget( Container.VisualElement, widget.VisualElement, unshadowed?.VisualElement );
            } else {
                RemoveModalWidget( ModalContainer.VisualElement, widget.VisualElement, unshadowed?.VisualElement );
            }
            if (unshadowed != null) {
                LoadFocus( unshadowed.VisualElement );
            }
        }

    }
}
