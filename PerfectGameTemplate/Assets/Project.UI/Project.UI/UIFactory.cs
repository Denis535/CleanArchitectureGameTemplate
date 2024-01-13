#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class UIFactory : MonoBehaviour {

        public static Func<object?, string?>? StringSelector { get; set; }

        // Widget
        public View Widget(string name) {
            var result = Create<View>( name, "widget-view" );
            return result;
        }
        public View LeftWidget(string name) {
            var result = Create<View>( name, "left-widget-view" );
            return result;
        }
        public View SmallWidget(string name) {
            var result = Create<View>( name, "small-widget-view" );
            return result;
        }
        public View MediumWidget(string name) {
            var result = Create<View>( name, "medium-widget-view" );
            return result;
        }
        public View LargeWidget(string name) {
            var result = Create<View>( name, "large-widget-view" );
            return result;
        }

        // Widget
        public View DialogWidget() {
            var result = Create<View>( null, "dialog-widget-view" );
            return result;
        }
        public View InfoDialogWidget() {
            var result = Create<View>( null, "info-dialog-widget-view" );
            return result;
        }
        public View WarningDialogWidget() {
            var result = Create<View>( null, "warning-dialog-widget-view" );
            return result;
        }
        public View ErrorDialogWidget() {
            var result = Create<View>( null, "error-dialog-widget-view" );
            return result;
        }

        // Card
        public Card Card() {
            var result = Create<Card>( null );
            return result;
        }
        public Header Header() {
            var result = Create<Header>( null );
            return result;
        }
        public Content Content() {
            var result = Create<Content>( null );
            return result;
        }
        public Footer Footer() {
            var result = Create<Footer>( null );
            return result;
        }

        // Card
        public Card DialogCard() {
            var result = Create<Card>( null, "dialog-card" );
            return result;
        }
        public Card InfoDialogCard() {
            var result = Create<Card>( null, "info-dialog-card" );
            return result;
        }
        public Card WarningDialogCard() {
            var result = Create<Card>( null, "warning-dialog-card" );
            return result;
        }
        public Card ErrorDialogCard() {
            var result = Create<Card>( null, "error-dialog-card" );
            return result;
        }

        // Slot
        public Slot Slot() {
            var result = Create<Slot>( null );
            return result;
        }

        // Scope
        public ColumnScope ColumnScope() {
            var result = Create<ColumnScope>( null );
            return result;
        }
        public RowScope RowScope() {
            var result = Create<RowScope>( null );
            return result;
        }

        // Group
        public ColumnGroup ColumnGroup() {
            var result = Create<ColumnGroup>( null );
            return result;
        }
        public RowGroup RowGroup() {
            var result = Create<RowGroup>( null );
            return result;
        }

        // ScrollView
        public ScrollView ScrollView() {
            var result = Create<ScrollView>( null );
            {
                result.horizontalScroller.highButton.BringToFront();
                result.verticalScroller.highButton.BringToFront();
            }
            return result;
        }

        // Box
        public Box Box() {
            var result = Create<Box>( null );
            return result;
        }

        // Label
        public Label Label(string? text) {
            var result = Create<Label>( null );
            {
                result.text = text;
            }
            return result;
        }
        // Button
        public Button Button(string? text) {
            var result = Create<Button>( null );
            {
                result.text = text;
            }
            return result;
        }
        public RepeatButton RepeatButton(string? text) {
            var result = Create<RepeatButton>( null );
            {
                result.text = text;
            }
            return result;
        }
        // Field
        public TextField TextField(string? label, int maxLength, bool isMultiline) {
            var result = Create<TextField>( null );
            {
                result.label = label;
                result.maxLength = maxLength;
                result.multiline = isMultiline;
                result.isReadOnly = false;
            }
            return result;
        }
        public TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            var result = Create<TextField>( null );
            {
                result.label = label;
                result.maxLength = maxLength;
                result.multiline = isMultiline;
                result.isReadOnly = true;
            }
            return result;
        }
        public PopupField<object?> PopupField(string? label) {
            var result = Create<PopupField<object?>>( null );
            {
                result.label = label;
                result.formatSelectedValueCallback = StringSelector;
                result.formatListItemCallback = StringSelector;
            }
            return result;
        }
        public DropdownField DropdownField(string? label) {
            var result = Create<DropdownField>( null );
            {
                result.label = label;
                result.formatSelectedValueCallback = StringSelector;
                result.formatListItemCallback = StringSelector;
            }
            return result;
        }
        public Slider Slider(string? label) {
            var result = Create<Slider>( null );
            {
                result.label = label;
            }
            return result;
        }
        public SliderInt SliderInt(string? label) {
            var result = Create<SliderInt>( null );
            {
                result.label = label;
            }
            return result;
        }
        public Toggle Toggle(string? label) {
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
