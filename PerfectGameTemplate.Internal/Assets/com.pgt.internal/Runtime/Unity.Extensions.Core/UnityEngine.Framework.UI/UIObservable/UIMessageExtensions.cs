#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIMessageExtensions {

        // Execute
        public static void Execute<TSender>(this UICommand<TSender> command, TSender sender) where TSender : IUIObservable {
            sender.Execute( command );
        }

        // Raise
        public static void Raise<TSender>(this UIEvent<TSender> @event, TSender sender) where TSender : IUIObservable {
            sender.Raise( @event );
        }

    }
}
