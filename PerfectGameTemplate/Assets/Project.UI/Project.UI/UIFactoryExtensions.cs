namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions {

        // ScreenView
        public static VisualElement ScreenView(this UIFactory factory, out VisualElement view, out VisualElement viewsContainer, out VisualElement modalViewsContainer) {
            var visualElement = view = new VisualElement();
            visualElement.name = "screen-view";
            visualElement.AddToClassList( "screen-view" );
            visualElement.pickingMode = PickingMode.Ignore;
            {
                viewsContainer = new VisualElement();
                viewsContainer.name = "views-container";
                viewsContainer.AddToClassList( "views-container" );
                viewsContainer.pickingMode = PickingMode.Ignore;
                visualElement.Add( viewsContainer );
            }
            {
                modalViewsContainer = new VisualElement();
                modalViewsContainer.name = "modal-views-container";
                modalViewsContainer.AddToClassList( "modal-views-container" );
                modalViewsContainer.pickingMode = PickingMode.Ignore;
                visualElement.Add( modalViewsContainer );
            }
            return visualElement;
        }

        // DialogWidgetView
        public static View DialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.DialogWidget().AsScope( out view )) {
                using (factory.DialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }
        public static View InfoDialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.InfoDialogWidget().AsScope( out view )) {
                using (factory.InfoDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }
        public static View WarningDialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.WarningDialogWidget().AsScope( out view )) {
                using (factory.WarningDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }
        public static View ErrorDialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.ErrorDialogWidget().AsScope( out view )) {
                using (factory.ErrorDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }

    }
}
