#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class MainMenuWidgetView : UIWidgetViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper CreateGame { get; }
        public ButtonWrapper JoinGame { get; }
        public ButtonWrapper Settings { get; }
        public ButtonWrapper Quit { get; }

        // Constructor
        public MainMenuWidgetView(MainMenuWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.MainMenuWidgetView( out var view, out var title, out var createGame, out var joinGame, out var settings, out var quit );
            View = view.Wrap();
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
