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
        // State
        private UIScreenState State => GetState( Application.AppState );
        private Tracker<UIScreenState, UIScreen> StateTracker { get; } = new Tracker<UIScreenState, UIScreen>( i => i.State );

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
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
            if (StateTracker.IsChanged( this, out var state )) {
                switch (state) {
                    case UIScreenState.MainScreen:
                        Widget?.DetachSelf();
                        this.AttachWidget( UIWidgetFactory.MainWidget() );
                        break;
                    case UIScreenState.GameScreen:
                        Widget?.DetachSelf();
                        this.AttachWidget( UIWidgetFactory.GameWidget() );
                        break;
                    case UIScreenState.None:
                        Widget?.DetachSelf();
                        break;
                }
            }
            if (Widget is MainWidget mainWidget) {
                mainWidget.Update();
            } else
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

        // Helpers
        private static UIScreenState GetState(AppState state) {
            if (state is AppState.MainSceneLoading or AppState.MainSceneLoaded or AppState.MainSceneUnloading or AppState.GameSceneLoading or AppState.GameSceneUnloading) {
                return UIScreenState.MainScreen;
            }
            if (state is AppState.GameSceneLoaded) {
                return UIScreenState.GameScreen;
            }
            if (state is AppState.Quitting or AppState.Quited) {
                return UIScreenState.None;
            }
            return UIScreenState.None;
        }

    }
    internal enum UIScreenState {
        None,
        MainScreen,
        GameScreen,
    }
}
