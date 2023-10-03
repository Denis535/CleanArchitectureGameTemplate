#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class MainWidget : UIWidgetBase<MainWidgetView> {

        // Globals
        private Application2 Application { get; }

        // Constructor
        public MainWidget() {
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase descendant) {
            base.OnBeforeDescendantAttach( descendant );
            View.SetBackgroundEffect( Descendants.Where( i => !i.IsModal() ).Where( i => i.IsViewable ).Count() );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase descendant) {
            base.OnAfterDescendantAttach( descendant );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase descendant) {
            base.OnBeforeDescendantDetach( descendant );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase descendant) {
            View.SetBackgroundEffect( Descendants.Where( i => !i.IsModal() ).Where( i => i.IsViewable ).Where( i => i != descendant ).Count() );
            base.OnAfterDescendantDetach( descendant );
        }

        // Update
        public void Update() {
            if (Application.IsMainSceneLoaded) {
                if (!Children.OfType<MainMenuWidget>().Any()) {
                    this.AttachChild( UIWidgetFactory.MainMenuWidget() );
                }
            }
        }

        // Helpers
        private MainWidgetView CreateView() {
            var view = UIViewFactory.MainWidget();
            return view;
        }

    }
}
