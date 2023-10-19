﻿#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class JoinGameWidgetView2 : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper GameViewSlot { get; }
        public SlotWrapper PlayerViewSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public JoinGameWidgetView2(JoinGameWidget2 widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var gameViewSlot, out var playerViewSlot, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            GameViewSlot = gameViewSlot.Wrap();
            PlayerViewSlot = playerViewSlot.Wrap();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Slot gameViewSlot, out Slot playerViewSlot, out Button okey, out Button back) {
            return view = UIFactory.LargeWidget( "join-game-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Join Game" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.RowScope().Classes( "grow-0", "basis-40" ).Children(
                            gameViewSlot = UIFactory.Slot( "game-view-slot" ).Classes( "grow-1", "basis-0" ),
                            playerViewSlot = UIFactory.Slot( "player-view-slot" ).Classes( "grow-1", "basis-0" )
                        ),
                        UIFactory.ColumnGroup().Classes( "dark-5", "medium", "grow-1" ).Children(
                            UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "title" )
                        )
                    ),
                    UIFactory.Footer().Children(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

        // GameView
        public class GameView_ : UISubViewBase {

            // View
            public override VisualElement VisualElement { get; }
            public ElementWrapper View { get; }
            public LabelWrapper Title { get; }
            public TextWrapper<string> GameName { get; }
            public PopupWrapper<object> GameMode { get; }
            public PopupWrapper<object> GameWorld { get; }
            public ToggleWrapper<bool> IsGamePrivate { get; }

            // Constructor
            public GameView_(JoinGameWidget2 widget) : base( widget ) {
                VisualElement = CreateVisualElement( out var view, out var title, out var gameName, out var gameMode, out var gameWorld, out var isGamePrivate );
                View = view.Wrap();
                Title = title.Wrap();
                GameName = gameName.Wrap();
                GameMode = gameMode.Wrap();
                GameWorld = gameWorld.Wrap();
                IsGamePrivate = isGamePrivate.Wrap();
            }
            public override void Dispose() {
                base.Dispose();
            }

            // Helpers
            private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out TextField gameName, out PopupField<object?> gameMode, out PopupField<object?> gameWorld, out Toggle isGamePrivate) {
                return view = UIFactory.ColumnGroup().Classes( "light-5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        gameName = UIFactory.TextFieldReadOnly( "Name", 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        gameMode = UIFactory.PopupField( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ),
                        gameWorld = UIFactory.PopupField( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ),
                        isGamePrivate = UIFactory.Toggle( "Private" ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" )
                    )
                );
            }

        }
        // PlayerView
        public class PlayerView_ : UISubViewBase {

            // View
            public override VisualElement VisualElement { get; }
            public ElementWrapper View { get; }
            public LabelWrapper Title { get; }
            public TextWrapper<string> PlayerName { get; }
            public PopupWrapper<object> PlayerRole { get; }

            // Constructor
            public PlayerView_(JoinGameWidget2 widget) : base( widget ) {
                VisualElement = CreateVisualElement( out var view, out var title, out var playerName, out var playerRole );
                View = view.Wrap();
                Title = title.Wrap();
                PlayerName = playerName.Wrap();
                PlayerRole = playerRole.Wrap();
            }
            public override void Dispose() {
                base.Dispose();
            }

            // Helpers
            private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out TextField playerName, out PopupField<object?> playerRole) {
                return view = UIFactory.ColumnGroup().Classes( "light-5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        playerName = UIFactory.TextFieldReadOnly( "Name", 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        playerRole = UIFactory.PopupField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" )
                    )
                );
            }

        }
    }
}
