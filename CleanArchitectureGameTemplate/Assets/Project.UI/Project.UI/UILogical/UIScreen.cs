#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI.Common;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class UIScreen : UIScreenBase {

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
            this.AttachWidget( new RootWidget2() );
        }
        public new void OnDestroy() {
            Widget?.DetachSelf();
            base.OnDestroy();
        }

        // Start
        public void Start() {
        }
        public void Update() {
#if UNITY_EDITOR
            //AddViewIfNeeded( Document, Widget!.View!.VisualElement );
#endif
            if (stateTracker.IsChanged( State )) {
                Widget!.DetachChildren();
                if (IsMainScreen) {
                    Widget!.AttachChild( new MainWidget() );
                } else if (IsGameScreen) {
                    Widget!.AttachChild( new GameWidget() );
                }
            }
            foreach (var descendant in Widget!.Descendants) {
                (descendant as MainWidget)?.Update();
                (descendant as GameWidget)?.Update();
            }
        }

        // AttachWidget
        protected override void __AttachWidget__(UIWidgetBase widget, object? argument) {
            base.__AttachWidget__( widget, argument );
            AddView( Document, widget.GetVisualElement()! );
        }
        protected override void __DetachWidget__(UIWidgetBase widget, object? argument) {
            if (Document && Document.rootVisualElement != null) {
                RemoveView( Document, widget.GetVisualElement()! ); // NullReferenceException: Object reference not set to an instance of an object
                base.__DetachWidget__( widget, argument );
            } else {
                if (Document) Debug.LogWarning( "UIDocument must be alive" );
                if (Document.rootVisualElement != null) Debug.LogWarning( "UIDocument must have rootVisualElement" );
            }
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
