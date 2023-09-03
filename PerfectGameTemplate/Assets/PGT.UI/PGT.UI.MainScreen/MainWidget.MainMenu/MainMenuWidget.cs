#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class MainMenuWidget : UIWidget2<MainMenuWidgetView> {

        private UIRouter Router2 => Singleton.GetInstance<UIRouter>();

        // Constructor
        public MainMenuWidget() {
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
        private MainMenuWidgetView CreateView() {
            var view = UIVisualFactory.MainMenuWidget();
            view.OnCommand( (MainMenuWidgetView.CreateGameCommand cmd) => {
                Router.AttachChild( UILogicalFactory.CreateGameWidget() );
            } );
            view.OnCommand( (MainMenuWidgetView.JoinGameCommand cmd) => {
                Router.AttachChild( UILogicalFactory.JoinGameWidget() );
            } );
            view.OnCommand( (MainMenuWidgetView.SettingsCommand cmd) => {
                Router.AttachChild( UILogicalFactory.SettingsWidget() );
            } );
            view.OnCommand( (MainMenuWidgetView.QuitCommand cmd) => {
                var dialog = UILogicalFactory.DialogWidget( "Confirmation", "Are you sure?" ).SetConfirm( "Yes", () => Router2.Quit() ).SetCancel( "No", null );
                Router.AttachChild( dialog );
            } );
            view.OnCommand( (MainMenuWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (MainMenuWidgetView.CancelCommand cmd) => {
                var dialog = UILogicalFactory.DialogWidget( "Confirmation", "Are you sure?" ).SetConfirm( "Yes", () => Router2.Quit() ).SetCancel( "No", null );
                Router.AttachChild( dialog );
            } );
            return view;
        }

    }
}
