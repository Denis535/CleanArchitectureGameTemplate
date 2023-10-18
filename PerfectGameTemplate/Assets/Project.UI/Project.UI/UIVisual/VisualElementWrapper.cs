#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class VisualElementWrapper {

        protected internal VisualElement VisualElement { get; }

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

        // Constructor
        public VisualElementWrapper(VisualElement visualElement) {
            VisualElement = visualElement;
        }

    }
    public abstract class VisualElementWrapper<T> : VisualElementWrapper where T : VisualElement {

        protected internal new T VisualElement => (T) base.VisualElement;

        // Constructor
        public VisualElementWrapper(T visualElement) : base( visualElement ) {
        }

    }
    public static partial class VisualElementWrapperExtensions {

        // Element
        public static ElementWrapper Wrap(this VisualElement visualElement) {
            return new ElementWrapper( visualElement );
        }
        // Text
        public static LabelWrapper Wrap(this Label visualElement) {
            return new LabelWrapper( visualElement );
        }
        public static ButtonWrapper Wrap(this Button visualElement) {
            return new ButtonWrapper( visualElement );
        }
        // Field
        public static FieldWrapper<T> Wrap<T>(this BaseField<T?> visualElement) where T : notnull {
            return new FieldWrapper<T>( visualElement );
        }
        public static PopupWrapper<T> Wrap<T>(this PopupField<T?> visualElement) where T : notnull {
            return new PopupWrapper<T>( visualElement );
        }
        public static SliderWrapper<T> Wrap<T>(this BaseSlider<T> visualElement) where T : struct, IComparable<T> {
            return new SliderWrapper<T>( visualElement );
        }
        public static ToggleWrapper<bool> Wrap(this Toggle visualElement) {
            return new ToggleWrapper<bool>( visualElement );
        }
        // Slot
        public static SlotWrapper Wrap(this Slot visualElement) {
            return new SlotWrapper( visualElement );
        }

    }
    public static partial class VisualElementWrapperExtensions {

        // OnAttachToPanel
        public static void OnAttachToPanel<T>(this VisualElementWrapper<T> wrapper, Action<VisualElementWrapper>? callback) where T : VisualElement {
            wrapper.VisualElement.OnAttachToPanel( evt => callback?.Invoke( wrapper ) );
        }
        public static void OnDetachFromPanel<T>(this VisualElementWrapper<T> wrapper, Action<VisualElementWrapper>? callback) where T : VisualElement {
            wrapper.VisualElement.OnDetachFromPanel( evt => callback?.Invoke( wrapper ) );
        }

        // OnClick
        public static void OnClick(this ButtonWrapper wrapper, Action<VisualElementWrapper>? callback) {
            wrapper.VisualElement.OnClick( evt => callback?.Invoke( wrapper ) );
        }

        // OnChange
        public static void OnChange<T>(this FieldWrapper<T> wrapper, Action<VisualElementWrapper, T?>? callback) where T : notnull {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue ) );
        }
        public static void OnChange<T>(this FieldWrapper<T> wrapper, Action<VisualElementWrapper, T?, T?>? callback) where T : notnull {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue, evt.previousValue ) );
        }

        // OnChange
        public static void OnChange<T>(this PopupWrapper<T> wrapper, Action<VisualElementWrapper, T?>? callback) where T : notnull {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue ) );
        }
        public static void OnChange<T>(this PopupWrapper<T> wrapper, Action<VisualElementWrapper, T?, T?>? callback) where T : notnull {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue, evt.previousValue ) );
        }

        // OnChange
        public static void OnChange<T>(this SliderWrapper<T> wrapper, Action<VisualElementWrapper, T>? callback) where T : struct, IComparable<T> {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue ) );
        }
        public static void OnChange<T>(this SliderWrapper<T> wrapper, Action<VisualElementWrapper, T, T>? callback) where T : struct, IComparable<T> {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue, evt.previousValue ) );
        }

        // OnChange
        public static void OnChange<T>(this ToggleWrapper<T> wrapper, Action<VisualElementWrapper, bool>? callback) where T : struct, IComparable<T> {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue ) );
        }
        public static void OnChange<T>(this ToggleWrapper<T> wrapper, Action<VisualElementWrapper, bool, bool>? callback) where T : struct, IComparable<T> {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue, evt.previousValue ) );
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
    public class ToggleWrapper<T> : VisualElementWrapper<Toggle> where T : struct, IComparable<T> {

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
