namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions {

        // ScreenView
        public static VisualElement Screen(this UIFactory factory, out VisualElement screen, out VisualElement container, out VisualElement modalContainer) {
            var visualElement = screen = new VisualElement();
            visualElement.name = "screen";
            visualElement.AddToClassList( "screen" );
            visualElement.pickingMode = PickingMode.Ignore;
            {
                container = new VisualElement();
                container.name = "container";
                container.AddToClassList( "container" );
                container.pickingMode = PickingMode.Ignore;
                visualElement.Add( container );
            }
            {
                modalContainer = new VisualElement();
                modalContainer.name = "modal-container";
                modalContainer.AddToClassList( "modal-container" );
                modalContainer.pickingMode = PickingMode.Ignore;
                visualElement.Add( modalContainer );
            }
            return visualElement;
        }

    }
}
