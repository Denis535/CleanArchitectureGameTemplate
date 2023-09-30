#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tracker<T, TObj> {

        private Func<TObj, T> ValueSelector { get; }
        private Option<T> Value { get; set; }

        // Constructor
        public Tracker(Func<TObj, T> valueSelector) {
            ValueSelector = valueSelector;
            Value = default;
        }

        // IsChanged
        public bool IsChanged(TObj @object) {
            var newValue = ValueSelector( @object );
            if (!Value.Equals( newValue )) {
                Value = new Option<T>( newValue );
                return true;
            } else {
                return false;
            }
        }
        public bool IsChanged(TObj @object, out T value) {
            var newValue = ValueSelector( @object );
            if (!Value.Equals( newValue )) {
                Value = new Option<T>( newValue );
                value = Value.Value;
                return true;
            } else {
                value = Value.Value;
                return false;
            }
        }
        public bool IsChanged(TObj @object, out T value, out Option<T> prevValue) {
            var newValue = ValueSelector( @object );
            if (!Value.Equals( newValue )) {
                prevValue = Value;
                Value = new Option<T>( newValue );
                value = Value.Value;
                return true;
            } else {
                prevValue = Value;
                value = Value.Value;
                return false;
            }
        }

    }
}
