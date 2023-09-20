#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Unity.Services.Lobbies;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidget : UIWidgetBase<CreateGameWidgetView> {

        // Globals
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }

        // Constructor
        public CreateGameWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>( null );
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
        public override void OnBeforeDescendantAttach(UIWidgetBase widget) {
            base.OnBeforeDescendantAttach( widget );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase widget) {
            base.OnAfterDescendantAttach( widget );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase widget) {
            base.OnBeforeDescendantDetach( widget );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase widget) {
            if (widget is CreateGameWidget2 child) {
                View.Game.GameName.Value = child.View.Game.GameName.Value;
                View.Game.GameMode.As<GameMode>().ValueChoices = child.View.Game.GameMode.As<GameMode>().ValueChoices;
                View.Game.GameWorld.As<GameWorld>().ValueChoices = child.View.Game.GameWorld.As<GameWorld>().ValueChoices;
                View.Game.IsGamePrivate.Value = child.View.Game.IsGamePrivate.Value;
                View.Player.PlayerName.Value = child.View.Player.PlayerName.Value;
                View.Player.PlayerRole.Value = child.View.Player.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( widget );
        }

        // Helpers
        private CreateGameWidgetView CreateView() {
            var view = UIVisualFactory.CreateGameWidget();
            view.Game.OnEvent( (CreateGameWidgetView.GameView.GameNameEvent evt) => {
            } );
            view.Game.OnEvent( (CreateGameWidgetView.GameView.GameModeEvent evt) => {
            } );
            view.Game.OnEvent( (CreateGameWidgetView.GameView.GameWorldEvent evt) => {
            } );
            view.Game.OnEvent( (CreateGameWidgetView.GameView.IsGamePrivateEvent evt) => {
            } );
            view.Player.OnEvent( (CreateGameWidgetView.PlayerView.PlayerNameEvent evt) => {
            } );
            view.Player.OnEvent( (CreateGameWidgetView.PlayerView.PlayerRoleEvent evt) => {
            } );
            view.OnCommand( (CreateGameWidgetView.OkeyCommand cmd) => {
                this.AttachChild( UILogicalFactory.CreateGameWidget2() );
            } );
            view.OnCommand( (CreateGameWidgetView.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
