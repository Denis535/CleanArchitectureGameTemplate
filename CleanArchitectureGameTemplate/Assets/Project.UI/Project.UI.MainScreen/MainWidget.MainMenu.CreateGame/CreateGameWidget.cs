#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class CreateGameWidget : UIWidgetBase<CreateGameWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        //private ILobbyService LobbyService { get; }
        // View
        protected override CreateGameWidgetView View { get; }
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
        public override void OnAttach(object? argument) {
        }
        public override void OnDetach(object? argument) {
        }

        // ShowDescendantWidget
        protected override void ShowDescendantWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Add( gameDescWidget );
                return;
            }
            if (widget is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Add( playerDescWidget );
                return;
            }
            if (widget is RoomWidget roomWidget) {
                View.RoomSlot.Add( roomWidget );
                return;
            }
            if (widget is ChatWidget chatWidget) {
                View.ChatSlot.Add( chatWidget );
                return;
            }
            base.ShowDescendantWidget( widget );
        }
        protected override void HideDescendantWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Remove( gameDescWidget );
                return;
            }
            if (widget is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Remove( playerDescWidget );
                return;
            }
            if (widget is RoomWidget roomWidget) {
                View.RoomSlot.Remove( roomWidget );
                return;
            }
            if (widget is ChatWidget chatWidget) {
                View.ChatSlot.Remove( chatWidget );
                return;
            }
            base.HideDescendantWidget( widget );
        }

        // Helpers
        private static CreateGameWidgetView CreateView(CreateGameWidget widget, UIFactory factory, UIRouter router) {
            var view = new CreateGameWidgetView( factory );
            view.Okey.OnClick( evt => {
                var gameName = widget.GameDescWidget.Name;
                var gameMode = widget.GameDescWidget.Mode;
                var gameWorld = widget.GameDescWidget.World;
                var isGamePrivate = widget.GameDescWidget.IsPrivate;
                var playerName = widget.PlayerDescWidget.Name;
                var playerRole = widget.PlayerDescWidget.Role;
                var isPlayerReady = widget.PlayerDescWidget.IsReady;
                {
                    var gameDesc = new GameDesc( gameName, gameMode );
                    var worldDesc = new WorldDesc( gameWorld );
                    var playerDesc = new PlayerDesc( playerName, playerRole );
                    router.LoadGameSceneAsync( gameDesc, worldDesc, playerDesc ).Throw();
                    widget.AttachChild( new LoadingWidget() );
                }
            } );
            view.Back.OnClick( evt => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
