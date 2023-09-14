#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public abstract class DialogWidgetViewBase : UIWidgetView2, IUIModalWidgetView {

        // Constructor
        public DialogWidgetViewBase() {
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // DialogDialog
    public class DialogWidgetView : DialogWidgetViewBase {

        // Content
        private readonly Card card = default!;
        private readonly Header header = default!;
        private readonly Content content = default!;
        private readonly Footer footer = default!;
        private readonly Label title = default!;
        private readonly Label message = default!;
        // Props
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper Message => message.Wrap();

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

        // Submit
        public void Submit(string text, Action? onConfirm) {
            var confirm = new Button().SetUp( "confirm" ).Text( text );
            confirm.OnClick( evt => onConfirm?.Invoke() );
            footer.Add( confirm );
        }
        public void Cancel(string text, Action? onCancel) {
            var cancel = new Button().SetUp( "cancel" ).Text( text );
            cancel.OnClick( evt => onCancel?.Invoke() );
            footer.Add( cancel );
        }

    }
    // InfoDialog
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Content
        private readonly Card card = default!;
        private readonly Header header = default!;
        private readonly Content content = default!;
        private readonly Footer footer = default!;
        private readonly Label title = default!;
        private readonly Label message = default!;
        // Props
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper Message => message.Wrap();

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

        // Submit
        public void Submit(string text, Action? onConfirm) {
            var confirm = new Button().SetUp( "confirm" ).Text( text );
            confirm.OnClick( evt => onConfirm?.Invoke() );
            footer.Add( confirm );
        }
        public void Cancel(string text, Action? onCancel) {
            var cancel = new Button().SetUp( "cancel" ).Text( text );
            cancel.OnClick( evt => onCancel?.Invoke() );
            footer.Add( cancel );
        }

    }
    // WarningDialog
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Content
        private readonly Card card = default!;
        private readonly Header header = default!;
        private readonly Content content = default!;
        private readonly Footer footer = default!;
        private readonly Label title = default!;
        private readonly Label message = default!;
        // Props
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper Message => message.Wrap();

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

        // Submit
        public void Submit(string text, Action? onConfirm) {
            var confirm = new Button().SetUp( "confirm" ).Text( text );
            confirm.OnClick( evt => onConfirm?.Invoke() );
            footer.Add( confirm );
        }
        public void Cancel(string text, Action? onCancel) {
            var cancel = new Button().SetUp( "cancel" ).Text( text );
            cancel.OnClick( evt => onCancel?.Invoke() );
            footer.Add( cancel );
        }

    }
    // ErrorDialog
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Content
        private readonly Card card = default!;
        private readonly Header header = default!;
        private readonly Content content = default!;
        private readonly Footer footer = default!;
        private readonly Label title = default!;
        private readonly Label message = default!;
        // Props
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public TextElementWrapper Title => title.Wrap();
        public TextElementWrapper Message => message.Wrap();

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

        // Submit
        public void Submit(string text, Action? onConfirm) {
            var confirm = new Button().SetUp( "confirm" ).Text( text );
            confirm.OnClick( evt => onConfirm?.Invoke() );
            footer.Add( confirm );
        }
        public void Cancel(string text, Action? onCancel) {
            var cancel = new Button().SetUp( "cancel" ).Text( text );
            cancel.OnClick( evt => onCancel?.Invoke() );
            footer.Add( cancel );
        }

    }
}
