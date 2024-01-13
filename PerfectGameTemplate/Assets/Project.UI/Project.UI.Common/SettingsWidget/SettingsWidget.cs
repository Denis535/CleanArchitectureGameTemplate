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
        public override void OnBeforeAttach() {
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
        }

        // Helpers
        private static SettingsWidgetView CreateView(SettingsWidget widget, UIFactory factory) {
            var view = new SettingsWidgetView( widget, factory );
            view.PlayerProfile.OnClick( i => {
                widget.AttachChild( new PlayerProfileWidget() );
            } );
            view.VideoSettings.OnClick( i => {
                widget.AttachChild( new VideoSettingsWidget() );
            } );
            view.AudioSettings.OnClick( i => {
                widget.AttachChild( new AudioSettingsWidget() );
            } );
            view.Back.OnClick( i => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
