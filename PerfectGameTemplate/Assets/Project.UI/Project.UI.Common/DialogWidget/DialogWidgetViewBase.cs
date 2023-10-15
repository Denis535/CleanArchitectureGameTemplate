#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public abstract class DialogWidgetViewBase : UIWidgetViewBase, IUIModalWidgetView {

        // VisualElement
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
        public DialogWidgetViewBase(UIWidgetBase widget) : base( widget ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public void OnSubmit(string text, Action? callback) {
            var button = UIFactory.Button( text ).Name( "submit" );
            button.OnClick( evt => {
                if (button.IsValid()) {
                    callback?.Invoke();
                }
            } );
            footer.Add( button );
        }
        public void OnCancel(string text, Action? callback) {
            var button = UIFactory.Button( text ).Name( "cancel" );
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
        public DialogWidgetView(DialogWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget(
                i => i.Name( "dialog-widget-view" ).Classes( "dialog-widget-view" ),
                card = UIFactory.Card(
                    i => i.Name( null ).Classes( "dialog-card" ),
                    header = UIFactory.Header(
                        i => i.SetDisplayed( false ),
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content(
                        i => i.SetDisplayed( false ),
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer(
                        i => i.SetDisplayed( false )
                    )
                )
            );
        }

    }
    // InfoDialog
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public InfoDialogWidgetView(InfoDialogWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget(
                i => i.Name( "info-dialog-widget-view" ).Classes( "info-dialog-widget-view" ),
                card = UIFactory.Card(
                    i => i.Name( null ).Classes( "info-dialog-card" ),
                    header = UIFactory.Header(
                        i => i.SetDisplayed( false ),
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content(
                        i => i.SetDisplayed( false ),
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer(
                        i => i.SetDisplayed( false )
                    )
                )
            );
        }

    }
    // WarningDialog
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public WarningDialogWidgetView(WarningDialogWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget(
                i => i.Name( "warning-dialog-widget-view" ).Classes( "warning-dialog-widget-view" ),
                card = UIFactory.Card(
                    i => i.Name( null ).Classes( "warning-dialog-card" ),
                    header = UIFactory.Header(
                        i => i.SetDisplayed( false ),
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content(
                        i => i.SetDisplayed( false ),
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer(
                        i => i.SetDisplayed( false )
                    )
                )
            );
        }

    }
    // ErrorDialog
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public ErrorDialogWidgetView(ErrorDialogWidget widget) : base( widget ) {
            // VisualElement
            VisualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static VisualElement CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget(
                i => i.Name( "error-dialog-widget-view" ).Classes( "error-dialog-widget-view" ),
                card = UIFactory.Card(
                    i => i.Name( null ).Classes( "error-dialog-card" ),
                    header = UIFactory.Header(
                        i => i.SetDisplayed( false ),
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content(
                        i => i.SetDisplayed( false ),
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer(
                        i => i.SetDisplayed( false )
                    )
                )
            );
        }

    }
}
