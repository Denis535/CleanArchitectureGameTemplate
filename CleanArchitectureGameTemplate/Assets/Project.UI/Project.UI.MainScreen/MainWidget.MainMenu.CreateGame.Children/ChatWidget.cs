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
                for (var i = 0; i <= 60; i++) {
                    var message = new ChatWidgetView_MessageView( factory, $"Message: {view.MessageList.Views.Count}", view.MessageList.Views.Count );
                    view.MessageList.Add( message );
                }
            } );
            view.Send.OnClick( evt => {
                if (!string.IsNullOrWhiteSpace( view.Text.Value )) {
                    var message = new ChatWidgetView_MessageView( factory, view.Text.Value, view.MessageList.Views.Count );
                    view.MessageList.Add( message );
                    view.Text.Value = null;
                }
            } );
            return view;
        }

    }
}
