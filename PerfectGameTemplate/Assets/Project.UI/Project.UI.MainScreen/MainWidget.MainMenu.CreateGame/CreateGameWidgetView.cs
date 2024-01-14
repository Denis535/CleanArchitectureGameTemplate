#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidgetView : UIWidgetViewBase {

        // Globals
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
        public CreateGameWidgetView(CreateGameWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.CreateGameWidgetView( out var view, out var title, out var gameSlot, out var playerSlot, out var lobbySlot, out var chatSlot, out var okey, out var back );
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

    // GameView
    public class GameView : UISubViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public PopupFieldWrapper<object> Mode { get; }
        public PopupFieldWrapper<object> World { get; }
        public ToggleFieldWrapper<bool> IsPrivate { get; }

        // Constructor
        public GameView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.GameView( out var view, out var title, out var name, out var mode, out var world, out var isPrivate );
            View = view.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Mode = mode.Wrap();
            World = world.Wrap();
            IsPrivate = isPrivate.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // PlayerView
    public class PlayerView : UISubViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public PopupFieldWrapper<object> Role { get; }
        public ToggleFieldWrapper<bool> IsReady { get; }

        // Constructor
        public PlayerView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.PlayerView( out var view, out var title, out var name, out var role, out var isReady );
            View = view.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Role = role.Wrap();
            IsReady = isReady.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // LobbyView
    public class LobbyView : UISubViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Players { get; }

        // Constructor
        public LobbyView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.LobbyView( out var view, out var title, out var players );
            View = view.Wrap();
            Title = title.Wrap();
            Players = players.AsSlot();
            for (var i = 1; i <= 32; i++) {
                Players.Add( Factory.LobbyView_PlayerView( $"Player: {i}", i - 1 ) );
            }
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // ChatView
    public class ChatView : UISubViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper Messages { get; }
        public TextFieldWrapper<string> Text { get; }
        public ButtonWrapper Send { get; }

        // Constructor
        public ChatView(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.ChatView( out var view, out var title, out var messages, out var text, out var send );
            View = view.Wrap();
            Title = title.Wrap();
            Messages = messages.AsSlot();
            Text = text.Wrap();
            Send = send.Wrap();
            for (var i = 1; i <= 32; i++) {
                Messages.Add( Factory.ChatView_MessageView( $"Message: {i}", i - 1 ) );
            }
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
