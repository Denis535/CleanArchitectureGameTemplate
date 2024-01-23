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
        public override SettingsWidgetView View { get; }

        // Constructor
        public SettingsWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = CreateView( this, Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

        // Helpers
        private static SettingsWidgetView CreateView(SettingsWidget widget, UIFactory factory) {
            var view = new SettingsWidgetView( factory );
            view.PlayerProfile.OnClick( () => {
                widget.AttachChild( new PlayerProfileWidget() );
            } );
            view.VideoSettings.OnClick( () => {
                widget.AttachChild( new VideoSettingsWidget() );
            } );
            view.AudioSettings.OnClick( () => {
                widget.AttachChild( new AudioSettingsWidget() );
            } );
            view.Back.OnClick( () => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
