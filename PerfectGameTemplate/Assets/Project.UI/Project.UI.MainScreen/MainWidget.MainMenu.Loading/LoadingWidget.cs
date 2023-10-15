#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class LoadingWidget : UIWidgetBase<LoadingWidgetView> {

        // View
        public override LoadingWidgetView View { get; }

        // Constructor
        public LoadingWidget() {
            View = CreateView( this );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
        }

        // Helpers
        private static LoadingWidgetView CreateView(LoadingWidget widget) {
            var view = UIViewFactory.LoadingWidget( widget );
            return view;
        }

    }
}
