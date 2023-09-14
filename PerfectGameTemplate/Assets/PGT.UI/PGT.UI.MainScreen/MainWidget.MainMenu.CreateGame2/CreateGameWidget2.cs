#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using Unity.Services.Lobbies;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidget2 : UIWidget2<CreateGameWidgetView2> {

        // Globals
        private CreateGameWidget? CreateGameWidget => (CreateGameWidget?) Parent;
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }

        // Constructor
        public CreateGameWidget2() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>();
            Application = this.GetDependencyContainer().Resolve<Application2>();
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>();
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>();
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.Game.GameName.Value = CreateGameWidget!.View.Game.GameName.Value;
            View.Game.GameMode.As<GameMode>().ValueChoices = CreateGameWidget!.View.Game.GameMode.As<GameMode>().ValueChoices;
            View.Game.GameWorld.As<GameWorld>().ValueChoices = CreateGameWidget!.View.Game.GameWorld.As<GameWorld>().ValueChoices;
            View.Game.IsGamePrivate.Value = CreateGameWidget!.View.Game.IsGamePrivate.Value;
            View.Player.PlayerName.Value = CreateGameWidget!.View.Player.PlayerName.Value;
            View.Player.PlayerRole.As<PlayerRole>().ValueChoices = CreateGameWidget!.View.Player.PlayerRole.As<PlayerRole>().ValueChoices;
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
            base.OnAfterDescendantDetach( widget );
        }

        // Helpers/View
        private CreateGameWidgetView2 CreateView() {
            var view = UIVisualFactory.CreateGameWidget2();
            view.Game.OnEvent( (CreateGameWidgetView2.GameView.GameNameEvent evt) => {
            } );
            view.Game.OnEvent( (CreateGameWidgetView2.GameView.GameModeEvent evt) => {
            } );
            view.Game.OnEvent( (CreateGameWidgetView2.GameView.GameWorldEvent evt) => {
            } );
            view.Game.OnEvent( (CreateGameWidgetView2.GameView.IsGamePrivateEvent evt) => {
            } );
            view.Player.OnEvent( (CreateGameWidgetView2.PlayerView.PlayerNameEvent evt) => {
            } );
            view.Player.OnEvent( (CreateGameWidgetView2.PlayerView.PlayerRoleEvent evt) => {
            } );
            view.OnCommand( (CreateGameWidgetView2.OkeyCommand cmd) => {
                var gameName = view.Game.GameName.Value!;
                var gameMode = view.Game.GameMode.As<GameMode>().Value;
                var gameWorld = view.Game.GameWorld.As<GameWorld>().Value;
                var isGamePrivate = view.Game.IsGamePrivate.Value;
                var gameDesc = new GameDesc( gameName, gameMode, gameWorld, isGamePrivate );
                var playerName = View.Player.PlayerName.Value!;
                var playerRole = View.Player.PlayerRole.As<PlayerRole>().Value;
                var playerDesc = new PlayerDesc( playerName, playerRole );
                _ = Router.LoadGameSceneAsync( gameDesc, playerDesc );
                this.AttachChild( UILogicalFactory.LoadingWidget() );
            } );
            view.OnCommand( (CreateGameWidgetView2.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
