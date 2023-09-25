#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class UIScreen : UIScreenBase<UIScreenView> {

        // Globals
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            //Router.OnMainSceneLoadedEvent += () => {
            //    // Exception: Reentering the Update method is not allowed. This can happen when calling WaitForCompletion on an operation while inside of a callback.
            //    if (Widget != null) this.DetachWidget();
            //    this.AttachWidget( UIWidgetFactory.MainWidget() );
            //};
            //Router.OnGameSceneLoadedEvent += () => {
            //    // Exception: Reentering the Update method is not allowed. This can happen when calling WaitForCompletion on an operation while inside of a callback.
            //    if (Widget != null) this.DetachWidget();
            //    this.AttachWidget( UIWidgetFactory.GameWidget() );
            //};
            View = UIViewBase.Create<UIScreenView>();
        }
        public new void OnDestroy() {
            base.OnDestroy();
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
                this.AttachWidget( UIWidgetFactory.MainWidget() );
            } else
            if (Router.IsGameSceneLoaded && Widget is not GameWidget) {
                if (Widget != null) this.DetachWidget();
                this.AttachWidget( UIWidgetFactory.GameWidget() );
            }
            if (Widget is GameWidget gameWidget) {
                gameWidget.Update();
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
        }
        public override void OnAfterDescendantWidgetAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantWidgetAttach( descendant );
        }
        public override void OnBeforeDescendantWidgetDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantWidgetDetach( descendant );
        }
        public override void OnAfterDescendantWidgetDetach(UIWidgetBase descendant) {
            base.OnAfterDescendantWidgetDetach( descendant );
        }

    }
}
