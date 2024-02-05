#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions_Game {

        // GameWidget
        public static Widget GameWidget(this UIFactory factory, out Widget widget) {
            using (factory.Widget( "game-widget" ).AsScope( out widget )) {
            }
            return widget;
        }

        // GameMenuWidget
        public static Widget GameMenuWidget(this UIFactory factory, out Widget widget, out Label title, out Button resume, out Button settings, out Button back) {
            using (factory.LeftWidget( "game-menu-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Game Menu" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        VisualElementScope.Add( resume = factory.Select( "Resume" ).Name( "resume" ) );
                        VisualElementScope.Add( settings = factory.Select( "Settings" ).Name( "settings" ) );
                        VisualElementScope.Add( back = factory.Select( "Back To Main Menu" ).Name( "back" ) );
                    }
                }
            }
            return widget;
        }

    }
}
