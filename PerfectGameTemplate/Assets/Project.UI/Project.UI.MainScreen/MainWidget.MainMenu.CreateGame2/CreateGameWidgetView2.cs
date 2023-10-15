﻿#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class CreateGameWidgetView2 {
        public record OkeyCommand() : UICommand<CreateGameWidgetView2>;
        public record BackCommand() : UICommand<CreateGameWidgetView2>;
    }
    public partial class CreateGameWidgetView2 : UIWidgetViewBase {

        // Props
        private readonly VisualElement visualElement;
        private readonly Label title;
        private readonly GameView game = default!;
        private readonly PlayerView player = default!;
        private readonly Button okey;
        private readonly Button back;
        // Props
        public override VisualElement VisualElement => visualElement;
        public TextElementWrapper Title => title.Wrap();
        public GameView Game => game;
        public PlayerView Player => player;
        public TextElementWrapper Okey => okey.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public CreateGameWidgetView2(CreateGameWidget2 widget) : base( widget ) {
            // Props
            visualElement = CreateVisualElement( out title, out okey, out back );
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
        private static VisualElement CreateVisualElement(out Label title, out Button okey, out Button back) {
            return UIFactory.LargeWidget(
                i => i.Name( "create-game-widget-view" ),
                UIFactory.Card(
                    UIFactory.Header(
                        title = UIFactory.Label( "Create Game" ).Name( "title" )
                    ),
                    UIFactory.Content(
                        UIFactory.RowScope(
                            i => i.Name( null ).Classes( "grow-0", "basis-40" )
                            //gameView = new GameView().Name( null ).Classes( "grow-1", "basis-0" ),
                            //playerView = new PlayerView().Name( null ).Classes( "grow-1", "basis-0" )
                        ),
                        UIFactory.ColumnGroup(
                            i => i.Name( null ).Classes( "dark5", "medium", "grow-1" ),
                            UIFactory.Label( "Lobby" ).Name( "title" ).Classes( "title" )
                        )
                    ),
                    UIFactory.Footer(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
    public partial class CreateGameWidgetView2 : UIWidgetViewBase {
        public class GameView : UISubViewBase {
            public record GameNameEvent(string GameName) : UIEvent<GameView>;
            public record GameModeEvent(object? GameMode) : UIEvent<GameView>;
            public record GameWorldEvent(object? GameWorld) : UIEvent<GameView>;
            public record IsGamePrivateEvent(bool IsGamePrivate) : UIEvent<GameView>;

            // Props
            private readonly VisualElement visualElement;
            private readonly Label title = default!;
            private readonly TextField gameName = default!;
            private readonly DropdownField2 gameMode = default!;
            private readonly DropdownField2 gameWorld = default!;
            private readonly Toggle isGamePrivate = default!;
            // Props
            public override VisualElement VisualElement => visualElement;
            public TextElementWrapper Title => title.Wrap();
            public FieldWrapper<string> GameName => gameName.Wrap();
            public PopupFieldWrapper<object> GameMode => gameMode.Wrap();
            public PopupFieldWrapper<object> GameWorld => gameWorld.Wrap();
            public FieldWrapper<bool> IsGamePrivate => isGamePrivate.Wrap();

            // Constructor
            public GameView(CreateGameWidgetView2 view) : base( view ) {
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
            private static ColumnGroup CreateVisualElement(out Label title, out TextField gameName, out DropdownField2 gameMode, out DropdownField2 gameWorld, out Toggle isGamePrivate) {
                return UIFactory.ColumnGroup(
                    i => i.Name( null ).Classes( "light5", "medium", "grow-1" ),
                    title = UIFactory.Label( "Game" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope(
                        gameName = UIFactory.TextField( "Name", 100, false ).Name( "game-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope(
                        gameMode = UIFactory.DropdownField( "Mode" ).Name( "game-mode" ).Classes( "label-width-150px", "grow-1" ),
                        gameWorld = UIFactory.DropdownField( "World" ).Name( "game-world" ).Classes( "label-width-150px", "grow-1" ),
                        isGamePrivate = UIFactory.Toggle( "Private" ).Name( "is-game-private" ).Classes( "label-width-150px", "grow-0" )
                    )
                );
            }

        }
        public class PlayerView : UISubViewBase {
            public record PlayerNameEvent(string PlayerName) : UIEvent<PlayerView>;
            public record PlayerRoleEvent(object? PlayerRole) : UIEvent<PlayerView>;

            // Props
            private readonly VisualElement visualElement;
            private readonly Label title = default!;
            private readonly TextField playerName = default!;
            private readonly DropdownField2 playerRole = default!;
            // Props
            public override VisualElement VisualElement => visualElement;
            public TextElementWrapper Title => title.Wrap();
            public FieldWrapper<string> PlayerName => playerName.Wrap();
            public PopupFieldWrapper<object> PlayerRole => playerRole.Wrap();

            // Constructor
            public PlayerView(CreateGameWidgetView2 view) : base( view ) {
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
            private static ColumnGroup CreateVisualElement(out Label title, out TextField playerName, out DropdownField2 playerRole) {
                return UIFactory.ColumnGroup(
                    i => i.Name( null ).Classes( "light5", "medium", "grow-1" ),
                    title = UIFactory.Label( "Player" ).Name( "title" ).Classes( "title" ),
                    UIFactory.RowScope(
                        playerName = UIFactory.TextField( "Name", 100, false ).Name( "player-name" ).Classes( "label-width-150px", "grow-1" )
                    ),
                    UIFactory.RowScope(
                        playerRole = UIFactory.DropdownField( "Role" ).Name( "player-role" ).Classes( "label-width-150px", "grow-1" )
                    )
                );
            }

        }
    }
}
