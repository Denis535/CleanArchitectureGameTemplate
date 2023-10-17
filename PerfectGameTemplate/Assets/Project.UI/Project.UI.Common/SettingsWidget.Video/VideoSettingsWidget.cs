#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class VideoSettingsWidget : UIWidgetBase<VideoSettingsWidgetView> {

        // Globals
        private Globals.VideoSettings VideoSettings { get; }
        // VIew
        public override VideoSettingsWidgetView View { get; }

        // Constructor
        public VideoSettingsWidget() {
            VideoSettings = this.GetDependencyContainer().Resolve<Globals.VideoSettings>( null );
            View = CreateView( this, VideoSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            View.IsFullScreen.Value = VideoSettings.IsFullScreen;
            View.ScreenResolution.ValueChoices = (VideoSettings.ScreenResolution, VideoSettings.ScreenResolutions);
            View.IsVSync.Value = VideoSettings.IsVSync;
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
            VideoSettings.Load();
        }

        // Helpers
        private static VideoSettingsWidgetView CreateView(VideoSettingsWidget widget, Globals.VideoSettings videoSettings) {
            var view = UIViewFactory.VideoSettingsWidget( widget );
            view.OnEvent( (VideoSettingsWidgetView.IsFullScreenEvent evt) => {
                videoSettings.IsFullScreen = evt.IsFullScreen;
            } );
            view.OnEvent( (VideoSettingsWidgetView.ScreenResolutionEvent evt) => {
                videoSettings.ScreenResolution = (Resolution) evt.ScreenResolution!;
            } );
            view.OnEvent( (VideoSettingsWidgetView.IsVSyncEvent evt) => {
                videoSettings.IsVSync = evt.IsVSync;
            } );
            view.OnCommand( (VideoSettingsWidgetView.OkeyCommand cmd) => {
                videoSettings.IsFullScreen = cmd.Sender.IsFullScreen.Value;
                videoSettings.ScreenResolution = cmd.Sender.ScreenResolution.Value;
                videoSettings.IsVSync = cmd.Sender.IsVSync.Value;
                videoSettings.Save();
                widget.DetachSelf();
            } );
            view.OnCommand( (VideoSettingsWidgetView.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
