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
        public SlotWrapper GameSlot { get; }
        public SlotWrapper PlayerSlot { get; }
        public SlotWrapper LobbySlot { get; }
        public SlotWrapper ChatSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public CreateGameWidgetView(CreateGameWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var gameSlot, out var playerSlot, out var lobbySlot, out var chatSlot, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            GameSlot = gameSlot.AsSlot();
            PlayerSlot = playerSlot.AsSlot();
            LobbySlot = lobbySlot.AsSlot();
            ChatSlot = chatSlot.AsSlot();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Slot gameSlot, out Slot playerSlot, out Slot lobbySlot, out Slot chatSlot, out Button okey, out Button back) {
            using (UIFactory.LargeWidget( "create-game-widget-view" ).AsScope( out view )) {
                using (UIFactory.Card().AsScope()) {
                    using (UIFactory.Header().AsScope()) {
                        title = UIFactory.Label( "Create Game" ).Name( "title" );
                    }
                    using (UIFactory.Content().AsScope()) {
                        using (UIFactory.RowScope().Name( "game-and-player-scope" ).Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            gameSlot = UIFactory.Slot().Name( "game-slot" ).Classes( "grow-1", "basis-0pc" );
                            playerSlot = UIFactory.Slot().Name( "player-slot" ).Classes( "grow-1", "basis-0pc" );
                        }
                        using (UIFactory.RowScope().Name( "lobby-and-chat-scope" ).Classes( "grow-1", "basis-auto" ).AsScope()) {
                            lobbySlot = UIFactory.Slot().Name( "lobby-slot" ).Classes( "grow-1", "basis-0pc" );
                            chatSlot = UIFactory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" );
                        }
                    }
                    using (UIFactory.Footer().AsScope()) {
                        okey = UIFactory.Button( "Ok" ).Name( "okey" );
                        back = UIFactory.Button( "Back" ).Name( "back" );
                    }
                }
            }
            return view;
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
            using (UIFactory.ColumnGroup().Name( "game-view" ).Classes( "medium", "grow-1" ).AsScope( out view )) {
                title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "medium" );
                using (UIFactory.RowScope().AsScope()) {
                    name = UIFactory.TextField( null, 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" );
                }
                using (UIFactory.RowScope().AsScope()) {
                    mode = UIFactory.PopupField( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" );
                    world = UIFactory.PopupField( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" );
                    isPrivate = UIFactory.Toggle( "Private" ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" );
                }
            }
            return view;
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
            using (UIFactory.ColumnGroup().Name( "player-view" ).Classes( "medium", "grow-1" ).AsScope( out view )) {
                title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "medium" );
                using (UIFactory.RowScope().AsScope()) {
                    name = UIFactory.TextFieldReadOnly( null, 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" );
                }
                using (UIFactory.RowScope().AsScope()) {
                    role = UIFactory.PopupField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" );
                    isReady = UIFactory.Toggle( "Ready" ).Name( "is-player-ready" ).Classes( "label-width-150px", "grow-0" );
                }
            }
            return view;
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
            using (UIFactory.ColumnGroup().Name( "lobby-view" ).Classes( "medium", "grow-1" ).AsScope( out view )) {
                title = UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "medium", "shrink-0" );
                players = UIFactory.ScrollView().Name( "players-view" ).Classes( "dark2", "medium", "reverse", "grow-1" );
            }
            return view;
        }
        private static Box CreatePlayer(string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (UIFactory.Box().Name( "player" ).Classes( style, "medium", "grow-1" ).Pipe( i => i.style.width = 2000 ).AsScope( out var view )) {
                UIFactory.Label( text ).Classes( "font-style-bold" );
                return view;
            }
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
            using (UIFactory.ColumnGroup().Name( "chat-view" ).Classes( "medium", "grow-1" ).AsScope( out view )) {
                title = UIFactory.Label( "Chat" ).Name( "title" ).Classes( "medium", "shrink-0" );
                messages = UIFactory.ScrollView().Name( "messages-view" ).Classes( "dark", "medium", "reverse", "grow-1" );
                using (UIFactory.RowScope().Name( "input-text-scope" ).Classes( "shrink-0" ).AsScope()) {
                    text = UIFactory.TextField( null, 128, false ).Name( "input-text" ).Classes( "grow-1" );
                    send = UIFactory.Button( "Send" ).Name( "send" );
                }
            }
            return view;
        }
        private static Box CreateMessage(string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (UIFactory.Box().Name( "message" ).Classes( style, "medium", "grow-1" ).Pipe( i => i.style.width = 2000 ).AsScope( out var view )) {
                UIFactory.Label( text );
                return view;
            }
        }

    }
}
