#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class MainMenuWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<MainMenuWidgetView, UxmlTraits> { }
        public record CreateGameCommand() : UICommand<MainMenuWidgetView>;
        public record JoinGameCommand() : UICommand<MainMenuWidgetView>;
        public record SettingsCommand() : UICommand<MainMenuWidgetView>;
        public record QuitCommand() : UICommand<MainMenuWidgetView>;
        public record SubmitCommand() : UICommand<MainMenuWidgetView>;
        public record CancelCommand() : UICommand<MainMenuWidgetView>;
    }
    public partial class MainMenuWidgetView : UIWidgetView2 {

        // Content
        private Label title = default!;
        private Button createGame = default!;
        private Button joinGame = default!;
        private Button settings = default!;
        private Button quit = default!;
        // Props
        public TextWrapper Title => title;
        public TextWrapper CreateGame => createGame;
        public TextWrapper JoinGame => joinGame;
        public TextWrapper Settings => settings;
        public TextWrapper Quit => quit;

        // Constructor
        public MainMenuWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            title = this.RequireElement<Label>( "title" );
            createGame = this.RequireElement<Button>( "create-game" );
            joinGame = this.RequireElement<Button>( "join-game" );
            settings = this.RequireElement<Button>( "settings" );
            quit = this.RequireElement<Button>( "quit" );
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
            createGame.OnClickOrSubmit( evt => {
                new CreateGameCommand().Execute( this );
            } );
            joinGame.OnClickOrSubmit( evt => {
                new JoinGameCommand().Execute( this );
            } );
            settings.OnClickOrSubmit( evt => {
                new SettingsCommand().Execute( this );
            } );
            quit.OnClickOrSubmit( evt => {
                new QuitCommand().Execute( this );
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
