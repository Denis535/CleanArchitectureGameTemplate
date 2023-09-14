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

    }
    // Dialog
    public class DialogWidget : DialogWidgetBase<DialogWidgetView> {

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
        public DialogWidget(string? title, string? message) {
            View = UIVisualFactory.DialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Submit
        public DialogWidget Submit(string text, Action? onConfirm) {
            View.Submit( text, () => {
                onConfirm?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public DialogWidget Cancel(string text, Action? onCancel) {
            View.Cancel( text, () => {
                onCancel?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

    }
    // InfoDialog
    public class InfoDialogWidget : DialogWidgetBase<InfoDialogWidgetView> {

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
        public InfoDialogWidget(string? title, string? message) {
            View = UIVisualFactory.InfoDialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Submit
        public InfoDialogWidget Submit(string text, Action? onConfirm) {
            View.Submit( text, () => {
                onConfirm?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public InfoDialogWidget Cancel(string text, Action? onCancel) {
            View.Cancel( text, () => {
                onCancel?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

    }
    // WarningDialog
    public class WarningDialogWidget : DialogWidgetBase<WarningDialogWidgetView> {

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
        public WarningDialogWidget(string? title, string? message) {
            View = UIVisualFactory.WarningDialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Submit
        public WarningDialogWidget Submit(string text, Action? onConfirm) {
            View.Submit( text, () => {
                onConfirm?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public WarningDialogWidget Cancel(string text, Action? onCancel) {
            View.Cancel( text, () => {
                onCancel?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

    }
    // ErrorDialog
    public class ErrorDialogWidget : DialogWidgetBase<ErrorDialogWidgetView> {

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
        public ErrorDialogWidget(string? title, string? message) {
            View = UIVisualFactory.ErrorDialogWidget();
            Title = title;
            Message = message;
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Submit
        public ErrorDialogWidget Submit(string text, Action? onConfirm) {
            View.Submit( text, () => {
                onConfirm?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }
        public ErrorDialogWidget Cancel(string text, Action? onCancel) {
            View.Cancel( text, () => {
                onCancel?.Invoke();
                this.DetachSelf();
            } );
            View.Footer.IsDisplayed = true;
            return this;
        }

    }
}
