#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Project.App;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class JoinGameWidget : UIWidgetBase<JoinGameWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }
        // View
        public override JoinGameWidgetView View { get; }
        public GameView GameView { get; }
        public PlayerView PlayerView { get; }
        public LobbyView LobbyView { get; }
        public ChatView ChatView { get; }

        // Constructor
        public JoinGameWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>();
            View = CreateView( this, Factory, Router );
            View.GameSlot.Add( GameView = CreateGameView( this, Factory ) );
            View.PlayerSlot.Add( PlayerView = CreatePlayerView( this, Factory ) );
            View.LobbySlot.Add( LobbyView = CreateLobbyView( this, Factory ) );
            View.ChatSlot.Add( ChatView = CreateChatView( this, Factory ) );
        }
        public override void Dispose() {
            GameView.Dispose();
            PlayerView.Dispose();
            LobbyView.Dispose();
            ChatView.Dispose();
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            GameView.Name.Value = "Anonymous";
            GameView.Mode.ValueChoices = (GameMode._1x4, Enum2.GetValues<GameMode>().Cast<object?>().ToArray());
            GameView.World.ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>().Cast<object?>().ToArray());
            GameView.IsPrivate.Value = true;
            PlayerView.Name.Value = PlayerProfile.PlayerName;
            PlayerView.Role.ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>().Cast<object?>().ToArray());
            PlayerView.IsReady.Value = false;
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
        private static JoinGameWidgetView CreateView(JoinGameWidget widget, UIFactory factory, UIRouter router) {
            var view = new JoinGameWidgetView( factory );
            view.Okey.OnClick( i => {
                var gameName = widget.GameView.Name.Value!;
                var gameMode = (GameMode) widget.GameView.Mode.Value!;
                var gameWorld = (GameWorld) widget.GameView.World.Value!;
                var isGamePrivate = widget.GameView.IsPrivate.Value;
                var playerName = widget.PlayerView.Name.Value!;
                var playerRole = (PlayerRole) widget.PlayerView.Role.Value!;
                var isPlayerReady = widget.PlayerView.IsReady;
                {
                    var gameDesc = new GameDesc( gameName, gameMode, gameWorld );
                    var playerDesc = new PlayerDesc( playerName, playerRole );
                    router.LoadGameSceneAsync( gameDesc, playerDesc, default ).Throw();
                    widget.AttachChild( new LoadingWidget() );
                }
            } );
            view.Back.OnClick( i => {
                widget.DetachSelf();
            } );
            return view;
        }
        private static GameView CreateGameView(JoinGameWidget widget, UIFactory factory) {
            var view = new GameView( factory );
            return view;
        }
        private static PlayerView CreatePlayerView(JoinGameWidget widget, UIFactory factory) {
            var view = new PlayerView( factory );
            return view;
        }
        private static LobbyView CreateLobbyView(JoinGameWidget widget, UIFactory factory) {
            var view = new LobbyView( factory );
            return view;
        }
        private static ChatView CreateChatView(JoinGameWidget widget, UIFactory factory) {
            var view = new ChatView( factory );
            return view;
        }

    }
}
