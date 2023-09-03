#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public readonly struct UIWidgetRouter {

        private UIWidget Target { get; }

        // Constructor
        internal UIWidgetRouter(UIWidget target) {
            Target = target;
        }

        // AttachChild
        public void AttachChild(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Object.Message( $"Widget {Target} must have no child {widget} widget" ).Valid( !Target.Children.Contains( widget ) );
            Target.__AttachChild__( widget );
        }

        // DetachSelf
        public void DetachSelf() {
            Assert.Object.Message( $"Widget {Target} must have parent or must be be attached" ).Valid( Target.Parent != null || Target.IsAttached );
            if (Target.Parent != null) {
                Target.Parent.Router.DetachChild( Target );
            } else {
                Target.Screen!.Router.DetachWidget( Target );
            }
        }
        // DetachChild
        public void DetachChild<T>() where T : UIWidget {
            Assert.Object.Message( $"Widget {Target} must have child {typeof( T )} widget" ).Valid( Target.Children.OfType<T>().Any() );
            Target.__DetachChild__( Target.Children.OfType<T>().Last() );
        }
        public void DetachChild(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Object.Message( $"Widget {Target} must have child {widget} widget" ).Valid( Target.Children.Contains( widget ) );
            Target.__DetachChild__( widget );
        }
        // DetachChildren
        public void DetachChildren() {
            foreach (var child in Target.Children.Reverse()) {
                Target.__DetachChild__( child );
            }
        }

    }
}
