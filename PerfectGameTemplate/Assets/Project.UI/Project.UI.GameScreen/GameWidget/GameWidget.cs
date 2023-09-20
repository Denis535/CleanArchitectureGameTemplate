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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Actions.Enable();
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
            Actions.Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            if (descendant is GameMenuWidget) {
                Actions.Disable();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Actions.Enable();
            }
            base.OnAfterDescendantDetach( descendant );
        }

        // Update
        public void Update() {
            //if (Actions.Game.Fire.WasPressedThisFrame()) {
            //    Debug.Log( "Fire" );
            //}
        }

        // Helpers/View
        private GameWidgetView CreateView() {
            var view = UIVisualFactory.GameWidget();
            view.OnCommand( (GameWidgetView.PauseCommand cmd) => {
                this.AttachChild( UILogicalFactory.GameMenuWidget() );
            } );
            return view;
        }

    }
}
