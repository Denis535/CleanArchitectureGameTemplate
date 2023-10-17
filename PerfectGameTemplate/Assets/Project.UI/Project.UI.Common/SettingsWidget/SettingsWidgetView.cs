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
    public partial class SettingsWidgetView : UIObservableWidgetViewBase {

        // View
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly Button playerProfile;
        private readonly Button videoSettings;
        private readonly Button audioSettings;
        private readonly Button back;
        // View
        public override VisualElement VisualElement => visualElement;
        // View
        public ElementWrapper View => visualElement.Wrap();
        public LabelWrapper Title => title.Wrap();
        public ButtonWrapper PlayerProfile => playerProfile.Wrap();
        public ButtonWrapper VideoSettings => videoSettings.Wrap();
        public ButtonWrapper AudioSettings => audioSettings.Wrap();
        public ButtonWrapper Back => back.Wrap();

        // Constructor
        public SettingsWidgetView(SettingsWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out title, out playerProfile, out videoSettings, out audioSettings, out back );
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

        // Helpers
        private static View CreateVisualElement(out Label title, out Button playerProfile, out Button videoSettings, out Button audioSettings, out Button back) {
            return UIFactory.MediumWidget( "settings-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Settings" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.ColumnGroup().Classes( ".dark2", ".large", ".grow-1" ).Children(
                            playerProfile = UIFactory.Button( "Player Profile" ).Name( "player-profile" ).Classes( "width-75", "align-self-center" ),
                            videoSettings = UIFactory.Button( "Video Settings" ).Name( "video-settings" ).Classes( "width-75", "align-self-center" ),
                            audioSettings = UIFactory.Button( "Audio Settings" ).Name( "audio-settings" ).Classes( "width-75", "align-self-center" )
                        )
                    ),
                    UIFactory.Footer().Children(
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
}
