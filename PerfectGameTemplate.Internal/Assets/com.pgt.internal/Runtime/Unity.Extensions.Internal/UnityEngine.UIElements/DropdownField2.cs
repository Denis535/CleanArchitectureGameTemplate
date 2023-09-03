#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Scripting;

    public class DropdownField2 : PopupField<object?> {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<DropdownField2, UxmlTraits> {
        }
        [Preserve]
        public new class UxmlTraits : BaseField<object?>.UxmlTraits {

            private static readonly UxmlIntAttributeDescription IndexAttributeDesc = new UxmlIntAttributeDescription() { name = "index" };
            private static readonly UxmlStringAttributeDescription ValueAttributeDesc = new UxmlStringAttributeDescription() { name = "value" };
            private static readonly UxmlStringAttributeDescription ChoicesAttributeDesc = new UxmlStringAttributeDescription() { name = "choices", defaultValue = null };

            public override void Init(VisualElement element, IUxmlAttributes bag, CreationContext context) {
                base.Init( element, bag, context );
                var element_ = (DropdownField2) element;
                var index = 0;
                if (IndexAttributeDesc.TryGetValueFromBag( bag, context, ref index )) {
                    element_.index = index;
                }
                var value = default( string );
                if (ValueAttributeDesc.TryGetValueFromBag( bag, context, ref value )) {
                    element_.value = (object?) value;
                }
                var choices = default( string );
                if (ChoicesAttributeDesc.TryGetValueFromBag( bag, context, ref choices )) {
                    element_.choices = choices.Split( ',' ).Select( i => i.Trim() ).Cast<object?>().ToList();
                }
            }

        }

        public static Func<object?, string>? Formatter { get; set; }


        // Constructor
        public DropdownField2() {
            if (Formatter != null) {
                formatSelectedValueCallback = formatListItemCallback = Formatter;
            }
        }
        public DropdownField2(string? label) {
            if (Formatter != null) {
                formatSelectedValueCallback = formatListItemCallback = Formatter;
            }
            this.label = label;
        }
        public DropdownField2(string? label, int index, object?[] choices) {
            if (Formatter != null) {
                formatSelectedValueCallback = formatListItemCallback = Formatter;
            }
            this.label = label;
            this.index = index;
            this.choices = choices.ToList();
        }
        public DropdownField2(string? label, object? value, object?[] choices) {
            if (Formatter != null) {
                formatSelectedValueCallback = formatListItemCallback = Formatter;
            }
            this.label = label;
            this.value = value;
            this.choices = choices.ToList();
        }

    }
}
