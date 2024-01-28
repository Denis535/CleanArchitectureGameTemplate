﻿#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.UI.Common;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class GameMenuWidget : UIWidgetBase<GameMenuWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private UIRouter Router { get; }
        // View
        protected override GameMenuWidgetView View { get; }

        // Constructor
        public GameMenuWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            View = CreateView( this, Factory, Router );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

        // Helpers
        private static GameMenuWidgetView CreateView(GameMenuWidget widget, UIFactory factory, UIRouter router) {
            var view = new GameMenuWidgetView( factory );
            view.Resume.OnClick( () => {
                widget.DetachSelf();
            } );
            view.Settings.OnClick( () => {
                widget.AttachChild( new SettingsWidget() );
            } );
            view.Back.OnClick( () => {
                var dialog = new DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.LoadMainSceneAsync( default ).Throw() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
