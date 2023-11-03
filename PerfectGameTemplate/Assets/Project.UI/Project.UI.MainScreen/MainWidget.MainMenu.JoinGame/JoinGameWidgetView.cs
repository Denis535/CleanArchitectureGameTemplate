#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class JoinGameWidgetView : UIWidgetViewBase {

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
        public JoinGameWidgetView(JoinGameWidget widget) : base( widget ) {
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
            return view = UIFactory.LargeWidget( "join-game-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Join Game" ).Name( "title" )
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
}
