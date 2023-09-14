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

    public class JoinGameWidget2 : UIWidget2<JoinGameWidgetView2> {

        // Globals
        private JoinGameWidget? JoinGameWidget => (JoinGameWidget?) Parent;
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }

        // Constructor
        public JoinGameWidget2() {
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
            View.Game.GameName.Value = JoinGameWidget!.View.Game.GameName.Value;
            View.Game.GameMode.As<GameMode>().ValueChoices = JoinGameWidget!.View.Game.GameMode.As<GameMode>().ValueChoices;
            View.Game.GameWorld.As<GameWorld>().ValueChoices = JoinGameWidget!.View.Game.GameWorld.As<GameWorld>().ValueChoices;
            View.Game.IsGamePrivate.Value = JoinGameWidget!.View.Game.IsGamePrivate.Value;
            View.Player.PlayerName.Value = JoinGameWidget!.View.Player.PlayerName.Value;
            View.Player.PlayerRole.As<PlayerRole>().ValueChoices = JoinGameWidget!.View.Player.PlayerRole.As<PlayerRole>().ValueChoices;
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
        private JoinGameWidgetView2 CreateView() {
            var view = UIVisualFactory.JoinGameWidget2();
            view.Game.OnEvent( (JoinGameWidgetView2.GameView.GameNameEvent evt) => {
            } );
            view.Game.OnEvent( (JoinGameWidgetView2.GameView.GameModeEvent evt) => {
            } );
            view.Game.OnEvent( (JoinGameWidgetView2.GameView.GameWorldEvent evt) => {
            } );
            view.Game.OnEvent( (JoinGameWidgetView2.GameView.IsGamePrivateEvent evt) => {
            } );
            view.Player.OnEvent( (JoinGameWidgetView2.PlayerView.PlayerNameEvent evt) => {
            } );
            view.Player.OnEvent( (JoinGameWidgetView2.PlayerView.PlayerRoleEvent evt) => {
            } );
            view.OnCommand( (JoinGameWidgetView2.OkeyCommand cmd) => {
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
            view.OnCommand( (JoinGameWidgetView2.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
