#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    // todo: when compiler will be updated then make all wrappers readonly structures
    public abstract class VisualElementWrapper<T> where T : VisualElement {

        protected T VisualElement { get; }

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

        public VisualElementWrapper(T visualElement) {
            VisualElement = visualElement;
        }

    }
    public static class VisualElementWrapperExtensions {

        // Element
        public static ElementWrapper Wrap(this VisualElement element) {
            return new ElementWrapper( element );
        }
        // Text
        public static LabelWrapper Wrap(this Label label) {
            return new LabelWrapper( label );
        }
        public static ButtonWrapper Wrap(this Button button) {
            return new ButtonWrapper( button );
        }
        // Field
        public static FieldWrapper<T> Wrap<T>(this BaseField<T?> field) where T : notnull {
            return new FieldWrapper<T>( field );
        }
        public static PopupWrapper<T> Wrap<T>(this PopupField<T?> popup) where T : notnull {
            return new PopupWrapper<T>( popup );
        }
        public static SliderWrapper<T> Wrap<T>(this BaseSlider<T> slider) where T : struct, IComparable<T> {
            return new SliderWrapper<T>( slider );
        }
        public static ToggleWrapper<bool> Wrap(this Toggle toggle) {
            return new ToggleWrapper<bool>( toggle );
        }
        // Slot
        public static SlotWrapper Wrap(this Slot slot) {
            return new SlotWrapper( slot );
        }

    }
    // Element
    public class ElementWrapper : VisualElementWrapper<VisualElement> {

        public ElementWrapper(VisualElement element) : base( element ) {
        }

    }
    // Text
    public class LabelWrapper : VisualElementWrapper<Label> {

        public string? Text {
            get => VisualElement.text;
            set => VisualElement.text = value;
        }

        public LabelWrapper(Label label) : base( label ) {
        }

    }
    public class ButtonWrapper : VisualElementWrapper<Button> {

        public string? Text {
            get => VisualElement.text;
            set => VisualElement.text = value;
        }

        public ButtonWrapper(Button button) : base( button ) {
        }

    }
    // Field
    public class FieldWrapper<T> : VisualElementWrapper<BaseField<T?>> where T : notnull {

        public T? Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }

        public FieldWrapper(BaseField<T?> field) : base( field ) {
        }

    }
    public class PopupWrapper<T> : VisualElementWrapper<PopupField<T?>> where T : notnull {

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

        public PopupWrapper(PopupField<T?> popup) : base( popup ) {
        }

    }
    public class SliderWrapper<T> : VisualElementWrapper<BaseSlider<T>> where T : struct, IComparable<T> {

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

        public SliderWrapper(BaseSlider<T> slider) : base( slider ) {
        }

    }
    public class ToggleWrapper<T> : VisualElementWrapper<Toggle> {

        public bool Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }

        public ToggleWrapper(Toggle toggle) : base( toggle ) {
            Assert.Object.Message( $"ToggleWrapper {this} is invalid" ).Valid( this is ToggleWrapper<bool> );
        }

    }
    // Slot
    public class SlotWrapper : VisualElementWrapper<Slot> {

        public IReadOnlyList<VisualElement> Elements {
            get => (IReadOnlyList<VisualElement>) VisualElement.Children();
        }

        public SlotWrapper(Slot slot) : base( slot ) {
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