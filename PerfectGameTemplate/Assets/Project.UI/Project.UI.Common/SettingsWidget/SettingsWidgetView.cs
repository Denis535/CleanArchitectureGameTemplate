#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class SettingsWidgetView : UIWidgetViewBase {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper PlayerProfile { get; }
        public ButtonWrapper VideoSettings { get; }
        public ButtonWrapper AudioSettings { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public SettingsWidgetView(SettingsWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var playerProfile, out var videoSettings, out var audioSettings, out var back );
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
        private static View CreateVisualElement(UIFactory factory, out View view, out Label title, out Button playerProfile, out Button videoSettings, out Button audioSettings, out Button back) {
            using (factory.MediumWidget( "settings-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( playerProfile = factory.Button( "Player Profile" ).Name( "player-profile" ).Classes( "width-50pc", "align-self-center" ) );
                            VisualElementScope.Add( videoSettings = factory.Button( "Video Settings" ).Name( "video-settings" ).Classes( "width-50pc", "align-self-center" ) );
                            VisualElementScope.Add( audioSettings = factory.Button( "Audio Settings" ).Name( "audio-settings" ).Classes( "width-50pc", "align-self-center" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }
}
