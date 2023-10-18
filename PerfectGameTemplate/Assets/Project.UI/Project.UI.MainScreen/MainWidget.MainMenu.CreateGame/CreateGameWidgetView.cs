#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper GameSlot { get; }
        public SlotWrapper PlayerSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public CreateGameWidgetView(CreateGameWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var gameSlot, out var playerSlot, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            GameSlot = gameSlot.Wrap();
            PlayerSlot = playerSlot.Wrap();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Slot gameSlot, out Slot playerSlot, out Button okey, out Button back) {
            return view = UIFactory.LargeWidget( "create-game-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Create Game" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.RowScope().Classes( "grow-0", "basis-40" ).Children(
                            gameSlot = UIFactory.Slot().Classes( "grow-1", "basis-0" ),
                            playerSlot = UIFactory.Slot().Classes( "grow-1", "basis-0" )
                        ),
                        UIFactory.ColumnGroup().Classes( "dark5", "medium", "grow-1" ).Children(
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
            public PopupWrapper<GameMode> GameMode { get; }
            public PopupWrapper<GameWorld> GameWorld { get; }
            public ToggleWrapper<bool> IsGamePrivate { get; }

            // Constructor
            public GameView_(CreateGameWidget widget) : base( widget ) {
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
            private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out TextField gameName, out PopupField<GameMode> gameMode, out PopupField<GameWorld> gameWorld, out Toggle isGamePrivate) {
                return view = UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        gameName = UIFactory.TextField( "Name", 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        gameMode = UIFactory.PopupField<GameMode>( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ),
                        gameWorld = UIFactory.PopupField<GameWorld>( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ),
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
            public PopupWrapper<PlayerRole> PlayerRole { get; }

            // Constructor
            public PlayerView_(CreateGameWidget widget) : base( widget ) {
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
            private static ColumnGroup CreateVisualElement(out ColumnGroup view, out Label title, out TextField playerName, out PopupField<PlayerRole> playerRole) {
                return view = UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        playerName = UIFactory.TextField( "Name", 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        playerRole = UIFactory.PopupField<PlayerRole>( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" )
                    )
                );
            }

        }
    }
}
