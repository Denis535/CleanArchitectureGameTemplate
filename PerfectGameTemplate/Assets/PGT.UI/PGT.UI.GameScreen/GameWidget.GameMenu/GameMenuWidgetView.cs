#nullable enable
namespace PGT.UI.GameScreen {
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
        public record ExitCommand() : UICommand<GameMenuWidgetView>;
        public record SubmitCommand() : UICommand<GameMenuWidgetView>;
        public record CancelCommand() : UICommand<GameMenuWidgetView>;
    }
    public partial class GameMenuWidgetView : UIWidgetView2 {

        // Content
        private Label title = default!;
        private Button resume = default!;
        private Button settings = default!;
        private Button exit = default!;
        // Prop
        public TextWrapper Title => title;
        public TextWrapper Resume => resume;
        public TextWrapper Settings => settings;
        public TextWrapper Exit => exit;

        // Constructor
        public GameMenuWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            title = this.RequireElement<Label>( "title" );
            resume = this.RequireElement<Button>( "resume" );
            settings = this.RequireElement<Button>( "settings" );
            exit = this.RequireElement<Button>( "exit" );
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
            resume.OnClickOrSubmit( evt => {
                new ResumeCommand().Execute( this );
            } );
            settings.OnClickOrSubmit( evt => {
                new SettingsCommand().Execute( this );
            } );
            exit.OnClickOrSubmit( evt => {
                new ExitCommand().Execute( this );
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
