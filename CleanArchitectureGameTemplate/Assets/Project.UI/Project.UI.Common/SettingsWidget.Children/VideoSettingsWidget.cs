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
        private UIFactory Factory { get; }
        private Globals.VideoSettings VideoSettings { get; }
        // View
        protected override VideoSettingsWidgetView View { get; }

        // Constructor
        public VideoSettingsWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            VideoSettings = this.GetDependencyContainer().Resolve<Globals.VideoSettings>( null );
            View = CreateView( this, Factory, VideoSettings );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.IsFullScreen.Value = VideoSettings.IsFullScreen;
            View.ScreenResolution.ValueChoices = (VideoSettings.ScreenResolution, VideoSettings.ScreenResolutions.Cast<object?>().ToArray());
            View.IsVSync.Value = VideoSettings.IsVSync;
        }
        public override void OnDetach() {
            VideoSettings.Load();
        }

        // Submit
        public void Submit() {
            VideoSettings.IsFullScreen = View.IsFullScreen.Value;
            VideoSettings.ScreenResolution = (Resolution) View.ScreenResolution.Value!;
            VideoSettings.IsVSync = View.IsVSync.Value;
            VideoSettings.Save();
        }
        public void Cancel() {
        }

        // Helpers
        private static VideoSettingsWidgetView CreateView(VideoSettingsWidget widget, UIFactory factory, Globals.VideoSettings videoSettings) {
            var view = new VideoSettingsWidgetView( factory );
            view.IsFullScreen.OnChange( (isFullScreen) => {
                videoSettings.IsFullScreen = isFullScreen;
            } );
            view.ScreenResolution.OnChange( (screenResolution) => {
                videoSettings.ScreenResolution = (Resolution) screenResolution!;
            } );
            view.IsVSync.OnChange( (isVSync) => {
                videoSettings.IsVSync = isVSync;
            } );
            return view;
        }

    }
}
