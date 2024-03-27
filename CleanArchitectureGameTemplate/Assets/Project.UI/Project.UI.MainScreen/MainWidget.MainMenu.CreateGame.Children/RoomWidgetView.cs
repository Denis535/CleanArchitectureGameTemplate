#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class RoomWidgetView : UIViewBase {

        // View
        public ElementWrapper Group { get; }
        public LabelWrapper Title { get; }
        public ElementWrapper PlayersView { get; }
        public ViewListSlotWrapper<RoomWidgetView_PlayerView> PlayersSlot { get; }

        // Constructor
        public RoomWidgetView(UIFactory factory) {
            VisualElement = factory.RoomWidget( out var group, out var title, out var playersView );
            Group = group.Wrap();
            Title = title.Wrap();
            PlayersView = playersView.Wrap();
            PlayersSlot = playersView.AsViewListSlot<RoomWidgetView_PlayerView>();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    public class RoomWidgetView_PlayerView : UIViewBase {

        // Constructor
        public RoomWidgetView_PlayerView(UIFactory factory, string text, int id) {
            VisualElement = factory.RoomWidget_Player( text, id );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
