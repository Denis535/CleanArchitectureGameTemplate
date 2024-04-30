#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.InputSystem;

    public class GameWidget : UIWidgetBase<GameWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private Application2 Application { get; }
        // Actions
        private InputActions Actions { get; }

        // Constructor
        public GameWidget() {
            Factory = Utils.Container.RequireDependency<UIFactory>( null );
            Application = Utils.Container.RequireDependency<Application2>( null );
            View = CreateView( this, Factory );
            Actions = new InputActions();
        }
        public override void Dispose() {
            Actions.Dispose();
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
            Actions.Enable();
        }
        public override void OnDetach(object? argument) {
            Actions.Disable();
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant, object? argument) {
            base.OnBeforeDescendantAttach( descendant, argument );
            if (descendant is GameMenuWidget) {
                Application.Pause();
                Actions.Disable();
            }
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant, object? argument) {
            base.OnAfterDescendantAttach( descendant, argument );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant, object? argument) {
            base.OnBeforeDescendantDetach( descendant, argument );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant, object? argument) {
            if (IsAttached && descendant is GameMenuWidget) {
                Actions.Enable();
                Application.UnPause();
            }
            base.OnAfterDescendantDetach( descendant, argument );
        }

        // Update
        public void Update() {
            if (Actions.UI.Cancel.WasPressedThisFrame()) {
                AttachChild( new GameMenuWidget() );
            }
        }

        // Helpers
        private static GameWidgetView CreateView(GameWidget widget, UIFactory factory) {
            var view = new GameWidgetView( factory );
            return view;
        }

    }
}
