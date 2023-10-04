#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Project.App;
    using Unity.Services.Authentication;
    using Unity.Services.Core;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class MainWidget : UIWidgetBase<MainWidgetView> {

        // Globals
        private Application2 Application { get; }
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;

        // Constructor
        public MainWidget() {
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
        }
        public override async void OnAttach() {
            while (!Application.IsMainSceneLoaded) await Task.Yield();
            while (UnityServices.State != ServicesInitializationState.Initializing) await Task.Yield();
            while (!AuthenticationService.IsSignedIn) await Task.Yield();
            this.AttachChild( UIWidgetFactory.MainMenuWidget() );
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            View.SetBackgroundEffect( Descendants.Where( i => !i.IsModal() ).Where( i => i.IsViewable ).Count() );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            View.SetBackgroundEffect( Descendants.Where( i => !i.IsModal() ).Where( i => i.IsViewable ).Where( i => i != descendant ).Count() );
            base.OnAfterDescendantDetach( descendant );
        }

        // Update
        public void Update() {
        }

        // Helpers
        private static MainWidgetView CreateView() {
            var view = UIViewFactory.MainWidget();
            return view;
        }

    }
}
