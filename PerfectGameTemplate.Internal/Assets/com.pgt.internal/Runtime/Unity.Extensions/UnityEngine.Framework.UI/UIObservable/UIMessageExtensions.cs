#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIMessageExtensions {

        // Execute
        public static void Execute<TSender>(this UICommand<TSender> command, TSender sender) where TSender : IUIMessageObservable {
            sender.GetDispatcher().Execute( command, sender );
        }
        public static void Execute<TSender>(this UICommand<TSender>.Validatable command, TSender sender, out bool isValid) where TSender : IUIMessageObservable {
            sender.GetDispatcher().Execute( command, sender, out isValid );
        }

        // Raise
        public static void Raise<TSender>(this UIEvent<TSender> @event, TSender sender) where TSender : IUIMessageObservable {
            sender.GetDispatcher().Raise( @event, sender );
        }
        public static void Raise<TSender>(this UIEvent<TSender>.Validatable @event, TSender sender, out bool isValid) where TSender : IUIMessageObservable {
            sender.GetDispatcher().Raise( @event, sender, out isValid );
        }

        // Helpers
        private static UIMessageDispatcher GetDispatcher(this IUIMessageObservable observable) {
            if (observable is UIScreen screen) {
                return screen.Dispatcher;
            }
            if (observable is UIWidget widget) {
                return widget.Dispatcher;
            }
            if (observable is UIView view) {
                return view.Dispatcher;
            }
            throw Exceptions.Internal.NotSupported( $"Observable {observable} not supported" );
        }

    }
}
