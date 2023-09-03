﻿#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class SettingsWidget : UIWidget2<SettingsWidgetView> {

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

        // Helpers/View
        private SettingsWidgetView CreateView() {
            var view = UIVisualFactory.SettingsWidget();
            view.OnCommand( (SettingsWidgetView.PlayerProfileCommand cmd) => {
                Router.AttachChild( UILogicalFactory.PlayerProfileWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.VideoSettingsCommand cmd) => {
                Router.AttachChild( UILogicalFactory.VideoSettingsWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.AudioSettingsCommand cmd) => {
                Router.AttachChild( UILogicalFactory.AudioSettingsWidget() );
            } );
            view.OnCommand( (SettingsWidgetView.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (SettingsWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (SettingsWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
