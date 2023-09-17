#nullable enable
namespace Project.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.InputSystem;

    public class GameScreen : UIScreen2<GameScreenView> {

        private InputActions Actions { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            View = UIVisualFactory.GameScreen();
            Actions = new InputActions();
            this.AttachWidget( UILogicalFactory.GameWidget() );
        }
        public new void OnDestroy() {
            Actions.Dispose();
            base.OnDestroy();
        }

        // OnEnable
        public void OnEnable() {
            Actions.Enable();
        }
        public void OnDisable() {
            Actions.Disable();
        }

        // Start
        public new void Start() {
            base.Start();
        }
        public new void Update() {
            base.Update();
        }

        // ShowWidget
        public override void ShowWidget(UIWidgetBase widget) {
            base.ShowWidget( widget );
        }
        public override void HideWidget(UIWidgetBase widget) {
            base.HideWidget( widget );
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantWidgetAttach(UIWidgetBase widget) {
            if (widget is GameMenuWidget) {
                Actions.Disable();
            }
        }
        public override void OnAfterDescendantWidgetAttach(UIWidgetBase widget) {
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidgetBase widget) {
        }
        public override void OnAfterDescendantWidgetDetach(UIWidgetBase widget) {
            if (widget is GameMenuWidget) {
                if (Actions.asset) {
                    Actions.Enable();
                }
            }
        }

    }
}
