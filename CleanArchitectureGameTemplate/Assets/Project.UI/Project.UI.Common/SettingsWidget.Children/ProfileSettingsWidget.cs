﻿#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class ProfileSettingsWidget : UIWidgetBase<ProfileSettingsWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private Storage.ProfileSettings ProfileSettings { get; }

        // Constructor
        public ProfileSettingsWidget() {
            Factory = Factory = Utils.Container.RequireDependency<UIFactory>( null );
            ProfileSettings = Utils.Container.RequireDependency<Storage.ProfileSettings>( null );
            View = CreateView( this, Factory, ProfileSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
        }
        public override void OnDetach(object? argument) {
            if (argument is DetachReason.Submit) {
                ProfileSettings.Name = View.Name.Value!;
                ProfileSettings.Save();
            } else {
                ProfileSettings.Load();
            }
        }

        // Helpers
        private static ProfileSettingsWidgetView CreateView(ProfileSettingsWidget widget, UIFactory factory, Storage.ProfileSettings profileSettings) {
            var view = new ProfileSettingsWidgetView( factory );
            view.Group.OnAttachToPanel( evt => {
                view.Name.Value = profileSettings.Name;
                view.Name.SetValid( profileSettings.IsNameValid( view.Name.Value ) );
            } );
            view.Name.OnChange( evt => {
                view.Name.SetValid( profileSettings.IsNameValid( evt.newValue! ) );
            } );
            return view;
        }

    }
}
