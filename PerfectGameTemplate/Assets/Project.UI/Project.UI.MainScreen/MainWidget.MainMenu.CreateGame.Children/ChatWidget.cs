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
        public override ChatWidgetView View { get; }

        // Constructor
        public ChatWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = new ChatWidgetView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            for (var i = 1; i <= 32; i++) {
                View.Messages.Add( Factory.MessageItem( $"Message: {i}", i - 1 ) );
            }
        }
        public override void OnDetach() {
        }

    }
}
