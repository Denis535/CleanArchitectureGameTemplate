#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public abstract class DialogWidgetViewBase : UIWidgetViewBase, IUIModalWidgetView {

        // View
        protected VisualElement visualElement = default!;
        protected Card card = default!;
        protected Header header = default!;
        protected Content content = default!;
        protected Footer footer = default!;
        protected Label title = default!;
        protected Label message = default!;
        // View
        public override VisualElement VisualElement => visualElement;
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public TextWrapper Title => title.Wrap();
        public TextWrapper Message => message.Wrap();

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
            visualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
            header.SetDisplayed( false );
            content.SetDisplayed( false );
            footer.SetDisplayed( false );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget( "dialog-widget-view" ).Classes( "dialog-widget-view" ).Children(
                card = UIFactory.DialogCard().Children(
                    header = UIFactory.Header().Children(
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content().Children(
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer()
                )
            );
        }

    }
    // InfoDialog
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public InfoDialogWidgetView(InfoDialogWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
            header.SetDisplayed( false );
            content.SetDisplayed( false );
            footer.SetDisplayed( false );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget( "info-dialog-widget-view" ).Classes( "info-dialog-widget-view" ).Children(
                card = UIFactory.InfoDialogCard().Children(
                    header = UIFactory.Header().Children(
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content().Children(
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer()
                )
            );
        }

    }
    // WarningDialog
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public WarningDialogWidgetView(WarningDialogWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
            header.SetDisplayed( false );
            content.SetDisplayed( false );
            footer.SetDisplayed( false );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget( "warning-dialog-widget-view" ).Classes( "warning-dialog-widget-view" ).Children(
                card = UIFactory.WarningDialogCard().Children(
                    header = UIFactory.Header().Children(
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content().Children(
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer()
                )
            );
        }

    }
    // ErrorDialog
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public ErrorDialogWidgetView(ErrorDialogWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
            header.SetDisplayed( false );
            content.SetDisplayed( false );
            footer.SetDisplayed( false );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            return UIFactory.ModalWidget( "error-dialog-widget-view" ).Classes( "error-dialog-widget-view" ).Children(
                card = UIFactory.ErrorDialogCard().Children(
                    header = UIFactory.Header().Children(
                        title = UIFactory.Label( null ).Name( "title" )
                    ),
                    content = UIFactory.Content().Children(
                        message = UIFactory.Label( null ).Name( "message" )
                    ),
                    footer = UIFactory.Footer()
                )
            );
        }

    }
}
