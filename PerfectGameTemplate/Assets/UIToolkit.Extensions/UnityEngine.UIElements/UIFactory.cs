#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIFactory {

        public static Func<object?, string?>? GetDisplayString { get; set; }

        // Widget
        public static View Widget(string name) {
            var result = new View();
            result.SetName( name );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View LeftWidget(string name) {
            var result = new View();
            result.SetName( name );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "left-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View SmallWidget(string name) {
            var result = new View();
            result.SetName( name );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "small-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View MediumWidget(string name) {
            var result = new View();
            result.SetName( name );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "medium-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View LargeWidget(string name) {
            var result = new View();
            result.SetName( name );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "large-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Widget
        public static View DialogWidget() {
            var result = new View();
            result.SetName( "dialog-widget-view" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "modal-widget-view" );
            result.AddToClassList( "dialog-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View InfoDialogWidget() {
            var result = new View();
            result.SetName( "info-dialog-widget-view" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "modal-widget-view" );
            result.AddToClassList( "info-dialog-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View WarningDialogWidget() {
            var result = new View();
            result.SetName( "warning-dialog-widget-view" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "modal-widget-view" );
            result.AddToClassList( "warning-dialog-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static View ErrorDialogWidget() {
            var result = new View();
            result.SetName( "error-dialog-widget-view" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "modal-widget-view" );
            result.AddToClassList( "error-dialog-widget-view" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Card
        public static Card Card() {
            var result = new Card();
            result.SetName( "card" );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Header Header() {
            var result = new Header();
            result.SetName( "header" );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Content Content() {
            var result = new Content();
            result.SetName( "content" );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Footer Footer() {
            var result = new Footer();
            result.SetName( "footer" );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Card
        public static Card DialogCard() {
            var result = new Card();
            result.SetName( "dialog-card" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "dialog-card" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Card InfoDialogCard() {
            var result = new Card();
            result.SetName( "info-dialog-card" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "info-dialog-card" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Card WarningDialogCard() {
            var result = new Card();
            result.SetName( "warning-dialog-card" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "warning-dialog-card" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Card ErrorDialogCard() {
            var result = new Card();
            result.SetName( "error-dialog-card" );
            result.AddToClassList( "visual-element" );
            result.AddToClassList( "error-dialog-card" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Slot
        public static Slot Slot() {
            var result = new Slot();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Scope
        public static ColumnScope ColumnScope() {
            var result = new ColumnScope();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static RowScope RowScope() {
            var result = new RowScope();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Group
        public static ColumnGroup ColumnGroup() {
            var result = new ColumnGroup();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static RowGroup RowGroup() {
            var result = new RowGroup();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // ScrollView
        public static ScrollView ScrollView() {
            var result = new ScrollView();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.horizontalScroller.highButton.BringToFront();
                result.verticalScroller.highButton.BringToFront();
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Box
        public static Box Box() {
            var result = new Box();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Label
        public static Label Label(string? text) {
            var result = new Label();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.text = text;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        // Button
        public static Button Button(string? text) {
            var result = new Button();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.text = text;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static RepeatButton RepeatButton(string? text) {
            var result = new RepeatButton();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.text = text;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        // Field
        public static TextField TextField(string? label, int maxLength, bool isMultiline) {
            var result = new TextField();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
                result.maxLength = maxLength;
                result.multiline = isMultiline;
                result.isReadOnly = false;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            var result = new TextField();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
                result.maxLength = maxLength;
                result.multiline = isMultiline;
                result.isReadOnly = true;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static PopupField<object?> PopupField(string? label) {
            var result = new PopupField<object?>();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
                result.formatSelectedValueCallback = GetDisplayString;
                result.formatListItemCallback = GetDisplayString;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static DropdownField DropdownField(string? label) {
            var result = new DropdownField();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
                result.formatSelectedValueCallback = GetDisplayString;
                result.formatListItemCallback = GetDisplayString;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Slider Slider(string? label) {
            var result = new Slider();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static SliderInt SliderInt(string? label) {
            var result = new SliderInt();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }
        public static Toggle Toggle(string? label) {
            var result = new Toggle();
            result.SetName( null );
            result.AddToClassList( "visual-element" );
            {
                result.label = label;
            }
            VisualElementScope.Current?.Add( result );
            return result;
        }

        // Helpers
        private static void SetName(this VisualElement visualElement, string? name) {
            visualElement.name = name;
        }

    }
}
