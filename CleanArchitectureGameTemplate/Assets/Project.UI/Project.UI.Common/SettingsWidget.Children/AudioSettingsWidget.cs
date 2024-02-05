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
        protected override AudioSettingsWidgetView View { get; }

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

        // Submit
        public void Submit() {
            AudioSettings.MasterVolume = View.MasterVolume.Value;
            AudioSettings.MusicVolume = View.MusicVolume.Value;
            AudioSettings.SfxVolume = View.SfxVolume.Value;
            AudioSettings.GameVolume = View.GameVolume.Value;
            AudioSettings.Save();
        }
        public void Cancel() {
        }

        // Helpers
        private static AudioSettingsWidgetView CreateView(AudioSettingsWidget widget, UIFactory factory, Globals.AudioSettings audioSettings) {
            var view = new AudioSettingsWidgetView( factory );
            view.MasterVolume.OnChange( (masterVolume) => {
                audioSettings.MasterVolume = masterVolume;
            } );
            view.MusicVolume.OnChange( (musicVolume) => {
                audioSettings.MusicVolume = musicVolume;
            } );
            view.SfxVolume.OnChange( (sfxVolume) => {
                audioSettings.SfxVolume = sfxVolume;
            } );
            view.GameVolume.OnChange( (gameVolume) => {
                audioSettings.GameVolume = gameVolume;
            } );
            return view;
        }

    }
}
