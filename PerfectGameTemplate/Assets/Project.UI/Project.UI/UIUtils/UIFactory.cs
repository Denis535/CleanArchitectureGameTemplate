#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactory {

        // Widget
        public static View Widget(Action<View> callback, params VisualElement[] children) {
            return new View().Name( "widget-view" ).Classes( "widget-view" ).Pipe( callback ).Children( children );
        }
        public static View LeftWidget(Action<View> callback, params VisualElement[] children) {
            return new View().Name( "left-widget-view" ).Classes( "left-widget-view" ).Pipe( callback ).Children( children );
        }
        public static View SmallWidget(Action<View> callback, params VisualElement[] children) {
            return new View().Name( "small-widget-view" ).Classes( "small-widget-view" ).Pipe( callback ).Children( children );
        }
        public static View MediumWidget(Action<View> callback, params VisualElement[] children) {
            return new View().Name( "medium-widget-view" ).Classes( "medium-widget-view" ).Pipe( callback ).Children( children );
        }
        public static View LargeWidget(Action<View> callback, params VisualElement[] children) {
            return new View().Name( "large-widget-view" ).Classes( "large-widget-view" ).Pipe( callback ).Children( children );
        }
        public static View ModalWidget(Action<View> callback, params VisualElement[] children) {
            return new View().Name( "modal-widget-view" ).Classes( "modal-widget-view" ).Pipe( callback ).Children( children );
        }

        // Card
        public static Card Card(Header? header, Content? content, Footer? footer) {
            return new Card().Children( header, content, footer );
        }
        public static Header Header(params VisualElement[] children) {
            return new Header().Children( children );
        }
        public static Content Content(params VisualElement[] children) {
            return new Content().Children( children );
        }
        public static Footer Footer(params VisualElement[] children) {
            return new Footer().Children( children );
        }
        // Card
        public static Card Card(Action<Card> callback, Header? header, Content? content, Footer? footer) {
            return new Card().Pipe( callback ).Children( header, content, footer );
        }
        public static Header Header(Action<Header> callback, params VisualElement[] children) {
            return new Header().Pipe( callback ).Children( children );
        }
        public static Content Content(Action<Content> callback, params VisualElement[] children) {
            return new Content().Pipe( callback ).Children( children );
        }
        public static Footer Footer(Action<Footer> callback, params VisualElement[] children) {
            return new Footer().Pipe( callback ).Children( children );
        }

        // Scope
        public static ColumnScope ColumnScope(params VisualElement[] children) {
            return new ColumnScope().Children( children );
        }
        public static RowScope RowScope(params VisualElement[] children) {
            return new RowScope().Children( children );
        }
        // Scope
        public static ColumnScope ColumnScope(Action<ColumnScope> callback, params VisualElement[] children) {
            return new ColumnScope().Pipe( callback ).Children( children );
        }
        public static RowScope RowScope(Action<RowScope> callback, params VisualElement[] children) {
            return new RowScope().Pipe( callback ).Children( children );
        }

        // Group
        public static ColumnGroup ColumnGroup(params VisualElement[] children) {
            return new ColumnGroup().Children( children );
        }
        public static RowGroup RowGroup(params VisualElement[] children) {
            return new RowGroup().Children( children );
        }
        // Group
        public static ColumnGroup ColumnGroup(Action<ColumnGroup> callback, params VisualElement[] children) {
            return new ColumnGroup().Pipe( callback ).Children( children );
        }
        public static RowGroup RowGroup(Action<RowGroup> callback, params VisualElement[] children) {
            return new RowGroup().Pipe( callback ).Children( children );
        }

        // Box
        public static Box Box(params VisualElement[] children) {
            return new Box().Children( children );
        }
        // Box
        public static Box Box(Action<Box> callback, params VisualElement[] children) {
            return new Box().Pipe( callback ).Children( children );
        }

        // Misc
        public static Label Label(string? text) {
            return new Label().Text( text );
        }
        public static Button Button(string? text) {
            return new Button().Text( text );
        }
        public static TextField TextField(string label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' );
        }
        public static TextField TextFieldReadOnly(string label, int maxLength, bool isMultiline) {
            return new TextField( label, maxLength, isMultiline, false, '*' ).Pipe( i => i.isReadOnly = true );
        }
        public static Slider Slider(string label, float min, float max) {
            return new Slider( label, min, max );
        }
        public static SliderInt SliderInt(string label, int min, int max) {
            return new SliderInt( label, min, max );
        }
        public static Toggle Toggle(string label) {
            return new Toggle( label );
        }
        public static DropdownField2 DropdownField(string label) {
            return new DropdownField2( label );
        }

    }
}
