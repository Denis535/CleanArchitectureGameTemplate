#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class IUIObservableExtensions {

        // Execute
        public static void Execute<TObservable>(this TObservable observable, UICommand<TObservable> command) where TObservable : IUIObservable {
            command.Sender = observable;
            observable.Dispatch( command );
        }

        // Raise
        public static void Raise<TObservable>(this TObservable observable, UIEvent<TObservable> @event) where TObservable : IUIObservable {
            @event.Sender = observable;
            observable.Dispatch( @event );
        }

        // OnCommand
        public static void OnCommand<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIObservable where TMessage : UICommand<TObservable> {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }
        public static void OnCommandNonStrict<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIObservable where TMessage : UICommand {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }

        // OnEvent
        public static void OnEvent<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIObservable where TMessage : UIEvent<TObservable> {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }
        public static void OnEventNonStrict<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIObservable where TMessage : UIEvent {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }

        // Helpers
        private static void Dispatch(this IUIObservable observable, UIMessage message) {
            observable.OnMessageEvent?.Invoke( message );
            observable.DispatchBubbleUp( message );
        }
        private static void DispatchBubbleUp(this IUIObservable observable, UIMessage message) {
            if (!message.IsReceived) {
                var owner = observable.GetObservable();
                if (owner != null) {
                    owner.OnMessageEvent?.Invoke( message );
                    DispatchBubbleUp( owner, message );
                }
            }
        }
        private static IUIObservable? GetObservable(this IUIObservable observable) {
            if (observable is UIScreenBase screen) {
                return null;
            }
            if (observable is UIWidgetBase widget) {
                return (IUIObservable?) widget.Parent ?? widget.Screen;
            }
            if (observable is UIViewBase view) {
                return view.Observable;
            }
            throw Exceptions.Internal.NotSupported( $"Observable {observable} is not supported" );
        }

    }
}
