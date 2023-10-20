#nullable enable
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
        private UIRouter Router { get; }
        // View
        public override GameMenuWidgetView View { get; }

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
            var view = new GameMenuWidgetView( widget );
            view.Resume.OnClick( i => {
                widget.DetachSelf();
            } );
            view.Settings.OnClick( i => {
                widget.AttachChild( new SettingsWidget() );
            } );
            view.Back.OnClick( i => {
                var dialog = new DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => router.LoadMainSceneAsync( default ).Throw() ).OnCancel( "No", null );
                widget.AttachChild( dialog );
            } );
            return view;
        }

    }
}
