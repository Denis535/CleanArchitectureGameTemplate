#nullable enable
namespace PGT.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public abstract class UIScreen2<TView> : UIScreen<TView> where TView : UIScreenView2 {

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
#if UNITY_EDITOR
            AddViewIfNeeded( Document, View );
#endif
        }

        // AttachWidget
        protected override void __AttachWidget__(UIWidget widget) {
            base.__AttachWidget__( widget );
        }
        protected override void __DetachWidget__(UIWidget widget) {
            base.__DetachWidget__( widget );
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
            base.OnBeforeDescendantWidgetAttach( widget );
        }
        public override void OnAfterDescendantWidgetAttach(UIWidget widget) {
            base.OnAfterDescendantWidgetAttach( widget );
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidget widget) {
            base.OnBeforeDescendantWidgetDetach( widget );
        }
        public override void OnAfterDescendantWidgetDetach(UIWidget widget) {
            base.OnAfterDescendantWidgetDetach( widget );
        }

    }
}
