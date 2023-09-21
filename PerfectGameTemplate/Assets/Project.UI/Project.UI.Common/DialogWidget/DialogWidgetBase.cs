#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public abstract class DialogWidgetBase<TView> : UIWidgetBase<TView>, IUIModalWidget where TView : DialogWidgetViewBase {

        // Props
        public string? Title {
            get => View.Title.Text;
            set {
                View.Header.IsDisplayed = value != null;
                View.Title.Text = value;
            }
        }
        public string? Message {
            get => View.Message.Text;
            set {
                View.Content.IsDisplayed = value != null;
                View.Message.Text = value;
            }
        }

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

        // OnSubmit
        public DialogWidgetBase<TView> OnSubmit(string text, Action? onConfirm) {
            View.OnSubmit( text, () => {
                onConfirm?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public DialogWidgetBase<TView> OnCancel(string text, Action? onCancel) {
            View.OnCancel( text, () => {
                onCancel?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

        // OnSubmit
        public DialogWidgetBase<TView> OnSubmit(string text, Action? onConfirm, out Task task) {
            var tcs = new TaskCompletionSource<object?>();
            task = tcs.Task;
            View.OnSubmit( text, () => {
                onConfirm?.Invoke();
                tcs.SetResult( null );
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public DialogWidgetBase<TView> OnCancel(string text, Action? onCancel, out Task task) {
            var tcs = new TaskCompletionSource<object?>();
            task = tcs.Task;
            View.OnCancel( text, () => {
                onCancel?.Invoke();
                tcs.SetResult( null );
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

    }
    // Dialog
    public class DialogWidget : DialogWidgetBase<DialogWidgetView> {

        // Constructor
        public DialogWidget(string? title, string? message) {
            View = UIVisualFactory.DialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public new DialogWidget OnSubmit(string text, Action? onConfirm) {
            return (DialogWidget) base.OnSubmit( text, onConfirm );
        }
        public new DialogWidget OnCancel(string text, Action? onCancel) {
            return (DialogWidget) base.OnCancel( text, onCancel );
        }

        // OnSubmit
        public new DialogWidget OnSubmit(string text, Action? onConfirm, out Task task) {
            return (DialogWidget) base.OnSubmit( text, onConfirm, out task );
        }
        public new DialogWidget OnCancel(string text, Action? onCancel, out Task task) {
            return (DialogWidget) base.OnCancel( text, onCancel, out task );
        }

    }
    // InfoDialog
    public class InfoDialogWidget : DialogWidgetBase<InfoDialogWidgetView> {

        // Constructor
        public InfoDialogWidget(string? title, string? message) {
            View = UIVisualFactory.InfoDialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public new InfoDialogWidget OnSubmit(string text, Action? onConfirm) {
            return (InfoDialogWidget) base.OnSubmit( text, onConfirm );
        }
        public new InfoDialogWidget OnCancel(string text, Action? onCancel) {
            return (InfoDialogWidget) base.OnCancel( text, onCancel );
        }

        // OnSubmit
        public new InfoDialogWidget OnSubmit(string text, Action? onConfirm, out Task task) {
            return (InfoDialogWidget) base.OnSubmit( text, onConfirm, out task );
        }
        public new InfoDialogWidget OnCancel(string text, Action? onCancel, out Task task) {
            return (InfoDialogWidget) base.OnCancel( text, onCancel, out task );
        }

    }
    // WarningDialog
    public class WarningDialogWidget : DialogWidgetBase<WarningDialogWidgetView> {

        // Constructor
        public WarningDialogWidget(string? title, string? message) {
            View = UIVisualFactory.WarningDialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public new WarningDialogWidget OnSubmit(string text, Action? onConfirm) {
            return (WarningDialogWidget) base.OnSubmit( text, onConfirm );
        }
        public new WarningDialogWidget OnCancel(string text, Action? onCancel) {
            return (WarningDialogWidget) base.OnCancel( text, onCancel );
        }

        // OnSubmit
        public new WarningDialogWidget OnSubmit(string text, Action? onConfirm, out Task task) {
            return (WarningDialogWidget) base.OnSubmit( text, onConfirm, out task );
        }
        public new WarningDialogWidget OnCancel(string text, Action? onCancel, out Task task) {
            return (WarningDialogWidget) base.OnCancel( text, onCancel, out task );
        }

    }
    // ErrorDialog
    public class ErrorDialogWidget : DialogWidgetBase<ErrorDialogWidgetView> {

        // Constructor
        public ErrorDialogWidget(string? title, string? message) {
            View = UIVisualFactory.ErrorDialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnSubmit
        public new ErrorDialogWidget OnSubmit(string text, Action? onConfirm) {
            return (ErrorDialogWidget) base.OnSubmit( text, onConfirm );
        }
        public new ErrorDialogWidget OnCancel(string text, Action? onCancel) {
            return (ErrorDialogWidget) base.OnCancel( text, onCancel );
        }

        // OnSubmit
        public new ErrorDialogWidget OnSubmit(string text, Action? onConfirm, out Task task) {
            return (ErrorDialogWidget) base.OnSubmit( text, onConfirm, out task );
        }
        public new ErrorDialogWidget OnCancel(string text, Action? onCancel, out Task task) {
            return (ErrorDialogWidget) base.OnCancel( text, onCancel, out task );
        }

    }
}
