#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.InputSystem;

    public class UIScreen : UIScreenBase<UIScreenView> {

        // Globals
        private UIRouter Router { get; set; } = default!;
        // Actions
        private InputActions Actions { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Actions = new InputActions();
            View = UIViewBase.Create<UIScreenView>();
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
        public async void Start() {
            await Router.LoadMainSceneAsync( default );
        }
        public void Update() {
#if UNITY_EDITOR
            AddViewIfNeeded( Document, View );
#endif
            if (Router.IsMainSceneLoaded && Widget is not MainWidget) {
                if (Widget != null) this.DetachWidget();
                this.AttachWidget( UILogicalFactory.MainWidget() );
            } else
            if (Router.IsGameSceneLoaded && Widget is not GameWidget) {
                if (Widget != null) this.DetachWidget();
                this.AttachWidget( UILogicalFactory.GameWidget() );
            }
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
        public override void OnBeforeDescendantWidgetAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantWidgetAttach( descendant );
            if (descendant is GameMenuWidget) {
                Actions.Disable();
            }
        }
        public override void OnAfterDescendantWidgetAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantWidgetAttach( descendant );
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantWidgetDetach( descendant );
        }
        public override void OnAfterDescendantWidgetDetach(UIWidgetBase descendant) {
            if (descendant is GameMenuWidget) {
                Actions.Enable();
            }
            base.OnAfterDescendantWidgetDetach( descendant );
        }

    }
}
