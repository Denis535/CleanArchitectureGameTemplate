#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class JoinGameWidget : UIWidgetBase<JoinGameWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        // Children
        private GameDescWidget GameDesc => View.GameDescSlot.Child!;
        private PlayerDescWidget PlayerDesc => View.PlayerDescSlot.Child!;
        private RoomWidget Room => View.RoomSlot.Child!;
        private ChatWidget Chat => View.ChatSlot.Child!;

        // Constructor
        public JoinGameWidget() {
            Factory = Utils.Container.RequireDependency<UIFactory>( null );
            Router = Utils.Container.RequireDependency<UIRouter>( null );
            View = CreateView( this, Factory, Router );
            this.AttachChild( new GameDescWidget() );
            this.AttachChild( new PlayerDescWidget() );
            this.AttachChild( new RoomWidget() );
            this.AttachChild( new ChatWidget() );
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
        public override void ShowWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Set( gameDescWidget );
                return;
            }
            if (widget is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Set( playerDescWidget );
                return;
            }
            if (widget is RoomWidget roomWidget) {
                View.RoomSlot.Set( roomWidget );
                return;
            }
            if (widget is ChatWidget chatWidget) {
                View.ChatSlot.Set( chatWidget );
                return;
            }
            base.ShowWidget( widget );
        }
        public override void HideWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Clear( gameDescWidget );
                return;
            }
            if (widget is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Clear( playerDescWidget );
                return;
            }
            if (widget is RoomWidget roomWidget) {
                View.RoomSlot.Clear( roomWidget );
                return;
            }
            if (widget is ChatWidget chatWidget) {
                View.ChatSlot.Clear( chatWidget );
                return;
            }
            base.HideWidget( widget );
        }

        // Helpers
        private static JoinGameWidgetView CreateView(JoinGameWidget widget, UIFactory factory, UIRouter router) {
            var view = new JoinGameWidgetView( factory );
            view.Okey.OnClick( evt => {
                var gameName = widget.GameDesc.Name;
                var gameMode = widget.GameDesc.Mode;
                var gameWorld = widget.GameDesc.World;
                var isGamePrivate = widget.GameDesc.IsPrivate;
                var playerName = widget.PlayerDesc.Name;
                var playerRole = widget.PlayerDesc.Role;
                var isPlayerReady = widget.PlayerDesc.IsReady;
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
