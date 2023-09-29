#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tracker<T, TObj> {

        private Func<TObj, T> ValueGetter { get; }
        private bool HasPrevValue { get; set; } = false;
        private T PrevValue { get; set; } = default!;

        // Constructor
        public Tracker(Func<TObj, T> valueGetter) {
            ValueGetter = valueGetter;
        }

        // IsFresh
        public bool IsFresh(TObj @object) {
            var newValue = ValueGetter( @object );
            if (IsFresh( newValue, HasPrevValue, PrevValue )) {
                (HasPrevValue, PrevValue) = (true, newValue);
                return true;
            } else {
                (HasPrevValue, PrevValue) = (true, newValue);
                return false;
            }
        }
        public bool IsFresh(TObj @object, out T value) {
            var newValue = ValueGetter( @object );
            if (IsFresh( newValue, HasPrevValue, PrevValue )) {
                (HasPrevValue, PrevValue) = (true, newValue);
                value = newValue;
                return true;
            } else {
                (HasPrevValue, PrevValue) = (true, newValue);
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
