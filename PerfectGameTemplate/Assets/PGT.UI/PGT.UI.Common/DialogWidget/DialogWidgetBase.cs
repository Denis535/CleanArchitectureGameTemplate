#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public abstract class DialogWidgetBase<TView> : UIWidget2<TView>, IUIModalWidget where TView : DialogWidgetViewBase {

        // Constructor
        public DialogWidgetBase() {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
        }

        // SetConfirm
        public DialogWidgetBase<TView> SetConfirm(string text, Action? onConfirm) {
            View.SetConfirm( text, () => {
                onConfirm?.Invoke();
                Router.DetachSelf();
            } );
            return this;
        }
        public DialogWidgetBase<TView> SetCancel(string text, Action? onCancel) {
            View.SetCancel( text, () => {
                onCancel?.Invoke();
                Router.DetachSelf();
            } );
            return this;
        }

    }
    // Dialog
    public class DialogWidget : DialogWidgetBase<DialogWidgetView> {

        // Constructor
        public DialogWidget(string title, string message) {
            View = UIVisualFactory.DialogWidget( title, message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetConfirm
        public new DialogWidget SetConfirm(string text, Action? onConfirm) {
            return (DialogWidget) base.SetConfirm( text, onConfirm );
        }
        public new DialogWidget SetCancel(string text, Action? onCancel) {
            return (DialogWidget) base.SetCancel( text, onCancel );
        }

    }
    // Info
    public class InfoDialogWidget : DialogWidgetBase<InfoDialogWidgetView> {

        // Constructor
        public InfoDialogWidget(string title, string message) {
            View = UIVisualFactory.InfoDialogWidget( title, message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetConfirm
        public new InfoDialogWidget SetConfirm(string text, Action? onConfirm) {
            return (InfoDialogWidget) base.SetConfirm( text, onConfirm );
        }
        public new InfoDialogWidget SetCancel(string text, Action? onCancel) {
            return (InfoDialogWidget) base.SetCancel( text, onCancel );
        }

    }
    // Warning
    public class WarningDialogWidget : DialogWidgetBase<WarningDialogWidgetView> {

        // Constructor
        public WarningDialogWidget(string title, string message) {
            View = UIVisualFactory.WarningDialogWidget( title, message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetConfirm
        public new WarningDialogWidget SetConfirm(string text, Action? onConfirm) {
            return (WarningDialogWidget) base.SetConfirm( text, onConfirm );
        }
        public new WarningDialogWidget SetCancel(string text, Action? onCancel) {
            return (WarningDialogWidget) base.SetCancel( text, onCancel );
        }

    }
    // Error
    public class ErrorDialogWidget : DialogWidgetBase<ErrorDialogWidgetView> {

        // Constructor
        public ErrorDialogWidget(string title, string message) {
            View = UIVisualFactory.ErrorDialogWidget( title, message );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // SetConfirm
        public new ErrorDialogWidget SetConfirm(string text, Action? onConfirm) {
            return (ErrorDialogWidget) base.SetConfirm( text, onConfirm );
        }
        public new ErrorDialogWidget SetCancel(string text, Action? onCancel) {
            return (ErrorDialogWidget) base.SetCancel( text, onCancel );
        }

    }
}
