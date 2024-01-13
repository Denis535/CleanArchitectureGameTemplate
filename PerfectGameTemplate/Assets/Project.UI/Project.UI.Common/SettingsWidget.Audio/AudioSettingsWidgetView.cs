#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class AudioSettingsWidgetView : UIWidgetViewBase {

        // Factory
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
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var masterVolume, out var musicVolume, out var sfxVolume, out var gameVolume, out var okey, out var back );
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

        // Helpers
        private static View CreateVisualElement(UIFactory factory, out View view, out Label title, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume, out Button okey, out Button back) {
            using (factory.MediumWidget( "audio-settings-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Audio Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( masterVolume = factory.Slider( "Master Volume" ).Name( "master-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( musicVolume = factory.Slider( "Music Volume" ).Name( "music-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( sfxVolume = factory.Slider( "Sfx Volume" ).Name( "sfx-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( gameVolume = factory.Slider( "Game Volume" ).Name( "game-volume" ).Classes( "label-width-25pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }
}
