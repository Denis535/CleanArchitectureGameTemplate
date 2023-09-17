#nullable enable
namespace Project.UI.MainScreen {
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
    }
    public partial class MainMenuWidgetView : UIWidgetView2 {

        // Content
        private Label title = default!;
        private Button createGame = default!;
        private Button joinGame = default!;
        private Button settings = default!;
        private Button quit = default!;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper CreateGame => createGame.Wrap();
        public TextElementWrapper JoinGame => joinGame.Wrap();
        public TextElementWrapper Settings => settings.Wrap();
        public TextElementWrapper Quit => quit.Wrap();

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
            createGame.OnClick( evt => {
                new CreateGameCommand().Execute( this );
            } );
            joinGame.OnClick( evt => {
                new JoinGameCommand().Execute( this );
            } );
            settings.OnClick( evt => {
                new SettingsCommand().Execute( this );
            } );
            quit.OnClick( evt => {
                new QuitCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
