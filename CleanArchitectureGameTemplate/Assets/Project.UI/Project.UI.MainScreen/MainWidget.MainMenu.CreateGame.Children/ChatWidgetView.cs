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
        public SlotWrapper Messages { get; }
        public TextFieldWrapper<string> Text { get; }
        public ButtonWrapper Send { get; }

        // Constructor
        public ChatWidgetView(UIFactory factory) {
            VisualElement = factory.ChatWidget( out var group, out var title, out var messages, out var text, out var send );
            Group = group.Wrap();
            Title = title.Wrap();
            Messages = messages.AsSlot();
            Messages.OnAdded( message => { // dirty hack
                var view = (ScrollView) Messages.VisualElement;
                using var evt = GeometryChangedEvent.GetPooled( Rect.zero, view.contentContainer.layout );
                evt.target = view.contentContainer;
                view.contentContainer.SendEvent( evt );
            } );
            Messages.OnRemoved( message => { // dirty hack
                var view = (ScrollView) Messages.VisualElement;
                using var evt = GeometryChangedEvent.GetPooled( Rect.zero, view.contentContainer.layout );
                evt.target = view.contentContainer;
                view.contentContainer.SendEvent( evt );
            } );
            Text = text.Wrap();
            Send = send.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
