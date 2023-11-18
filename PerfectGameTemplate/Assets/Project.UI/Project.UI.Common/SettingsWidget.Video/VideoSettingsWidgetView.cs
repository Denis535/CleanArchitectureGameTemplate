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
        public ToggleWrapper<bool> IsFullScreen { get; }
        public PopupWrapper<object> ScreenResolution { get; }
        public ToggleWrapper<bool> IsVSync { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public VideoSettingsWidgetView(VideoSettingsWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var isFullScreen, out var screenResolution, out var isVSync, out var okey, out var back );
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

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Toggle isFullScreen, out PopupField<object?> screenResolution, out Toggle isVSync, out Button okey, out Button back) {
            using (UIFactory.MediumWidget( "video-settings-widget-view" ).AsScope( out view )) {
                using (UIFactory.Card().AsScope()) {
                    using (UIFactory.Header().AsScope()) {
                        title = UIFactory.Label( "Video Settings" ).Name( "title" );
                    }
                    using (UIFactory.Content().AsScope()) {
                        using (UIFactory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            isFullScreen = UIFactory.Toggle( "Full Screen" ).Name( "is-full-screen" ).Classes( "label-width-25pc" );
                            screenResolution = UIFactory.PopupField( "Screen Resolution" ).Name( "screen-resolution" ).Classes( "label-width-25pc" );
                            isVSync = UIFactory.Toggle( "V-Sync" ).Name( "is-v-sync" ).Classes( "label-width-25pc" );
                        }
                    }
                    using (UIFactory.Footer().AsScope()) {
                        okey = UIFactory.Button( "Ok" ).Name( "okey" );
                        back = UIFactory.Button( "Back" ).Name( "back" );
                    }
                }
            }
            return view;
        }

    }
}
