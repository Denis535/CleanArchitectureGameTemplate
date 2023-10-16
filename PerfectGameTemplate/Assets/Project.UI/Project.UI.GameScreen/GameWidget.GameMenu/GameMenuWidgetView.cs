#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class GameMenuWidgetView {
        public record ResumeCommand() : UICommand<GameMenuWidgetView>;
        public record SettingsCommand() : UICommand<GameMenuWidgetView>;
        public record BackCommand() : UICommand<GameMenuWidgetView>;
    }
    public partial class GameMenuWidgetView : UIWidgetViewBase {

        // Props
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly Button resume;
        private readonly Button settings;
        private readonly Button back;
        // Prop
        public override VisualElement VisualElement => visualElement;
        public TextWrapper Title => title.Wrap();
        public TextWrapper Resume => resume.Wrap();
        public TextWrapper Settings => settings.Wrap();
        public TextWrapper Back => back.Wrap();

        // Constructor
        public GameMenuWidgetView(GameMenuWidget widget) : base( widget ) {
            // Props
            visualElement = CreateVisualElement( out title, out resume, out settings, out back );
            // OnEvent
            VisualElement.OnAttachToPanel( evt => {
            } );
            resume.OnClick( evt => {
                new ResumeCommand().Execute( this );
            } );
            settings.OnClick( evt => {
                new SettingsCommand().Execute( this );
            } );
            back.OnClick( evt => {
                new BackCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Label title, out Button resume, out Button settings, out Button back) {
            return UIFactory.LeftWidget( "game-menu-widget-view" ).Children(
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
