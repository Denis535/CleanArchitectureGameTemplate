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

        // Widget
        public static View Widget(string name) {
            return new View().Name( name ).Classes( "visual-element", "widget-view" );
        }
        public static View LeftWidget(string name) {
            return new View().Name( name ).Classes( "visual-element", "left-widget-view" );
        }
        public static View SmallWidget(string name) {
            return new View().Name( name ).Classes( "visual-element", "small-widget-view" );
        }
        public static View MediumWidget(string name) {
            return new View().Name( name ).Classes( "visual-element", "medium-widget-view" );
        }
        public static View LargeWidget(string name) {
            return new View().Name( name ).Classes( "visual-element", "large-widget-view" );
        }

        // Widget
        public static View DialogWidget() {
            return new View().Name( "dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "dialog-widget-view" );
        }
        public static View InfoDialogWidget() {
            return new View().Name( "info-dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "info-dialog-widget-view" );
        }
        public static View WarningDialogWidget() {
            return new View().Name( "warning-dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "warning-dialog-widget-view" );
        }
        public static View ErrorDialogWidget() {
            return new View().Name( "error-dialog-widget-view" ).Classes( "visual-element", "modal-widget-view", "error-dialog-widget-view" );
        }

        // Card
        public static Card Card(this View view) {
            var card = Card();
            view.Add( card );
            return card;
        }
        public static Card DialogCard(this View view) {
            var card = DialogCard();
            view.Add( card );
            return card;
        }
        public static Card InfoDialogCard(this View view) {
            var card = InfoDialogCard();
            view.Add( card );
            return card;
        }
        public static Card WarningDialogCard(this View view) {
            var card = WarningDialogCard();
            view.Add( card );
            return card;
        }
        public static Card ErrorDialogCard(this View view) {
            var card = ErrorDialogCard();
            view.Add( card );
            return card;
        }
        // Card
        private static Card Card() {
            return new Card().Name( "card" ).Classes( "visual-element" );
        }
        private static Card DialogCard() {
            return new Card().Name( "dialog-card" ).Classes( "visual-element", "dialog-card" );
        }
        private static Card InfoDialogCard() {
            return new Card().Name( "info-dialog-card" ).Classes( "visual-element", "info-dialog-card" );
        }
        private static Card WarningDialogCard() {
            return new Card().Name( "warning-dialog-card" ).Classes( "visual-element", "warning-dialog-card" );
        }
        private static Card ErrorDialogCard() {
            return new Card().Name( "error-dialog-card" ).Classes( "visual-element", "error-dialog-card" );
        }

        // Card
        public static Header Header(this View view, params VisualElement[] children) {
            var card = (Card) view.Children().First();
            var header = Header().Children( children );
            card.Add( header );
            return header;
        }
        public static Content Content(this View view, params VisualElement[] children) {
            var card = (Card) view.Children().First();
            var content = Content().Children( children );
            card.Add( content );
            return content;
        }
        public static Footer Footer(this View view, params VisualElement[] children) {
            var card = (Card) view.Children().First();
            var footer = Footer().Children( children );
            card.Add( footer );
            return footer;
        }
        // Card
        private static Header Header() {
            return new Header().Name( "header" ).Classes( "visual-element" );
        }
        private static Content Content() {
            return new Content().Name( "content" ).Classes( "visual-element" );
        }
        private static Footer Footer() {
            return new Footer().Name( "footer" ).Classes( "visual-element" );
        }

        // Slot
        public static Slot Slot() {
            return new Slot().Classes( "visual-element" );
        }

        // Scope
        public static ColumnScope ColumnScope() {
            return new ColumnScope().Classes( "visual-element" );
        }
        public static RowScope RowScope() {
            return new RowScope().Classes( "visual-element" );
        }

        // Group
        public static ColumnGroup ColumnGroup() {
            return new ColumnGroup().Classes( "visual-element" );
        }
        public static RowGroup RowGroup() {
            return new RowGroup().Classes( "visual-element" );
        }

        // ScrollView
        public static ScrollView ScrollView() {
            var view = new ScrollView().Classes( "visual-element" );
            view.horizontalScroller.highButton.BringToFront();
            view.verticalScroller.highButton.BringToFront();
            return view;
        }

        // Box
        public static Box Box() {
            return new Box().Classes( "visual-element" );
        }

        // Label
        public static Label Label(string? text) {
            return new Label().Text( text ).Classes( "visual-element" );
        }
        // Button
        public static Button Button(string? text) {
            return new Button().Text( text ).Classes( "visual-element" );
        }
        // Field
        public static TextField TextField(string? label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' ).Classes( "visual-element" );
        }
        public static TextField TextFieldReadOnly(string? label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' ).Classes( "visual-element" ).Pipe( i => i.isReadOnly = true );
        }
        public static PopupField<object?> PopupField(string? label) {
            return new PopupField<object?>( label ).Classes( "visual-element" ).Pipe( i => i.formatSelectedValueCallback = GetDisplayString ).Pipe( i => i.formatListItemCallback = GetDisplayString );
        }
        public static DropdownField DropdownField(string? label) {
            return new DropdownField( label ).Classes( "visual-element" ).Pipe( i => i.formatSelectedValueCallback = GetDisplayString ).Pipe( i => i.formatListItemCallback = GetDisplayString );
        }
        public static Slider Slider(string? label) {
            return new Slider( label ).Classes( "visual-element" );
        }
        public static SliderInt SliderInt(string? label) {
            return new SliderInt( label ).Classes( "visual-element" );
        }
        public static Toggle Toggle(string? label) {
            return new Toggle( label ).Classes( "visual-element" );
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
