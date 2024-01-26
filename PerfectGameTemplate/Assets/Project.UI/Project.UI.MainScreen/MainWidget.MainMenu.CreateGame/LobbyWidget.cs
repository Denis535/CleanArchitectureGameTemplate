//#nullable enable
//namespace Project.UI.MainScreen {
//    using System;
//    using System.Collections;
//    using System.Collections.Generic;
//    using UnityEngine;
//    using UnityEngine.Framework;
//    using UnityEngine.Framework.UI;
//    using UnityEngine.UIElements;

//    public class LobbyWidget : UIWidgetBase<LobbyWidgetView> {

//        // Globals
//        private UIFactory Factory { get; }
//        // View
//        public override LobbyWidgetView View { get; }

//        // Constructor
//        public LobbyWidget() {
//            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
//            View = new LobbyWidgetView( Factory );
//        }
//        public override void Dispose() {
//            base.Dispose();
//        }

//        // OnAttach
//        public override void OnAttach() {
//        }
//        public override void OnDetach() {
//        }

//    }
//    public class LobbyWidgetView : UIViewBase {

//        // VisualElement
//        public override VisualElement VisualElement { get; }

//        // Constructor
//        public LobbyWidgetView(UIFactory factory) {
//            VisualElement = factory.LobbyWidget();
//        }
//        public override void Dispose() {
//            base.Dispose();
//        }

//    }
//}
