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
            GameViewSlot = gameViewSlot.Wrap();
            PlayerViewSlot = playerViewSlot.Wrap();
            LobbyViewSlot = lobbyViewSlot.Wrap();
            ChatViewSlot = chatViewSlot.Wrap();
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
                            gameViewSlot = UIFactory.Slot( "game-view-slot" ).Classes( "grow-1", "basis-0pc" ),
                            playerViewSlot = UIFactory.Slot( "player-view-slot" ).Classes( "grow-1", "basis-0pc" )
                        ),
                        UIFactory.RowScope().Classes( "grow-1", "basis-auto" ).Children(
                            lobbyViewSlot = UIFactory.Slot( "lobby-view-slot" ).Classes( "grow-1", "basis-0pc" ),
                            chatViewSlot = UIFactory.Slot( "chat-view-slot" ).Classes( "grow-1", "basis-0pc" )
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
            return view = UIFactory.ColumnGroup( "game-view" ).Classes( "dark-100", "medium", "grow-1" ).Children(
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
            return view = UIFactory.ColumnGroup( "players-view" ).Classes( "dark-100", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                UIFactory.RowScope().Children(
                    name = UIFactory.TextField( null, 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
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

        // Constructor
        public LobbyView(UIWidgetBase widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title );
            View = view.Wrap();
            Title = title.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title) {
            return view = UIFactory.ColumnGroup( "lobby-view" ).Classes( "light-100", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "title" ),
                UIFactory.ScrollView( "players-view" ).Classes( "dark-30", "medium", "reverse", "grow-1" ).Children(
                    CreatePlayer( "Player 1" ),
                    CreatePlayer( "Player 2" ),
                    CreatePlayer( "Player 3" ),
                    CreatePlayer( "Player 4" ),
                    CreatePlayer( "Player 5" ),
                    CreatePlayer( "Player 6" ),
                    CreatePlayer( "Player 7" ),
                    CreatePlayer( "Player 8" ),
                    CreatePlayer( "Player 9" ),
                    CreatePlayer( "Player 10" ),
                    CreatePlayer( "Player 11" ),
                    CreatePlayer( "Player 12" ),
                    CreatePlayer( "Player 13" ),
                    CreatePlayer( "Player 14" ),
                    CreatePlayer( "Player 15" ),
                    CreatePlayer( "Player 16" ),
                    CreatePlayer( "Player 17" ),
                    CreatePlayer( "Player 18" ),
                    CreatePlayer( "Player 19" ),
                    CreatePlayer( "Player 20" ),
                    CreatePlayer( "Player 21" ),
                    CreatePlayer( "Player 22" ),
                    CreatePlayer( "Player 23" ),
                    CreatePlayer( "Player 24" ),
                    CreatePlayer( "Player 25" ),
                    CreatePlayer( "Player 26" ),
                    CreatePlayer( "Player 27" ),
                    CreatePlayer( "Player 28" ),
                    CreatePlayer( "Player 29" ),
                    CreatePlayer( "Player 30" ),
                    CreatePlayer( "Player 31" ),
                    CreatePlayer( "Player 32" ).Pipe( i => i.style.width = 1000 )
                )
            );
        }
        private static Box CreatePlayer(string text) {
            return UIFactory.Box( "player" ).Classes( "light-100", "small", "grow-1" ).Children( UIFactory.Label( text ).Classes( "margin-0px" ) );
        }

    }
    // ChatView
    public class ChatView : UISubViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }

        // Constructor
        public ChatView(UIWidgetBase widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title );
            View = view.Wrap();
            Title = title.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title) {
            return view = UIFactory.ColumnGroup( "chat-view" ).Classes( "light-100", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Chat" ).Name( "title" ).Classes( "title" ),
                UIFactory.ScrollView( "messages-view" ).Classes( "dark-30", "medium", "reverse", "grow-1" ).Children(
                    CreateMessage( "Message 1" ),
                    CreateMessage( "Message 2" ),
                    CreateMessage( "Message 3" )
                ),
                UIFactory.RowScope().Children(
                    UIFactory.TextField( null, 128, false ).Name( "message" ).Classes( "grow-1" ),
                    UIFactory.Button( "Ok" ).Name( "send" )
                )
            );
        }
        private static Box CreateMessage(string text) {
            return UIFactory.Box( "message" ).Classes( "dark-100", "small", "grow-1" ).Children( UIFactory.Label( text ).Classes( "margin-0px" ) );
        }

    }
}
