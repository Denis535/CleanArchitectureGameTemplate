#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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
            View = CreateView( this, Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
        }
        public override void OnDetach(object? argument) {
        }

        // Helpers
        private static ChatWidgetView CreateView(ChatWidget widget, UIFactory factory) {
            var view = new ChatWidgetView( factory );
            view.Group.OnAttachToPanel( evt => {
                for (var i = 1; i <= 32; i++) {
                    view.Messages.Add( factory.MessageItem( $"Message: {view.Messages.Children.Count() + 1}", view.Messages.Children.Count() ) );
                }
            } );
            view.Send.OnClick( evt => {
                if (!string.IsNullOrWhiteSpace( view.Text.Value )) {
                    view.Messages.Add( factory.MessageItem( view.Text.Value, view.Messages.Children.Count() ) );
                    view.Text.Value = null;
                }
            } );
            return view;
        }

    }
}
