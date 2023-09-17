#nullable enable
namespace Project.UI.MainScreen {
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
            this.AttachWidget( UILogicalFactory.MainWidget() );
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
        }
        public override void OnAfterDescendantWidgetAttach(UIWidgetBase widget) {
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidgetBase widget) {
        }
        public override void OnAfterDescendantWidgetDetach(UIWidgetBase widget) {
        }

    }
}
