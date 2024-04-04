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
        private IReadOnlyList<ChatWidgetView_MessageView> Messages => View.MessagesSlot.Views;

        // Constructor
        public ChatWidget() {
            Factory = this.GetDependencyContainer().RequireDependency<UIFactory>( null );
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
                    var message = new ChatWidgetView_MessageView( factory, $"Message: {view.MessagesSlot.Views.Count}", view.MessagesSlot.Views.Count );
                    view.MessagesSlot.Add( message );
                }
            } );
            view.Send.OnClick( evt => {
                if (!string.IsNullOrWhiteSpace( view.Text.Value )) {
                    var message = new ChatWidgetView_MessageView( factory, view.Text.Value, view.MessagesSlot.Views.Count );
                    view.MessagesSlot.Add( message );
                    view.Text.Value = null;
                }
            } );
            return view;
        }

    }
}
