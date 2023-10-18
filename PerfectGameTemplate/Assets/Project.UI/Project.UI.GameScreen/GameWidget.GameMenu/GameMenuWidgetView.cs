#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class GameMenuWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper Resume { get; }
        public ButtonWrapper Settings { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public GameMenuWidgetView(GameMenuWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var resume, out var settings, out var back );
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
        private static View CreateVisualElement(out View view, out Label title, out Button resume, out Button settings, out Button back) {
            return view = UIFactory.LeftWidget( "game-menu-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Game Menu" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        resume = UIFactory.Button( "Resume" ).Name( "resume" ),
                        settings = UIFactory.Button( "Settings" ).Name( "settings" ),
                        back = UIFactory.Button( "Back To Main Menu" ).Name( "back" )
                    )
                )
            );
        }

    }
}
