#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IUIModalWidgetView {
    }
    public static class IUIModalWidgetViewExtensions {

        // IsModal
        public static bool IsModal(this UIWidgetBase widget) {
            return widget is IUIModalWidget;
        }

    }
}
