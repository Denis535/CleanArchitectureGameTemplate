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
        }
        public override void OnDetach() {
        }

        // Submit
        public void Submit() {
            VideoSettings.IsFullScreen = View.IsFullScreen.Value;
            VideoSettings.ScreenResolution = (Resolution) View.ScreenResolution.Value!;
            VideoSettings.IsVSync = View.IsVSync.Value;
            VideoSettings.Save();
        }
        public void Cancel() {
            VideoSettings.Load();
        }

        // Helpers
        private static VideoSettingsWidgetView CreateView(VideoSettingsWidget widget, UIFactory factory, Globals.VideoSettings videoSettings) {
            var view = new VideoSettingsWidgetView( factory );
            view.Scope.OnAttachToPanel( () => {
                view.IsFullScreen.Value = videoSettings.IsFullScreen;
                view.ScreenResolution.ValueChoices = (videoSettings.ScreenResolution, videoSettings.ScreenResolutions.Cast<object?>().ToArray());
                view.IsVSync.Value = videoSettings.IsVSync;
            } );
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
