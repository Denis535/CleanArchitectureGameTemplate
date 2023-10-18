#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class SettingsWidget : UIWidgetBase<SettingsWidgetView> {

        // View
        public override SettingsWidgetView View { get; }

        // Constructor
        public SettingsWidget() {
            View = CreateView( this );
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
        private static SettingsWidgetView CreateView(SettingsWidget widget) {
            var view = UIViewFactory.SettingsWidget( widget );
            view.PlayerProfile.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.PlayerProfileWidget() );
            } );
            view.VideoSettings.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.VideoSettingsWidget() );
            } );
            view.AudioSettings.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.AudioSettingsWidget() );
            } );
            view.Back.OnClick( i => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
