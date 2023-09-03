﻿#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class IUIMessageObservableExtensions {

        // OnMessage
        //public static void OnMessage<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIMessageObservable where TMessage : UIMessage<TObservable> {
        //    observable.OnMessageEvent += message => {
        //        if (message is TMessage message_) {
        //            Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
        //            callback( message_ );
        //            message_.IsReceived = true;
        //        }
        //    };
        //}
        //public static void OnMessageNonStrict<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIMessageObservable where TMessage : UIMessage {
        //    observable.OnMessageEvent += message => {
        //        if (message is TMessage message_) {
        //            Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
        //            callback( message_ );
        //            message_.IsReceived = true;
        //        }
        //    };
        //}

        // OnCommand
        public static void OnCommand<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIMessageObservable where TMessage : UICommand<TObservable> {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }
        public static void OnCommandNonStrict<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIMessageObservable where TMessage : UICommand {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }

        // OnEvent
        public static void OnEvent<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIMessageObservable where TMessage : UIEvent<TObservable> {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }
        public static void OnEventNonStrict<TObservable, TMessage>(this TObservable observable, Action<TMessage> callback) where TObservable : IUIMessageObservable where TMessage : UIEvent {
            observable.OnMessageEvent += message => {
                if (message is TMessage message_) {
                    Assert.Object.Message( $"Message {message} is already received" ).Valid( !message.IsReceived );
                    callback( message_ );
                    message_.IsReceived = true;
                }
            };
        }

    }
}
