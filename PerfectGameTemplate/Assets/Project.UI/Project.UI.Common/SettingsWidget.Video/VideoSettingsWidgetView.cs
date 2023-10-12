#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class VideoSettingsWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<VideoSettingsWidgetView, UxmlTraits> { }
        public record IsFullScreenEvent(bool IsFullScreen) : UIEvent<VideoSettingsWidgetView>;
        public record ScreenResolutionEvent(object? ScreenResolution) : UIEvent<VideoSettingsWidgetView>;
        public record IsVSyncEvent(bool IsVSync) : UIEvent<VideoSettingsWidgetView>;
        public record OkeyCommand() : UICommand<VideoSettingsWidgetView>;
        public record BackCommand() : UICommand<VideoSettingsWidgetView>;
    }
    public partial class VideoSettingsWidgetView : UIWidgetViewBase {

        // Content
        private Label title = default!;
        private Toggle isFullScreen = default!;
        private DropdownField2 screenResolution = default!;
        private Toggle isVSync = default!;
        private Button okey = default!;
        private Button back = default!;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public FieldWrapper<bool> IsFullScreen => isFullScreen.Wrap();
        public PopupFieldWrapper<object> ScreenResolution => screenResolution.Wrap();
        public FieldWrapper<bool> IsVSync => isVSync.Wrap();
        public TextElementWrapper Okey => okey.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public VideoSettingsWidgetView() {
            AddToClassList( "middle-widget-view" );
            Add( CreateCard() );
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            title = this.RequireElement<Label>( "title" );
            isFullScreen = this.RequireElement<Toggle>( "is-full-screen" );
            screenResolution = this.RequireElement<DropdownField2>( "screen-resolution" );
            isVSync = this.RequireElement<Toggle>( "is-v-sync" );
            okey = this.RequireElement<Button>( "okey" );
            back = this.RequireElement<Button>( "back" );
            // OnEvent
            this.OnAttachToPanel( evt => {
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
        private static Card CreateCard() {
            return UIFactory.Card(
                UIFactory.Header(
                    UIFactory.Label( "Video Settings", "title" )
                ),
                UIFactory.Content(
                    UIFactory.ColumnGroup(
                        i => i.SetUp( null, ".dark2.large.grow-1" ),
                        UIFactory.Toggle( "Full Screen", "is-full-screen", "label-width-25" ),
                        UIFactory.DropdownField( "Screen Resolution", "screen-resolution", "label-width-25" ),
                        UIFactory.Toggle( "V-Sync", "is-v-sync", "label-width-25" )
                    )
                ),
                UIFactory.Footer(
                    UIFactory.Button( "Ok", "okey" ),
                    UIFactory.Button( "Back", "back" )
                )
            );
        }

    }
}
