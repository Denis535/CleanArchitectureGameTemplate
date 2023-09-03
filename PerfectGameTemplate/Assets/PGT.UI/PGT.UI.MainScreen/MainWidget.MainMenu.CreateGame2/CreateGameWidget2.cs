#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using Unity.Services.Lobbies;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class CreateGameWidget2 : UIWidget2<CreateGameWidgetView2> {

        private UIRouter Router2 => Singleton.GetInstance<UIRouter>();
        private AppManager AppManager => Singleton.GetInstance<AppManager>();
        private ILobbyService LobbyService => AppManager.LobbyService;
        private Globals.PlayerProfile PlayerProfile => Singleton.GetInstance<Globals.PlayerProfile>();

        // Constructor
        public CreateGameWidget2(CreateGameWidget createGameWidget) {
            View = CreateView( createGameWidget.View );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidget widget) {
            base.OnBeforeDescendantAttach( widget );
        }
        public override void OnAfterDescendantAttach(UIWidget widget) {
            base.OnAfterDescendantAttach( widget );
        }
        public override void OnBeforeDescendantDetach(UIWidget widget) {
            base.OnBeforeDescendantDetach( widget );
        }
        public override void OnAfterDescendantDetach(UIWidget widget) {
            base.OnAfterDescendantDetach( widget );
        }

        // Helpers/View
        private CreateGameWidgetView2 CreateView(CreateGameWidgetView createGameWidgetView) {
            var view = UIVisualFactory.CreateGameWidget2( createGameWidgetView );
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
                var gameDesc = new GameDesc( view.Game.GameName.Value, view.Game.GameMode.As<GameMode>().Value, view.Game.GameWorld.As<GameWorld>().Value, view.Game.IsGamePrivate.Value );
                var playerDesc = new PlayerDesc( View.Player.PlayerName.Value, View.Player.PlayerRole.As<PlayerRole>().Value );
                _ = Router2.LoadGameSceneAsync( gameDesc, playerDesc );
                Router.AttachChild( UILogicalFactory.LoadingWidget() );
            } );
            view.OnCommand( (CreateGameWidgetView2.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (CreateGameWidgetView2.SubmitCommand cmd) => {
            } );
            view.OnCommand( (CreateGameWidgetView2.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
