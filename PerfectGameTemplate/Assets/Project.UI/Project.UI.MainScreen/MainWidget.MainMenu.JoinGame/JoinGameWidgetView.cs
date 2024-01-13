#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class JoinGameWidgetView : UIWidgetViewBase {

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
        public JoinGameWidgetView(JoinGameWidget widget, UIFactory factory) : base( widget ) {
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
            using (factory.LargeWidget( "join-game-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Join Game" ).Name( "title" ) );
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
}
