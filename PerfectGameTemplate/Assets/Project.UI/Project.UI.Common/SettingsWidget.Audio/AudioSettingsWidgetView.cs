#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class AudioSettingsWidgetView {
        public record MasterVolumeEvent(float MasterVolume) : UIEvent<AudioSettingsWidgetView>;
        public record MusicVolumeEvent(float MusicVolume) : UIEvent<AudioSettingsWidgetView>;
        public record SfxVolumeEvent(float SfxVolume) : UIEvent<AudioSettingsWidgetView>;
        public record GameVolumeEvent(float GameVolume) : UIEvent<AudioSettingsWidgetView>;
        public record OkeyCommand() : UICommand<AudioSettingsWidgetView>;
        public record BackCommand() : UICommand<AudioSettingsWidgetView>;
    }
    public partial class AudioSettingsWidgetView : UIWidgetViewBase {

        // VisualElement
        private readonly Label title;
        private readonly Slider masterVolume;
        private readonly Slider musicVolume;
        private readonly Slider sfxVolume;
        private readonly Slider gameVolume;
        private readonly Button okey;
        private readonly Button back;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public SliderFieldWrapper<float> MasterVolume => masterVolume.Wrap();
        public SliderFieldWrapper<float> MusicVolume => musicVolume.Wrap();
        public SliderFieldWrapper<float> SfxVolume => sfxVolume.Wrap();
        public SliderFieldWrapper<float> GameVolume => gameVolume.Wrap();
        public TextElementWrapper Okey => okey.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public AudioSettingsWidgetView(AudioSettingsWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement( out title, out masterVolume, out musicVolume, out sfxVolume, out gameVolume, out okey, out back );
            // OnEvent
            VisualElement.OnAttachToPanel( evt => {
            } );
            masterVolume.OnChange( evt => {
                new MasterVolumeEvent( evt.newValue ).Raise( this );
            } );
            musicVolume.OnChange( evt => {
                new MusicVolumeEvent( evt.newValue ).Raise( this );
            } );
            sfxVolume.OnChange( evt => {
                new SfxVolumeEvent( evt.newValue ).Raise( this );
            } );
            gameVolume.OnChange( evt => {
                new GameVolumeEvent( evt.newValue ).Raise( this );
            } );
            okey.OnClick( evt => {
                new OkeyCommand().Execute( this );
            } );
            back.OnClick( evt => {
                new BackCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement(out Label title, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume, out Button okey, out Button back) {
            return UIFactory.MediumWidget(
                i => i.Name( "audio-settings-widget-view" ),
                UIFactory.Card(
                    UIFactory.Header(
                        title = UIFactory.Label( "Audio Settings" ).Name( "title" )
                    ),
                    UIFactory.Content(
                        UIFactory.ColumnGroup(
                            i => i.Name( null ).Classes( "dark2", "large", "grow-1" ),
                            masterVolume = UIFactory.Slider( "Master Volume", 0, 1 ).Name( "master-volume" ).Classes( "label-width-25" ),
                            musicVolume = UIFactory.Slider( "Music Volume", 0, 1 ).Name( "music-volume" ).Classes( "label-width-25" ),
                            sfxVolume = UIFactory.Slider( "Sfx Volume", 0, 1 ).Name( "sfx-volume" ).Classes( "label-width-25" ),
                            gameVolume = UIFactory.Slider( "Game Volume", 0, 1 ).Name( "game-volume" ).Classes( "label-width-25" )
                        )
                    ),
                    UIFactory.Footer(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
}
