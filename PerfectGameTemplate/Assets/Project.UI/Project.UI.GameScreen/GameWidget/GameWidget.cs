#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.InputSystem;

    public class GameWidget : UIWidgetBase<GameWidgetView> {

        private InputActions Actions { get; }

        // Constructor
        public GameWidget() {
            View = CreateView();
            Actions = new InputActions();
        }
        public override void Dispose() {
            Actions.Dispose();
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            SetGameEnabled( true, Actions );
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
            SetGameEnabled( false, Actions );
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            if (descendant is GameMenuWidget) {
                SetGameEnabled( false, Actions );
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
                SetGameEnabled( true, Actions );
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
        private static void SetGameEnabled(bool value, InputActions actions) {
            if (value) {
                actions.Enable();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                actions.Disable();
            }
        }

    }
}
