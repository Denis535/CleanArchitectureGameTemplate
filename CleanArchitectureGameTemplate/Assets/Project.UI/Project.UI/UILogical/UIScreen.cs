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

        // Globals
        private Application2 Application { get; set; } = default!;
        // State
        private ValueTracker2<UIScreenState, UIScreen> StateTracker { get; } = new ValueTracker2<UIScreenState, UIScreen>( i => i.State );
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
            //AddVisualElementIfNeeded( Document, Widget!.GetVisualElement()! );
#endif
            if (StateTracker.IsChanged( this )) {
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
            AddVisualElement( Document, widget.GetVisualElement()! );
        }
        protected override void __DetachWidget__(UIWidgetBase widget, object? argument) {
            if (Document) {
                Debug.LogWarning( $"You are trying to detach '{widget}' widget but UIDocument is destroyed" );
                return;
            }
            if (Document.rootVisualElement != null) {
                Debug.LogWarning( $"You are trying to detach '{widget}' widget but UIDocument's rootVisualElement is null" );
                return;
            }
            RemoveVisualElement( Document, widget.GetVisualElement()! );
            base.__DetachWidget__( widget, argument );
        }

        // Helpers
        private static UIScreenState GetState(AppState state) {
            if (state is AppState.MainSceneLoading or AppState.MainSceneLoaded or AppState.MainSceneUnloading or AppState.MainSceneUnloaded or AppState.GameSceneLoading) {
                return UIScreenState.MainScreen;
            }
            if (state is AppState.GameSceneLoaded) {
                return UIScreenState.GameScreen;
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
