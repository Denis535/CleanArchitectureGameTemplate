#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class CreateGameWidgetView : UIViewBase {

        // View
        public ElementWrapper Widget { get; }
        public LabelWrapper Title { get; }
        public WidgetSlotWrapper<GameDescWidget> GameDescSlot { get; }
        public WidgetSlotWrapper<PlayerDescWidget> PlayerDescSlot { get; }
        public WidgetSlotWrapper<RoomWidget> RoomSlot { get; }
        public WidgetSlotWrapper<ChatWidget> ChatSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public CreateGameWidgetView(UIFactory factory) {
            VisualElement = factory.CreateGameWidget( out var widget, out var title, out var gameDescSlot, out var playerDescSlot, out var roomSlot, out var chatSlot, out var okey, out var back );
            Widget = widget.Wrap();
            Title = title.Wrap();
            GameDescSlot = gameDescSlot.AsWidgetSlot<GameDescWidget>();
            PlayerDescSlot = playerDescSlot.AsWidgetSlot<PlayerDescWidget>();
            RoomSlot = roomSlot.AsWidgetSlot<RoomWidget>();
            ChatSlot = chatSlot.AsWidgetSlot<ChatWidget>();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
