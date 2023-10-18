#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class CreateGameWidgetView2 : UIWidgetViewBase {

        // View
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly Slot gameSlot;
        private readonly Slot playerSlot;
        private readonly Button okey;
        private readonly Button back;
        // View
        public override VisualElement VisualElement => visualElement;
        // View
        public ElementWrapper View => visualElement.Wrap();
        public LabelWrapper Title => title.Wrap();
        public SlotWrapper GameSlot => gameSlot.Wrap();
        public SlotWrapper PlayerSlot => playerSlot.Wrap();
        public ButtonWrapper Okey => okey.Wrap();
        public ButtonWrapper Back => back.Wrap();

        // Constructor
        public CreateGameWidgetView2(CreateGameWidget2 widget) : base( widget ) {
            visualElement = CreateVisualElement( out title, out gameSlot, out playerSlot, out okey, out back );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Label title, out Slot gameSlot, out Slot playerSlot, out Button okey, out Button back) {
            return UIFactory.LargeWidget( "create-game-widget-view" ).Children(
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
            private readonly VisualElement visualElement;
            private readonly Label title;
            private readonly TextField gameName;
            private readonly PopupField<GameMode> gameMode;
            private readonly PopupField<GameWorld> gameWorld;
            private readonly Toggle isGamePrivate;
            // View
            public override VisualElement VisualElement => visualElement;
            public LabelWrapper Title => title.Wrap();
            public FieldWrapper<string> GameName => gameName.Wrap();
            public PopupWrapper<GameMode> GameMode => gameMode.Wrap();
            public PopupWrapper<GameWorld> GameWorld => gameWorld.Wrap();
            public ToggleWrapper<bool> IsGamePrivate => isGamePrivate.Wrap();

            // Constructor
            public GameView_(CreateGameWidget2 widget) : base( widget ) {
                visualElement = CreateVisualElement( out title, out gameName, out gameMode, out gameWorld, out isGamePrivate );
            }
            public override void Dispose() {
                base.Dispose();
            }

            // Helpers
            private static ColumnGroup CreateVisualElement(out Label title, out TextField gameName, out PopupField<GameMode> gameMode, out PopupField<GameWorld> gameWorld, out Toggle isGamePrivate) {
                return UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
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
            private readonly VisualElement visualElement;
            private readonly Label title;
            private readonly TextField playerName;
            private readonly PopupField<PlayerRole> playerRole;
            // View
            public override VisualElement VisualElement => visualElement;
            public LabelWrapper Title => title.Wrap();
            public FieldWrapper<string> PlayerName => playerName.Wrap();
            public PopupWrapper<PlayerRole> PlayerRole => playerRole.Wrap();

            // Constructor
            public PlayerView_(CreateGameWidget2 widget) : base( widget ) {
                visualElement = CreateVisualElement( out title, out playerName, out playerRole );
            }
            public override void Dispose() {
                base.Dispose();
            }

            // Helpers
            private static ColumnGroup CreateVisualElement(out Label title, out TextField playerName, out PopupField<PlayerRole> playerRole) {
                return UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
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
