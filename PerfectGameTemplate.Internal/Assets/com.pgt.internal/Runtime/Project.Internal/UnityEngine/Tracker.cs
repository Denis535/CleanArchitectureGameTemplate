#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tracker<T, TObj> {

        private Func<TObj, T> ValueSelector { get; }
        private bool HasValue { get; set; }
        private T Value { get; set; }

        // Constructor
        public Tracker(Func<TObj, T> valueSelector) {
            ValueSelector = valueSelector;
            HasValue = false;
            Value = default!;
        }

        // IsChanged
        public bool IsChanged(TObj @object) {
            var newValue = ValueSelector( @object );
            if (!HasValue || IsChanged( Value, newValue )) {
                (HasValue, Value) = (true, newValue);
                return true;
            } else {
                return false;
            }
        }
        public bool IsChanged(TObj @object, out T value) {
            var newValue = ValueSelector( @object );
            if (!HasValue || IsChanged( Value, newValue )) {
                (HasValue, Value) = (true, newValue);
                value = Value;
                return true;
            } else {
                value = Value;
                return false;
            }
        }
        public bool IsChanged(TObj @object, out T value, out bool hasPrevValue, out T prevValue) {
            var newValue = ValueSelector( @object );
            if (!HasValue || IsChanged( Value, newValue )) {
                (hasPrevValue, prevValue) = (HasValue, Value);
                (HasValue, Value) = (true, newValue);
                value = Value;
                return true;
            } else {
                (hasPrevValue, prevValue) = (HasValue, Value);
                value = Value;
                return false;
            }
        }

        // Helpers
        private static bool IsChanged(T value, T newValue) {
            return !EqualityComparer<T>.Default.Equals( value, newValue );
        }

    }
}
