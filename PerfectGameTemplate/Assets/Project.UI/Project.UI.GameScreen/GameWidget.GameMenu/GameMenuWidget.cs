﻿#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class GameMenuWidget : UIWidgetBase<GameMenuWidgetView> {

        // Globals
        private UIRouter Router { get; }
        // View
        public override GameMenuWidgetView View { get; protected init; }

        // Constructor
        public GameMenuWidget() {
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
        private static GameMenuWidgetView CreateView(GameMenuWidget widget, UIRouter router) {
            var view = UIViewFactory.GameMenuWidget( widget );
            view.OnCommand( (GameMenuWidgetView.ResumeCommand cmd) => {
                widget.DetachSelf();
            } );
            view.OnCommand( (GameMenuWidgetView.SettingsCommand cmd) => {
                widget.AttachChild( UIWidgetFactory.SettingsWidget() );
            } );
            view.OnCommand( (GameMenuWidgetView.BackCommand cmd) => {
                var dialog = UIWidgetFactory.DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.LoadMainSceneAsync( default ).Throw() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
