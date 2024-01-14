#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class GameMenuWidgetView : UIWidgetViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper Resume { get; }
        public ButtonWrapper Settings { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public GameMenuWidgetView(GameMenuWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.GameMenuWidgetView( out var view, out var title, out var resume, out var settings, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            Resume = resume.Wrap();
            Settings = settings.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
