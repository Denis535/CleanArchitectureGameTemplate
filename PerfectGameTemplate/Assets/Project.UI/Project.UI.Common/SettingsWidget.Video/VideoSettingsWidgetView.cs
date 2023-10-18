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
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly Toggle isFullScreen;
        private readonly PopupField<Resolution> screenResolution;
        private readonly Toggle isVSync;
        private readonly Button okey;
        private readonly Button back;
        // View
        public override VisualElement VisualElement => visualElement;
        // View
        public ElementWrapper View => visualElement.Wrap();
        public LabelWrapper Title => title.Wrap();
        public ToggleWrapper<bool> IsFullScreen => isFullScreen.Wrap();
        public PopupWrapper<Resolution> ScreenResolution => screenResolution.Wrap();
        public ToggleWrapper<bool> IsVSync => isVSync.Wrap();
        public ButtonWrapper Okey => okey.Wrap();
        public ButtonWrapper Back => back.Wrap();

        // Constructor
        public VideoSettingsWidgetView(VideoSettingsWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out title, out isFullScreen, out screenResolution, out isVSync, out okey, out back );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Label title, out Toggle isFullScreen, out PopupField<Resolution> screenResolution, out Toggle isVSync, out Button okey, out Button back) {
            return UIFactory.MediumWidget( "video-settings-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Video Settings" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.ColumnGroup().Classes( "dark2", "large", "grow-1" ).Children(
                            isFullScreen = UIFactory.Toggle( "Full Screen" ).Name( "is-full-screen" ).Classes( "label-width-25" ),
                            screenResolution = UIFactory.PopupField<Resolution>( "Screen Resolution" ).Name( "screen-resolution" ).Classes( "label-width-25" ),
                            isVSync = UIFactory.Toggle( "V-Sync" ).Name( "is-v-sync" ).Classes( "label-width-25" )
                        )
                    ),
                    UIFactory.Footer().Children(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
}
