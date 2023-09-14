#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class VisualElementWrapper<T> where T : VisualElement {

        internal readonly T target;

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
    public static class VisualElementWrapperExtensions {

        // Wrap
        public static ElementWrapper Wrap(this VisualElement target) {
            return new ElementWrapper( target );
        }
        public static TextElementWrapper Wrap(this TextElement target) {
            return new TextElementWrapper( target );
        }
        public static FieldWrapper<T> Wrap<T>(this BaseField<T?> target) where T : notnull {
            return new FieldWrapper<T>( target );
        }
        public static SliderFieldWrapper<T> Wrap<T>(this BaseSlider<T?> target) where T : notnull, IComparable<T?> {
            return new SliderFieldWrapper<T>( target );
        }
        public static PopupFieldWrapper<T> Wrap<T>(this PopupField<T?> target) where T : notnull {
            return new PopupFieldWrapper<T>( target );
        }
        public static PopupFieldWrapper2<T> Wrap<T>(this PopupField<object?> target) where T : notnull {
            return new PopupFieldWrapper2<T>( target );
        }

        // As
        public static PopupFieldWrapper2<T> As<T>(this PopupFieldWrapper<object> wrapper) where T : notnull {
            return new PopupFieldWrapper2<T>( wrapper.target );
        }

    }
    // Element
    public class ElementWrapper : VisualElementWrapper<VisualElement> {

        public ElementWrapper(VisualElement target) : base( target ) {
        }

        public override string ToString() {
            return "{0}".Format( GetType().Name );
        }

    }
    // TextElement
    public class TextElementWrapper : VisualElementWrapper<TextElement> {

        public string? Text {
            get => target.text;
            set => target.text = value;
        }

        public TextElementWrapper(TextElement target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Text={1} }".Format( GetType().Name, target.text?.ToString() ?? "Null" );
        }

    }
    // Field
    public class FieldWrapper<T> : VisualElementWrapper<BaseField<T?>> where T : notnull {

        public T? Value {
            get => target.value;
            set => target.value = value;
        }

        public FieldWrapper(BaseField<T?> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

    }
    // SliderField
    public class SliderFieldWrapper<T> : VisualElementWrapper<BaseSlider<T?>> where T : notnull, IComparable<T?> {

        public T? Value {
            get => target.value;
            set => target.value = value;
        }
        public T? Min {
            get => target.lowValue;
            set => target.lowValue = value;
        }
        public T? Max {
            get => target.highValue;
            set => target.highValue = value;
        }
        public (T? Value, T? Min, T? Max) ValueMinMax {
            get => (target.value, target.lowValue, target.highValue);
            set => (target.value, target.lowValue, target.highValue) = (value.Value, value.Min, value.Max);
        }

        public SliderFieldWrapper(BaseSlider<T?> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

    }
    // PopupField
    public class PopupFieldWrapper<T> : VisualElementWrapper<PopupField<T?>> where T : notnull {

        public T? Value {
            get => target.value;
            set => target.value = value;
        }
        public T?[] Choices {
            get => target.choices.ToArray();
            set => target.choices = value.ToList();
        }
        public (T? Value, T?[] Choices) ValueChoices {
            get => (target.value, target.choices.ToArray());
            set => (target.value, target.choices) = (value.Value, value.Choices.ToList());
        }

        public PopupFieldWrapper(PopupField<T?> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

    }
    // PopupField
    public class PopupFieldWrapper2<T> : VisualElementWrapper<PopupField<object?>> where T : notnull {

        public T? Value {
            get => (T?) target.value;
            set => target.value = value;
        }
        public T?[] Choices {
            get => target.choices.Cast<T>().ToArray();
            set => target.choices = value.Cast<object?>().ToList();
        }
        public (T? Value, T?[] Choices) ValueChoices {
            get => (Value, Choices);
            set => (Value, Choices) = (value.Value, value.Choices);
        }

        internal PopupFieldWrapper2(PopupField<object?> target) : base( target ) {
        }

        public override string ToString() {
            return "{0}: { Value={1} }".Format( GetType().Name, target.value?.ToString() ?? "Null" );
        }

    }
}
