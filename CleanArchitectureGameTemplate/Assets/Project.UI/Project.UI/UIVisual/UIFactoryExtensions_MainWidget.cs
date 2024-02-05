#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions_MainWidget {

        // MainWidget
        public static Widget MainWidget(this UIFactory factory, out Widget widget) {
            using (factory.Widget( "main-widget" ).AsScope( out widget )) {
            }
            return widget;
        }

        // MainMenuWidget
        public static Widget MainMenuWidget(this UIFactory factory, out Widget widget, out Label title, out Button createGame, out Button joinGame, out Button settings, out Button quit) {
            using (factory.LeftWidget( "main-menu-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Main Menu" ).Name( "main-menu" ) );
                    }
                    using (factory.Content().AsScope()) {
                        VisualElementScope.Add( createGame = factory.Select( "Create Game" ).Name( "create-game" ) );
                        VisualElementScope.Add( joinGame = factory.Select( "Join Game" ).Name( "join-game" ) );
                        VisualElementScope.Add( settings = factory.Select( "Settings" ).Name( "settings" ) );
                        VisualElementScope.Add( quit = factory.Select( "Quit" ).Name( "quit" ) );
                    }
                }
            }
            return widget;
        }

        // CreateGameWidget
        public static Widget CreateGameWidget(this UIFactory factory, out Widget widget, out Label title, out Slot gameDescSlot, out Slot playerDescSlot, out Slot roomSlot, out Slot chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "create-game-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Create Game" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            VisualElementScope.Add( gameDescSlot = factory.Slot().Name( "game-desc-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( playerDescSlot = factory.Slot().Name( "player-desc-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                        using (factory.RowScope().Classes( "grow-1", "basis-auto" ).AsScope()) {
                            VisualElementScope.Add( roomSlot = factory.Slot().Name( "room-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( chatSlot = factory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Submit( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Cancel( "Back" ).Name( "back" ) );
                    }
                }
            }
            return widget;
        }
        public static ColumnGroup GameDescWidget(this UIFactory factory, out ColumnGroup group, out Label title, out TextField name, out PopupField<object?> mode, out PopupField<object?> world, out Toggle isPrivate) {
            using (factory.ColumnGroup().Name( "game-desc" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( title = factory.Label( "Game" ).Name( "title" ).Classes( "medium" ) );
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( name = factory.TextField( null, null, 64 ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" ) );
                }
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( mode = factory.PopupField( "Mode", null ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( world = factory.PopupField( "World", null ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( isPrivate = factory.ToggleField( "Private", false ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" ) );
                }
            }
            return group;
        }
        public static ColumnGroup PlayerDescWidget(this UIFactory factory, out ColumnGroup group, out Label title, out TextField name, out PopupField<object?> role, out Toggle isReady) {
            using (factory.ColumnGroup().Name( "player-desc" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( title = factory.Label( "Player" ).Name( "title" ).Classes( "medium" ) );
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( name = factory.TextField( null, null, 64 ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" ) );
                }
                using (factory.RowScope().AsScope()) {
                    VisualElementScope.Add( role = factory.PopupField( "Role", null ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" ) );
                    VisualElementScope.Add( isReady = factory.ToggleField( "Ready", false ).Name( "is-player-ready" ).Classes( "label-width-150px", "grow-0" ) );
                }
            }
            return group;
        }
        public static ColumnGroup RoomWidget(this UIFactory factory, out ColumnGroup group, out Label title, out ScrollView players) {
            using (factory.ColumnGroup().Name( "room" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( title = factory.Label( "Room" ).Name( "title" ).Classes( "medium", "shrink-0" ) );
                VisualElementScope.Add( players = factory.ScrollView().Name( "players" ).Classes( "dark", "medium", "reverse", "grow-1" ) );
            }
            return group;
        }
        public static ColumnGroup ChatWidget(this UIFactory factory, out ColumnGroup group, out Label title, out ScrollView messages, out TextField text, out Button send) {
            using (factory.ColumnGroup().Name( "chat" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( title = factory.Label( "Chat" ).Name( "title" ).Classes( "medium", "shrink-0" ) );
                VisualElementScope.Add( messages = factory.ScrollView().Name( "messages" ).Classes( "dark", "medium", "reverse", "grow-1" ) );
                using (factory.RowScope().Classes( "shrink-0" ).AsScope()) {
                    VisualElementScope.Add( text = factory.TextField( null, null, 128 ).Name( "text" ).Classes( "grow-1" ) );
                    VisualElementScope.Add( send = factory.Button( "Send" ).Name( "send" ) );
                }
            }
            return group;
        }
        public static Box PlayerItem(this UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "player" ).Classes( style, "medium", "shrink-0" ).AsScope( out var view )) {
                VisualElementScope.Add( factory.Label( text ).Classes( "font-style-bold" ) );
                return view;
            }
        }
        public static Box MessageItem(this UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 4 ) switch {
                0 => "light2",
                1 => "light",
                2 => "gray",
                3 => "dark",
                4 => "dark2",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "message" ).Classes( style, "medium", "shrink-0" ).AsScope( out var view )) {
                VisualElementScope.Add( factory.Label( text ) );
                return view;
            }
        }

        // JoinGameWidget
        public static Widget JoinGameWidget(this UIFactory factory, out Widget widget, out Label title, out Slot gameDescSlot, out Slot playerDescSlot, out Slot roomSlot, out Slot chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "join-game-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Join Game" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            VisualElementScope.Add( gameDescSlot = factory.Slot().Name( "game-desc-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( playerDescSlot = factory.Slot().Name( "player-desc-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                        using (factory.RowScope().Classes( "grow-1", "basis-auto" ).AsScope()) {
                            VisualElementScope.Add( roomSlot = factory.Slot().Name( "room-slot" ).Classes( "grow-1", "basis-0pc" ) );
                            VisualElementScope.Add( chatSlot = factory.Slot().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Submit( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Cancel( "Back" ).Name( "back" ) );
                    }
                }
            }
            return widget;
        }

        // LoadingWidget
        public static Widget LoadingWidget(this UIFactory factory, out Widget widget, out Label loading) {
            using (factory.Widget( "loading-widget" ).AsScope( out widget )) {
                using (factory.ColumnScope().Classes( "padding-2pc", "grow-1", "justify-content-end", "align-items-center" ).AsScope()) {
                    VisualElementScope.Add( loading = factory.Label( "Loading..." ).Name( "loading" ).Classes( "color-light", "font-size-200pc", "font-style-bold" ) );
                }
            }
            return widget;
        }

    }
}
