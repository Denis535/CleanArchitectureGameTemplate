﻿#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class AccountSettingsWidget : UIWidgetBase<AccountSettingsWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private Globals.AccountSettings AccountSettings { get; }
        // View
        protected override AccountSettingsWidgetView View { get; }

        // Constructor
        public AccountSettingsWidget() {
            Factory = Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            AccountSettings = this.GetDependencyContainer().Resolve<Globals.AccountSettings>( null );
            View = CreateView( this, Factory, AccountSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

        // Submit
        public void Submit() {
            AccountSettings.PlayerName = View.Name.Value!;
            AccountSettings.Save();
        }
        public void Cancel() {
            AccountSettings.Load();
        }

        // Helpers
        private static AccountSettingsWidgetView CreateView(AccountSettingsWidget widget, UIFactory factory, Globals.AccountSettings accountSettings) {
            var view = new AccountSettingsWidgetView( factory );
            view.Scope.OnAttachToPanel( () => {
                view.Name.Value = accountSettings.PlayerName;
                view.Name.IsValid = accountSettings.IsNameValid( view.Name.Value );
            } );
            view.Name.OnChange( (name) => {
                view.Name.IsValid = accountSettings.IsNameValid( name! );
            } );
            return view;
        }

    }
}
