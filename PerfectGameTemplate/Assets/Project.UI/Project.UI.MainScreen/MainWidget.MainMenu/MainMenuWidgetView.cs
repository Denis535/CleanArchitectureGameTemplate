#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class MainMenuWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public ButtonWrapper CreateGame { get; }
        public ButtonWrapper JoinGame { get; }
        public ButtonWrapper Settings { get; }
        public ButtonWrapper Quit { get; }

        // Constructor
        public MainMenuWidgetView(MainMenuWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var createGame, out var joinGame, out var settings, out var quit );
            View = view.Wrap();
            Title = title.Wrap();
            CreateGame = createGame.Wrap();
            JoinGame = joinGame.Wrap();
            Settings = settings.Wrap();
            Quit = quit.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out Button createGame, out Button joinGame, out Button settings, out Button quit) {
            using (UIFactory.LeftWidget( "main-menu-widget-view" ).AsScope( out view )) {
                using (UIFactory.Card().AsScope()) {
                    using (UIFactory.Header().AsScope()) {
                        VisualElementScope.Add( title = UIFactory.Label( "Main Menu" ).Name( "main-menu" ) );
                    }
                    using (UIFactory.Content().AsScope()) {
                        VisualElementScope.Add( createGame = UIFactory.Button( "Create Game" ).Name( "create-game" ) );
                        VisualElementScope.Add( joinGame = UIFactory.Button( "Join Game" ).Name( "join-game" ) );
                        VisualElementScope.Add( settings = UIFactory.Button( "Settings" ).Name( "settings" ) );
                        VisualElementScope.Add( quit = UIFactory.Button( "Quit" ).Name( "quit" ) );
                    }
                }
            }
            return view;
        }

    }
}
