#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public partial class PlayerProfileWidgetView {
        public record NameEvent(string Name) : UIEvent<PlayerProfileWidgetView>;
        public record OkeyCommand(bool IsValid) : UICommand<PlayerProfileWidgetView>;
        public record BackCommand() : UICommand<PlayerProfileWidgetView>;
    }
    public partial class PlayerProfileWidgetView : UIWidgetViewBase {

        // Content
        private readonly Label title;
        private readonly new TextField name;
        private readonly Button okey;
        private readonly Button back;
        // Props
        public TextElementWrapper Title => title.Wrap();
        public FieldWrapper<string> Name => name.Wrap();
        public TextElementWrapper Okey => okey.Wrap();
        public TextElementWrapper Back => back.Wrap();

        // Constructor
        public PlayerProfileWidgetView() {
            AddToClassList( "middle-widget-view" );
            // Content
            Add( GetContent( out title, out name, out okey, out back ) );
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
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static Card GetContent(out Label title, out TextField name, out Button okey, out Button back) {
            return UIFactory.Card(
                UIFactory.Header(
                    title = UIFactory.Label( "Player Profile", "title" )
                ),
                UIFactory.Content(
                    UIFactory.ColumnGroup(
                        i => i.Name( null, ".dark2.large.grow-1" ),
                        name = UIFactory.TextField( "Name", 16, false, "name", "label-width-25" )
                    )
                ),
                UIFactory.Footer(
                    okey = UIFactory.Button( "Ok", "okey" ),
                    back = UIFactory.Button( "Back", "back" )
                )
            );
        }

    }
}
