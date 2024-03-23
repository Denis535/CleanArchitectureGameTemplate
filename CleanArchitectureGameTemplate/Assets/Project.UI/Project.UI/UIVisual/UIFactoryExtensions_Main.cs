#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions_Main {

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
                        factory.Label( "Main Menu" ).Name( "main-menu" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope()) {
                        factory.Select( "Create Game" ).Name( "create-game" ).AddToScope( out createGame );
                        factory.Select( "Join Game" ).Name( "join-game" ).AddToScope( out joinGame );
                        factory.Select( "Settings" ).Name( "settings" ).AddToScope( out settings );
                        factory.Select( "Quit" ).Name( "quit" ).AddToScope( out quit );
                    }
                }
            }
            return widget;
        }

        // CreateGameWidget
        public static Widget CreateGameWidget(this UIFactory factory, out Widget widget, out Label title, out ColumnScope gameDescSlot, out ColumnScope playerDescSlot, out ColumnScope roomSlot, out ColumnScope chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "create-game-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        factory.Label( "Create Game" ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            factory.ColumnScope().Name( "game-desc-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out gameDescSlot );
                            factory.ColumnScope().Name( "player-desc-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out playerDescSlot );
                        }
                        using (factory.RowScope().Classes( "grow-1", "basis-auto" ).AsScope()) {
                            factory.ColumnScope().Name( "room-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out roomSlot );
                            factory.ColumnScope().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out chatSlot );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        factory.Submit( "Ok" ).Name( "okey" ).AddToScope( out okey );
                        factory.Cancel( "Back" ).Name( "back" ).AddToScope( out back );
                    }
                }
            }
            return widget;
        }
        public static ColumnGroup GameDescWidget(this UIFactory factory, out ColumnGroup group, out Label title, out TextField name, out PopupField<object?> mode, out PopupField<object?> world, out Toggle isPrivate) {
            using (factory.ColumnGroup().Name( "game-desc" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                factory.Label( "Game" ).Name( "title" ).Classes( "medium" ).AddToScope( out title );
                using (factory.RowScope().AsScope()) {
                    factory.TextField( null, null, 64 ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" ).AddToScope( out name );
                }
                using (factory.RowScope().AsScope()) {
                    factory.PopupField( "Mode", null ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ).AddToScope( out mode );
                    factory.PopupField( "World", null ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ).AddToScope( out world );
                    factory.ToggleField( "Private", false ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" ).AddToScope( out isPrivate );
                }
            }
            return group;
        }
        public static ColumnGroup PlayerDescWidget(this UIFactory factory, out ColumnGroup group, out Label title, out TextField name, out PopupField<object?> role, out Toggle isReady) {
            using (factory.ColumnGroup().Name( "player-desc" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                factory.Label( "Player" ).Name( "title" ).Classes( "medium" ).AddToScope( out title );
                using (factory.RowScope().AsScope()) {
                    factory.TextField( null, null, 64 ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" ).AddToScope( out name );
                }
                using (factory.RowScope().AsScope()) {
                    factory.PopupField( "Role", null ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" ).AddToScope( out role );
                    factory.ToggleField( "Ready", false ).Name( "is-player-ready" ).Classes( "label-width-150px", "grow-0" ).AddToScope( out isReady );
                }
            }
            return group;
        }
        public static ColumnGroup RoomWidget(this UIFactory factory, out ColumnGroup group, out Label title, out ScrollView players) {
            using (factory.ColumnGroup().Name( "room" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                factory.Label( "Room" ).Name( "title" ).Classes( "medium", "shrink-0" ).AddToScope( out title );
                factory.ScrollView().Name( "players" ).Classes( "dark5", "medium", "reverse", "grow-1" ).AddToScope( out players );
            }
            return group;
        }
        public static ColumnGroup ChatWidget(this UIFactory factory, out ColumnGroup group, out Label title, out ScrollView messages, out TextField text, out Button send) {
            using (factory.ColumnGroup().Name( "chat" ).Classes( "gray", "medium", "grow-1" ).AsScope( out group )) {
                factory.Label( "Chat" ).Name( "title" ).Classes( "medium", "shrink-0" ).AddToScope( out title );
                factory.ScrollView().Name( "messages" ).Classes( "dark5", "medium", "reverse", "grow-1" ).AddToScope( out messages );
                using (factory.RowScope().Classes( "shrink-0" ).AsScope()) {
                    factory.TextField( null, null, 128, true ).Name( "text" ).Classes( "max-height-100px", "grow-1" ).AddToScope( out text );
                    factory.Button( "Send" ).Name( "send" ).AddToScope( out send );
                }
            }
            return group;
        }
        public static Box PlayerItem(this UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 20 ) switch {
                0 => "light10",
                1 => "light9",
                2 => "light8",
                3 => "light7",
                4 => "light6",
                5 => "light5",
                6 => "light4",
                7 => "light3",
                8 => "light2",
                9 => "light",
                10 => "gray",
                11 => "dark",
                12 => "dark2",
                13 => "dark3",
                14 => "dark4",
                15 => "dark5",
                16 => "dark6",
                17 => "dark7",
                18 => "dark8",
                19 => "dark9",
                20 => "dark10",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "player" ).Classes( style, "medium", "shrink-0" ).AsScope( out var view )) {
                factory.Label( text ).Classes( "font-style-bold" ).AddToScope();
                return view;
            }
        }
        public static Box MessageItem(this UIFactory factory, string text, int id) {
            var style = (int) Mathf.PingPong( id, 20 ) switch {
                0 => "light10",
                1 => "light9",
                2 => "light8",
                3 => "light7",
                4 => "light6",
                5 => "light5",
                6 => "light4",
                7 => "light3",
                8 => "light2",
                9 => "light",
                10 => "gray",
                11 => "dark",
                12 => "dark2",
                13 => "dark3",
                14 => "dark4",
                15 => "dark5",
                16 => "dark6",
                17 => "dark7",
                18 => "dark8",
                19 => "dark9",
                20 => "dark10",
                _ => throw Exceptions.Internal.Exception( null )
            };
            using (factory.Box().Name( "message" ).Classes( style, "medium", "shrink-0" ).AsScope( out var view )) {
                factory.Label( text ).AddToScope();
                return view;
            }
        }

        // JoinGameWidget
        public static Widget JoinGameWidget(this UIFactory factory, out Widget widget, out Label title, out ColumnScope gameDescSlot, out ColumnScope playerDescSlot, out ColumnScope roomSlot, out ColumnScope chatSlot, out Button okey, out Button back) {
            using (factory.LargeWidget( "join-game-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        factory.Label( "Join Game" ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.RowScope().Classes( "grow-0", "basis-40pc" ).AsScope()) {
                            factory.ColumnScope().Name( "game-desc-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out gameDescSlot );
                            factory.ColumnScope().Name( "player-desc-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out playerDescSlot );
                        }
                        using (factory.RowScope().Classes( "grow-1", "basis-auto" ).AsScope()) {
                            factory.ColumnScope().Name( "room-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out roomSlot );
                            factory.ColumnScope().Name( "chat-slot" ).Classes( "grow-1", "basis-0pc" ).AddToScope( out chatSlot );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        factory.Submit( "Ok" ).Name( "okey" ).AddToScope( out okey );
                        factory.Cancel( "Back" ).Name( "back" ).AddToScope( out back );
                    }
                }
            }
            return widget;
        }

        // LoadingWidget
        public static Widget LoadingWidget(this UIFactory factory, out Widget widget, out Label loading) {
            using (factory.Widget( "loading-widget" ).AsScope( out widget )) {
                using (factory.ColumnScope().Classes( "padding-2pc", "grow-1", "justify-content-end", "align-items-center" ).AsScope()) {
                    factory.Label( "Loading..." ).Name( "loading" ).Classes( "color-light", "font-size-200pc", "font-style-bold" ).AddToScope( out loading );
                }
            }
            return widget;
        }

    }
}
