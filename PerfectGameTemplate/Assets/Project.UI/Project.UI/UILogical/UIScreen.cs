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

        private readonly Tracker<UIScreenState> stateTracker = new Tracker<UIScreenState>();

        // Globals
        private Application2 Application { get; set; } = default!;
        // State
        public UIScreenState State => GetState( Application.State );
        public bool IsMainScreen => State == UIScreenState.MainScreen;
        public bool IsGameScreen => State == UIScreenState.GameScreen;

        // Awake
        public new void Awake() {
            base.Awake();
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            View = UIViewFactory.Screen( this );
            AddView( Document, View );
        }
        public new void OnDestroy() {
            Widget?.DetachSelf();
            //RemoveView( Document, View );
            View.Dispose();
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
#if UNITY_EDITOR
            AddViewIfNeeded( Document, View );
#endif
            if (stateTracker.IsChanged( State )) {
                if (IsMainScreen) {
                    Widget?.DetachSelf();
                    this.AttachWidget( UIWidgetFactory.MainWidget() );
                } else if (IsGameScreen) {
                    Widget?.DetachSelf();
                    this.AttachWidget( UIWidgetFactory.GameWidget() );
                } else {
                    Widget?.DetachSelf();
                }
            }
            (Widget as MainWidget)?.Update();
            (Widget as GameWidget)?.Update();
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
    // UIScreenState
    public enum UIScreenState {
        None,
        MainScreen,
        GameScreen,
    }
}
