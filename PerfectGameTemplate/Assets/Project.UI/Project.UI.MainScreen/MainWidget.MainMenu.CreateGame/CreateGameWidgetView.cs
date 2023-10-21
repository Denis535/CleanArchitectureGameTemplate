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
            return view = UIFactory.ColumnGroup().Classes( "light-5", "medium", "grow-1" ).Children(
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
            return view = UIFactory.ColumnGroup().Classes( "light-5", "medium", "grow-1" ).Children(
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
            return view = UIFactory.ColumnGroup().Classes( "dark-5", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "title" ),
                UIFactory.ScrollView( "players-scroll-view" ).Classes( "dark-5", "grow-1" ).Children(
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 1" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 2" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 3" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 4" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 5" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 6" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 7" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 8" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 9" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 10" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 11" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 12" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 13" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 14" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 15" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 16" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 17" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 18" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 19" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 20" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 21" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 22" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 23" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 24" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 25" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 26" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 27" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 28" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 29" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 30" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 31" ) ),
                    UIFactory.Box().Classes( "light-5", "small", "grow-1" ).Children( UIFactory.Label( "Player 32" ) )
                )
            );
        }

        //public class LobbyItemView : UISubViewBase {

        //    // View
        //    public override VisualElement VisualElement { get; }
        //    public ElementWrapper View { get; }

        //    // Constructor
        //    public LobbyItemView(UIWidgetBase widget) : base( widget ) {
        //        VisualElement = CreateVisualElement( out var view );
        //        View = view.Wrap();
        //    }
        //    public override void Dispose() {
        //        base.Dispose();
        //    }

        //    // Helpers
        //    private static Box CreateVisualElement(out Box view) {
        //        return view = UIFactory.Box().Classes( "light-5", "small", "grow-1" );
        //    }

        //}

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
            return view = UIFactory.ColumnGroup().Classes( "dark-5", "medium", "grow-1" ).Children(
                title = UIFactory.Label( "Chat" ).Name( "title" ).Classes( "title" )
            );
        }

    }
}
