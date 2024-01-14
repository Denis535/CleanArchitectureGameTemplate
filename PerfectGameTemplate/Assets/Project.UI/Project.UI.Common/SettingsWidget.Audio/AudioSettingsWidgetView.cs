#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class AudioSettingsWidgetView : UIWidgetViewBase {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SliderFieldWrapper<float> MasterVolume { get; }
        public SliderFieldWrapper<float> MusicVolume { get; }
        public SliderFieldWrapper<float> SfxVolume { get; }
        public SliderFieldWrapper<float> GameVolume { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public AudioSettingsWidgetView(AudioSettingsWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = Factory.AudioSettingsView( out var view, out var title, out var masterVolume, out var musicVolume, out var sfxVolume, out var gameVolume, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            MasterVolume = masterVolume.Wrap();
            MusicVolume = musicVolume.Wrap();
            SfxVolume = sfxVolume.Wrap();
            GameVolume = gameVolume.Wrap();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
