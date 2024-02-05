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
        private Globals.PlayerProfile PlayerProfile { get; }
        // View
        protected override AccountSettingsWidgetView View { get; }

        // Constructor
        public AccountSettingsWidget() {
            Factory = Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            View = CreateView( this, Factory, PlayerProfile );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.Name.Value = PlayerProfile.PlayerName;
            View.Name.IsValid = Globals.PlayerProfile.IsNameValid( View.Name.Value );
        }
        public override void OnDetach() {
            PlayerProfile.Load();
        }

        // Submit
        public void Submit() {
            PlayerProfile.PlayerName = View.Name.Value!;
            PlayerProfile.Save();
        }
        public void Cancel() {
        }

        // Helpers
        private static AccountSettingsWidgetView CreateView(AccountSettingsWidget widget, UIFactory factory, Globals.PlayerProfile playerProfile) {
            var view = new AccountSettingsWidgetView( factory );
            view.Name.OnChange( (name) => {
                view.Name.IsValid = Globals.PlayerProfile.IsNameValid( name! );
                //playerProfile.PlayerName = view.Name.Value!;
            } );
            return view;
        }

    }
}
