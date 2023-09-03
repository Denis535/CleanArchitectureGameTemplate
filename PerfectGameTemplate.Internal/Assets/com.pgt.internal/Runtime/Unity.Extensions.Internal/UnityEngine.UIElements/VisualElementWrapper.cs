#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public abstract class VisualElementWrapper<T> where T : VisualElement {

        protected readonly T target;

        public bool IsEnabled {
            get => target.enabledSelf;
            set => target.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => target.IsDisplayed();
            set => target.SetDisplayed( value );
        }
        public bool IsValid {
            get => target.IsValid();
            set => target.SetValid( value );
        }

        public VisualElementWrapper(T target) {
            this.target = target;
        }

    }
    // Element
    public class ElementWrapper : VisualElementWrapper<VisualElement> {

        public ElementWrapper(VisualElement target) : base( target ) {
        }

        public override string ToString() {
            return "{0}".Format( GetType().Name );
        }

        [return: NotNullIfNotNull( nameof( target ) )]
        public static implicit operator ElementWrapper?(VisualElement? target) {
            if (target != null) return new ElementWrapper( target );
            return null;
        }

    }
    // Text
    public class TextWrapper : VisualElementWrapper<TextElement> {

        public string? Text {
            get => target.text;
            set => target.text = value;
        }

        public TextWrapper(TextElement target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Text={1} }".Format( GetType().Name, target.text?.ToString() ?? "Null" );
        }

        [return: NotNullIfNotNull( nameof( target ) )]
        public static implicit operator TextWrapper?(TextElement? target) {
            if (target != null) return new TextWrapper( target );
            return null;
        }

    }
    // Value
    public class ValueWrapper<T> : VisualElementWrapper<BaseField<T>> {

        public T Value {
            get => target.value;
            set => target.value = value;
        }

        public ValueWrapper(BaseField<T> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

        [return: NotNullIfNotNull( nameof( target ) )]
        public static implicit operator ValueWrapper<T>?(BaseField<T>? target) {
            if (target != null) return new ValueWrapper<T>( target );
            return null;
        }

    }
    // Value/MinMax
    public class ValueMinMaxWrapper<T> : VisualElementWrapper<BaseSlider<T>> where T : IComparable<T> {

        public T Value {
            get => target.value;
            set => target.value = value;
        }
        public T Min {
            get => target.lowValue;
            set => target.lowValue = value;
        }
        public T Max {
            get => target.highValue;
            set => target.highValue = value;
        }
        public (T Value, T Min, T Max) ValueMinMax {
            get => (target.value, target.lowValue, target.highValue);
            set => (target.value, target.lowValue, target.highValue) = (value.Value, value.Min, value.Max);
        }

        public ValueMinMaxWrapper(BaseSlider<T> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

        [return: NotNullIfNotNull( nameof( target ) )]
        public static implicit operator ValueMinMaxWrapper<T>?(BaseSlider<T>? target) {
            if (target != null) return new ValueMinMaxWrapper<T>( target );
            return null;
        }

    }
    // Value/Choices
    public class ValueChoicesWrapper<T> : VisualElementWrapper<PopupField<T>> {

        public T Value {
            get => target.value;
            set => target.value = value;
        }
        public T[] Choices {
            get => target.choices.ToArray();
            set => target.choices = value.ToList();
        }
        public (T Value, T[] Choices) ValueChoices {
            get => (target.value, target.choices.ToArray());
            set => (target.value, target.choices) = (value.Value, value.Choices.ToList());
        }

        public ValueChoicesWrapper(PopupField<T> target) : base( target ) {
        }

        public ValueChoicesWrapper2<TAs, T> As<TAs>() {
            return new ValueChoicesWrapper2<TAs, T>( target );
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

        [return: NotNullIfNotNull( nameof( target ) )]
        public static implicit operator ValueChoicesWrapper<T>?(PopupField<T>? target) {
            if (target != null) return new ValueChoicesWrapper<T>( target );
            return null;
        }

    }
    // Value/Choices
    public class ValueChoicesWrapper2<T, TSource> : VisualElementWrapper<PopupField<TSource>> {

        public T Value {
            get => (T) (object?) target.value!;
            set => target.value = (TSource) (object?) value!;
        }
        public T[] Choices {
            get => target.choices.Cast<T>().ToArray();
            set => target.choices = value.Cast<TSource>().ToList();
        }
        public (T Value, T[] Choices) ValueChoices {
            get => (Value, Choices);
            set => (Value, Choices) = (value.Value, value.Choices);
        }

        internal ValueChoicesWrapper2(PopupField<TSource> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

        [return: NotNullIfNotNull( nameof( target ) )]
        public static implicit operator ValueChoicesWrapper2<T, TSource>?(PopupField<TSource> target) {
            if (target != null) return new ValueChoicesWrapper2<T, TSource>( target );
            return null;
        }

    }
}
