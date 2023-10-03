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
        private static MainMenuWidgetView CreateView(UIWidgetBase widget, UIRouter router) {
            var view = UIViewFactory.MainMenuWidget();
            view.OnCommand( (MainMenuWidgetView.CreateGameCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.CreateGameWidget() );
            } );
            view.OnCommand( (MainMenuWidgetView.JoinGameCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.JoinGameWidget() );
            } );
            view.OnCommand( (MainMenuWidgetView.SettingsCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.SettingsWidget() );
            } );
            view.OnCommand( (MainMenuWidgetView.QuitCommand cmd) => {
                var dialog = UIWidgetFactory.DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.Quit() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
