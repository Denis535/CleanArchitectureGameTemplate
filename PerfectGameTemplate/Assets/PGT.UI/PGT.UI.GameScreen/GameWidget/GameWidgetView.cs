#nullable enable
namespace PGT.UI.GameScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class GameWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<GameWidgetView, UxmlTraits> { }
        public record SubmitCommand() : UICommand<GameWidgetView>;
        public record CancelCommand() : UICommand<GameWidgetView>;
    }
    public partial class GameWidgetView : UIWidgetView2 {

        // Constructor
        public GameWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
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
