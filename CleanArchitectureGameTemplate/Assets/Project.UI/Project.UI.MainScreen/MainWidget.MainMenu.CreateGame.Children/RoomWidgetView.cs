﻿#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class RoomWidgetView : UIViewBase {

        // VisualElement
        protected override VisualElement VisualElement { get; }
        public ElementWrapper Group { get; }
        public LabelWrapper Title { get; }
        public ViewListSlotWrapper<UIViewBase> PlayerSlot { get; }

        // Constructor
        public RoomWidgetView(UIFactory factory) {
            VisualElement = factory.RoomWidget( out var group, out var title, out var playerSlot );
            Group = group.Wrap();
            Title = title.Wrap();
            PlayerSlot = playerSlot.AsViewListSlot<UIViewBase>();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    public class RoomWidgetView_PlayerView : UIViewBase {

        // VisualElement
        protected override VisualElement VisualElement { get; }

        // Constructor
        public RoomWidgetView_PlayerView(UIFactory factory, string text, int id) {
            VisualElement = factory.RoomWidget_Player( text, id );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
