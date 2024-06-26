#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class UIScreen : UIScreenBase {

        // Globals
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;
        // Widget
        public new UIRootWidget2? Widget => (UIRootWidget2?) base.Widget;
        // State
        public UIScreenState State => GetState( Router.State );
        private ValueTracker<UIScreenState, UIScreen> StateTracker { get; } = new ValueTracker<UIScreenState, UIScreen>( i => i.State );
        public bool IsMainScreen => State == UIScreenState.MainScreen;
        public bool IsGameScreen => State == UIScreenState.GameScreen;

        // Awake
        public new void Awake() {
            base.Awake();
            Router = Utils.Container.RequireDependency<UIRouter>( null );
            Application = Utils.Container.RequireDependency<Application2>( null );
            AttachWidget( new UIRootWidget2() );
        }
        public new void OnDestroy() {
            Widget!.DetachSelf();
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
            Widget!.Update();
        }

        // AttachWidget
        public override void AttachWidget(UIWidgetBase widget, object? argument = null) {
            base.AttachWidget( widget, argument );
            AddView( Document, widget.View! );
        }
        public override void DetachWidget(UIWidgetBase widget, object? argument = null) {
            if (Document && Document.rootVisualElement != null) {
                RemoveView( Document, widget.View! );
            } else {
                if (!Document) Debug.LogWarning( $"You are trying to detach '{widget}' widget but UIDocument is destroyed" );
                if (Document.rootVisualElement == null) Debug.LogWarning( $"You are trying to detach '{widget}' widget but UIDocument's rootVisualElement is null" );
            }
            base.DetachWidget( widget, argument );
        }

        // Helpers
        private static UIScreenState GetState(UIRouterState state) {
            if (state is UIRouterState.MainSceneLoading or UIRouterState.MainSceneLoaded or UIRouterState.GameSceneLoading) {
                return UIScreenState.MainScreen;
            }
            if (state is UIRouterState.GameSceneLoaded) {
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
