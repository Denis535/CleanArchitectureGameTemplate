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

    }
}
