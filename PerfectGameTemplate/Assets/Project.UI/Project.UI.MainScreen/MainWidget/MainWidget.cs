﻿#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Project.App;
    using Project.UI.Common;
    using Unity.Services.Authentication;
    using Unity.Services.Core;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class MainWidget : UIWidgetBase<MainWidgetView> {

        // Globals
        private UIRouter Router { get; }
        private UIFactory Factory { get; }
        private Application2 Application { get; }
        private Globals Globals { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;
        // View
        public override MainWidgetView View { get; }

        // Constructor
        public MainWidget() {
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            Globals = this.GetDependencyContainer().Resolve<Globals>( null );
            View = CreateView( this, Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override async void OnAttach() {
            // await MainScene
            if (!Application.IsMainSceneLoaded) {
                while (!Application.IsMainSceneLoaded) {
                    await Task.Yield();
                }
            }
            // await UnityServices
            if (UnityServices.State != ServicesInitializationState.Initialized) {
                try {
                    var options = new InitializationOptions();
                    if (Globals.Profile != null) options.SetProfile( Globals.Profile );
                    await UnityServices.InitializeAsync( options );
                } catch (Exception ex) {
                    var dialog = new ErrorDialogWidget( "Error", ex.Message ).OnSubmit( "Ok", () => Router.Quit() );
                    this.AttachChild( dialog );
                    return;
                }
            }
            // await AuthenticationService
            if (!AuthenticationService.IsSignedIn) {
                try {
                    var options = new SignInOptions();
                    options.CreateAccount = true;
                    await AuthenticationService.SignInAnonymouslyAsync( options );
                } catch (Exception ex) {
                    var dialog = new ErrorDialogWidget( "Error", ex.Message ).OnSubmit( "Ok", () => Router.Quit() );
                    this.AttachChild( dialog );
                    return;
                }
            }
            // MainMenuWidget
            this.AttachChild( new MainMenuWidget() );
        }
        public override void OnDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            View.SetEffect( ((RootWidget2) Parent!).View.WidgetSlot.Children.Count );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            base.OnAfterDescendantDetach( descendant );
            View.SetEffect( ((RootWidget2) Parent!).View.WidgetSlot.Children.Count );
        }

        // Update
        public void Update() {
        }

        // Helpers
        private static MainWidgetView CreateView(MainWidget widget, UIFactory factory) {
            var view = new MainWidgetView( factory );
            return view;
        }

    }
}
