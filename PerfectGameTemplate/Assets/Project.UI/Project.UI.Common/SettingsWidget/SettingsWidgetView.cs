#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class SettingsWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<SettingsWidgetView, UxmlTraits> { }
        public record PlayerProfileCommand() : UICommand<SettingsWidgetView>;
        public record VideoSettingsCommand() : UICommand<SettingsWidgetView>;
        public record AudioSettingsCommand() : UICommand<SettingsWidgetView>;
        public record BackCommand() : UICommand<SettingsWidgetView>;
    }
    public partial class SettingsWidgetView : UIWidgetView2 {

        // Content
        private Label title = default!;
        private Button playerProfile = default!;
        private Button videoSettings = default!;
        private Button audioSettings = default!;
        private Button back = default!;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper PlayerProfile => playerProfile.Wrap();
        public TextElementWrapper VideoSettings => videoSettings.Wrap();
        public TextElementWrapper AudioSettings => audioSettings.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public SettingsWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            title = this.RequireElement<Label>( "title" );
            playerProfile = this.RequireElement<Button>( "player-profile" );
            videoSettings = this.RequireElement<Button>( "video-settings" );
            audioSettings = this.RequireElement<Button>( "audio-settings" );
            back = this.RequireElement<Button>( "back" );
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
            playerProfile.OnClick( evt => {
                new PlayerProfileCommand().Execute( this );
            } );
            videoSettings.OnClick( evt => {
                new VideoSettingsCommand().Execute( this );
            } );
            audioSettings.OnClick( evt => {
                new AudioSettingsCommand().Execute( this );
            } );
            back.OnClick( evt => {
                new BackCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
