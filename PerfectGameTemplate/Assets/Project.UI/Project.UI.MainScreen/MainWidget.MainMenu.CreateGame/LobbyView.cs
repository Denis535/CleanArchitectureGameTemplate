#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class LobbyView : UIViewBase {

        // VisualElement
        public override VisualElement VisualElement { get; }
        public ElementWrapper Group { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Players { get; }

        // Constructor
        public LobbyView(UIFactory factory) {
            VisualElement = factory.LobbyGroup( out var group, out var title, out var players );
            Group = group.Wrap();
            Title = title.Wrap();
            Players = players.AsSlot();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
