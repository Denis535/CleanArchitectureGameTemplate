#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using Unity.Services.Lobbies;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class CreateGameWidget : UIWidget2<CreateGameWidgetView> {

        private UIRouter Router2 => Singleton.GetInstance<UIRouter>();
        private AppManager AppManager => Singleton.GetInstance<AppManager>();
        private ILobbyService LobbyService => AppManager.LobbyService;
        private Globals.PlayerProfile PlayerProfile => Singleton.GetInstance<Globals.PlayerProfile>();

        // Constructor
        public CreateGameWidget() {
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
            if (widget is CreateGameWidget2 createGameWidget2) {
                View.Game.GameName.Value = createGameWidget2.View.Game.GameName.Value;
                View.Game.GameMode.As<GameMode>().ValueChoices = createGameWidget2.View.Game.GameMode.As<GameMode>().ValueChoices;
                View.Game.GameWorld.As<GameWorld>().ValueChoices = createGameWidget2.View.Game.GameWorld.As<GameWorld>().ValueChoices;
                View.Game.IsGamePrivate.Value = createGameWidget2.View.Game.IsGamePrivate.Value;
                View.Player.PlayerName.Value = createGameWidget2.View.Player.PlayerName.Value;
                View.Player.PlayerRole.Value = createGameWidget2.View.Player.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( widget );
        }

        // Helpers/View
        private CreateGameWidgetView CreateView() {
            var view = UIVisualFactory.CreateGameWidget( PlayerProfile );
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
                Router.AttachChild( UILogicalFactory.CreateGameWidget2( this ) );
            } );
            view.OnCommand( (CreateGameWidgetView.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (CreateGameWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (CreateGameWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
