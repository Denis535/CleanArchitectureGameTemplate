#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.App;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class CreateGameWidget2 : UIWidgetBase<CreateGameWidgetView2> {

        // Globals
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }
        // VIew
        public override CreateGameWidgetView2 View { get; }

        // Constructor
        public CreateGameWidget2() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>();
            View = CreateView( this, Router );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            var parent = (CreateGameWidget?) Parent;
            View.Game.GameName.Value = parent!.View.Game.GameName.Value;
            View.Game.GameMode.As<GameMode>().ValueChoices = parent!.View.Game.GameMode.As<GameMode>().ValueChoices;
            View.Game.GameWorld.As<GameWorld>().ValueChoices = parent!.View.Game.GameWorld.As<GameWorld>().ValueChoices;
            View.Game.IsGamePrivate.Value = parent!.View.Game.IsGamePrivate.Value;
            View.Player.PlayerName.Value = parent!.View.Player.PlayerName.Value;
            View.Player.PlayerRole.As<PlayerRole>().ValueChoices = parent!.View.Player.PlayerRole.As<PlayerRole>().ValueChoices;
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
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
            base.OnAfterDescendantDetach( descendant );
        }

        // Helpers
        private static CreateGameWidgetView2 CreateView(CreateGameWidget2 widget, UIRouter router) {
            var view = UIViewFactory.CreateGameWidget2( widget );
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
                var playerName = view.Player.PlayerName.Value!;
                var playerRole = view.Player.PlayerRole.As<PlayerRole>().Value;
                var playerDesc = new PlayerDesc( playerName, playerRole );
                router.LoadGameSceneAsync( gameDesc, playerDesc, default ).Throw();
                widget.AttachChild( UIWidgetFactory.LoadingWidget() );
            } );
            view.OnCommand( (CreateGameWidgetView2.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
