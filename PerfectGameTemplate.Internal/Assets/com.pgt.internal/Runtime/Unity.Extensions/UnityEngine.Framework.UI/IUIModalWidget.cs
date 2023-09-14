#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IUIModalWidget {
    }
    public static class IUIModalWidgetExtensions {

        // IsModal
        public static bool IsModal(this UIViewBase view) {
            return view is IUIModalWidgetView;
        }

    }
}
