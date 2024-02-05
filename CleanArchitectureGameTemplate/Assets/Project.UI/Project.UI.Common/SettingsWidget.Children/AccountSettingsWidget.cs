#nullable enable
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
        private Globals.AccountSettings PlayerProfile { get; }
        // View
        protected override AccountSettingsWidgetView View { get; }

        // Constructor
        public AccountSettingsWidget() {
            Factory = Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.AccountSettings>( null );
            View = CreateView( this, Factory, PlayerProfile );
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
            PlayerProfile.PlayerName = View.Name.Value!;
            PlayerProfile.Save();
        }
        public void Cancel() {
            PlayerProfile.Load();
        }

        // Helpers
        private static AccountSettingsWidgetView CreateView(AccountSettingsWidget widget, UIFactory factory, Globals.AccountSettings playerProfile) {
            var view = new AccountSettingsWidgetView( factory );
            view.Scope.OnAttachToPanel( () => {
                view.Name.Value = playerProfile.PlayerName;
                view.Name.IsValid = Globals.AccountSettings.IsNameValid( view.Name.Value );
            } );
            view.Name.OnChange( (name) => {
                view.Name.IsValid = Globals.AccountSettings.IsNameValid( name! );
            } );
            return view;
        }

    }
}
