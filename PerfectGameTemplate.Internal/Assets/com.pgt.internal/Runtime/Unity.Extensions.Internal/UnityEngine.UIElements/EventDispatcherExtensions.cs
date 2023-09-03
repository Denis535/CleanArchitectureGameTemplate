#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;

    public static class EventDispatcherExtensions {

        private static readonly MethodInfo DispatchMethod = typeof( EventDispatcher ).GetMethod( "Dispatch", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly );

        // Dispatch
        public static void Dispatch(this EventDispatcher dispatcher, IPanel panel, EventBase @event) {
            DispatchMethod.Invoke( dispatcher, new object[] { @event, panel, 1 } );
        }
        public static void DispatchImmediate(this EventDispatcher dispatcher, IPanel panel, EventBase @event) {
            DispatchMethod.Invoke( dispatcher, new object[] { @event, panel, 2 } );
        }

    }
}
