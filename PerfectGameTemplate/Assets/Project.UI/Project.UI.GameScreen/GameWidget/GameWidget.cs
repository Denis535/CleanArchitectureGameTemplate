#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.InputSystem;

    public class GameWidget : UIWidgetBase<GameWidgetView> {

        // Globals
        private Application2 Application { get; }
        // Actions
        private InputActions Actions { get; }

        // Constructor
        public GameWidget() {
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            Actions = new InputActions();
            View = CreateView();
        }
        public override void Dispose() {
            Actions.Dispose();
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
        }
        public override void OnAttach() {
            Actions.Enable();
        }
        public override void OnDetach() {
            Actions.Disable();
        }
        public override void OnAfterDetach() {
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            if (descendant is GameMenuWidget) {
                Application.Game!.Pause();
                Actions.Disable();
            }
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            if (IsAttached && descendant is GameMenuWidget) {
                Actions.Enable();
                Application.Game!.UnPause();
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Update
        public void Update() {
            if (Actions.UI.Cancel.WasPressedThisFrame()) {
                this.AttachChild( UIWidgetFactory.GameMenuWidget() );
            }
        }

        // Helpers
        private static GameWidgetView CreateView() {
            var view = UIViewFactory.GameWidget();
            return view;
        }

    }
}
