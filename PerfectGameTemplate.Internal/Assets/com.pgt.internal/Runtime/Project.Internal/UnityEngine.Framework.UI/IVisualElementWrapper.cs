#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.UIElements;

    public interface IVisualElementWrapper<T> where T : VisualElement {

        public T VisualElement { get; }
        public bool IsEnabled { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsValid { get; set; }

    }
    public static class IVisualElementWrapperExtensions {

        // Wrap
        public static ElementWrapper Wrap(this VisualElement visualElement) {
            return new ElementWrapper( visualElement );
        }
        public static TextWrapper Wrap(this TextElement visualElement) {
            return new TextWrapper( visualElement );
        }
        public static FieldWrapper<T> Wrap<T>(this BaseField<T?> visualElement) where T : notnull {
            return new FieldWrapper<T>( visualElement );
        }
        public static SliderWrapper<T> Wrap<T>(this BaseSlider<T> visualElement) where T : struct, IComparable<T> {
            return new SliderWrapper<T>( visualElement );
        }
        public static PopupWrapper<T> Wrap<T>(this PopupField<T?> visualElement) where T : notnull {
            return new PopupWrapper<T>( visualElement );
        }
        public static SlotWrapper Wrap(this Slot visualElement) {
            return new SlotWrapper( visualElement );
        }

        // As
        public static PopupWrapper2<T> As<T>(this PopupWrapper<object> wrapper) where T : notnull {
            return new PopupWrapper2<T>( wrapper.VisualElement );
        }

    }
    // Element
    public struct ElementWrapper : IVisualElementWrapper<VisualElement> {

        public VisualElement VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public ElementWrapper(VisualElement visualElement) {
            VisualElement = visualElement;
        }

    }
    // Text
    public struct TextWrapper : IVisualElementWrapper<TextElement> {

        public TextElement VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public string? Text {
            get => VisualElement.text;
            set => VisualElement.text = value;
        }

        public TextWrapper(TextElement visualElement) {
            VisualElement = visualElement;
        }

    }
    // Field
    public struct FieldWrapper<T> : IVisualElementWrapper<BaseField<T?>> where T : notnull {

        public BaseField<T?> VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public T? Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }

        public FieldWrapper(BaseField<T?> visualElement) {
            VisualElement = visualElement;
        }

    }
    // Slider
    public struct SliderWrapper<T> : IVisualElementWrapper<BaseSlider<T>> where T : struct, IComparable<T> {

        public BaseSlider<T> VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public T Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }
        public T Min {
            get => VisualElement.lowValue;
            set => VisualElement.lowValue = value;
        }
        public T Max {
            get => VisualElement.highValue;
            set => VisualElement.highValue = value;
        }
        public (T Value, T Min, T Max) ValueMinMax {
            get => (VisualElement.value, VisualElement.lowValue, VisualElement.highValue);
            set => (VisualElement.value, VisualElement.lowValue, VisualElement.highValue) = (value.Value, value.Min, value.Max);
        }

        public SliderWrapper(BaseSlider<T> visualElement) {
            VisualElement = visualElement;
        }

    }
    // Popup
    public struct PopupWrapper<T> : IVisualElementWrapper<PopupField<T?>> where T : notnull {

        public PopupField<T?> VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public T? Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }
        public T?[] Choices {
            get => VisualElement.choices.ToArray();
            set => VisualElement.choices = value.ToList();
        }
        public (T? Value, T?[] Choices) ValueChoices {
            get => (VisualElement.value, VisualElement.choices.ToArray());
            set => (VisualElement.value, VisualElement.choices) = (value.Value, value.Choices.ToList());
        }

        public PopupWrapper(PopupField<T?> visualElement) {
            VisualElement = visualElement;
        }

    }
    // Popup
    public struct PopupWrapper2<T> : IVisualElementWrapper<PopupField<object?>> {

        public PopupField<object?> VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public T? Value {
            get => (T?) VisualElement.value;
            set => VisualElement.value = value;
        }
        public T?[] Choices {
            get => VisualElement.choices.Cast<T>().ToArray();
            set => VisualElement.choices = value.Cast<object?>().ToList();
        }
        public (T? Value, T?[] Choices) ValueChoices {
            get => (Value, Choices);
            set => (Value, Choices) = (value.Value, value.Choices);
        }

        public PopupWrapper2(PopupField<object?> visualElement) {
            VisualElement = visualElement;
        }

    }
    // Slot
    public struct SlotWrapper : IVisualElementWrapper<VisualElement> {

        public VisualElement VisualElement { get; }

        public bool IsEnabled {
            get => VisualElement.enabledSelf;
            set => VisualElement.SetEnabled( value );
        }
        public bool IsDisplayed {
            get => VisualElement.IsDisplayed();
            set => VisualElement.SetDisplayed( value );
        }
        public bool IsValid {
            get => VisualElement.IsValid();
            set => VisualElement.SetValid( value );
        }

        public IReadOnlyList<VisualElement> Elements => (IReadOnlyList<VisualElement>) VisualElement.Children();

        public SlotWrapper(VisualElement visualElement) {
            VisualElement = visualElement;
        }

        public void Add(VisualElement element) {
            VisualElement.Add( element );
        }
        public void Remove(VisualElement element) {
            VisualElement.Remove( element );
        }
        public bool Contains(VisualElement element) {
            return VisualElement.Contains( element );
        }

    }
}
