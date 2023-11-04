#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class AudioSettingsWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SliderWrapper<float> MasterVolume { get; }
        public SliderWrapper<float> MusicVolume { get; }
        public SliderWrapper<float> SfxVolume { get; }
        public SliderWrapper<float> GameVolume { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public AudioSettingsWidgetView(AudioSettingsWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var masterVolume, out var musicVolume, out var sfxVolume, out var gameVolume, out var okey, out var back );
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
        private static View CreateVisualElement(out View view, out Label title, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume, out Button okey, out Button back) {
            return view = UIFactory.MediumWidget( "audio-settings-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Audio Settings" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.ColumnGroup().Classes( "dark-30", "large", "grow-1" ).Children(
                            masterVolume = UIFactory.Slider( "Master Volume" ).Name( "master-volume" ).Classes( "label-width-25pc" ),
                            musicVolume = UIFactory.Slider( "Music Volume" ).Name( "music-volume" ).Classes( "label-width-25pc" ),
                            sfxVolume = UIFactory.Slider( "Sfx Volume" ).Name( "sfx-volume" ).Classes( "label-width-25pc" ),
                            gameVolume = UIFactory.Slider( "Game Volume" ).Name( "game-volume" ).Classes( "label-width-25pc" )
                        )
                    ),
                    UIFactory.Footer().Children(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
}
