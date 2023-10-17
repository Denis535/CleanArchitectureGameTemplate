#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

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
        // View
        public ElementWrapper View => visualElement.Wrap();
        public ElementWrapper Card => card.Wrap();
        public ElementWrapper Header => header.Wrap();
        public ElementWrapper Content => content.Wrap();
        public ElementWrapper Footer => footer.Wrap();
        public LabelWrapper Title => title.Wrap();
        public LabelWrapper Message => message.Wrap();

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

        // Heleprs
        protected static void PlayAppearanceAnimation(VisualElement view) {
            var animation = ValueAnimation<float>.Create( view, Mathf.LerpUnclamped );
            animation.valueUpdated = (view, t) => {
                var tx = Easing.OutBack( Easing.InPower( t, 2 ), 4 );
                var ty = Easing.OutBack( Easing.OutPower( t, 2 ), 4 );
                var x = Mathf.LerpUnclamped( 0.8f, 1f, tx );
                var y = Mathf.LerpUnclamped( 0.8f, 1f, ty );
                view.transform.scale = new Vector3( x, y, 1 );
            };
            animation.from = 0;
            animation.to = 1;
            animation.durationMs = 500;
            animation.Start();
        }

    }
    // Dialog
    public class DialogWidgetView : DialogWidgetViewBase {

        // Constructor
        public DialogWidgetView(DialogWidget widget) : base( widget ) {
            visualElement = CreateVisualElement( out card, out header, out content, out footer, out title, out message );
            visualElement.OnAttachToPanel( evt => {
                PlayAppearanceAnimation( visualElement );
            } );
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
            visualElement.OnAttachToPanel( evt => {
                PlayAppearanceAnimation( visualElement );
            } );
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
            visualElement.OnAttachToPanel( evt => {
                PlayAppearanceAnimation( visualElement );
            } );
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
            visualElement.OnAttachToPanel( evt => {
                PlayAppearanceAnimation( visualElement );
            } );
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
