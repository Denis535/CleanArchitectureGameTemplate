#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;

    public static class IPanelExtensions {

        private static readonly PropertyInfo FocusControllerProperty = typeof( EventDispatcher ).GetProperty( "focusController", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly );

        // SetFocusController
        public static void SetFocusController(this IPanel panel, FocusController focusController) {
            FocusControllerProperty.SetValue( panel, focusController );
        }

    }
}
