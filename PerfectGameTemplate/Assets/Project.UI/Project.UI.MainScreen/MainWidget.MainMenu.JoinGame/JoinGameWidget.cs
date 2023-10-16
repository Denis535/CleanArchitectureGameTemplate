#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
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
        // VIew
        public override JoinGameWidgetView View { get; }

        // Constructor
        public JoinGameWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>();
            View = CreateView( this );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            View.GameView.GameName.Value = "Anonymous";
            View.GameView.GameMode.As<GameMode>().ValueChoices = (GameMode._1x4, Enum2.GetValues<GameMode>());
            View.GameView.GameWorld.As<GameWorld>().ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>());
            View.GameView.IsGamePrivate.Value = true;
            View.PlayerView.PlayerName.Value = PlayerProfile.PlayerName;
            View.PlayerView.PlayerRole.As<PlayerRole>().ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>());
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
            if (descendant is JoinGameWidget2 joinGameWidget) {
                View.GameView.GameName.Value = joinGameWidget.View.GameView.GameName.Value;
                View.GameView.GameMode.As<GameMode>().ValueChoices = joinGameWidget.View.GameView.GameMode.As<GameMode>().ValueChoices;
                View.GameView.GameWorld.As<GameWorld>().ValueChoices = joinGameWidget.View.GameView.GameWorld.As<GameWorld>().ValueChoices;
                View.GameView.IsGamePrivate.Value = joinGameWidget.View.GameView.IsGamePrivate.Value;
                View.PlayerView.PlayerName.Value = joinGameWidget.View.PlayerView.PlayerName.Value;
                View.PlayerView.PlayerRole.Value = joinGameWidget.View.PlayerView.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Helpers
        private static JoinGameWidgetView CreateView(JoinGameWidget widget) {
            var view = UIViewFactory.JoinGameWidget( widget );
            view.GameView.OnEvent( (JoinGameWidgetView.GameView_.GameNameEvent evt) => {
            } );
            view.GameView.OnEvent( (JoinGameWidgetView.GameView_.GameModeEvent evt) => {
            } );
            view.GameView.OnEvent( (JoinGameWidgetView.GameView_.GameWorldEvent evt) => {
            } );
            view.GameView.OnEvent( (JoinGameWidgetView.GameView_.IsGamePrivateEvent evt) => {
            } );
            view.PlayerView.OnEvent( (JoinGameWidgetView.PlayerView_.PlayerNameEvent evt) => {
            } );
            view.PlayerView.OnEvent( (JoinGameWidgetView.PlayerView_.PlayerRoleEvent evt) => {
            } );
            view.OnCommand( (JoinGameWidgetView.OkeyCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.JoinGameWidget2() );
            } );
            view.OnCommand( (JoinGameWidgetView.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
