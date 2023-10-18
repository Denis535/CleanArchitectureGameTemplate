#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactory {

        // Element
        public static Label Label(string? text) {
            return new Label().Text( text );
        }
        public static Button Button(string? text) {
            return new Button().Text( text );
        }
        public static TextField TextField(string? label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' );
        }
        public static TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' ).Pipe( i => i.isReadOnly = true );
        }
        public static PopupField<object?> PopupField(string? label, params object?[] choices) {
            return new PopupField<object?>( label ).Pipe( i => i.choices = choices.ToList() ).Pipe( i => i.formatSelectedValueCallback = GetDisplayString ).Pipe( i => i.formatListItemCallback = GetDisplayString );
        }
        public static PopupField<T> PopupField<T>(string? label, params T[] choices) {
            return new PopupField<T>( label ).Pipe( i => i.choices = choices.ToList() ).Pipe( i => i.formatSelectedValueCallback = GetDisplayString ).Pipe( i => i.formatListItemCallback = GetDisplayString );
        }
        public static Slider Slider(string? label, float min, float max) {
            return new Slider( label, min, max );
        }
        public static SliderInt SliderInt(string? label, int min, int max) {
            return new SliderInt( label, min, max );
        }
        public static Toggle Toggle(string? label) {
            return new Toggle( label );
        }

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
        public static Header Header() {
            return new Header().Name( "header" );
        }
        public static Content Content() {
            return new Content().Name( "content" );
        }
        public static Footer Footer() {
            return new Footer().Name( "footer" );
        }

        // Scope
        public static ColumnScope ColumnScope() {
            return new ColumnScope();
        }
        public static RowScope RowScope() {
            return new RowScope();
        }

        // Group
        public static ColumnGroup ColumnGroup() {
            return new ColumnGroup();
        }
        public static RowGroup RowGroup() {
            return new RowGroup();
        }

        // Box
        public static Box Box() {
            return new Box();
        }

        // Slot
        public static Slot Slot() {
            return new Slot();
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
