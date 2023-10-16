#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.UIElements;

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
        public static TextWrapper Wrap(this TextElement target) {
            return new TextWrapper( target );
        }
        public static FieldWrapper<T> Wrap<T>(this BaseField<T?> target) where T : notnull {
            return new FieldWrapper<T>( target );
        }
        public static SliderWrapper<T> Wrap<T>(this BaseSlider<T?> target) where T : notnull, IComparable<T?> {
            return new SliderWrapper<T>( target );
        }
        public static PopupWrapper<T> Wrap<T>(this PopupField<T?> target) where T : notnull {
            return new PopupWrapper<T>( target );
        }
        public static SlotWrapper Wrap(this Slot target) {
            return new SlotWrapper( target );
        }

        // As
        public static PopupWrapper2<T> As<T>(this PopupWrapper<object> wrapper) where T : notnull {
            return new PopupWrapper2<T>( wrapper.target );
        }

    }
    // Element
    public class ElementWrapper : VisualElementWrapper<VisualElement> {

        public ElementWrapper(VisualElement target) : base( target ) {
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

    }
    // Field
    public class FieldWrapper<T> : VisualElementWrapper<BaseField<T?>> where T : notnull {

        public T? Value {
            get => target.value;
            set => target.value = value;
        }

        public FieldWrapper(BaseField<T?> target) : base( target ) {
        }

    }
    // Slider
    public class SliderWrapper<T> : VisualElementWrapper<BaseSlider<T?>> where T : notnull, IComparable<T?> {

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

        public SliderWrapper(BaseSlider<T?> target) : base( target ) {
        }

    }
    // Popup
    public class PopupWrapper<T> : VisualElementWrapper<PopupField<T?>> where T : notnull {

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

        public PopupWrapper(PopupField<T?> target) : base( target ) {
        }

    }
    // Popup
    public class PopupWrapper2<T> : VisualElementWrapper<PopupField<object?>> where T : notnull {

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

        internal PopupWrapper2(PopupField<object?> target) : base( target ) {
        }

    }
    // Slot
    public class SlotWrapper : VisualElementWrapper<VisualElement> {

        public IReadOnlyList<VisualElement> Elements => (IReadOnlyList<VisualElement>) target.Children();

        public SlotWrapper(VisualElement target) : base( target ) {
        }

        public void Add(VisualElement element) {
            target.Add( element );
        }
        public void Remove(VisualElement element) {
            target.Remove( element );
        }
        public bool Contains(VisualElement element) {
            return target.Contains( element );
        }

    }
}
