#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class GameWidget : UIWidgetBase<GameWidgetView> {

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
            view.OnCommand( (GameWidgetView.PauseCommand cmd) => {
                this.AttachChild( UILogicalFactory.GameMenuWidget() );
            } );
            return view;
        }

    }
}
