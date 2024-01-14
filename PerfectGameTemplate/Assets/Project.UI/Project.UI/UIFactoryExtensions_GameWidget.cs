 namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions_GameWidget {

        // GameWidgetView
        public static View GameWidgetView(this UIFactory factory, out View view) {
            using (factory.Widget( "game-widget-view" ).AsScope( out view )) {
            }
            return view;
        }

        // GameMenuWidgetView
        public static View GameMenuWidgetView(this UIFactory factory, out View view, out Label title, out Button resume, out Button settings, out Button back) {
            using (factory.LeftWidget( "game-menu-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Game Menu" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        VisualElementScope.Add( resume = factory.Button( "Resume" ).Name( "resume" ) );
                        VisualElementScope.Add( settings = factory.Button( "Settings" ).Name( "settings" ) );
                        VisualElementScope.Add( back = factory.Button( "Back To Main Menu" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }
}
