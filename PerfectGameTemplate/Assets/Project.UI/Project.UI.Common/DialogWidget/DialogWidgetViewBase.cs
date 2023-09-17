#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public abstract class DialogWidgetViewBase : UIWidgetView2, IUIModalWidgetView {

        // Content
        protected Card card = default!;
        protected Header header = default!;
        protected Content content = default!;
        protected Footer footer = default!;
        protected Label title = default!;
        protected Label message = default!;
        // Props
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper Message => message.Wrap();

        // Constructor
        public DialogWidgetViewBase() {
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public void OnSubmit(string text, Action? onConfirm) {
            var confirm = new Button().SetUp( "confirm" ).Text( text );
            confirm.OnClick( evt => {
                if (confirm.IsValid()) {
                    onConfirm?.Invoke();
                }
            } );
            footer.Add( confirm );
        }
        public void OnCancel(string text, Action? onCancel) {
            var cancel = new Button().SetUp( "cancel" ).Text( text );
            cancel.OnClick( evt => {
                if (cancel.IsValid()) {
                    onCancel?.Invoke();
                }
            } );
            footer.Add( cancel );
        }

    }
    // Dialog
    public class DialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public DialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "dialog-widget-view" );
            Add( card = new Card().SetUp( null, "unity-dialog-card" ).Children(
                header = new Header().Apply( i => i.SetDisplayed( false ) ),
                content = new Content().Apply( i => i.SetDisplayed( false ) ),
                footer = new Footer().Apply( i => i.SetDisplayed( false ) )
            ) );
            header.Add( title = new Label( null ).SetUp( "title" ) );
            content.Add( message = new Label( null ).SetUp( "message" ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // InfoDialog
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public InfoDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "info-dialog-widget-view" );
            Add( card = new Card().SetUp( null, "unity-info-dialog-card" ).Children(
                header = new Header().Apply( i => i.SetDisplayed( false ) ),
                content = new Content().Apply( i => i.SetDisplayed( false ) ),
                footer = new Footer().Apply( i => i.SetDisplayed( false ) )
            ) );
            header.Add( title = new Label( null ).SetUp( "title" ) );
            content.Add( message = new Label( null ).SetUp( "message" ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // WarningDialog
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public WarningDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "warning-dialog-widget-view" );
            Add( card = new Card().SetUp( null, "unity-warning-dialog-card" ).Children(
                header = new Header().Apply( i => i.SetDisplayed( false ) ),
                content = new Content().Apply( i => i.SetDisplayed( false ) ),
                footer = new Footer().Apply( i => i.SetDisplayed( false ) )
            ) );
            header.Add( title = new Label( null ).SetUp( "title" ) );
            content.Add( message = new Label( null ).SetUp( "message" ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // ErrorDialog
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public ErrorDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "error-dialog-widget-view" );
            Add( card = new Card().SetUp( null, "unity-error-dialog-card" ).Children(
                header = new Header().Apply( i => i.SetDisplayed( false ) ),
                content = new Content().Apply( i => i.SetDisplayed( false ) ),
                footer = new Footer().Apply( i => i.SetDisplayed( false ) )
            ) );
            header.Add( title = new Label( null ).SetUp( "title" ) );
            content.Add( message = new Label( null ).SetUp( "message" ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
