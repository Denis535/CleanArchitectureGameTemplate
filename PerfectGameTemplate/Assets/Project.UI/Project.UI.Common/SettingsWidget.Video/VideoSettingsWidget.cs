#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class VideoSettingsWidget : UIWidget2<VideoSettingsWidgetView> {

        // Globals
        private Globals.VideoSettings VideoSettings { get; }

        // Constructor
        public VideoSettingsWidget() {
            VideoSettings = this.GetDependencyContainer().Resolve<Globals.VideoSettings>( null );
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.IsFullScreen.Value = VideoSettings.IsFullScreen;
            View.ScreenResolution.As<Resolution>().ValueChoices = (VideoSettings.ScreenResolution, VideoSettings.ScreenResolutions);
            View.IsVSync.Value = VideoSettings.IsVSync;
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
            VideoSettings.Load();
        }

        // Helpers/View
        private VideoSettingsWidgetView CreateView() {
            var view = UIVisualFactory.VideoSettingsWidget();
            view.OnEvent( (VideoSettingsWidgetView.IsFullScreenEvent evt) => {
                VideoSettings.IsFullScreen = evt.IsFullScreen;
            } );
            view.OnEvent( (VideoSettingsWidgetView.ScreenResolutionEvent evt) => {
                VideoSettings.ScreenResolution = (Resolution) evt.ScreenResolution!;
            } );
            view.OnEvent( (VideoSettingsWidgetView.IsVSyncEvent evt) => {
                VideoSettings.IsVSync = evt.IsVSync;
            } );
            view.OnCommand( (VideoSettingsWidgetView.OkeyCommand cmd) => {
                VideoSettings.IsFullScreen = cmd.Sender.IsFullScreen.Value;
                VideoSettings.ScreenResolution = cmd.Sender.ScreenResolution.As<Resolution>().Value;
                VideoSettings.IsVSync = cmd.Sender.IsVSync.Value;
                VideoSettings.Save();
                this.DetachSelf();
            } );
            view.OnCommand( (VideoSettingsWidgetView.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
