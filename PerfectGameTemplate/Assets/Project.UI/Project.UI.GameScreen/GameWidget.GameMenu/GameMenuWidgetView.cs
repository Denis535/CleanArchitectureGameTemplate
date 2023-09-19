#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class GameMenuWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<GameMenuWidgetView, UxmlTraits> { }
        public record ResumeCommand() : UICommand<GameMenuWidgetView>;
        public record SettingsCommand() : UICommand<GameMenuWidgetView>;
        public record MainMenuCommand() : UICommand<GameMenuWidgetView>;
    }
    public partial class GameMenuWidgetView : UIWidgetViewBase {

        // Content
        private Label title = default!;
        private Button resume = default!;
        private Button settings = default!;
        private Button mainMenu = default!;
        // Prop
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper Resume => resume.Wrap();
        public TextElementWrapper Settings => settings.Wrap();
        public TextElementWrapper MainMenu => mainMenu.Wrap();

        // Constructor
        public GameMenuWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            title = this.RequireElement<Label>( "title" );
            resume = this.RequireElement<Button>( "resume" );
            settings = this.RequireElement<Button>( "settings" );
            mainMenu = this.RequireElement<Button>( "main-menu" );
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
            resume.OnClick( evt => {
                new ResumeCommand().Execute( this );
            } );
            settings.OnClick( evt => {
                new SettingsCommand().Execute( this );
            } );
            mainMenu.OnClick( evt => {
                new MainMenuCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
