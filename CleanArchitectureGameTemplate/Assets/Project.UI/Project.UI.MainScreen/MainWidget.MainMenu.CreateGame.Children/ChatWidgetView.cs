#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class ChatWidgetView : UIViewBase {

        // VisualElement
        protected override VisualElement VisualElement { get; }
        public ElementWrapper Group { get; }
        public LabelWrapper Title { get; }
        public ViewListSlotWrapper<UIViewBase> MessageList { get; }
        public TextFieldWrapper<string> Text { get; }
        public ButtonWrapper Send { get; }

        // Constructor
        public ChatWidgetView(UIFactory factory) {
            VisualElement = factory.ChatWidget( out var group, out var title, out var messageList, out var text, out var send );
            Group = group.Wrap();
            Title = title.Wrap();
            MessageList = messageList.AsViewListSlot<UIViewBase>();
            Text = text.Wrap();
            Send = send.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    public class ChatWidgetView_MessageView : UIViewBase {

        // VisualElement
        protected override VisualElement VisualElement { get; }

        // Constructor
        public ChatWidgetView_MessageView(UIFactory factory, string text, int id) {
            VisualElement = factory.ChatWidget_MessageItem( text, id );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
