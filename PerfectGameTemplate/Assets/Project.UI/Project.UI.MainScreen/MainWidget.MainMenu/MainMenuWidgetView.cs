#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class MainMenuWidgetView : UIWidgetViewBase {

        // VisualElement
        public override VisualElement VisualElement { get; }
        public ElementWrapper Widget { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper CreateGame { get; }
        public ButtonWrapper JoinGame { get; }
        public ButtonWrapper Settings { get; }
        public ButtonWrapper Quit { get; }

        // Constructor
        public MainMenuWidgetView(UIFactory factory) {
            VisualElement = factory.MainMenuWidget( out var widget, out var title, out var createGame, out var joinGame, out var settings, out var quit );
            Widget = widget.Wrap();
            Title = title.Wrap();
            CreateGame = createGame.Wrap();
            JoinGame = joinGame.Wrap();
            Settings = settings.Wrap();
            Quit = quit.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
