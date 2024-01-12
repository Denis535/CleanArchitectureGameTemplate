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
        public SlotWrapper GameSlot { get; }
        public SlotWrapper PlayerSlot { get; }
        public SlotWrapper LobbySlot { get; }
        public SlotWrapper ChatSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public JoinGameWidgetView(JoinGameWidget widget) : base( widget ) {
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
            using (UIFactory.LargeWidget( "join-game-widget-view" ).AsScope( out view )) {
                using (UIFactory.Card().AsScope()) {
                    using (UIFactory.Header().AsScope()) {
                        VisualElementScope.Add( title = UIFactory.Label( "Join Game" ).Name( "title" ) );
                    }
                    using (UIFactory.Content().AsScope()) {
                        using (UIFactory.RowScope().Name( "game-and-player-scope" ).Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            VisualElementScope.Add( gameSlot = UIFactory.Slot().Name( "game-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( playerSlot = UIFactory.Slot().Name( "player-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                        using (UIFactory.RowScope().Name( "lobby-and-chat-scope" ).Classes( "grow-1", "basis-auto" ).AsScope()) {
                            VisualElementScope.Add( lobbySlot = UIFactory.Slot().Name( "lobby-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( chatSlot = UIFactory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                    }
                    using (UIFactory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = UIFactory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = UIFactory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }
}
