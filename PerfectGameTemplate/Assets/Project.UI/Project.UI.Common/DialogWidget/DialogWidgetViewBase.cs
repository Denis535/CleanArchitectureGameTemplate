#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public abstract class DialogWidgetViewBase : UIWidgetViewBase, IUIModalWidgetView {

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
        public void OnSubmit(string text, Action? callback) {
            var button = UIFactory.Button( text, "submit" );
            button.OnClick( evt => {
                if (button.IsValid()) {
                    callback?.Invoke();
                }
            } );
            footer.Add( button );
        }
        public void OnCancel(string text, Action? callback) {
            var button = UIFactory.Button( text, "cancel" );
            button.OnClick( evt => {
                if (button.IsValid()) {
                    callback?.Invoke();
                }
            } );
            footer.Add( button );
        }

    }
    // Dialog
    public class DialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public DialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "dialog-widget-view" );
            // Content
            Add( GetContent( out card, out header, out content, out footer, out title, out message ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static Card GetContent(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return card = UIFactory.Card(
                i => i.Name( null, "unity-dialog-card" ),
                header = UIFactory.Header(
                    i => i.SetDisplayed( false ),
                    title = UIFactory.Label( null, "title" )
                ),
                content = UIFactory.Content(
                    i => i.SetDisplayed( false ),
                    message = UIFactory.Label( null, "message" )
                ),
                footer = UIFactory.Footer(
                    i => i.SetDisplayed( false )
                )
            );
        }

    }
    // InfoDialog
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public InfoDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "info-dialog-widget-view" );
            // Content
            Add( GetContent( out card, out header, out content, out footer, out title, out message ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static Card GetContent(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return card = UIFactory.Card(
                i => i.Name( null, "unity-info-dialog-card" ),
                header = UIFactory.Header(
                    i => i.SetDisplayed( false ),
                    title = UIFactory.Label( null, "title" )
                ),
                content = UIFactory.Content(
                    i => i.SetDisplayed( false ),
                    message = UIFactory.Label( null, "message" )
                ),
                footer = UIFactory.Footer(
                    i => i.SetDisplayed( false )
                )
            );
        }

    }
    // WarningDialog
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public WarningDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "warning-dialog-widget-view" );
            // Content
            Add( GetContent( out card, out header, out content, out footer, out title, out message ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static Card GetContent(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return card = UIFactory.Card(
                i => i.Name( null, "unity-warning-dialog-card" ),
                header = UIFactory.Header(
                    i => i.SetDisplayed( false ),
                    title = UIFactory.Label( null, "title" )
                ),
                content = UIFactory.Content(
                    i => i.SetDisplayed( false ),
                    message = UIFactory.Label( null, "message" )
                ),
                footer = UIFactory.Footer(
                    i => i.SetDisplayed( false )
                )
            );
        }

    }
    // ErrorDialog
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public ErrorDialogWidgetView() {
            AddToClassList( "modal-widget-view" );
            AddToClassList( "error-dialog-widget-view" );
            // Content
            Add( GetContent( out card, out header, out content, out footer, out title, out message ) );
        }
        public override void Initialize() {
            base.Initialize();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static Card GetContent(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return card = UIFactory.Card(
                i => i.Name( null, "unity-error-dialog-card" ),
                header = UIFactory.Header(
                    i => i.SetDisplayed( false ),
                    title = UIFactory.Label( null, "title" )
                ),
                content = UIFactory.Content(
                    i => i.SetDisplayed( false ),
                    message = UIFactory.Label( null, "message" )
                ),
                footer = UIFactory.Footer(
                    i => i.SetDisplayed( false )
                )
            );
        }

    }
}
