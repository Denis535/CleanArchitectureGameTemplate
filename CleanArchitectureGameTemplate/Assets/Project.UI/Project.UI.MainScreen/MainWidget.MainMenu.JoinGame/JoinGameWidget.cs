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

    public class JoinGameWidget : UIWidgetBase<JoinGameWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        //private ILobbyService LobbyService { get; }
        // View
        protected override JoinGameWidgetView View { get; }
        // Children
        private GameDescWidget GameDescWidget { get; }
        private PlayerDescWidget PlayerDescWidget { get; }
        private RoomWidget RoomWidget { get; }
        private ChatWidget ChatWidget { get; }

        // Constructor
        public JoinGameWidget() {
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

        // ShowWidget
        protected override void ShowWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget) {
                View.GameDescSlot.Add( widget.GetVisualElement()! );
                return;
            }
            if (widget is PlayerDescWidget) {
                View.PlayerDescSlot.Add( widget.GetVisualElement()! );
                return;
            }
            if (widget is RoomWidget) {
                View.RoomSlot.Add( widget.GetVisualElement()! );
                return;
            }
            if (widget is ChatWidget) {
                View.ChatSlot.Add( widget.GetVisualElement()! );
                return;
            }
            base.ShowWidget( widget );
        }
        protected override void HideWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget) {
                View.GameDescSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            if (widget is PlayerDescWidget) {
                View.PlayerDescSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            if (widget is RoomWidget) {
                View.RoomSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            if (widget is ChatWidget) {
                View.ChatSlot.Remove( widget.GetVisualElement()! );
                return;
            }
            base.HideWidget( widget );
        }

        // Helpers
        private static JoinGameWidgetView CreateView(JoinGameWidget widget, UIFactory factory, UIRouter router) {
            var view = new JoinGameWidgetView( factory );
            view.Okey.OnClick( evt => {
                var gameName = widget.GameDescWidget.Name;
                var gameMode = widget.GameDescWidget.Mode;
                var gameWorld = widget.GameDescWidget.World;
                var isGamePrivate = widget.GameDescWidget.IsPrivate;
                var playerName = widget.PlayerDescWidget.Name;
                var playerRole = widget.PlayerDescWidget.Role;
                var isPlayerReady = widget.PlayerDescWidget.IsReady;
                {
                    var gameDesc = new GameDesc( gameName, gameMode, gameWorld );
                    var playerDesc = new PlayerDesc( playerName, playerRole );
                    router.LoadGameSceneAsync( gameDesc, playerDesc ).Throw();
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
