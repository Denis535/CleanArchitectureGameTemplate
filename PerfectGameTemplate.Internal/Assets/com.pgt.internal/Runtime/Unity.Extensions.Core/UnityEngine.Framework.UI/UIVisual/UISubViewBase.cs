#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UISubViewBase : UIViewBase {

        // Constructor
        public UISubViewBase() {
            AddToClassList( "sub-view" );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
