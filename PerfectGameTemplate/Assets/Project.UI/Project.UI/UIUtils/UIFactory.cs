#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactory {

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

        // Misc
        public static Label Label(string? text, string? name = null, string? classes = null) {
            return new Label().Text( text ).Name( name, classes );
        }
        public static Button Button(string? text, string? name = null, string? classes = null) {
            return new Button().Text( text ).Name( name, classes );
        }
        public static TextField TextField(string label, int maxLength, bool multiline, string? name = null, string? classes = null) {
            return new TextField( label, maxLength, multiline, false, '*' ).Name( name, classes );
        }
        public static Slider Slider(string label, float min, float max, string? name = null, string? classes = null) {
            return new Slider( label, min, max ).Name( name, classes );
        }
        public static SliderInt SliderInt(string label, int min, int max, string? name = null, string? classes = null) {
            return new SliderInt( label, min, max ).Name( name, classes );
        }
        public static Toggle Toggle(string label, string? name = null, string? classes = null) {
            return new Toggle( label ).Name( name, classes );
        }
        public static DropdownField2 DropdownField(string label, string? name = null, string? classes = null) {
            return new DropdownField2( label ).Name( name, classes );
        }

    }
}
