#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public readonly struct UIMessageDispatcher {

        private IUIMessageObservable Observable { get; }

        // Constructor
        internal UIMessageDispatcher(IUIMessageObservable observable) {
            Observable = observable;
        }

        // Execute
        public void Execute<TSender>(UICommand<TSender> command, TSender sender) {
            command.Sender = sender;
            Dispatch( Observable, command );
        }
        public void Execute<TSender>(UICommand<TSender>.Validatable command, TSender sender, out bool isValid) {
            command.Sender = sender;
            Dispatch( Observable, command );
            isValid = command.IsValid;
        }

        // Raise
        public void Raise<TSender>(UIEvent<TSender> @event, TSender sender) {
            @event.Sender = sender;
            Dispatch( Observable, @event );
        }
        public void Raise<TSender>(UIEvent<TSender>.Validatable @event, TSender sender, out bool isValid) {
            @event.Sender = sender;
            Dispatch( Observable, @event );
            isValid = @event.IsValid;
        }

        // Helpers
        private static void Dispatch(IUIMessageObservable observable, UIMessage message) {
            observable.OnMessageEvent?.Invoke( message );
            DispatchBubbleUp( observable, message );
        }
        private static void DispatchBubbleUp(IUIMessageObservable observable, UIMessage message) {
            if (!message.IsReceived) {
                var owner = GetOwner( observable );
                if (owner != null) {
                    owner.OnMessageEvent?.Invoke( message );
                    DispatchBubbleUp( owner, message );
                }
            }
        }
        // Helpers
        private static IUIMessageObservable? GetOwner(IUIMessageObservable observable) {
            if (observable is UIScreen screen) {
                return null;
            }
            if (observable is UIWidget widget) {
                return (IUIMessageObservable?) widget.Parent ?? widget.Screen;
            }
            if (observable is UIView view) {
                if (view is UIScreenView screenView) {
                    return screenView.Screen;
                }
                if (view is UIWidgetView widgetView) {
                    return widgetView.Widget;
                }
                if (view is UISubView subView) {
                    var ancestor = subView.GetFirstAncestorOfType<UIView>();
                    if (ancestor != null) return ancestor;
                    return null;
                }
            }
            throw Exceptions.Internal.NotSupported( $"Observable {observable} not supported" );
        }

    }
}
