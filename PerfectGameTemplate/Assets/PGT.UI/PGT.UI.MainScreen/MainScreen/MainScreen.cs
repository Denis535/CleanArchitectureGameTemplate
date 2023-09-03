#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class MainScreen : UIScreen2<MainScreenView> {

        // Awake
        public new void Awake() {
            base.Awake();
            View = UIVisualFactory.MainScreen();
            Router.AttachWidget( UILogicalFactory.MainWidget() );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // OnEnable
        public void OnEnable() {
        }
        public void OnDisable() {
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
        }
        public override void OnAfterDescendantWidgetAttach(UIWidget widget) {
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidget widget) {
        }
        public override void OnAfterDescendantWidgetDetach(UIWidget widget) {
        }

    }
}
