#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class MainMenuWidget : UIWidgetBase<MainMenuWidgetView> {

        // Globals
        private UIRouter Router { get; }
        // View
        public override MainMenuWidgetView View { get; }

        // Constructor
        public MainMenuWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            View = CreateView( this, Router );
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
        private static MainMenuWidgetView CreateView(MainMenuWidget widget, UIRouter router) {
            var view = UIViewFactory.MainMenuWidget( widget );
            view.CreateGame.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.CreateGameWidget() );
            } );
            view.JoinGame.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.JoinGameWidget() );
            } );
            view.Settings.OnClick( i => {
                widget.AttachChild( UIWidgetFactory.SettingsWidget() );
            } );
            view.Quit.OnClick( i => {
                var dialog = UIWidgetFactory.DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.Quit() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
