#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using Unity.Services.Lobbies;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class JoinGameWidget : UIWidget2<JoinGameWidgetView> {

        private UIRouter Router2 => Singleton.GetInstance<UIRouter>();
        private AppManager AppManager => Singleton.GetInstance<AppManager>();
        private ILobbyService LobbyService => AppManager.LobbyService;
        private Globals.PlayerProfile PlayerProfile => Singleton.GetInstance<Globals.PlayerProfile>();

        // Constructor
        public JoinGameWidget() {
            View = CreateView();
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
            if (widget is JoinGameWidget2 joinGameWidget2) {
                View.Game.GameName.Value = joinGameWidget2.View.Game.GameName.Value;
                View.Game.GameMode.As<GameMode>().ValueChoices = joinGameWidget2.View.Game.GameMode.As<GameMode>().ValueChoices;
                View.Game.GameWorld.As<GameWorld>().ValueChoices = joinGameWidget2.View.Game.GameWorld.As<GameWorld>().ValueChoices;
                View.Game.IsGamePrivate.Value = joinGameWidget2.View.Game.IsGamePrivate.Value;
                View.Player.PlayerName.Value = joinGameWidget2.View.Player.PlayerName.Value;
                View.Player.PlayerRole.Value = joinGameWidget2.View.Player.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( widget );
        }

        // Helpers/View
        private JoinGameWidgetView CreateView() {
            var view = UIVisualFactory.JoinGameWidget( PlayerProfile );
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
                Router.AttachChild( UILogicalFactory.JoinGameWidget2( this ) );
            } );
            view.OnCommand( (JoinGameWidgetView.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (JoinGameWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (JoinGameWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
