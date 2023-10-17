#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class JoinGameWidgetView {
        public record OkeyCommand() : UICommand<JoinGameWidgetView>;
        public record BackCommand() : UICommand<JoinGameWidgetView>;
    }
    public partial class JoinGameWidgetView : UIObservableWidgetViewBase {

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
        public JoinGameWidgetView(JoinGameWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out title, out gameSlot, out playerSlot, out okey, out back );
            okey.OnClick( evt => {
                new OkeyCommand().Execute( this );
            } );
            back.OnClick( evt => {
                new BackCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Label title, out Slot gameSlot, out Slot playerSlot, out Button okey, out Button back) {
            return UIFactory.LargeWidget( "join-game-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Join Game" ).Name( "title" )
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

    }
    public partial class JoinGameWidgetView {
        // GameView
        public class GameView_ : UIObservableSubViewBase {
            public record GameNameEvent(string GameName) : UIEvent<GameView_>;
            public record GameModeEvent(GameMode GameMode) : UIEvent<GameView_>;
            public record GameWorldEvent(GameWorld GameWorld) : UIEvent<GameView_>;
            public record IsGamePrivateEvent(bool IsGamePrivate) : UIEvent<GameView_>;

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
            public GameView_(JoinGameWidget widget) : base( widget ) {
                visualElement = CreateVisualElement( out title, out gameName, out gameMode, out gameWorld, out isGamePrivate );
                // View
                gameName.OnChange( evt => {
                    new GameNameEvent( evt.newValue ).Raise( this );
                } );
                gameMode.OnChange( evt => {
                    new GameModeEvent( evt.newValue ).Raise( this );
                } );
                gameWorld.OnChange( evt => {
                    new GameWorldEvent( evt.newValue ).Raise( this );
                } );
                isGamePrivate.OnChange( evt => {
                    new IsGamePrivateEvent( evt.newValue ).Raise( this );
                } );
            }
            public override void Dispose() {
                base.Dispose();
            }

            // Helpers
            private static ColumnGroup CreateVisualElement(out Label title, out TextField gameName, out PopupField<GameMode> gameMode, out PopupField<GameWorld> gameWorld, out Toggle isGamePrivate) {
                return UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        gameName = UIFactory.TextFieldReadOnly( "Name", 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        gameMode = UIFactory.PopupField<GameMode>( "Mode" ).Name( "game-mode" ).Classes( ".label-width-150px", "grow-1" ),
                        gameWorld = UIFactory.PopupField<GameWorld>( "World" ).Name( "game-world" ).Classes( ".label-width-150px", "grow-1" ),
                        isGamePrivate = UIFactory.Toggle( "Private" ).Name( "is-game-private" ).Classes( ".label-width-150px", "grow-0" )
                    )
                );
            }

        }
        // PlayerView
        public class PlayerView_ : UIObservableSubViewBase {
            public record PlayerNameEvent(string PlayerName) : UIEvent<PlayerView_>;
            public record PlayerRoleEvent(PlayerRole PlayerRole) : UIEvent<PlayerView_>;

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
            public PlayerView_(JoinGameWidget widget) : base( widget ) {
                visualElement = CreateVisualElement( out title, out playerName, out playerRole );
                // View
                playerName.OnChange( evt => {
                    new PlayerNameEvent( evt.newValue ).Raise( this );
                } );
                playerRole.OnChange( evt => {
                    new PlayerRoleEvent( evt.newValue ).Raise( this );
                } );
            }
            public override void Dispose() {
                base.Dispose();
            }

            // Helpers
            private static ColumnGroup CreateVisualElement(out Label title, out TextField playerName, out PopupField<PlayerRole> playerRole) {
                return UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        playerName = UIFactory.TextFieldReadOnly( "Name", 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        playerRole = UIFactory.PopupField<PlayerRole>( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" )
                    )
                );
            }

        }
    }
}
