#nullable enable
namespace PGT.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class GameWidget : UIWidget2<GameWidgetView> {

        // Constructor
        public GameWidget() {
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
        private GameWidgetView CreateView() {
            var view = UIVisualFactory.GameWidget();
            view.OnCommand( (GameWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (GameWidgetView.CancelCommand cmd) => {
                Router.AttachChild( UILogicalFactory.GameMenuWidget() );
            } );
            return view;
        }

    }
}
