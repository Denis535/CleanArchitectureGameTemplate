#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactory {

        public static Func<object?, string?>? StringSelector { get; set; }

        // Widget
        public static View Widget(string name) {
            var result = Create<View>( name, "widget-view" );
            return result;
        }
        public static View LeftWidget(string name) {
            var result = Create<View>( name, "left-widget-view" );
            return result;
        }
        public static View SmallWidget(string name) {
            var result = Create<View>( name, "small-widget-view" );
            return result;
        }
        public static View MediumWidget(string name) {
            var result = Create<View>( name, "medium-widget-view" );
            return result;
        }
        public static View LargeWidget(string name) {
            var result = Create<View>( name, "large-widget-view" );
            return result;
        }

        // Widget
        public static View DialogWidget() {
            var result = Create<View>( null, "dialog-widget-view" );
            return result;
        }
        public static View InfoDialogWidget() {
            var result = Create<View>( null, "info-dialog-widget-view" );
            return result;
        }
        public static View WarningDialogWidget() {
            var result = Create<View>( null, "warning-dialog-widget-view" );
            return result;
        }
        public static View ErrorDialogWidget() {
            var result = Create<View>( null, "error-dialog-widget-view" );
            return result;
        }

        // Card
        public static Card Card() {
            var result = Create<Card>( null );
            return result;
        }
        public static Header Header() {
            var result = Create<Header>( null );
            return result;
        }
        public static Content Content() {
            var result = Create<Content>( null );
            return result;
        }
        public static Footer Footer() {
            var result = Create<Footer>( null );
            return result;
        }

        // Card
        public static Card DialogCard() {
            var result = Create<Card>( null, "dialog-card" );
            return result;
        }
        public static Card InfoDialogCard() {
            var result = Create<Card>( null, "info-dialog-card" );
            return result;
        }
        public static Card WarningDialogCard() {
            var result = Create<Card>( null, "warning-dialog-card" );
            return result;
        }
        public static Card ErrorDialogCard() {
            var result = Create<Card>( null, "error-dialog-card" );
            return result;
        }

        // Slot
        public static Slot Slot() {
            var result = Create<Slot>( null );
            return result;
        }

        // Scope
        public static ColumnScope ColumnScope() {
            var result = Create<ColumnScope>( null );
            return result;
        }
        public static RowScope RowScope() {
            var result = Create<RowScope>( null );
            return result;
        }

        // Group
        public static ColumnGroup ColumnGroup() {
            var result = Create<ColumnGroup>( null );
            return result;
        }
        public static RowGroup RowGroup() {
            var result = Create<RowGroup>( null );
            return result;
        }

        // ScrollView
        public static ScrollView ScrollView() {
            var result = Create<ScrollView>( null );
            {
                result.horizontalScroller.highButton.BringToFront();
                result.verticalScroller.highButton.BringToFront();
            }
            return result;
        }

        // Box
        public static Box Box() {
            var result = Create<Box>( null );
            return result;
        }

        // Label
        public static Label Label(string? text) {
            var result = Create<Label>( null );
            {
                result.text = text;
            }
            return result;
        }
        // Button
        public static Button Button(string? text) {
            var result = Create<Button>( null );
            {
                result.text = text;
            }
            return result;
        }
        public static RepeatButton RepeatButton(string? text) {
            var result = Create<RepeatButton>( null );
            {
                result.text = text;
            }
            return result;
        }
        // Field
        public static TextField TextField(string? label, int maxLength, bool isMultiline) {
            var result = Create<TextField>( null );
            {
                result.label = label;
                result.maxLength = maxLength;
                result.multiline = isMultiline;
                result.isReadOnly = false;
            }
            return result;
        }
        public static TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            var result = Create<TextField>( null );
            {
                result.label = label;
                result.maxLength = maxLength;
                result.multiline = isMultiline;
                result.isReadOnly = true;
            }
            return result;
        }
        public static PopupField<object?> PopupField(string? label) {
            var result = Create<PopupField<object?>>( null );
            {
                result.label = label;
                result.formatSelectedValueCallback = StringSelector;
                result.formatListItemCallback = StringSelector;
            }
            return result;
        }
        public static DropdownField DropdownField(string? label) {
            var result = Create<DropdownField>( null );
            {
                result.label = label;
                result.formatSelectedValueCallback = StringSelector;
                result.formatListItemCallback = StringSelector;
            }
            return result;
        }
        public static Slider Slider(string? label) {
            var result = Create<Slider>( null );
            {
                result.label = label;
            }
            return result;
        }
        public static SliderInt SliderInt(string? label) {
            var result = Create<SliderInt>( null );
            {
                result.label = label;
            }
            return result;
        }
        public static Toggle Toggle(string? label) {
            var result = Create<Toggle>( null );
            {
                result.label = label;
            }
            return result;
        }

        // Helpers
        private static T Create<T>(string? name, string? @class = null) where T : VisualElement, new() {
            var result = new T();
            result.name = name;
            result.AddToClassList( "visual-element" );
            result.AddToClassList( @class );
            return result;
        }

    }
}
