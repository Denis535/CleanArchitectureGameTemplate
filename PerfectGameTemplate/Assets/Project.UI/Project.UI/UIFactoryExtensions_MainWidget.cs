namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions_MainWidget {

        // MainWidgetView
        public static Widget MainWidgetView(this UIFactory factory, out Widget view) {
            using (factory.Widget( "main-widget" ).AsScope( out view )) {
            }
            return view;
        }

        // MainMenuWidgetView
        public static Widget MainMenuWidgetView(this UIFactory factory, out Widget view, out Label title, out Button createGame, out Button joinGame, out Button settings, out Button quit) {
            using (factory.LeftWidget( "main-menu-widget" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Main Menu" ).Name( "main-menu" ) );
                    }
                    using (factory.Content().AsScope()) {
                        VisualElementScope.Add( createGame = factory.Button( "Create Game" ).Name( "create-game" ) );
                        VisualElementScope.Add( joinGame = factory.Button( "Join Game" ).Name( "join-game" ) );
                        VisualElementScope.Add( settings = factory.Button( "Settings" ).Name( "settings" ) );
                        VisualElementScope.Add( quit = factory.Button( "Quit" ).Name( "quit" ) );
                    }
                }
            }
            return view;
        }

        // CreateGameWidgetView
        public static Widget CreateGameWidgetView(this UIFactory factory, out Widget view, out Label title, out Slot gameSlot, out Slot playerSlot, out Slot lobbySlot, out Slot chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "create-game-widget" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Create Game" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Name( "game-and-player-scope" ).Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            VisualElementScope.Add( gameSlot = factory.Slot().Name( "game-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( playerSlot = factory.Slot().Name( "player-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                        using (factory.RowScope().Name( "lobby-and-chat-scope" ).Classes( "grow-1", "basis-auto" ).AsScope()) {
                            VisualElementScope.Add( lobbySlot = factory.Slot().Name( "lobby-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( chatSlot = factory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }
        public static ColumnGroup GameView(this UIFactory factory, out ColumnGroup view, out Label title, out TextField name, out PopupField<object?> mode, out PopupField<object?> world, out Toggle isPrivate) {
            using (factory.ColumnGroup().Name( "game-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Game" ).Name( "title" ).Classes( "medium" ) );
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( name = factory.TextField( null, 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" ) );
                }
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( mode = factory.PopupField( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( world = factory.PopupField( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( isPrivate = factory.Toggle( "Private" ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" ) );
                }
            }
            return view;
        }
        public static ColumnGroup PlayerView(this UIFactory factory, out ColumnGroup view, out Label title, out TextField name, out PopupField<object?> role, out Toggle isReady) {
            using (factory.ColumnGroup().Name( "player-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Player" ).Name( "title" ).Classes( "medium" ) );
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( name = factory.TextFieldReadOnly( null, 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" ) );
                }
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( role = factory.PopupField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( isReady = factory.Toggle( "Ready" ).Name( "is-player-ready" ).Classes( "label-width-150px", "grow-0" ) );
                }
            }
            return view;
        }
        public static ColumnGroup LobbyView(this UIFactory factory, out ColumnGroup view, out Label title, out ScrollView players) {
            using (factory.ColumnGroup().Name( "lobby-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Lobby" ).Name( "title" ).Classes( "medium", "shrink-0" ) );
                VisualElementScope.Add( players = factory.ScrollView().Name( "players-view" ).Classes( "dark2", "medium", "reverse", "grow-1" ) );
            }
            return view;
        }
        public static Box LobbyView_PlayerView(this UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "player" ).Classes( style, "medium", "grow-1", "shrink-0" ).Pipe( i => i.style.width = 2000 ).AsScope( out var view )) {
                VisualElementScope.Add( factory.Label( text ).Classes( "font-style-bold" ) );
                return view;
            }
        }
        public static ColumnGroup ChatView(this UIFactory factory, out ColumnGroup view, out Label title, out ScrollView messages, out TextField text, out Button send) {
            using (factory.ColumnGroup().Name( "chat-view" ).Classes( "gray", "medium", "grow-1" ).AsScope( out view )) {
                VisualElementScope.Add( title = factory.Label( "Chat" ).Name( "title" ).Classes( "medium", "shrink-0" ) );
                VisualElementScope.Add( messages = factory.ScrollView().Name( "messages-view" ).Classes( "dark", "medium", "reverse", "grow-1" ) );
                using (factory.RowScope().Name( "input-text-scope" ).Classes( "shrink-0" ).AsScope()) {
                    VisualElementScope.Add( text = factory.TextField( null, 128, false ).Name( "input-text" ).Classes( "grow-1" ) );
                    VisualElementScope.Add( send = factory.Button( "Send" ).Name( "send" ) );
                }
            }
            return view;
        }
        public static Box ChatView_MessageView(this UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "message" ).Classes( style, "medium", "grow-1", "shrink-0" ).Pipe( i => i.style.width = 2000 ).AsScope( out var view )) {
                VisualElementScope.Add( factory.Label( text ) );
                return view;
            }
        }

        // JoinGameWidgetView
        public static Widget JoinGameWidgetView(this UIFactory factory, out Widget view, out Label title, out Slot gameSlot, out Slot playerSlot, out Slot lobbySlot, out Slot chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "join-game-widget" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Join Game" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Name( "game-and-player-scope" ).Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            VisualElementScope.Add( gameSlot = factory.Slot().Name( "game-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( playerSlot = factory.Slot().Name( "player-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                        using (factory.RowScope().Name( "lobby-and-chat-scope" ).Classes( "grow-1", "basis-auto" ).AsScope()) {
                            VisualElementScope.Add( lobbySlot = factory.Slot().Name( "lobby-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( chatSlot = factory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

        // LoadingWidgetView
        public static Widget LoadingWidgetView(this UIFactory factory, out Widget view, out Label loading) {
            using (factory.Widget( "loading-widget" ).AsScope( out view )) {
                using (factory.ColumnScope().Classes( "padding-2pc", "grow-1", "justify-content-end", "align-items-center" ).AsScope()) {
                    VisualElementScope.Add( loading = factory.Label( "Loading..." ).Name( "loading" ).Classes( "color-light", "font-size-200pc", "font-style-bold" ) );
                }
            }
            return view;
        }

    }
}
