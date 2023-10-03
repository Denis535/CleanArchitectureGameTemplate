#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class JoinGameWidget : UIWidgetBase<JoinGameWidgetView> {

        // Globals
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }

        // Constructor
        public JoinGameWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>();
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.Game.GameName.Value = "Anonymous";
            View.Game.GameMode.As<GameMode>().ValueChoices = (GameMode._1x3, Enum2.GetValues<GameMode>());
            View.Game.GameWorld.As<GameWorld>().ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>());
            View.Game.IsGamePrivate.Value = true;
            View.Player.PlayerName.Value = PlayerProfile.PlayerName;
            View.Player.PlayerRole.As<PlayerRole>().ValueChoices = (PlayerRole.Master, Enum2.GetValues<PlayerRole>());
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            if (descendant is JoinGameWidget2 child) {
                View.Game.GameName.Value = child.View.Game.GameName.Value;
                View.Game.GameMode.As<GameMode>().ValueChoices = child.View.Game.GameMode.As<GameMode>().ValueChoices;
                View.Game.GameWorld.As<GameWorld>().ValueChoices = child.View.Game.GameWorld.As<GameWorld>().ValueChoices;
                View.Game.IsGamePrivate.Value = child.View.Game.IsGamePrivate.Value;
                View.Player.PlayerName.Value = child.View.Player.PlayerName.Value;
                View.Player.PlayerRole.Value = child.View.Player.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Helpers
        private JoinGameWidgetView CreateView() {
            var view = UIViewFactory.JoinGameWidget();
            view.Game.OnEvent( (JoinGameWidgetView.GameView.GameNameEvent evt) => {
            } );
            view.Game.OnEvent( (JoinGameWidgetView.GameView.GameModeEvent evt) => {
            } );
            view.Game.OnEvent( (JoinGameWidgetView.GameView.GameWorldEvent evt) => {
            } );
            view.Game.OnEvent( (JoinGameWidgetView.GameView.IsGamePrivateEvent evt) => {
            } );
            view.Player.OnEvent( (JoinGameWidgetView.PlayerView.PlayerNameEvent evt) => {
            } );
            view.Player.OnEvent( (JoinGameWidgetView.PlayerView.PlayerRoleEvent evt) => {
            } );
            view.OnCommand( (JoinGameWidgetView.OkeyCommand cmd) => {
                this.AttachChild( UIWidgetFactory.JoinGameWidget2() );
            } );
            view.OnCommand( (JoinGameWidgetView.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
