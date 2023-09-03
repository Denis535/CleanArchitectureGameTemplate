#nullable enable
namespace PGT.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class GameMenuWidget : UIWidget2<GameMenuWidgetView> {

        private UIRouter Router2 => Singleton.GetInstance<UIRouter>();

        // Constructor
        public GameMenuWidget() {
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
                Router.DetachSelf();
            } );
            view.OnCommand( (GameMenuWidgetView.SettingsCommand cmd) => {
                Router.AttachChild( UILogicalFactory.SettingsWidget() );
            } );
            view.OnCommand( (GameMenuWidgetView.ExitCommand cmd) => {
                var dialog = UILogicalFactory.DialogWidget( "Confirmation", "Are you sure?" ).SetConfirm( "Yes", async () => await Router2.LoadMainSceneAsync() ).SetCancel( "No", null );
                Router.AttachChild( dialog );
            } );
            view.OnCommand( (GameMenuWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (GameMenuWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
