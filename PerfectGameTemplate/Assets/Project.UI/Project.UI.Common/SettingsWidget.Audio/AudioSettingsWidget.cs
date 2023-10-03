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
        private Globals.AudioSettings AudioSettings { get; }

        // Constructor
        public AudioSettingsWidget() {
            AudioSettings = this.GetDependencyContainer().Resolve<Globals.AudioSettings>( null );
            View = CreateView( this, AudioSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            View.MasterVolume.Value = AudioSettings.MasterVolume;
            View.MusicVolume.Value = AudioSettings.MusicVolume;
            View.SfxVolume.Value = AudioSettings.SfxVolume;
            View.GameVolume.Value = AudioSettings.GameVolume;
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
            AudioSettings.Load();
        }

        // Helpers
        private static AudioSettingsWidgetView CreateView(UIWidgetBase widget, Globals.AudioSettings audioSettings) {
            var view = UIViewFactory.AudioSettingsWidget();
            view.OnEvent( (AudioSettingsWidgetView.MasterVolumeEvent evt) => {
                audioSettings.MasterVolume = evt.MasterVolume;
            } );
            view.OnEvent( (AudioSettingsWidgetView.MusicVolumeEvent evt) => {
                audioSettings.MusicVolume = evt.MusicVolume;
            } );
            view.OnEvent( (AudioSettingsWidgetView.SfxVolumeEvent evt) => {
                audioSettings.SfxVolume = evt.SfxVolume;
            } );
            view.OnEvent( (AudioSettingsWidgetView.GameVolumeEvent evt) => {
                audioSettings.GameVolume = evt.GameVolume;
            } );
            view.OnCommand( (AudioSettingsWidgetView.OkeyCommand cmd) => {
                audioSettings.MasterVolume = cmd.Sender.MasterVolume.Value;
                audioSettings.MusicVolume = cmd.Sender.MusicVolume.Value;
                audioSettings.SfxVolume = cmd.Sender.SfxVolume.Value;
                audioSettings.GameVolume = cmd.Sender.GameVolume.Value;
                audioSettings.Save();
                widget.DetachSelf();
            } );
            view.OnCommand( (AudioSettingsWidgetView.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
