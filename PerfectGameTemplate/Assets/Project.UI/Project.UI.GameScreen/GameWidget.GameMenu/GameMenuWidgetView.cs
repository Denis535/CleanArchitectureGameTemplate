#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class GameMenuWidgetView : UIWidgetViewBase {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper Resume { get; }
        public ButtonWrapper Settings { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public GameMenuWidgetView(GameMenuWidget widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var title, out var resume, out var settings, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            Resume = resume.Wrap();
            Settings = settings.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(UIFactory factory, out View view, out Label title, out Button resume, out Button settings, out Button back) {
            using (factory.LeftWidget( "game-menu-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Game Menu" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        VisualElementScope.Add( resume = factory.Button( "Resume" ).Name( "resume" ) );
                        VisualElementScope.Add( settings = factory.Button( "Settings" ).Name( "settings" ) );
                        VisualElementScope.Add( back = factory.Button( "Back To Main Menu" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }
}
