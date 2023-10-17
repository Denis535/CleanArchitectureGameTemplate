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
    public partial class AudioSettingsWidgetView : UIObservableWidgetViewBase {

        // View
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly Slider masterVolume;
        private readonly Slider musicVolume;
        private readonly Slider sfxVolume;
        private readonly Slider gameVolume;
        private readonly Button okey;
        private readonly Button back;
        // View
        public override VisualElement VisualElement => visualElement;
        public ElementWrapper View => visualElement.Wrap();
        public LabelWrapper Title => title.Wrap();
        public SliderWrapper<float> MasterVolume => masterVolume.Wrap();
        public SliderWrapper<float> MusicVolume => musicVolume.Wrap();
        public SliderWrapper<float> SfxVolume => sfxVolume.Wrap();
        public SliderWrapper<float> GameVolume => gameVolume.Wrap();
        public ButtonWrapper Okey => okey.Wrap();
        public ButtonWrapper Back => back.Wrap();

        // Constructor
        public AudioSettingsWidgetView(AudioSettingsWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out title, out masterVolume, out musicVolume, out sfxVolume, out gameVolume, out okey, out back );
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
        private static View CreateVisualElement(out Label title, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume, out Button okey, out Button back) {
            return UIFactory.MediumWidget( "audio-settings-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Audio Settings" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.ColumnGroup().Classes( "dark2", "large", "grow-1" ).Children(
                            masterVolume = UIFactory.Slider( "Master Volume", 0, 1 ).Name( "master-volume" ).Classes( "label-width-25" ),
                            musicVolume = UIFactory.Slider( "Music Volume", 0, 1 ).Name( "music-volume" ).Classes( "label-width-25" ),
                            sfxVolume = UIFactory.Slider( "Sfx Volume", 0, 1 ).Name( "sfx-volume" ).Classes( "label-width-25" ),
                            gameVolume = UIFactory.Slider( "Game Volume", 0, 1 ).Name( "game-volume" ).Classes( "label-width-25" )
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
