#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class SettingsWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper PlayerProfile { get; }
        public ButtonWrapper VideoSettings { get; }
        public ButtonWrapper AudioSettings { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public SettingsWidgetView(SettingsWidget widget, UIFactory factory) : base( widget ) {
            VisualElement = factory.SettingsWidget( out var view, out var title, out var playerProfile, out var videoSettings, out var audioSettings, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            PlayerProfile = playerProfile.Wrap();
            VideoSettings = videoSettings.Wrap();
            AudioSettings = audioSettings.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
