#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public abstract class UIScreen2<TView> : UIScreenBase<TView> where TView : UIScreenView2 {

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
        protected override void __AttachWidget__(UIWidgetBase widget) {
            base.__AttachWidget__( widget );
        }
        protected override void __DetachWidget__(UIWidgetBase widget) {
            base.__DetachWidget__( widget );
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
            base.OnBeforeDescendantWidgetAttach( widget );
        }
        public override void OnAfterDescendantWidgetAttach(UIWidgetBase widget) {
            base.OnAfterDescendantWidgetAttach( widget );
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidgetBase widget) {
            base.OnBeforeDescendantWidgetDetach( widget );
        }
        public override void OnAfterDescendantWidgetDetach(UIWidgetBase widget) {
            base.OnAfterDescendantWidgetDetach( widget );
        }

    }
}
