#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper GameViewSlot { get; }
        public SlotWrapper PlayerViewSlot { get; }
        public SlotWrapper LobbyViewSlot { get; }
        public SlotWrapper ChatViewSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public CreateGameWidgetView(CreateGameWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var gameViewSlot, out var playerViewSlot, out var lobbyViewSlot, out var chatViewSlot, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            GameViewSlot = gameViewSlot.AsSlot();
            PlayerViewSlot = playerViewSlot.AsSlot();
            LobbyViewSlot = lobbyViewSlot.AsSlot();
            ChatViewSlot = chatViewSlot.AsSlot();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Slot gameViewSlot, out Slot playerViewSlot, out Slot lobbyViewSlot, out Slot chatViewSlot, out Button okey, out Button back) {
            return view = UIFactory.LargeWidget( "create-game-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Create Game" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.RowScope().Classes( "grow-0", "basis-40pc" ).Children(
                            gameViewSlot = UIFactory.Slot().Name( "game-view-slot" ).Classes( "grow-1", "basis-0pc" ),
                            playerViewSlot = UIFactory.Slot().Name( "player-view-slot" ).Classes( "grow-1", "basis-0pc" )
                        ),
                        UIFactory.RowScope().Classes( "grow-1", "basis-auto" ).Children(
                            lobbyViewSlot = UIFactory.Slot().Name( "lobby-view-slot" ).Classes( "grow-1", "basis-0pc" ),
                            chatViewSlot = UIFactory.Slot().Name( "chat-view-slot" ).Classes( "grow-1", "basis-0pc" )
                        )
                    ),
                    UIFactory.Footer().Children(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }
    }

    // GameView
    public class GameView : UISubViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextWrapper<string> Name { get; }
        public PopupWrapper<object> Mode { get; }
        public PopupWrapper<object> World { get; }
        public ToggleWrapper<bool> IsPrivate { get; }

        // Constructor
        public GameView(UIWidgetBase widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var name, out var mode, out var world, out var isPrivate );
            View = view.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Mode = mode.Wrap();
            World = world.Wrap();
            IsPrivate = isPrivate.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out TextField name, out PopupField<object?> mode, out PopupField<object?> world, out Toggle isPrivate) {
            return view = UIFactory.ColumnGroup().Name( "game-view" ).Classes( "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "title" ),
                UIFactory.RowScope().Children(
                    name = UIFactory.TextField( null, 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" )
                ),
                UIFactory.RowScope().Children(
                    mode = UIFactory.PopupField( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ),
                    world = UIFactory.PopupField( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ),
                    isPrivate = UIFactory.Toggle( "Private" ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" )
                )
            );
        }

    }
    // PlayerView
    public class PlayerView : UISubViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextWrapper<string> Name { get; }
        public PopupWrapper<object> Role { get; }
        public ToggleWrapper<bool> IsReady { get; }

        // Constructor
        public PlayerView(UIWidgetBase widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var name, out var role, out var isReady );
            View = view.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Role = role.Wrap();
            IsReady = isReady.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out TextField name, out PopupField<object?> role, out Toggle isReady) {
            return view = UIFactory.ColumnGroup().Name( "players-view" ).Classes( "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                UIFactory.RowScope().Children(
                    name = UIFactory.TextFieldReadOnly( null, 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
                ),
                UIFactory.RowScope().Children(
                    role = UIFactory.PopupField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" ),
                    isReady = UIFactory.Toggle( "Ready" ).Name( "is-ready" ).Classes( "label-width-150px", "grow-1" )
                )
            );
        }

    }
    // LobbyView
    public class LobbyView : UISubViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Players { get; }

        // Constructor
        public LobbyView(UIWidgetBase widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var players );
            View = view.Wrap();
            Title = title.Wrap();
            Players = players.AsSlot();
            for (var i = 1; i <= 32; i++) {
                Players.Add( CreatePlayer( $"Player: {i}", i - 1 ) );
            }
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out ScrollView players) {
            return view = UIFactory.ColumnGroup().Name( "lobby-view" ).Classes( "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "title", "shrink-0" ),
                players = UIFactory.ScrollView().Name( "players-view" ).Classes( "light", "medium", "reverse", "grow-1" )
            );
        }
        private static Box CreatePlayer(string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => null,
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( $"Value is invalid" )
            };
            return UIFactory.Box().Name( "player" ).Classes( style, "medium", "grow-1" ).Pipe( i => i.style.width = 2000 ).Children( UIFactory.Label( text ).Classes( "font-style-bold", "margin-0px", "padding-0px" ) );
        }

    }
    // ChatView
    public class ChatView : UISubViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Messages { get; }
        public TextWrapper<string> Text { get; }
        public ButtonWrapper Send { get; }

        // Constructor
        public ChatView(UIWidgetBase widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var messages, out var text, out var send );
            View = view.Wrap();
            Title = title.Wrap();
            Messages = messages.AsSlot();
            Text = text.Wrap();
            Send = send.Wrap();
            for (var i = 1; i <= 32; i++) {
                Messages.Add( CreateMessage( $"Message: {i}", i - 1 ) );
            }
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out ScrollView messages, out TextField text, out Button send) {
            return view = UIFactory.ColumnGroup().Name( "chat-view" ).Classes( "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Chat" ).Name( "title" ).Classes( "title", "shrink-0" ),
                messages = UIFactory.ScrollView().Name( "messages-view" ).Classes( "dark", "medium", "reverse", "grow-1" ),
                UIFactory.RowScope().Classes( "shrink-0" ).Children(
                    text = UIFactory.TextField( null, 128, false ).Name( "message" ).Classes( "grow-1" ),
                    send = UIFactory.Button( "Send" ).Name( "send" )
                )
            );
        }
        private static Box CreateMessage(string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => null,
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( $"Value is invalid" )
            };
            return UIFactory.Box().Name( "message" ).Classes( style, "medium", "grow-1" ).Pipe( i => i.style.width = 2000 ).Children( UIFactory.Label( text ).Classes( "margin-0px", "padding-0px" ) );
        }

    }
}
