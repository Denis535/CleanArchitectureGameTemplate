#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class AudioSettingsWidget : UIWidget2<AudioSettingsWidgetView> {

        private Globals.AudioSettings AudioSettings => Singleton.GetInstance<Globals.AudioSettings>();

        // Constructor
        public AudioSettingsWidget() {
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
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
            var view = UIVisualFactory.AudioSettingsWidget( AudioSettings );
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
                Router.DetachSelf();
            } );
            view.OnCommand( (AudioSettingsWidgetView.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (AudioSettingsWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (AudioSettingsWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
