#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.App;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class PlayerDescWidget : UIWidgetBase<PlayerDescWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private Globals.AccountSettings AccountSettings { get; }
        // View
        protected override PlayerDescWidgetView View { get; }
        public string Name => View.Name.Value!;
        public PlayerRole Role => (PlayerRole) View.Role.Value!;
        public bool IsReady => View.IsReady.Value;

        // Constructor
        public PlayerDescWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            AccountSettings = this.GetDependencyContainer().Resolve<Globals.AccountSettings>( null );
            View = CreateView( Factory, AccountSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

        // Helpers
        private static PlayerDescWidgetView CreateView(UIFactory factory, Globals.AccountSettings accountSettings) {
            var view = new PlayerDescWidgetView( factory );
            view.Group.OnAttachToPanel( () => {
                view.Name.Value = accountSettings.PlayerName;
                view.Role.ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>().Cast<object?>().ToArray());
                view.IsReady.Value = false;
            } );
            return view;
        }

    }
}
