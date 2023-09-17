#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LoadingWidget : UIWidget2<LoadingWidgetView> {

        // Constructor
        public LoadingWidget() {
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
        }

        // Helpers/View
        private LoadingWidgetView CreateView() {
            var view = UIVisualFactory.LoadingWidget();
            return view;
        }

    }
}
