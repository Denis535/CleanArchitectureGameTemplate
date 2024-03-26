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
        public ElementWrapper MessagesView { get; }
        public ViewListSlotWrapper<ChatWidgetView_MessageView> MessagesSlot { get; }
        public TextFieldWrapper<string> Text { get; }
        public ButtonWrapper Send { get; }

        // Constructor
        public ChatWidgetView(UIFactory factory) {
            VisualElement = factory.ChatWidget( out var group, out var title, out var messagesView, out var text, out var send );
            Group = group.Wrap();
            Title = title.Wrap();
            MessagesView = messagesView.Wrap();
            MessagesSlot = messagesView.AsViewListSlot<ChatWidgetView_MessageView>();
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
            VisualElement = factory.ChatWidget_Message( text, id );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
