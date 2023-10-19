#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UIElements;

    public abstract class VisualElementWrapper {

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

        public VisualElementWrapper(VisualElement visualElement) {
            VisualElement = visualElement;
        }

    }
    public abstract class VisualElementWrapper<T> : VisualElementWrapper where T : VisualElement {

        public new T VisualElement => (T) base.VisualElement;

        public VisualElementWrapper(T visualElement) : base( visualElement ) {
        }

    }
    // ElementWrapper
    public class ElementWrapper : VisualElementWrapper<VisualElement> {

        public IReadOnlyList<VisualElement> Children {
            get => (IReadOnlyList<VisualElement>) VisualElement.Children();
        }

        public ElementWrapper(VisualElement visualElement) : base( visualElement ) {
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
    public class LabelWrapper : VisualElementWrapper<Label> {

        public string? Text {
            get => VisualElement.text;
            set => VisualElement.text = value;
        }

        public LabelWrapper(Label visualElement) : base( visualElement ) {
        }

    }
    public class ButtonWrapper : VisualElementWrapper<Button> {

        public string? Text {
            get => VisualElement.text;
            set => VisualElement.text = value;
        }

        public ButtonWrapper(Button visualElement) : base( visualElement ) {
        }

    }
    // FieldWrapper
    public class TextWrapper<T> : VisualElementWrapper<BaseField<string?>> where T : notnull {

        public string? Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }

        public TextWrapper(BaseField<string?> visualElement) : base( visualElement ) {
            Assert.Object.Message( $"TextWrapper {this} is invalid" ).Valid( this is TextWrapper<string> );
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

        public PopupWrapper(PopupField<T?> visualElement) : base( visualElement ) {
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

        public SliderWrapper(BaseSlider<T> visualElement) : base( visualElement ) {
        }

    }
    public class ToggleWrapper<T> : VisualElementWrapper<Toggle> where T : struct, IComparable<T> {

        public bool Value {
            get => VisualElement.value;
            set => VisualElement.value = value;
        }

        public ToggleWrapper(Toggle visualElement) : base( visualElement ) {
            Assert.Object.Message( $"ToggleWrapper {this} is invalid" ).Valid( this is ToggleWrapper<bool> );
        }

    }
    // SlotWrapper
    public class SlotWrapper : VisualElementWrapper<Slot> {

        public IReadOnlyList<VisualElement> Children {
            get => (IReadOnlyList<VisualElement>) VisualElement.Children();
        }

        public SlotWrapper(Slot visualElement) : base( visualElement ) {
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
    // VisualElementWrapperExtensions
    public static partial class VisualElementWrapperExtensions {

        // ElementWrapper
        public static ElementWrapper Wrap(this VisualElement visualElement) {
            return new ElementWrapper( visualElement );
        }
        public static LabelWrapper Wrap(this Label visualElement) {
            return new LabelWrapper( visualElement );
        }
        public static ButtonWrapper Wrap(this Button visualElement) {
            return new ButtonWrapper( visualElement );
        }
        // FieldWrapper
        public static TextWrapper<string> Wrap(this BaseField<string?> visualElement) {
            return new TextWrapper<string>( visualElement );
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
        // SlotWrapper
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
        public static void OnChange(this TextWrapper<string> wrapper, Action<VisualElementWrapper, string?>? callback) {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue ) );
        }
        public static void OnChange(this TextWrapper<string> wrapper, Action<VisualElementWrapper, string?, string?>? callback) {
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
        public static void OnChange(this ToggleWrapper<bool> wrapper, Action<VisualElementWrapper, bool>? callback) {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue ) );
        }
        public static void OnChange(this ToggleWrapper<bool> wrapper, Action<VisualElementWrapper, bool, bool>? callback) {
            wrapper.VisualElement.OnChange( evt => callback?.Invoke( wrapper, evt.newValue, evt.previousValue ) );
        }

    }
}
