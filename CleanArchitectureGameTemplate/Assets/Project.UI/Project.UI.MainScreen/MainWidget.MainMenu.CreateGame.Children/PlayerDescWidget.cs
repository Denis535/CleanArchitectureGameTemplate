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
        private Globals.PlayerProfile PlayerProfile { get; }
        // View
        protected override PlayerDescWidgetView View { get; }
        public string Name => View.Name.Value!;
        public PlayerRole Role => (PlayerRole) View.Role.Value!;
        public bool IsReady => View.IsReady.Value;

        // Constructor
        public PlayerDescWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            View = new PlayerDescWidgetView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.Name.Value = PlayerProfile.PlayerName;
            View.Role.ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>().Cast<object?>().ToArray());
            View.IsReady.Value = false;
        }
        public override void OnDetach() {
        }

    }
}
