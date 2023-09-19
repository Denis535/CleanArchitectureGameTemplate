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
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.MasterVolume.Value = AudioSettings.MasterVolume;
            View.MusicVolume.Value = AudioSettings.MusicVolume;
            View.SfxVolume.Value = AudioSettings.SfxVolume;
            View.GameVolume.Value = AudioSettings.GameVolume;
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
            AudioSettings.Load();
        }

        // Helpers/View
        private AudioSettingsWidgetView CreateView() {
            var view = UIVisualFactory.AudioSettingsWidget();
            view.OnEvent( (AudioSettingsWidgetView.MasterVolumeEvent evt) => {
                AudioSettings.MasterVolume = evt.MasterVolume;
            } );
            view.OnEvent( (AudioSettingsWidgetView.MusicVolumeEvent evt) => {
                AudioSettings.MusicVolume = evt.MusicVolume;
            } );
            view.OnEvent( (AudioSettingsWidgetView.SfxVolumeEvent evt) => {
                AudioSettings.SfxVolume = evt.SfxVolume;
            } );
            view.OnEvent( (AudioSettingsWidgetView.GameVolumeEvent evt) => {
                AudioSettings.GameVolume = evt.GameVolume;
            } );
            view.OnCommand( (AudioSettingsWidgetView.OkeyCommand cmd) => {
                AudioSettings.MasterVolume = cmd.Sender.MasterVolume.Value;
                AudioSettings.MusicVolume = cmd.Sender.MusicVolume.Value;
                AudioSettings.SfxVolume = cmd.Sender.SfxVolume.Value;
                AudioSettings.GameVolume = cmd.Sender.GameVolume.Value;
                AudioSettings.Save();
                this.DetachSelf();
            } );
            view.OnCommand( (AudioSettingsWidgetView.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
