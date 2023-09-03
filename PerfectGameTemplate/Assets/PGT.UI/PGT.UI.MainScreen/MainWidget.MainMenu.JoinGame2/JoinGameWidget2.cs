#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using Unity.Services.Lobbies;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class JoinGameWidget2 : UIWidget2<JoinGameWidgetView2> {

        private UIRouter Router2 => Singleton.GetInstance<UIRouter>();
        private AppManager AppManager => Singleton.GetInstance<AppManager>();
        private ILobbyService LobbyService => AppManager.LobbyService;
        private Globals.PlayerProfile PlayerProfile => Singleton.GetInstance<Globals.PlayerProfile>();

        // Constructor
        public JoinGameWidget2(JoinGameWidget joinGameWidget) {
            View = CreateView( joinGameWidget.View );
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
        private JoinGameWidgetView2 CreateView(JoinGameWidgetView joinGameWidgetView) {
            var view = UIVisualFactory.JoinGameWidget2( joinGameWidgetView );
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
                var gameDesc = new GameDesc( view.Game.GameName.Value, view.Game.GameMode.As<GameMode>().Value, view.Game.GameWorld.As<GameWorld>().Value, view.Game.IsGamePrivate.Value );
                var playerDesc = new PlayerDesc( View.Player.PlayerName.Value, View.Player.PlayerRole.As<PlayerRole>().Value );
                _ = Router2.LoadGameSceneAsync( gameDesc, playerDesc );
                Router.AttachChild( UILogicalFactory.LoadingWidget() );
            } );
            view.OnCommand( (JoinGameWidgetView2.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (JoinGameWidgetView2.SubmitCommand cmd) => {
            } );
            view.OnCommand( (JoinGameWidgetView2.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
