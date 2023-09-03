#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public readonly struct UIScreenRouter {

        private UIScreen Target { get; }

        // Constructor
        internal UIScreenRouter(UIScreen target) {
            Target = target;
        }

        // AttachWidget
        public void AttachWidget(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Object.Message( $"Screen {Target} must have no widget" ).Valid( Target.Widget == null );
            Target.__AttachWidget__( widget );
        }

        // DetachWidget
        public void DetachWidget() {
            Assert.Object.Message( $"Screen {Target} must have widget" ).Valid( Target.Widget != null );
            Target.__DetachWidget__( Target.Widget );
        }
        public void DetachWidget<T>() where T : UIWidget {
            Assert.Object.Message( $"Screen {Target} must have widget" ).Valid( Target.Widget != null );
            Assert.Object.Message( $"Screen {Target} must have {typeof( T )} widget" ).Valid( Target.Widget is T );
            Target.__DetachWidget__( Target.Widget );
        }
        public void DetachWidget(UIWidget widget) {
            Assert.Argument.Message( $"Argument 'widget' must be non-null" ).NotNull( widget );
            Assert.Object.Message( $"Screen {Target} must have widget" ).Valid( Target.Widget != null );
            Assert.Object.Message( $"Screen {Target} must have {widget} widget" ).Valid( Target.Widget == widget );
            Target.__DetachWidget__( widget );
        }

    }
}
