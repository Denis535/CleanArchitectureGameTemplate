#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public partial class MainWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<MainWidgetView, UxmlTraits> { }
    }
    public partial class MainWidgetView : UIWidgetViewBase {

        // Constructor
        public MainWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetBackgroundEffect
        public void SetBackgroundEffect(int value) {
            var t = Easing.OutPower( Mathf.InverseLerp( 1, 8, value ), 2 );
            transform.scale = Vector3.LerpUnclamped( new Vector3( 1, 1, 1 ), new Vector3( 2, 2, 1 ), t );
            style.unityBackgroundImageTintColor = Color.LerpUnclamped( new Color( 1, 1, 1, 1 ), new Color( 0, 0, 0, 1 ), t );
        }

    }
}
