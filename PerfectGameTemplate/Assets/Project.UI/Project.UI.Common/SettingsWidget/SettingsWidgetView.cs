#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class SettingsWidgetView {
        public record PlayerProfileCommand() : UICommand<SettingsWidgetView>;
        public record VideoSettingsCommand() : UICommand<SettingsWidgetView>;
        public record AudioSettingsCommand() : UICommand<SettingsWidgetView>;
        public record BackCommand() : UICommand<SettingsWidgetView>;
    }
    public partial class SettingsWidgetView : UIWidgetViewBase {

        // Content
        private readonly Label title;
        private readonly Button playerProfile;
        private readonly Button videoSettings;
        private readonly Button audioSettings;
        private readonly Button back;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper PlayerProfile => playerProfile.Wrap();
        public TextElementWrapper VideoSettings => videoSettings.Wrap();
        public TextElementWrapper AudioSettings => audioSettings.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public SettingsWidgetView() {
            AddToClassList( "middle-widget-view" );
            // Content
            Add( GetContent( out title, out playerProfile, out videoSettings, out audioSettings, out back ) );
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
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static Card GetContent(out Label title, out Button playerProfile, out Button videoSettings, out Button audioSettings, out Button back) {
            return UIFactory.Card(
                UIFactory.Header(
                    title = UIFactory.Label( "Settings", "title" )
                ),
                UIFactory.Content(
                    UIFactory.ColumnGroup(
                        i => i.SetUp( null, ".dark2.large.grow-1" ),
                        playerProfile = UIFactory.Button( "Player Profile", "player-profile", ".width-75.align-self-center" ),
                        videoSettings = UIFactory.Button( "Video Settings", "video-settings", ".width-75.align-self-center" ),
                        audioSettings = UIFactory.Button( "Audio Settings", "audio-settings", ".width-75.align-self-center" )
                    )
                ),
                UIFactory.Footer(
                    back = UIFactory.Button( "Back", "back" )
                )
            );
        }

    }
}
