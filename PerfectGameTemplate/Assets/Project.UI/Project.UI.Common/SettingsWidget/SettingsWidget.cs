﻿#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class SettingsWidget : UIWidgetBase<SettingsWidgetView> {

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
        private static SettingsWidgetView CreateView(UIWidgetBase widget) {
            var view = UIViewFactory.SettingsWidget();
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
