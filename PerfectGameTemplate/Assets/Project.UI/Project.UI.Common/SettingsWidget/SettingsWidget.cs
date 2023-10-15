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
            view.OnCommand( (SettingsWidgetView.PlayerProfileCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.PlayerProfileWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.VideoSettingsCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.VideoSettingsWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.AudioSettingsCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.AudioSettingsWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
