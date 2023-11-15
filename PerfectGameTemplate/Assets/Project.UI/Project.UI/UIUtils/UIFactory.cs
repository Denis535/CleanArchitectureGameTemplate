#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactory {

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

        // Helpers/GetDisplayString
        private static string GetDisplayString<T>(T value) {
            // GameDesc
            if (value is GameMode gameMode) return GetDisplayString( gameMode );
            if (value is GameWorld gameWorld) return GetDisplayString( gameWorld );
            // PlayerDesc
            if (value is PlayerRole playerRole) return GetDisplayString( playerRole );
            // Misc
            if (value is Resolution resolution) return GetDisplayString( resolution );
            return value?.ToString() ?? "Null";
        }
        // Helpers/GetDisplayString/GameDesc
        private static string GetDisplayString(GameMode value) {
            return value switch {
                // 1x...
                GameMode._1x1 => "1 x 1",
                GameMode._1x2 => "1 x 2",
                GameMode._1x3 => "1 x 3",
                GameMode._1x4 => "1 x 4",
                // 2x
                GameMode._2x1 => "2 x 1",
                GameMode._2x2 => "2 x 2",
                GameMode._2x3 => "2 x 3",
                GameMode._2x4 => "2 x 4",
                // 3x
                GameMode._3x1 => "3 x 1",
                GameMode._3x2 => "3 x 2",
                GameMode._3x3 => "3 x 3",
                GameMode._3x4 => "3 x 4",
                // 4x
                GameMode._4x1 => "4 x 1",
                GameMode._4x2 => "4 x 2",
                GameMode._4x3 => "4 x 3",
                GameMode._4x4 => "4 x 4",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} not supported" ),
            };
        }
        private static string GetDisplayString(GameWorld value) {
            return value switch {
                GameWorld.TestWorld1 => "Test World 1",
                GameWorld.TestWorld2 => "Test World 2",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} not supported" ),
            };
        }
        // Helpers/GetDisplayString/PlayerDesc
        private static string GetDisplayString(PlayerRole value) {
            return value switch {
                PlayerRole.Human => "Human",
                PlayerRole.Monster => "Monster",
                _ => throw Exceptions.Internal.NotSupported( $"Value {value} not supported" ),
            };
        }
        // Helpers/GetDisplayString/Misc
        private static string GetDisplayString(Resolution value) {
            return $"{value.width} x {value.height}";
        }

    }
}
