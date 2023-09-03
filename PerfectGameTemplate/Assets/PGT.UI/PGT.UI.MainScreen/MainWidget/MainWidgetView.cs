#nullable enable
namespace PGT.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public partial class MainWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<MainWidgetView, UxmlTraits> { }
        public record SubmitCommand() : UICommand<MainWidgetView>;
        public record CancelCommand() : UICommand<MainWidgetView>;
    }
    public partial class MainWidgetView : UIWidgetView2 {

        // Content
        private VisualElement background = default!;
        // Props
        public int Background {
            set {
                var t = Mathf.InverseLerp( 1, 8, value );
                t = Easing.OutPower( t, 2 );
                background.transform.scale = Vector3.LerpUnclamped( new Vector3( 1, 1, 1 ), new Vector3( 2, 2, 1 ), t );
                background.style.unityBackgroundImageTintColor = Color.LerpUnclamped( new Color( 1, 1, 1, 1 ), new Color( 0, 0, 0, 1 ), t );
            }
        }

        // Constructor
        public MainWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            background = this.RequireElement<VisualElement>( null, "background" );
            // OnEvent
            this.OnAttachToPanel( evt => {
            } );
            this.OnSubmit( evt => {
                new SubmitCommand().Execute( this );
            } );
            this.OnCancel( evt => {
                new CancelCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
