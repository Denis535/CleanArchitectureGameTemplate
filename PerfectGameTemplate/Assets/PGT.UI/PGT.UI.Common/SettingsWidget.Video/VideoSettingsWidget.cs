#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class VideoSettingsWidget : UIWidget2<VideoSettingsWidgetView> {

        private Globals.VideoSettings VideoSettings => Singleton.GetInstance<Globals.VideoSettings>();

        // Constructor
        public VideoSettingsWidget() {
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
            VideoSettings.Load();
        }

        // Helpers/View
        private VideoSettingsWidgetView CreateView() {
            var view = UIVisualFactory.VideoSettingsWidget( VideoSettings );
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
                Router.DetachSelf();
            } );
            view.OnCommand( (VideoSettingsWidgetView.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (VideoSettingsWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (VideoSettingsWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
