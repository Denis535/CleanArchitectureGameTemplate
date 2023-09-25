#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class MainWidget : UIWidgetBase<MainWidgetView> {

        // Constructor
        public MainWidget() {
            View = CreateView();
            this.AttachChild( UIWidgetFactory.MainMenuWidget() );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
        }

        // OnDescendantAttach
        public override void OnBeforeDescendantAttach(UIWidgetBase widget) {
            base.OnBeforeDescendantAttach( widget );
            View.SetBackgroundEffect( Descendants.Where( i => !i.IsModal() ).Where( i => i.IsViewable ).Count() );
        }
        public override void OnAfterDescendantAttach(UIWidgetBase widget) {
            base.OnAfterDescendantAttach( widget );
        }
        public override void OnBeforeDescendantDetach(UIWidgetBase widget) {
            base.OnBeforeDescendantDetach( widget );
        }
        public override void OnAfterDescendantDetach(UIWidgetBase widget) {
            View.SetBackgroundEffect( Descendants.Where( i => !i.IsModal() ).Where( i => i.IsViewable ).Where( i => i != widget ).Count() );
            base.OnAfterDescendantDetach( widget );
        }

        // Helpers
        private MainWidgetView CreateView() {
            var view = UIViewFactory.MainWidget();
            return view;
        }

    }
}
