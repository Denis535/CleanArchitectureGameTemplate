#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.Common;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class MainMenuWidget : UIWidgetBase<MainMenuWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }

        // Constructor
        public MainMenuWidget() {
            Factory = Utils.Container.RequireDependency<UIFactory>( null );
            Router = Utils.Container.RequireDependency<UIRouter>( null );
            View = CreateView( this, Factory, Router );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
        }
        public override void OnDetach(object? argument) {
        }

        // Helpers
        private static MainMenuWidgetView CreateView(MainMenuWidget widget, UIFactory factory, UIRouter router) {
            var view = new MainMenuWidgetView( factory );
            view.CreateGame.OnClick( evt => {
                widget.AttachChild( new CreateGameWidget() );
            } );
            view.JoinGame.OnClick( evt => {
                widget.AttachChild( new JoinGameWidget() );
            } );
            view.Settings.OnClick( evt => {
                widget.AttachChild( new SettingsWidget() );
            } );
            view.Quit.OnClick( evt => {
                var dialog = new DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.Quit() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
