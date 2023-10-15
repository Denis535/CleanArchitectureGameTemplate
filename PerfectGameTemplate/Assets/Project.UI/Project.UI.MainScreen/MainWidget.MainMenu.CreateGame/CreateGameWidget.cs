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
    using UnityEngine.UIElements;

    public class CreateGameWidget : UIWidgetBase<CreateGameWidgetView> {

        // Globals
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }
        // View
        public override CreateGameWidgetView View { get; protected init; }

        // Constructor
        public CreateGameWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>( null );
            View = CreateView( this );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            View.Game.GameName.Value = "Anonymous";
            View.Game.GameMode.As<GameMode>().ValueChoices = (GameMode._1x4, Enum2.GetValues<GameMode>());
            View.Game.GameWorld.As<GameWorld>().ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>());
            View.Game.IsGamePrivate.Value = true;
            View.Player.PlayerName.Value = PlayerProfile.PlayerName;
            View.Player.PlayerRole.As<PlayerRole>().ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>());
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
            if (descendant is CreateGameWidget2 createGameWidget) {
                View.Game.GameName.Value = createGameWidget.View.Game.GameName.Value;
                View.Game.GameMode.As<GameMode>().ValueChoices = createGameWidget.View.Game.GameMode.As<GameMode>().ValueChoices;
                View.Game.GameWorld.As<GameWorld>().ValueChoices = createGameWidget.View.Game.GameWorld.As<GameWorld>().ValueChoices;
                View.Game.IsGamePrivate.Value = createGameWidget.View.Game.IsGamePrivate.Value;
                View.Player.PlayerName.Value = createGameWidget.View.Player.PlayerName.Value;
                View.Player.PlayerRole.Value = createGameWidget.View.Player.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Helpers
        private static CreateGameWidgetView CreateView(CreateGameWidget widget) {
            var view = UIViewFactory.CreateGameWidget( widget );
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
                widget.AttachChild( UIWidgetFactory.CreateGameWidget2() );
            } );
            view.OnCommand( (CreateGameWidgetView.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
