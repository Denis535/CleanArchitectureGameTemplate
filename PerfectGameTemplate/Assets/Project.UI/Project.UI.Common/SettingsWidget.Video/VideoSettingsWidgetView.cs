#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class VideoSettingsWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ToggleFieldWrapper<bool> IsFullScreen { get; }
        public PopupFieldWrapper<object> ScreenResolution { get; }
        public ToggleFieldWrapper<bool> IsVSync { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public VideoSettingsWidgetView(VideoSettingsWidget widget, UIFactory factory) : base( widget ) {
            VisualElement = factory.VideoSettingsView( out var view, out var title, out var isFullScreen, out var screenResolution, out var isVSync, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            IsFullScreen = isFullScreen.Wrap();
            ScreenResolution = screenResolution.Wrap();
            IsVSync = isVSync.Wrap();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
