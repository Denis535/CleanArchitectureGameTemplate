#nullable enable
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

        // Constructor
        public GameMenuWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            View = CreateView();
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
        private GameMenuWidgetView CreateView() {
            var view = UIViewFactory.GameMenuWidget();
            view.OnCommand( (GameMenuWidgetView.ResumeCommand cmd) => {
                this.DetachSelf();
            } );
            view.OnCommand( (GameMenuWidgetView.SettingsCommand cmd) => {
                this.AttachChild( UIWidgetFactory.SettingsWidget() );
            } );
            view.OnCommand( (GameMenuWidgetView.MainMenuCommand cmd) => {
                var dialog = UIWidgetFactory.DialogWidget( "Confirmation", "Are you sure?" ).OnSubmit( "Yes", () => Router.LoadMainSceneAsync( default ).Throw() ).OnCancel( "No", null );
                this.AttachChild( dialog );
            } );
            return view;
        }

    }
}
