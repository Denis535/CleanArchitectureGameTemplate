#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public abstract class DialogWidgetViewBase : UIWidgetViewBase, IUIModalWidgetView {

        // Factory
        private UIFactory Factory { get; }
        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public ElementWrapper Card { get; }
        public ElementWrapper Header { get; }
        public ElementWrapper Content { get; }
        public ElementWrapper Footer { get; }
        public LabelWrapper Title { get; }
        public LabelWrapper Message { get; }

        // Constructor
        public DialogWidgetViewBase(UIWidgetBase widget, UIFactory factory) : base( widget ) {
            Factory = factory;
            VisualElement = CreateVisualElement( Factory, out var view, out var card, out var header, out var content, out var footer, out var title, out var message );
            View = view.Wrap();
            Card = card.Wrap();
            Header = header.Wrap().Pipe( i => i.IsDisplayed = false );
            Content = content.Wrap().Pipe( i => i.IsDisplayed = false );
            Footer = footer.Wrap().Pipe( i => i.IsDisplayed = false );
            Title = title.Wrap();
            Message = message.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public void OnSubmit(string text, Action? callback) {
            var button = Factory.Button( text ).Name( "submit" );
            button.OnClick( evt => {
                if (button.IsValid()) {
                    callback?.Invoke();
                }
            } );
            Footer.VisualElement.Add( button );
        }
        public void OnCancel(string text, Action? callback) {
            var button = Factory.Button( text ).Name( "cancel" );
            button.OnClick( evt => {
                if (button.IsValid()) {
                    callback?.Invoke();
                }
            } );
            Footer.VisualElement.Add( button );
        }

        // Heleprs
        protected abstract View CreateVisualElement(UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message);

    }
    // Dialog
    public class DialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public DialogWidgetView(DialogWidget widget, UIFactory factory) : base( widget, factory ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        protected override View CreateVisualElement(UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.DialogWidget().AsScope( out view )) {
                using (factory.DialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }

    }
    // InfoDialog
    public class InfoDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public InfoDialogWidgetView(InfoDialogWidget widget, UIFactory factory) : base( widget, factory ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        protected override View CreateVisualElement(UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.InfoDialogWidget().AsScope( out view )) {
                using (factory.InfoDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }

    }
    // WarningDialog
    public class WarningDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public WarningDialogWidgetView(WarningDialogWidget widget, UIFactory factory) : base( widget, factory ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        protected override View CreateVisualElement(UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.WarningDialogWidget().AsScope( out view )) {
                using (factory.WarningDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }

    }
    // ErrorDialog
    public class ErrorDialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public ErrorDialogWidgetView(ErrorDialogWidget widget, UIFactory factory) : base( widget, factory ) {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        protected override View CreateVisualElement(UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.ErrorDialogWidget().AsScope( out view )) {
                using (factory.ErrorDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return view;
        }

    }
}
