﻿#nullable enable
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
        public override void OnAttach() {
        }
        public override void OnDetach() {
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
        private static CreateGameWidgetView CreateView(CreateGameWidget widget, UIFactory factory, UIRouter router) {
            var view = new CreateGameWidgetView( factory );
            view.Okey.OnClick( () => {
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
