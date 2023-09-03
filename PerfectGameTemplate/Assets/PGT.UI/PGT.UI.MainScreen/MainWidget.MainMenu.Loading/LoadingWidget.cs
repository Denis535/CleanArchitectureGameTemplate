#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

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
            view.OnCommand( (LoadingWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (LoadingWidgetView.CancelCommand cmd) => {
            } );
            return view;
        }

    }
}
