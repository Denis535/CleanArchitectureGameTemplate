﻿#nullable enable
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
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>();
            View = CreateView( this, Router );
            View.GameViewSlot.Add( GameView = CreateGameView( this ) );
            View.PlayerViewSlot.Add( PlayerView = CreatePlayerView( this ) );
            View.LobbyViewSlot.Add( LobbyView = CreateLobbyView( this ) );
            View.ChatViewSlot.Add( ChatView = CreateChatView( this ) );
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
            GameView.GameName.Value = "Anonymous";
            GameView.GameMode.ValueChoices = (GameMode._1x4, Enum2.GetValues<GameMode>().Cast<object?>().ToArray());
            GameView.GameWorld.ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>().Cast<object?>().ToArray());
            GameView.IsGamePrivate.Value = true;
            PlayerView.PlayerName.Value = PlayerProfile.PlayerName;
            PlayerView.PlayerRole.ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>().Cast<object?>().ToArray());
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
        private static JoinGameWidgetView CreateView(JoinGameWidget widget, UIRouter router) {
            var view = new JoinGameWidgetView( widget );
            view.Okey.OnClick( i => {
                var gameName = widget.GameView.GameName.Value!;
                var gameMode = (GameMode) widget.GameView.GameMode.Value!;
                var gameWorld = (GameWorld) widget.GameView.GameWorld.Value!;
                var isGamePrivate = widget.GameView.IsGamePrivate.Value;
                var playerName = widget.PlayerView.PlayerName.Value!;
                var playerRole = (PlayerRole) widget.PlayerView.PlayerRole.Value!;
                {
                    var gameDesc = new GameDesc( gameName, gameMode, gameWorld, isGamePrivate );
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
        private static GameView CreateGameView(JoinGameWidget widget) {
            var view = new GameView( widget );
            return view;
        }
        private static PlayerView CreatePlayerView(JoinGameWidget widget) {
            var view = new PlayerView( widget );
            return view;
        }
        private static LobbyView CreateLobbyView(JoinGameWidget widget) {
            var view = new LobbyView( widget );
            return view;
        }
        private static ChatView CreateChatView(JoinGameWidget widget) {
            var view = new ChatView( widget );
            return view;
        }

    }
}
