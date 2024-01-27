#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class CreateGameWidget : UIWidgetBase<CreateGameWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        //private ILobbyService LobbyService { get; }
        // View
        public override CreateGameWidgetView View { get; }
        // Children
        private GameDescWidget GameDescWidget { get; }
        private PlayerDescWidget PlayerDescWidget { get; }
        private RoomWidget RoomWidget { get; }
        private ChatWidget ChatWidget { get; }

        // Constructor
        public CreateGameWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            //LobbyService = this.GetDependencyContainer().Resolve<ILobbyService>( null );
            View = CreateView( this, Factory, Router );
            this.AttachChild( GameDescWidget = new GameDescWidget() );
            this.AttachChild( PlayerDescWidget = new PlayerDescWidget() );
            this.AttachChild( RoomWidget = new RoomWidget() );
            this.AttachChild( ChatWidget = new ChatWidget() );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            if (descendant is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Add( gameDescWidget.View.VisualElement );
            }
            if (descendant is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Add( playerDescWidget.View.VisualElement );
            }
            if (descendant is RoomWidget roomWidget) {
                View.RoomSlot.Add( roomWidget.View.VisualElement );
            }
            if (descendant is ChatWidget chatWidget) {
                View.ChatSlot.Add( chatWidget.View.VisualElement );
            }
            base.OnBeforeDescendantAttach( descendant );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            if (descendant is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Remove( gameDescWidget.View.VisualElement );
            }
            if (descendant is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Remove( playerDescWidget.View.VisualElement );
            }
            if (descendant is RoomWidget roomWidget) {
                View.RoomSlot.Remove( roomWidget.View.VisualElement );
            }
            if (descendant is ChatWidget chatWidget) {
                View.ChatSlot.Remove( chatWidget.View.VisualElement );
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Helpers
        private static CreateGameWidgetView CreateView(CreateGameWidget widget, UIFactory factory, UIRouter router) {
            var view = new CreateGameWidgetView( factory );
            view.Okey.OnClick( () => {
                var gameName = widget.GameDescWidget.View.Name.Value!;
                var gameMode = (GameMode) widget.GameDescWidget.View.Mode.Value!;
                var gameWorld = (GameWorld) widget.GameDescWidget.View.World.Value!;
                var isGamePrivate = widget.GameDescWidget.View.IsPrivate.Value;
                var playerName = widget.PlayerDescWidget.View.Name.Value!;
                var playerRole = (PlayerRole) widget.PlayerDescWidget.View.Role.Value!;
                var isPlayerReady = widget.PlayerDescWidget.View.IsReady;
                {
                    var gameDesc = new GameDesc( gameName, gameMode, gameWorld );
                    var playerDesc = new PlayerDesc( playerName, playerRole );
                    router.LoadGameSceneAsync( gameDesc, playerDesc, default ).Throw();
                    widget.AttachChild( new LoadingWidget() );
                }
            } );
            view.Back.OnClick( () => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
