#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public readonly struct UIMessageDispatcher {

        private IUIObservable Observable { get; }

        // Constructor
        internal UIMessageDispatcher(IUIObservable observable) {
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
        private static void Dispatch(IUIObservable observable, UIMessage message) {
            observable.OnMessageEvent?.Invoke( message );
            DispatchBubbleUp( observable, message );
        }
        private static void DispatchBubbleUp(IUIObservable observable, UIMessage message) {
            if (!message.IsReceived) {
                var owner = GetOwner( observable );
                if (owner != null) {
                    owner.OnMessageEvent?.Invoke( message );
                    DispatchBubbleUp( owner, message );
                }
            }
        }
        // Helpers
        private static IUIObservable? GetOwner(IUIObservable observable) {
            if (observable is UIScreenBase screen) {
                return null;
            }
            if (observable is UIWidgetBase widget) {
                return (IUIObservable?) widget.Parent ?? widget.Screen;
            }
            if (observable is UIViewBase view) {
                if (view is UIScreenViewBase screenView) {
                    return screenView.Screen;
                }
                if (view is UIWidgetViewBase widgetView) {
                    return widgetView.Widget;
                }
                if (view is UISubViewBase subView) {
                    var ancestor = subView.GetFirstAncestorOfType<UIViewBase>();
                    if (ancestor != null) return ancestor;
                    return null;
                }
            }
            throw Exceptions.Internal.NotSupported( $"Observable {observable} not supported" );
        }

    }
}
