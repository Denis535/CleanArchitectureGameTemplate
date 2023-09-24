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
        public DialogWidgetBase<TView> OnSubmit(string text, Action? callback) {
            View.OnSubmit( text, () => {
                callback?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public DialogWidgetBase<TView> OnCancel(string text, Action? callback) {
            View.OnCancel( text, () => {
                callback?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

        // OnSubmit
        public DialogWidgetBase<TView> OnSubmit(string text, Action? callback, out Task task) {
            var tcs = new TaskCompletionSource<object?>();
            task = tcs.Task;
            View.OnSubmit( text, () => {
                callback?.Invoke();
                tcs.SetResult( null );
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public DialogWidgetBase<TView> OnCancel(string text, Action? callback, out Task task) {
            var tcs = new TaskCompletionSource<object?>();
            task = tcs.Task;
            View.OnCancel( text, () => {
                callback?.Invoke();
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
        public new DialogWidget OnSubmit(string text, Action? callback) {
            return (DialogWidget) base.OnSubmit( text, callback );
        }
        public new DialogWidget OnCancel(string text, Action? callback) {
            return (DialogWidget) base.OnCancel( text, callback );
        }

        // OnSubmit
        public new DialogWidget OnSubmit(string text, Action? callback, out Task task) {
            return (DialogWidget) base.OnSubmit( text, callback, out task );
        }
        public new DialogWidget OnCancel(string text, Action? callback, out Task task) {
            return (DialogWidget) base.OnCancel( text, callback, out task );
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
        public new InfoDialogWidget OnSubmit(string text, Action? callback) {
            return (InfoDialogWidget) base.OnSubmit( text, callback );
        }
        public new InfoDialogWidget OnCancel(string text, Action? callback) {
            return (InfoDialogWidget) base.OnCancel( text, callback );
        }

        // OnSubmit
        public new InfoDialogWidget OnSubmit(string text, Action? callback, out Task task) {
            return (InfoDialogWidget) base.OnSubmit( text, callback, out task );
        }
        public new InfoDialogWidget OnCancel(string text, Action? callback, out Task task) {
            return (InfoDialogWidget) base.OnCancel( text, callback, out task );
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
        public new WarningDialogWidget OnSubmit(string text, Action? callback) {
            return (WarningDialogWidget) base.OnSubmit( text, callback );
        }
        public new WarningDialogWidget OnCancel(string text, Action? callback) {
            return (WarningDialogWidget) base.OnCancel( text, callback );
        }

        // OnSubmit
        public new WarningDialogWidget OnSubmit(string text, Action? callback, out Task task) {
            return (WarningDialogWidget) base.OnSubmit( text, callback, out task );
        }
        public new WarningDialogWidget OnCancel(string text, Action? callback, out Task task) {
            return (WarningDialogWidget) base.OnCancel( text, callback, out task );
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
        public new ErrorDialogWidget OnSubmit(string text, Action? callback) {
            return (ErrorDialogWidget) base.OnSubmit( text, callback );
        }
        public new ErrorDialogWidget OnCancel(string text, Action? callback) {
            return (ErrorDialogWidget) base.OnCancel( text, callback );
        }

        // OnSubmit
        public new ErrorDialogWidget OnSubmit(string text, Action? callback, out Task task) {
            return (ErrorDialogWidget) base.OnSubmit( text, callback, out task );
        }
        public new ErrorDialogWidget OnCancel(string text, Action? callback, out Task task) {
            return (ErrorDialogWidget) base.OnCancel( text, callback, out task );
        }

    }
}
