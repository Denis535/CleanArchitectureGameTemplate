#nullable enable
namespace PGT.UI.Common {
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
        // Content
        protected Label title = default!;
        protected Label message = default!;
        protected Button? confirm;
        protected Button? cancel;
        // Props
        public TextWrapper Title => title;
        public TextWrapper Message => message;
        public TextWrapper? Confirm => confirm;
        public TextWrapper? Cancel => cancel;
        // Events
        public Action? OnConfirmEvent { get; set; }
        public Action? OnCancelEvent { get; set; }

        // Constructor
        public DialogWidgetViewBase() {
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetConfirm
        public virtual void SetConfirm(string text, Action? onConfirm) {
            Assert.Operation.Message( $"Confirm {confirm} must be null" ).Valid( confirm == null );
            footer.Add( confirm = ConfirmButton( text ) );
            confirm.OnClickOrSubmit( evt => OnConfirmEvent?.Invoke() );
            OnConfirmEvent = onConfirm;
        }
        public virtual void SetCancel(string text, Action? onCancel) {
            Assert.Operation.Message( $"Cancel {cancel} must be null" ).Valid( cancel == null );
            footer.Add( cancel = CancelButton( text ) );
            cancel.OnClickOrSubmit( evt => OnCancelEvent?.Invoke() );
            OnCancelEvent = onCancel;
        }

        // Helpers
        private protected static Card DialogCard(out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return new Card().SetUp( null, "unity-dialog-card" ).Children(
                header = new Header().Children( title = new Label().SetUp( "title" ) ),
                content = new Content().Children( message = new Label().SetUp( "message" ) ),
                footer = new Footer()
            );
        }
        private protected static Card InfoDialogCard(out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return new Card().SetUp( null, "unity-dialog-card", "unity-info-dialog-card" ).Children(
                header = new Header().Children( title = new Label().SetUp( "title" ) ),
                content = new Content().Children( message = new Label().SetUp( "message" ) ),
                footer = new Footer()
            );
        }
        private protected static Card WarningDialogCard(out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return new Card().SetUp( null, "unity-dialog-card", "unity-warning-dialog-card" ).Children(
                header = new Header().Children( title = new Label().SetUp( "title" ) ),
                content = new Content().Children( message = new Label().SetUp( "message" ) ),
                footer = new Footer()
            );
        }
        private protected static Card ErrorDialogCard(out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return new Card().SetUp( null, "unity-dialog-card", "unity-error-dialog-card" ).Children(
                header = new Header().Children( title = new Label().SetUp( "title" ) ),
                content = new Content().Children( message = new Label().SetUp( "message" ) ),
                footer = new Footer()
            );
        }
        private static Button ConfirmButton(string text) {
            return new Button().SetUp( "confirm", "confirm" ).Text( text );
        }
        private static Button CancelButton(string text) {
            return new Button().SetUp( "cancel", "cancel" ).Text( text );
        }

    }
    // Dialog
    public class DialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public DialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "dialog-widget-view" );
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            Add( card = DialogCard( out header, out content, out footer, out title, out message ) );
            // OnEvent
            this.OnClickOrSubmit( evt => {
                // NavigationSubmitEvent's bubble up phase doesn't work for Button
                // https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-35341
                //if (evt.target == confirm) {
                //} else 
                //if (evt.target == cancel) {
                //}
            } );
            this.OnCancel( evt => OnCancelEvent?.Invoke() );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // Info
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public InfoDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "dialog-widget-view" );
            AddToClassList( "info-dialog-widget-view" );
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            Add( card = InfoDialogCard( out header, out content, out footer, out title, out message ) );
            // OnEvent
            this.OnClickOrSubmit( evt => {
                // NavigationSubmitEvent's bubble up phase doesn't work for Button
                // https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-35341
                //if (evt.target == confirm) {
                //} else 
                //if (evt.target == cancel) {
                //}
            } );
            this.OnCancel( evt => OnCancelEvent?.Invoke() );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // Warning
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public WarningDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "dialog-widget-view" );
            AddToClassList( "warning-dialog-widget-view" );
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            Add( card = WarningDialogCard( out header, out content, out footer, out title, out message ) );
            // OnEvent
            this.OnClickOrSubmit( evt => {
                // NavigationSubmitEvent's bubble up phase doesn't work for Button
                // https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-35341
                //if (evt.target == confirm) {
                //} else 
                //if (evt.target == cancel) {
                //}
            } );
            this.OnCancel( evt => OnCancelEvent?.Invoke() );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
    // Error
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public ErrorDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "dialog-widget-view" );
            AddToClassList( "error-dialog-widget-view" );
        }
        public override void Initialize() {
            base.Initialize();
            // Content
            Add( card = ErrorDialogCard( out header, out content, out footer, out title, out message ) );
            // OnEvent
            this.OnClickOrSubmit( evt => {
                // NavigationSubmitEvent's bubble up phase doesn't work for Button
                // https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-35341
                //if (evt.target == confirm) {
                //} else 
                //if (evt.target == cancel) {
                //}
            } );
            this.OnCancel( evt => OnCancelEvent?.Invoke() );
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
