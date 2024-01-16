#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.Common;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class MainMenuWidget : UIWidgetBase<MainMenuWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        // View
        public override MainMenuWidgetView View { get; }

        // Constructor
        public MainMenuWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            View = CreateView( this, Factory, Router );
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
        private static MainMenuWidgetView CreateView(MainMenuWidget widget, UIFactory factory, UIRouter router) {
            var view = new MainMenuWidgetView( factory );
            view.CreateGame.OnClick( i => {
                widget.AttachChild( new CreateGameWidget() );
            } );
            view.JoinGame.OnClick( i => {
                widget.AttachChild( new JoinGameWidget() );
            } );
            view.Settings.OnClick( i => {
                widget.AttachChild( new SettingsWidget() );
            } );
            view.Quit.OnClick( i => {
                var dialog = new DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.Quit() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
