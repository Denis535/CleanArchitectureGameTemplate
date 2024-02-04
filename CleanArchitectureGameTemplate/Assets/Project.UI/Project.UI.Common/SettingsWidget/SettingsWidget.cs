#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class SettingsWidget : UIWidgetBase<SettingsWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // View
        protected override SettingsWidgetView View { get; }
        // Children
        private AccountSettingsWidget AccountSettingsWidget { get; }
        private VideoSettingsWidget VideoSettingsWidget { get; }
        private AudioSettingsWidget AudioSettingsWidget { get; }

        // Constructor
        public SettingsWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = CreateView( this, Factory );
            this.AttachChild( AccountSettingsWidget = new AccountSettingsWidget() );
            this.AttachChild( VideoSettingsWidget = new VideoSettingsWidget() );
            this.AttachChild( AudioSettingsWidget = new AudioSettingsWidget() );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

        // ShowWidget
        protected override void ShowWidget(UIWidgetBase widget) {
            if (widget is AccountSettingsWidget) {
                View.AccountSettingsSlot.Add( widget.GetVisualElement()! );
                return;
            }
            if (widget is VideoSettingsWidget) {
                View.VideoSettingsSlot.Add( widget.GetVisualElement()! );
                return;
            }
            if (widget is AudioSettingsWidget) {
                View.AudioSettingsSlot.Add( widget.GetVisualElement()! );
                return;
            }
            base.ShowWidget( widget );
        }
        protected override void HideWidget(UIWidgetBase widget) {
            if (widget is AccountSettingsWidget) {
                View.AccountSettingsSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            if (widget is VideoSettingsWidget) {
                View.VideoSettingsSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            if (widget is AudioSettingsWidget) {
                View.AudioSettingsSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            base.HideWidget( widget );
        }

        // Helpers
        private static SettingsWidgetView CreateView(SettingsWidget widget, UIFactory factory) {
            var view = new SettingsWidgetView( factory );
            view.Okey.OnClick( () => {
                widget.DetachSelf();
            } );
            view.Back.OnClick( () => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
