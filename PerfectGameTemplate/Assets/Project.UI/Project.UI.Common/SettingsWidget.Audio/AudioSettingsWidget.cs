#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class AudioSettingsWidget : UIWidgetBase<AudioSettingsWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private Globals.AudioSettings AudioSettings { get; }
        // View
        public override AudioSettingsWidgetView View { get; }

        // Constructor
        public AudioSettingsWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            AudioSettings = this.GetDependencyContainer().Resolve<Globals.AudioSettings>( null );
            View = CreateView( this, Factory, AudioSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.MasterVolume.ValueMinMax = (AudioSettings.MasterVolume, 0, 1);
            View.MusicVolume.ValueMinMax = (AudioSettings.MusicVolume, 0, 1);
            View.SfxVolume.ValueMinMax = (AudioSettings.SfxVolume, 0, 1);
            View.GameVolume.ValueMinMax = (AudioSettings.GameVolume, 0, 1);
        }
        public override void OnDetach() {
            AudioSettings.Load();
        }

        // Helpers
        private static AudioSettingsWidgetView CreateView(AudioSettingsWidget widget, UIFactory factory, Globals.AudioSettings audioSettings) {
            var view = new AudioSettingsWidgetView( factory );
            view.MasterVolume.OnChange( (i, masterVolume) => {
                audioSettings.MasterVolume = masterVolume;
            } );
            view.MusicVolume.OnChange( (i, musicVolume) => {
                audioSettings.MusicVolume = musicVolume;
            } );
            view.SfxVolume.OnChange( (i, sfxVolume) => {
                audioSettings.SfxVolume = sfxVolume;
            } );
            view.GameVolume.OnChange( (i, gameVolume) => {
                audioSettings.GameVolume = gameVolume;
            } );
            view.Okey.OnClick( () => {
                audioSettings.MasterVolume = view.MasterVolume.Value;
                audioSettings.MusicVolume = view.MusicVolume.Value;
                audioSettings.SfxVolume = view.SfxVolume.Value;
                audioSettings.GameVolume = view.GameVolume.Value;
                audioSettings.Save();
                widget.DetachSelf();
            } );
            view.Back.OnClick( () => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
