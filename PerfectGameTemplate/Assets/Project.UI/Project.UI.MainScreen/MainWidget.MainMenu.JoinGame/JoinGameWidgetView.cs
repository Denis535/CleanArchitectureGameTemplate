#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class JoinGameWidgetView {
        public record OkeyCommand() : UICommand<JoinGameWidgetView>;
        public record BackCommand() : UICommand<JoinGameWidgetView>;
    }
    public partial class JoinGameWidgetView : UIWidgetViewBase {

        // Props
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly Slot gameSlot;
        private readonly Slot playerSlot;
        private readonly Button okey;
        private readonly Button back;
        // Props
        public override VisualElement VisualElement => visualElement;
        public TextWrapper Title => title.Wrap();
        public SlotWrapper GameSlot => gameSlot.Wrap();
        public SlotWrapper PlayerSlot => playerSlot.Wrap();
        public TextWrapper Okey => okey.Wrap();
        public TextWrapper Back => back.Wrap();

        // Constructor
        public JoinGameWidgetView(JoinGameWidget widget) : base( widget ) {
            // Props
            visualElement = CreateVisualElement( out title, out gameSlot, out playerSlot, out okey, out back );
            // OnEvent
            VisualElement.OnAttachToPanel( evt => {
            } );
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
    public partial class JoinGameWidgetView : UIWidgetViewBase {
        // GameView
        public class GameView_ : UISubViewBase {
            public record GameNameEvent(string GameName) : UIEvent<GameView_>;
            public record GameModeEvent(object? GameMode) : UIEvent<GameView_>;
            public record GameWorldEvent(object? GameWorld) : UIEvent<GameView_>;
            public record IsGamePrivateEvent(bool IsGamePrivate) : UIEvent<GameView_>;

            // Props
            private readonly VisualElement visualElement;
            private readonly Label title;
            private readonly TextField gameName;
            private readonly DropdownField2<object?> gameMode;
            private readonly DropdownField2<object?> gameWorld;
            private readonly Toggle isGamePrivate;
            // Props
            public override VisualElement VisualElement => visualElement;
            public TextWrapper Title => title.Wrap();
            public FieldWrapper<string> GameName => gameName.Wrap();
            public PopupWrapper<object> GameMode => gameMode.Wrap();
            public PopupWrapper<object> GameWorld => gameWorld.Wrap();
            public FieldWrapper<bool> IsGamePrivate => isGamePrivate.Wrap();

            // Constructor
            public GameView_(JoinGameWidget widget) : base( widget ) {
                // Props
                visualElement = CreateVisualElement( out title, out gameName, out gameMode, out gameWorld, out isGamePrivate );
                // OnEvent
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
            private static ColumnGroup CreateVisualElement(out Label title, out TextField gameName, out DropdownField2<object?> gameMode, out DropdownField2<object?> gameWorld, out Toggle isGamePrivate) {
                return UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        gameName = UIFactory.TextFieldReadOnly( "Name", 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        gameMode = UIFactory.DropdownField( "Mode" ).Name( "game-mode" ).Classes( ".label-width-150px", "grow-1" ),
                        gameWorld = UIFactory.DropdownField( "World" ).Name( "game-world" ).Classes( ".label-width-150px", "grow-1" ),
                        isGamePrivate = UIFactory.Toggle( "Private" ).Name( "is-game-private" ).Classes( ".label-width-150px", "grow-0" )
                    )
                );
            }

        }
        // PlayerView
        public class PlayerView_ : UISubViewBase {
            public record PlayerNameEvent(string PlayerName) : UIEvent<PlayerView_>;
            public record PlayerRoleEvent(object? PlayerRole) : UIEvent<PlayerView_>;

            // Props
            private readonly VisualElement visualElement;
            private readonly Label title;
            private readonly TextField playerName;
            private readonly DropdownField2<object?> playerRole;
            // Props
            public override VisualElement VisualElement => visualElement;
            public TextWrapper Title => title.Wrap();
            public FieldWrapper<string> PlayerName => playerName.Wrap();
            public PopupWrapper<object> PlayerRole => playerRole.Wrap();

            // Constructor
            public PlayerView_(JoinGameWidget widget) : base( widget ) {
                // Props
                visualElement = CreateVisualElement( out title, out playerName, out playerRole );
                // OnEvent
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
            private static ColumnGroup CreateVisualElement(out Label title, out TextField playerName, out DropdownField2<object?> playerRole) {
                return UIFactory.ColumnGroup().Classes( "light5", "medium", "grow-1" ).Children(
                    title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope().Children(
                        playerName = UIFactory.TextFieldReadOnly( "Name", 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope().Children(
                        playerRole = UIFactory.DropdownField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" )
                    )
                );
            }

        }
    }
}
