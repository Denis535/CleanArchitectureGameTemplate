#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.Scripting;
    using UnityEngine.UIElements;

    public partial class PlayerProfileWidgetView {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<PlayerProfileWidgetView, UxmlTraits> { }
        public record NameEvent(string Name) : UIEvent<PlayerProfileWidgetView>;
        public record OkeyCommand(bool IsValid) : UICommand<PlayerProfileWidgetView>;
        public record BackCommand() : UICommand<PlayerProfileWidgetView>;
    }
    public partial class PlayerProfileWidgetView : UIWidgetView2 {

        // Content
        private Label title = default!;
        private new TextField name = default!;
        private Button okey = default!;
        private Button back = default!;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public FieldWrapper<string> Name => name.Wrap();
        public TextElementWrapper Okey => okey.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public PlayerProfileWidgetView() {
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            title = this.RequireElement<Label>( "title" );
            name = this.RequireElement<TextField>( "name" );
            okey = this.RequireElement<Button>( "okey" );
            back = this.RequireElement<Button>( "back" );
            // OnEvent
            this.OnAttachToPanel( evt => {
                new NameEvent( Name.Value! ).Raise( this );
            } );
            name.OnChange( evt => {
                new NameEvent( evt.newValue ).Raise( this );
            } );
            okey.OnClick( evt => {
                new OkeyCommand( okey.IsValid() ).Execute( this );
            } );
            back.OnClick( evt => {
                new BackCommand().Execute( this );
            } );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
