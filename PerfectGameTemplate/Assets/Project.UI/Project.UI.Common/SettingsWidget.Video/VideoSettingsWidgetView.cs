#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class VideoSettingsWidgetView {
        public record IsFullScreenEvent(bool IsFullScreen) : UIEvent<VideoSettingsWidgetView>;
        public record ScreenResolutionEvent(object? ScreenResolution) : UIEvent<VideoSettingsWidgetView>;
        public record IsVSyncEvent(bool IsVSync) : UIEvent<VideoSettingsWidgetView>;
        public record OkeyCommand() : UICommand<VideoSettingsWidgetView>;
        public record BackCommand() : UICommand<VideoSettingsWidgetView>;
    }
    public partial class VideoSettingsWidgetView : UIWidgetViewBase {

        // VisualElement
        private readonly Label title;
        private readonly Toggle isFullScreen;
        private readonly DropdownField2 screenResolution;
        private readonly Toggle isVSync;
        private readonly Button okey;
        private readonly Button back;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public FieldWrapper<bool> IsFullScreen => isFullScreen.Wrap();
        public PopupFieldWrapper<object> ScreenResolution => screenResolution.Wrap();
        public FieldWrapper<bool> IsVSync => isVSync.Wrap();
        public TextElementWrapper Okey => okey.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public VideoSettingsWidgetView(VideoSettingsWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement( out title, out isFullScreen, out screenResolution, out isVSync, out okey, out back );
            // OnEvent
            VisualElement.OnAttachToPanel( evt => {
            } );
            isFullScreen.OnChange( evt => {
                new IsFullScreenEvent( evt.newValue ).Raise( this );
            } );
            screenResolution.OnChange( evt => {
                new ScreenResolutionEvent( evt.newValue ).Raise( this );
            } );
            isVSync.OnChange( evt => {
                new IsVSyncEvent( evt.newValue ).Raise( this );
            } );
            okey.OnClick( evt => {
                new OkeyCommand().Execute( this );
            } );
            back.OnClick( evt => {
                new BackCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement(out Label title, out Toggle isFullScreen, out DropdownField2 screenResolution, out Toggle isVSync, out Button okey, out Button back) {
            return UIFactory.MediumWidget(
                i => i.Name( "video-settings-widget-view" ),
                UIFactory.Card(
                    UIFactory.Header(
                        title = UIFactory.Label( "Video Settings" ).Name( "title" )
                    ),
                    UIFactory.Content(
                        UIFactory.ColumnGroup(
                            i => i.Name( null ).Classes( "dark2", "large", "grow-1" ),
                            isFullScreen = UIFactory.Toggle( "Full Screen" ).Name( "is-full-screen" ).Classes( "label-width-25" ),
                            screenResolution = UIFactory.DropdownField( "Screen Resolution" ).Name( "screen-resolution" ).Classes( "label-width-25" ),
                            isVSync = UIFactory.Toggle( "V-Sync" ).Name( "is-v-sync" ).Classes( "label-width-25" )
                        )
                    ),
                    UIFactory.Footer(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
}
