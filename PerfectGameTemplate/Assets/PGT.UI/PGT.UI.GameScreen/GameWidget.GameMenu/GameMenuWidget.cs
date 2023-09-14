#nullable enable
namespace PGT.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class GameMenuWidget : UIWidget2<GameMenuWidgetView> {

        // Globals
        private UIRouter Router { get; }

        // Constructor
        public GameMenuWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>();
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
        private GameMenuWidgetView CreateView() {
            var view = UIVisualFactory.GameMenuWidget();
            view.OnCommand( (GameMenuWidgetView.ResumeCommand cmd) => {
                this.DetachSelf();
            } );
            view.OnCommand( (GameMenuWidgetView.SettingsCommand cmd) => {
                this.AttachChild( UILogicalFactory.SettingsWidget() );
            } );
            view.OnCommand( (GameMenuWidgetView.MainMenuCommand cmd) => {
                var dialog = UILogicalFactory.DialogWidget( "Confirmation", "Are you sure?" ).Submit( "Yes", async () => await Router.LoadMainSceneAsync() ).Cancel( "No", null );
                this.AttachChild( dialog );
            } );
            return view;
        }

    }
}
