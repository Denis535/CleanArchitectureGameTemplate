#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tracker<T, TObj> {

        private readonly Func<TObj, T> valueGetter;
        private bool hasPrevValue = false;
        private T prevValue = default!;

        // Constructor
        public Tracker(Func<TObj, T> valueGetter) {
            this.valueGetter = valueGetter;
        }

        // IsFresh
        public bool IsFresh(TObj @object) {
            var newValue = valueGetter( @object );
            if (IsFresh( newValue, hasPrevValue, prevValue )) {
                hasPrevValue = true;
                prevValue = newValue;
                return true;
            } else {
                hasPrevValue = true;
                prevValue = newValue;
                return false;
            }
        }
        public bool IsFresh(TObj @object, out T value) {
            var newValue = valueGetter( @object );
            if (IsFresh( newValue, hasPrevValue, prevValue )) {
                hasPrevValue = true;
                prevValue = newValue;
                value = newValue;
                return true;
            } else {
                hasPrevValue = true;
                prevValue = newValue;
                value = newValue;
                return false;
            }
        }

        // Helpers
        private static bool IsFresh(T newValue, bool hasPrevValue, T prevValue) {
            return !(hasPrevValue && EqualityComparer<T>.Default.Equals( newValue, prevValue ));
        }

    }
}
