#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class SettingsWidget : UIWidgetBase<SettingsWidgetView> {

        // Constructor
        public SettingsWidget() {
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
        }

        // Helpers
        private SettingsWidgetView CreateView() {
            var view = UIVisualFactory.SettingsWidget();
            view.OnCommand( (SettingsWidgetView.PlayerProfileCommand cmd) => {
                this.AttachChild( UILogicalFactory.PlayerProfileWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.VideoSettingsCommand cmd) => {
                this.AttachChild( UILogicalFactory.VideoSettingsWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.AudioSettingsCommand cmd) => {
                this.AttachChild( UILogicalFactory.AudioSettingsWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
