#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class MainMenuWidgetView {
        public record CreateGameCommand() : UICommand<MainMenuWidgetView>;
        public record JoinGameCommand() : UICommand<MainMenuWidgetView>;
        public record SettingsCommand() : UICommand<MainMenuWidgetView>;
        public record QuitCommand() : UICommand<MainMenuWidgetView>;
    }
    public partial class MainMenuWidgetView : UIWidgetViewBase {

        // Content
        private readonly Label title;
        private readonly Button createGame;
        private readonly Button joinGame;
        private readonly Button settings;
        private readonly Button quit;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper CreateGame => createGame.Wrap();
        public TextElementWrapper JoinGame => joinGame.Wrap();
        public TextElementWrapper Settings => settings.Wrap();
        public TextElementWrapper Quit => quit.Wrap();

        // Constructor
        public MainMenuWidgetView() {
            AddToClassList( "left-widget-view" );
            // Content
            Add( GetContent( out title, out createGame, out joinGame, out settings, out quit ) );
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

        // Helpers
        private static Card GetContent(out Label title, out Button createGame, out Button joinGame, out Button settings, out Button quit) {
            return UIFactory.Card(
                UIFactory.Header(
                    title = UIFactory.Label( "Main Menu" ).SetUp( "main-menu" )
                ),
                UIFactory.Content(
                    createGame = UIFactory.Button( "Create Game" ).SetUp( "create-game" ),
                    joinGame = UIFactory.Button( "Join Game" ).SetUp( "join-game" ),
                    settings = UIFactory.Button( "Settings" ).SetUp( "settings" ),
                    quit = UIFactory.Button( "Quit" ).SetUp( "quit" )
                ),
                null
            );
        }

    }
}
