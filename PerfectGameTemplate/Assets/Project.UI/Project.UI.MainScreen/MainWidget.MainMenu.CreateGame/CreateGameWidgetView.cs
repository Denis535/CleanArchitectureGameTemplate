#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidgetView : UIWidgetViewBase {

        // Factory
        private UIFactory Factory { get; }
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
        public CreateGameWidgetView(CreateGameWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var gameSlot, out var playerSlot, out var lobbySlot, out var chatSlot, out var okey, out var back );
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
        private static View CreateVisualElement(UIFactory factory, out View view, out Label title, out Slot gameSlot, out Slot playerSlot, out Slot lobbySlot, out Slot chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "create-game-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Create Game" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Name( "game-and-player-scope" ).Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            VisualElementScope.Add( gameSlot = factory.Slot().Name( "game-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( playerSlot = factory.Slot().Name( "player-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                        using (factory.RowScope().Name( "lobby-and-chat-scope" ).Classes( "grow-1", "basis-auto" ).AsScope()) {
                            VisualElementScope.Add( lobbySlot = factory.Slot().Name( "lobby-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( chatSlot = factory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }

    // GameView
    public class GameView : UISubViewBase {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public PopupFieldWrapper<object> Mode { get; }
        public PopupFieldWrapper<object> World { get; }
        public ToggleFieldWrapper<bool> IsPrivate { get; }

        // Constructor
        public GameView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var name, out var mode, out var world, out var isPrivate );
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
        private static ColumnGroup CreateVisualElement(UIFactory factory, out ColumnGroup view, out Label title, out TextField name, out PopupField<object?> mode, out PopupField<object?> world, out Toggle isPrivate) {
            using (factory.ColumnGroup().Name( "game-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Game" ).Name( "title" ).Classes( "medium" ) );
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( name = factory.TextField( null, 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" ) );
                }
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( mode = factory.PopupField( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( world = factory.PopupField( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( isPrivate = factory.Toggle( "Private" ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" ) );
                }
            }
            return view;
        }

    }
    // PlayerView
    public class PlayerView : UISubViewBase {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public PopupFieldWrapper<object> Role { get; }
        public ToggleFieldWrapper<bool> IsReady { get; }

        // Constructor
        public PlayerView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var name, out var role, out var isReady );
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
        private static ColumnGroup CreateVisualElement(UIFactory factory, out ColumnGroup view, out Label title, out TextField name, out PopupField<object?> role, out Toggle isReady) {
            using (factory.ColumnGroup().Name( "player-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Player" ).Name( "title" ).Classes( "medium" ) );
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( name = factory.TextFieldReadOnly( null, 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" ) );
                }
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( role = factory.PopupField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( isReady = factory.Toggle( "Ready" ).Name( "is-player-ready" ).Classes( "label-width-150px", "grow-0" ) );
                }
            }
            return view;
        }

    }
    // LobbyView
    public class LobbyView : UISubViewBase {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Players { get; }

        // Constructor
        public LobbyView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var players );
            View = view.Wrap();
            Title = title.Wrap();
            Players = players.AsSlot();
            for (var i = 1; i <= 32; i++) {
                Players.Add( CreatePlayer( Factory, $"Player: {i}", i - 1 ) );
            }
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(UIFactory factory, out ColumnGroup view, out Label title, out ScrollView players) {
            using (factory.ColumnGroup().Name( "lobby-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Lobby" ).Name( "title" ).Classes( "medium", "shrink-0" ) );
                VisualElementScope.Add( players = factory.ScrollView().Name( "players-view" ).Classes( "dark2", "medium", "reverse", "grow-1" ) );
            }
            return view;
        }
        private static Box CreatePlayer(UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "player" ).Classes( style, "medium", "grow-1" ).Pipe( i => i.style.width = 2000 ).AsScope( out var view )) {
                VisualElementScope.Add( factory.Label( text ).Classes( "font-style-bold" ) );
                return view;
            }
        }

    }
    // ChatView
    public class ChatView : UISubViewBase {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Messages { get; }
        public TextFieldWrapper<string> Text { get; }
        public ButtonWrapper Send { get; }

        // Constructor
        public ChatView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var messages, out var text, out var send );
            View = view.Wrap();
            Title = title.Wrap();
            Messages = messages.AsSlot();
            Text = text.Wrap();
            Send = send.Wrap();
            for (var i = 1; i <= 32; i++) {
                Messages.Add( CreateMessage( Factory, $"Message: {i}", i - 1 ) );
            }
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(UIFactory factory, out ColumnGroup view, out Label title, out ScrollView messages, out TextField text, out Button send) {
            using (factory.ColumnGroup().Name( "chat-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Chat" ).Name( "title" ).Classes( "medium", "shrink-0" ) );
                VisualElementScope.Add( messages = factory.ScrollView().Name( "messages-view" ).Classes( "dark", "medium", "reverse", "grow-1" ) );
                using (factory.RowScope().Name( "input-text-scope" ).Classes( "shrink-0" ).AsScope()) {
                    VisualElementScope.Add( text = factory.TextField( null, 128, false ).Name( "input-text" ).Classes( "grow-1" ) );
                    VisualElementScope.Add( send = factory.Button( "Send" ).Name( "send" ) );
                }
            }
            return view;
        }
        private static Box CreateMessage(UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "message" ).Classes( style, "medium", "grow-1" ).Pipe( i => i.style.width = 2000 ).AsScope( out var view )) {
                VisualElementScope.Add( factory.Label( text ) );
                return view;
            }
        }

    }
}
