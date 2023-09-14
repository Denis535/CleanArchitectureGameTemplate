#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIMessageExtensions {

        // Execute
        public static void Execute<TSender>(this UICommand<TSender> command, TSender sender) where TSender : IUIObservable {
            sender.GetDispatcher().Execute( command, sender );
        }
        public static void Execute<TSender>(this UICommand<TSender>.Validatable command, TSender sender, out bool isValid) where TSender : IUIObservable {
            sender.GetDispatcher().Execute( command, sender, out isValid );
        }

        // Raise
        public static void Raise<TSender>(this UIEvent<TSender> @event, TSender sender) where TSender : IUIObservable {
            sender.GetDispatcher().Raise( @event, sender );
        }
        public static void Raise<TSender>(this UIEvent<TSender>.Validatable @event, TSender sender, out bool isValid) where TSender : IUIObservable {
            sender.GetDispatcher().Raise( @event, sender, out isValid );
        }

        // Helpers
        private static UIMessageDispatcher GetDispatcher(this IUIObservable observable) {
            if (observable is UIScreenBase screen) {
                return screen.Dispatcher;
            }
            if (observable is UIWidgetBase widget) {
                return widget.Dispatcher;
            }
            if (observable is UIViewBase view) {
                return view.Dispatcher;
            }
            throw Exceptions.Internal.NotSupported( $"Observable {observable} not supported" );
        }

    }
}
