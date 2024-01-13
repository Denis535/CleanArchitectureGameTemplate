﻿#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class LoadingWidget : UIWidgetBase<LoadingWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override LoadingWidgetView View { get; }

        // Constructor
        public LoadingWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = CreateView( this, Factory );
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

        // Helpers
        private static LoadingWidgetView CreateView(LoadingWidget widget, UIFactory factory) {
            var view = new LoadingWidgetView( widget, factory );
            return view;
        }

    }
}
