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
                        UIFactory.RowScope().Classes( "grow-0", "basis-40" ).Children(
                            gameViewSlot = UIFactory.Slot( "game-view-slot" ).Classes( "grow-1", "basis-0" ),
                            playerViewSlot = UIFactory.Slot( "player-view-slot" ).Classes( "grow-1", "basis-0" )
                        ),
                        UIFactory.RowScope().Classes( "grow-1" ).Children(
                            lobbyViewSlot = UIFactory.Slot( "lobby-view-slot" ).Classes( "grow-1", "basis-0" ),
                            chatViewSlot = UIFactory.Slot( "chat-view-slot" ).Classes( "grow-1", "basis-0" )
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
            return view = UIFactory.ColumnGroup( "game-view" ).Classes( "light-5", "medium", "grow-1" ).Children(
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
            return view = UIFactory.ColumnGroup( "players-view" ).Classes( "light-5", "medium", "grow-1" ).Children(
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
            return view = UIFactory.ColumnGroup( "lobby-view" ).Classes( "dark-5", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "title" ),
                UIFactory.ScrollView( "players-view" ).Classes( "dark-5", "medium", "reverse", "grow-1" ).Children(
                    UIFactory.Box( "player-1" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 1" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-2" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 2" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-3" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 3" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-4" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 4" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-5" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 5" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-6" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 6" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-7" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 7" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-8" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 8" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-9" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 9" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-10" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 10" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-11" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 11" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-12" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 12" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-13" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 13" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-14" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 14" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-15" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 15" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-16" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 16" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-17" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 17" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-18" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 18" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-19" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 19" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-20" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 20" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-21" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 21" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-22" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 22" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-23" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 23" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-24" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 24" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-25" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 25" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-26" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 26" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-27" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 27" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-28" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 28" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-29" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 29" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-30" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 30" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-31" ).Classes( "dark-10", "small", "grow-1" ).Children( UIFactory.Label( "Player 31" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "player-32" ).Classes( "dark-10", "small", "grow-1" ).Pipe( i => i.style.width = 1000 ).Children( UIFactory.Label( "Player 32" ).Classes( "margin-0" ) )
                )
            );
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
            return view = UIFactory.ColumnGroup( "chat-view" ).Classes( "dark-5", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Chat" ).Name( "title" ).Classes( "title" ),
                UIFactory.ScrollView( "messages-view" ).Classes( "dark-5", "medium", "reverse", "grow-1" ).Children(
                    UIFactory.Box( "message-1" ).Classes( "light-10", "small", "grow-1" ).Children( UIFactory.Label( "Message 1" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "message-2" ).Classes( "light-10", "small", "grow-1" ).Children( UIFactory.Label( "Message 2" ).Classes( "margin-0" ) ),
                    UIFactory.Box( "message-3" ).Classes( "light-10", "small", "grow-1" ).Children( UIFactory.Label( "Message 3" ).Classes( "margin-0" ) )
                ),
                UIFactory.RowScope().Children(
                    UIFactory.TextField( null, 128, false ).Name( "message" ).Classes( "grow-1" ),
                    UIFactory.Button( "Ok" ).Name( "send" )
                )
            );
        }

    }
}
