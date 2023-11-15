#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class SettingsWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper PlayerProfile { get; }
        public ButtonWrapper VideoSettings { get; }
        public ButtonWrapper AudioSettings { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public SettingsWidgetView(SettingsWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var playerProfile, out var videoSettings, out var audioSettings, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            PlayerProfile = playerProfile.Wrap();
            VideoSettings = videoSettings.Wrap();
            AudioSettings = audioSettings.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Button playerProfile, out Button videoSettings, out Button audioSettings, out Button back) {
            using (UIFactory.MediumWidget( "settings-widget-view" ).AsScope( out view )) {
                using (UIFactory.Card().AsScope()) {
                    using (UIFactory.Header().AsScope()) {
                        title = UIFactory.Label( "Settings" ).Name( "title" );
                    }
                    using (UIFactory.Content().AsScope()) {
                        using (UIFactory.ColumnGroup().Classes( "large", "grow-1" ).AsScope()) {
                            playerProfile = UIFactory.Button( "Player Profile" ).Name( "player-profile" ).Classes( "width-50pc", "align-self-center" );
                            videoSettings = UIFactory.Button( "Video Settings" ).Name( "video-settings" ).Classes( "width-50pc", "align-self-center" );
                            audioSettings = UIFactory.Button( "Audio Settings" ).Name( "audio-settings" ).Classes( "width-50pc", "align-self-center" );
                        }
                    }
                    using (UIFactory.Footer().AsScope()) {
                        back = UIFactory.Button( "Back" ).Name( "back" );
                    }
                }
            }
            return view;
        }

    }
}
