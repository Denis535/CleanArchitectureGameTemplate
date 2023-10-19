#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.App;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class CreateGameWidget : UIWidgetBase<CreateGameWidgetView> {

        // Globals
        private UIRouter Router { get; }
        private Application2 Application { get; }
        private Globals.PlayerProfile PlayerProfile { get; }
        //private ILobbyService LobbyService { get; }
        // View
        public override CreateGameWidgetView View { get; }
        public CreateGameWidgetView.GameView_ GameView { get; }
        public CreateGameWidgetView.PlayerView_ PlayerView { get; }

        // Constructor
        public CreateGameWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>( null );
            View = CreateView( this );
            GameView = CreateGameView( this );
            PlayerView = CreatePlayerView( this );
            View.GameViewSlot.Add( GameView.VisualElement );
            View.PlayerViewSlot.Add( PlayerView.VisualElement );
        }
        public override void Dispose() {
            GameView.Dispose();
            PlayerView.Dispose();
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
            if (descendant is CreateGameWidget2 createGameWidget) {
                GameView.GameName.Value = createGameWidget.GameView.GameName.Value;
                GameView.GameMode.ValueChoices = createGameWidget.GameView.GameMode.ValueChoices;
                GameView.GameWorld.ValueChoices = createGameWidget.GameView.GameWorld.ValueChoices;
                GameView.IsGamePrivate.Value = createGameWidget.GameView.IsGamePrivate.Value;
                PlayerView.PlayerName.Value = createGameWidget.PlayerView.PlayerName.Value;
                PlayerView.PlayerRole.Value = createGameWidget.PlayerView.PlayerRole.Value;
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Helpers
        private static CreateGameWidgetView CreateView(CreateGameWidget widget) {
            var view = UIViewFactory.CreateGameWidget( widget );
            view.Okey.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.CreateGameWidget2() );
            } );
            view.Back.OnClick( i => {
                widget.DetachSelf();
            } );
            return view;
        }
        private static CreateGameWidgetView.GameView_ CreateGameView(CreateGameWidget widget) {
            var view = new CreateGameWidgetView.GameView_( widget );
            return view;
        }
        private static CreateGameWidgetView.PlayerView_ CreatePlayerView(CreateGameWidget widget) {
            var view = new CreateGameWidgetView.PlayerView_( widget );
            return view;
        }

    }
}
