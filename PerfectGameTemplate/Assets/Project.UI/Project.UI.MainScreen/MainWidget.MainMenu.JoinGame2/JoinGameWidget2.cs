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

    public class JoinGameWidget2 : UIWidgetBase<JoinGameWidgetView2> {

        // Globals
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }
        // View
        public override JoinGameWidgetView2 View { get; }
        public JoinGameWidgetView2.GameView_ GameView { get; }
        public JoinGameWidgetView2.PlayerView_ PlayerView { get; }

        // Constructor
        public JoinGameWidget2() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>( null );
            View = CreateView( this, Router );
            GameView = CreateGameView( this );
            PlayerView = CreatePlayerView( this );
            View.GameSlot.Add( GameView.VisualElement );
            View.PlayerSlot.Add( PlayerView.VisualElement );
        }
        public override void Dispose() {
            GameView.Dispose();
            PlayerView.Dispose();
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            var parent = (JoinGameWidget) Parent!;
            GameView.GameName.Value = parent.GameView.GameName.Value;
            GameView.GameMode.As<GameMode>().ValueChoices = parent.GameView.GameMode.As<GameMode>().ValueChoices;
            GameView.GameWorld.As<GameWorld>().ValueChoices = parent.GameView.GameWorld.As<GameWorld>().ValueChoices;
            GameView.IsGamePrivate.Value = parent.GameView.IsGamePrivate.Value;
            PlayerView.PlayerName.Value = parent.PlayerView.PlayerName.Value;
            PlayerView.PlayerRole.As<PlayerRole>().ValueChoices = parent.PlayerView.PlayerRole.As<PlayerRole>().ValueChoices;
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
        private static JoinGameWidgetView2 CreateView(JoinGameWidget2 widget, UIRouter router) {
            var view = UIViewFactory.JoinGameWidget2( widget );
            view.OnCommand( (JoinGameWidgetView2.OkeyCommand cmd) => {
                var gameName = widget.GameView.GameName.Value!;
                var gameMode = widget.GameView.GameMode.As<GameMode>().Value;
                var gameWorld = widget.GameView.GameWorld.As<GameWorld>().Value;
                var isGamePrivate = widget.GameView.IsGamePrivate.Value;
                var playerName = widget.PlayerView.PlayerName.Value!;
                var playerRole = widget.PlayerView.PlayerRole.As<PlayerRole>().Value;
                {
                    var gameDesc = new GameDesc( gameName, gameMode, gameWorld, isGamePrivate );
                    var playerDesc = new PlayerDesc( playerName, playerRole );
                    router.LoadGameSceneAsync( gameDesc, playerDesc, default ).Throw();
                    widget.AttachChild( UIWidgetFactory.LoadingWidget() );
                }
            } );
            view.OnCommand( (JoinGameWidgetView2.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }
        private static JoinGameWidgetView2.GameView_ CreateGameView(JoinGameWidget2 widget) {
            var view = new JoinGameWidgetView2.GameView_( widget );
            view.OnEvent( (JoinGameWidgetView2.GameView_.GameNameEvent evt) => {
            } );
            view.OnEvent( (JoinGameWidgetView2.GameView_.GameModeEvent evt) => {
            } );
            view.OnEvent( (JoinGameWidgetView2.GameView_.GameWorldEvent evt) => {
            } );
            view.OnEvent( (JoinGameWidgetView2.GameView_.IsGamePrivateEvent evt) => {
            } );
            return view;
        }
        private static JoinGameWidgetView2.PlayerView_ CreatePlayerView(JoinGameWidget2 widget) {
            var view = new JoinGameWidgetView2.PlayerView_( widget );
            view.OnEvent( (JoinGameWidgetView2.PlayerView_.PlayerNameEvent evt) => {
            } );
            view.OnEvent( (JoinGameWidgetView2.PlayerView_.PlayerRoleEvent evt) => {
            } );
            return view;
        }

    }
}
