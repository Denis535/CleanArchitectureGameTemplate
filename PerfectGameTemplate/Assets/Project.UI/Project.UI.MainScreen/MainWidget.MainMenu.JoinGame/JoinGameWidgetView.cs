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
        public JoinGameWidgetView(JoinGameWidget widget, UIFactory factory) : base( widget ) {
            VisualElement = factory.JoinGameWidget( out var view, out var title, out var gameSlot, out var playerSlot, out var lobbySlot, out var chatSlot, out var okey, out var back );
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

    }
}
