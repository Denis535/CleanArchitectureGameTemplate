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
        // View
        protected override CreateGameWidgetView View { get; }
        // Children
        private GameDescWidget GameDescWidget => View.GameDescSlot.Widget!;
        private PlayerDescWidget PlayerDescWidget => View.PlayerDescSlot.Widget!;
        private RoomWidget RoomWidget => View.RoomSlot.Widget!;
        private ChatWidget ChatWidget => View.ChatSlot.Widget!;

        // Constructor
        public CreateGameWidget() {
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
            base.ShowDescendantWidget( widget );
        }
        protected override void HideDescendantWidget(UIWidgetBase widget) {
            if (widget is GameDescWidget gameDescWidget) {
                View.GameDescSlot.Clear();
                return;
            }
            if (widget is PlayerDescWidget playerDescWidget) {
                View.PlayerDescSlot.Clear();
                return;
            }
            if (widget is RoomWidget roomWidget) {
                View.RoomSlot.Clear();
                return;
            }
            if (widget is ChatWidget chatWidget) {
                View.ChatSlot.Clear();
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
