#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
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
        public static Slider Slider(string? label, float min, float max) {
            return new Slider( label, min, max );
        }
        public static SliderInt SliderInt(string? label, int min, int max) {
            return new SliderInt( label, min, max );
        }
        public static Toggle Toggle(string? label) {
            return new Toggle( label );
        }
        public static DropdownField2<object?> DropdownField(string? label) {
            return new DropdownField2<object?>( label );
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

    }
}
