#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class ChatWidget : UIWidgetBase<ChatWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // View
        protected override ChatWidgetView View { get; }

        // Constructor
        public ChatWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = CreateView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnAfterAttach() {
            base.OnAfterAttach();
            for (var i = 1; i <= 32; i++) {
                View.Messages.Add( Factory.MessageItem( $"Message: {i}", View.Messages.Children.Count ) );
            }
        }
        public override void OnBeforeDetach() {
            base.OnBeforeDetach();
        }
        public override void OnDetach() {
        }

        // Helpers
        private static ChatWidgetView CreateView(UIFactory factory) {
            var view = new ChatWidgetView( factory );
            view.Send.OnClick( () => {
                view.Messages.Add( factory.MessageItem( view.Text.Value, view.Messages.Children.Count ) );
                view.Text.Value = null;
            } );
            return view;
        }

    }
}
