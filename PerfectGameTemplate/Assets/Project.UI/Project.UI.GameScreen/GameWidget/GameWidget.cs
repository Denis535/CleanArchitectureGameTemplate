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
        public override void OnAttach() {
            SetGameEnabled( true );
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
            SetGameEnabled( false );
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            if (descendant is GameMenuWidget) {
                SetGameEnabled( false );
            }
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            if (descendant is GameMenuWidget) {
                SetGameEnabled( true );
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Update
        public void Update() {
            if (Actions.UI.Cancel.WasPressedThisFrame()) {
                this.AttachChild( UILogicalFactory.GameMenuWidget() );
            }
        }

        // Helpers
        private GameWidgetView CreateView() {
            var view = UIVisualFactory.GameWidget();
            return view;
        }
        private void SetGameEnabled(bool value) {
            if (value) {
                Actions.Enable();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Application.IsGamePaused = false;
            } else {
                Application.IsGamePaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Actions.Disable();
            }
        }

    }
}
