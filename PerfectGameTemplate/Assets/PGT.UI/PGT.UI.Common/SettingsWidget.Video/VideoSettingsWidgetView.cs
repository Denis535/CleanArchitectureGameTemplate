#nullable enable
namespace PGT.UI.Common {
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
        public record SubmitCommand() : UICommand<VideoSettingsWidgetView>;
        public record CancelCommand() : UICommand<VideoSettingsWidgetView>;
    }
    public partial class VideoSettingsWidgetView : UIWidgetView2 {

        // Content
        private Label title = default!;
        private Toggle isFullScreen = default!;
        private DropdownField2 screenResolution = default!;
        private Toggle isVSync = default!;
        private Button okey = default!;
        private Button back = default!;
        // Props
        public TextWrapper Title => title;
        public ValueWrapper<bool> IsFullScreen => isFullScreen;
        public ValueChoicesWrapper<object?> ScreenResolution => screenResolution;
        public ValueWrapper<bool> IsVSync => isVSync;
        public TextWrapper Okey => okey;
        public TextWrapper Back => back;

        // Constructor
        public VideoSettingsWidgetView() {
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
            okey.OnClickOrSubmit( evt => {
                new OkeyCommand().Execute( this );
            } );
            back.OnClickOrSubmit( evt => {
                new BackCommand().Execute( this );
            } );
            this.OnSubmit( evt => {
                new SubmitCommand().Execute( this );
            } );
            this.OnCancel( evt => {
                new CancelCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
