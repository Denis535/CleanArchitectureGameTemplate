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
            return new View().Name( name ).Classes( "widget-view" );
        }
        public static View LeftWidget(string name) {
            return new View().Name( name ).Classes( "left-widget-view" );
        }
        public static View SmallWidget(string name) {
            return new View().Name( name ).Classes( "small-widget-view" );
        }
        public static View MediumWidget(string name) {
            return new View().Name( name ).Classes( "medium-widget-view" );
        }
        public static View LargeWidget(string name) {
            return new View().Name( name ).Classes( "large-widget-view" );
        }
        public static View ModalWidget(string name) {
            return new View().Name( name ).Classes( "modal-widget-view" );
        }

        // Card
        public static Card Card() {
            return new Card().Name( "card" );
        }
        public static Header Header() {
            return new Header().Name( "header" );
        }
        public static Content Content() {
            return new Content().Name( "content" );
        }
        public static Footer Footer() {
            return new Footer().Name( "footer" );
        }

        // Card
        public static Card DialogCard() {
            return new Card().Name( "dialog-card" ).Classes( "dialog-card" );
        }
        public static Card InfoDialogCard() {
            return new Card().Name( "info-dialog-card" ).Classes( "info-dialog-card" );
        }
        public static Card WarningDialogCard() {
            return new Card().Name( "warning-dialog-card" ).Classes( "warning-dialog-card" );
        }
        public static Card ErrorDialogCard() {
            return new Card().Name( "error-dialog-card" ).Classes( "error-dialog-card" );
        }

        // Slot
        public static Slot Slot(string? name = null) {
            return new Slot().Name( name );
        }

        // Scope
        public static ColumnScope ColumnScope(string? name = null) {
            return new ColumnScope().Name( name );
        }
        public static RowScope RowScope(string? name = null) {
            return new RowScope().Name( name );
        }

        // Group
        public static ColumnGroup ColumnGroup(string? name = null) {
            return new ColumnGroup().Name( name );
        }
        public static RowGroup RowGroup(string? name = null) {
            return new RowGroup().Name( name );
        }

        // ScrollView
        public static ScrollView ScrollView(string? name = null) {
            var view = new ScrollView().Name( name );
            view.horizontalScroller.highButton.BringToFront();
            view.verticalScroller.highButton.BringToFront();
            return view;
        }

        // Box
        public static Box Box(string? name = null) {
            return new Box().Name( name );
        }

        // Label
        public static Label Label(string? text) {
            return new Label().Text( text );
        }

        // Button
        public static Button Button(string? text) {
            return new Button().Text( text );
        }

        // Field
        public static TextField TextField(string? label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' );
        }
        public static TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' ).Pipe( i => i.isReadOnly = true );
        }
        public static PopupField<object?> PopupField(string? label) {
            return new PopupField<object?>( label ).Pipe( i => i.formatSelectedValueCallback = GetDisplayString ).Pipe( i => i.formatListItemCallback = GetDisplayString );
        }
        public static DropdownField DropdownField(string? label) {
            return new DropdownField( label ).Pipe( i => i.formatSelectedValueCallback = GetDisplayString ).Pipe( i => i.formatListItemCallback = GetDisplayString );
        }
        public static Slider Slider(string? label) {
            return new Slider( label );
        }
        public static SliderInt SliderInt(string? label) {
            return new SliderInt( label );
        }
        public static Toggle Toggle(string? label) {
            return new Toggle( label );
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
