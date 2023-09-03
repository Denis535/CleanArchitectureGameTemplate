#nullable enable
namespace PGT.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class GameScreen : UIScreen2<GameScreenView> {

        private UIInputActions Actions { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            View = UIVisualFactory.GameScreen();
            Actions = new UIInputActions();
            Router.AttachWidget( UILogicalFactory.GameWidget() );
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
        }
        public new void Update() {
            base.Update();
        }

        // ShowWidget
        public override void ShowWidget(UIWidget widget) {
            base.ShowWidget( widget );
        }
        public override void HideWidget(UIWidget widget) {
            base.HideWidget( widget );
        }

        // OnDescendantWidgetAttach
        public override void OnBeforeDescendantWidgetAttach(UIWidget widget) {
            if (widget is GameMenuWidget) {
                Actions.Disable();
            }
        }
        public override void OnAfterDescendantWidgetAttach(UIWidget widget) {
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidget widget) {
        }
        public override void OnAfterDescendantWidgetDetach(UIWidget widget) {
            if (widget is GameMenuWidget) {
                if (Actions.asset) {
                    Actions.Enable();
                }
            }
        }

    }
}
