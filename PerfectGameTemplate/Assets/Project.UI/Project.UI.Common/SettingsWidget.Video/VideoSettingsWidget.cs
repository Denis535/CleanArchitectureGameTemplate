#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class VideoSettingsWidget : UIWidgetBase<VideoSettingsWidgetView> {

        // Globals
        private Globals.VideoSettings VideoSettings { get; }
        // View
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
            View.ScreenResolution.ValueChoices = (VideoSettings.ScreenResolution, VideoSettings.ScreenResolutions.Cast<object?>().ToArray());
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
            var view = new VideoSettingsWidgetView( widget );
            view.IsFullScreen.OnChange( (i, isFullScreen) => {
                videoSettings.IsFullScreen = isFullScreen;
            } );
            view.ScreenResolution.OnChange( (i, screenResolution) => {
                videoSettings.ScreenResolution = (Resolution) screenResolution!;
            } );
            view.IsVSync.OnChange( (i, isVSync) => {
                videoSettings.IsVSync = isVSync;
            } );
            view.Okey.OnClick( i => {
                videoSettings.IsFullScreen = view.IsFullScreen.Value;
                videoSettings.ScreenResolution = (Resolution) view.ScreenResolution.Value!;
                videoSettings.IsVSync = view.IsVSync.Value;
                videoSettings.Save();
                widget.DetachSelf();
            } );
            view.Back.OnClick( i => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
