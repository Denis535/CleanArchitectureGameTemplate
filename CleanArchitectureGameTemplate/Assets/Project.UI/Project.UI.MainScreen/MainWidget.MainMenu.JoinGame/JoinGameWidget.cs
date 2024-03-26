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
        // View
        protected override JoinGameWidgetView View { get; }
        // Children
        private GameDescWidget GameDesc => View.GameDescSlot.Widget!;
        private PlayerDescWidget PlayerDesc => View.PlayerDescSlot.Widget!;
        private RoomWidget Room => View.RoomSlot.Widget!;
        private ChatWidget Chat => View.ChatSlot.Widget!;

        // Constructor
        public JoinGameWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
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
