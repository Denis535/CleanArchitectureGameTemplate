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
        private Storage Globals { get; set; } = default!;
        private IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;

        // Constructor
        public MainWidget() {
            Router = Utils.Container.RequireDependency<UIRouter>( null );
            Factory = Utils.Container.RequireDependency<UIFactory>( null );
            Application = Utils.Container.RequireDependency<Application2>( null );
            Globals = Utils.Container.RequireDependency<Storage>( null );
            View = CreateView( this, Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override async void OnAttach(object? argument) {
            // await MainScene
            if (!Router.IsMainSceneLoaded) {
                while (!Router.IsMainSceneLoaded) {
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
            // Children
            this.AttachChild( new MainMenuWidget() );
        }
        public override void OnDetach(object? argument) {
        }

        // ShowWidget
        public override void ShowWidget(UIWidgetBase widget) {
            base.ShowWidget( widget );
            View.SetEffect( ((UIRootWidget2) Parent!).View.WidgetSlot.Children.Count - 2 );
        }
        public override void HideWidget(UIWidgetBase widget) {
            base.HideWidget( widget );
            View.SetEffect( ((UIRootWidget2) Parent!).View.WidgetSlot.Children.Count - 2 );
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
