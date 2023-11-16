#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactory {

        public static Func<object?, string?>? GetDisplayString { get; set; }

        // Widget
        public static View Widget(string name) {
            var result = new View().Name( name ).Classes( "visual-element", "widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View LeftWidget(string name) {
            var result = new View().Name( name ).Classes( "visual-element", "left-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View SmallWidget(string name) {
            var result = new View().Name( name ).Classes( "visual-element", "small-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View MediumWidget(string name) {
            var result = new View().Name( name ).Classes( "visual-element", "medium-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View LargeWidget(string name) {
            var result = new View().Name( name ).Classes( "visual-element", "large-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }

        // Widget
        public static View DialogWidget() {
            var result = new View().Name( "dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "dialog-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View InfoDialogWidget() {
            var result = new View().Name( "info-dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "info-dialog-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View WarningDialogWidget() {
            var result = new View().Name( "warning-dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "warning-dialog-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }
        public static View ErrorDialogWidget() {
            var result = new View().Name( "error-dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "error-dialog-widget-view" );
            return result.Parent( VisualElementScope.Current );
        }

        // Card
        public static Card Card() {
            var result = new Card().Name( "card" ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Header Header() {
            var result = new Header().Name( "header" ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Content Content() {
            var result = new Content().Name( "content" ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Footer Footer() {
            var result = new Footer().Name( "footer" ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }

        // Card
        public static Card DialogCard() {
            var result = new Card().Name( "dialog-card" ).Classes( "visual-element", "dialog-card" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Card InfoDialogCard() {
            var result = new Card().Name( "info-dialog-card" ).Classes( "visual-element", "info-dialog-card" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Card WarningDialogCard() {
            var result = new Card().Name( "warning-dialog-card" ).Classes( "visual-element", "warning-dialog-card" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Card ErrorDialogCard() {
            var result = new Card().Name( "error-dialog-card" ).Classes( "visual-element", "error-dialog-card" );
            return result.Parent( VisualElementScope.Current );
        }

        // Slot
        public static Slot Slot() {
            var result = new Slot().Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }

        // Scope
        public static ColumnScope ColumnScope() {
            var result = new ColumnScope().Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static RowScope RowScope() {
            var result = new RowScope().Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }

        // Group
        public static ColumnGroup ColumnGroup() {
            var result = new ColumnGroup().Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static RowGroup RowGroup() {
            var result = new RowGroup().Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }

        // ScrollView
        public static ScrollView ScrollView() {
            var result = new ScrollView().Classes( "visual-element" );
            result.horizontalScroller.highButton.BringToFront();
            result.verticalScroller.highButton.BringToFront();
            return result.Parent( VisualElementScope.Current );
        }

        // Box
        public static Box Box() {
            var result = new Box().Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }

        // Label
        public static Label Label(string? text) {
            var result = new Label().Text( text ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        // Button
        public static Button Button(string? text) {
            var result = new Button().Text( text ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        // Field
        public static TextField TextField(string? label, int maxLength, bool isMultiline) {
            var result = new TextField( label, maxLength, isMultiline, false, '*' ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            var result = new TextField( label, maxLength, isMultiline, false, '*' ).Classes( "visual-element" );
            result.isReadOnly = true;
            return result.Parent( VisualElementScope.Current );
        }
        public static PopupField<object?> PopupField(string? label) {
            var result = new PopupField<object?>( label ).Classes( "visual-element" );
            result.formatSelectedValueCallback = GetDisplayString;
            result.formatListItemCallback = GetDisplayString;
            return result.Parent( VisualElementScope.Current );
        }
        public static DropdownField DropdownField(string? label) {
            var result = new DropdownField( label ).Classes( "visual-element" );
            result.formatSelectedValueCallback = GetDisplayString;
            result.formatListItemCallback = GetDisplayString;
            return result.Parent( VisualElementScope.Current );
        }
        public static Slider Slider(string? label) {
            var result = new Slider( label ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static SliderInt SliderInt(string? label) {
            var result = new SliderInt( label ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }
        public static Toggle Toggle(string? label) {
            var result = new Toggle( label ).Classes( "visual-element" );
            return result.Parent( VisualElementScope.Current );
        }

    }
}
