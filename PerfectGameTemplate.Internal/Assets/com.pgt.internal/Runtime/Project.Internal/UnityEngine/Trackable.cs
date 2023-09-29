#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Trackable<T> {

        private readonly TrackableSource<T> source;
        public T Value => source.Value;
        public bool IsFresh => source.IsFresh;

        // Constructor
        internal Trackable(TrackableSource<T> source) {
            this.source = source;
        }

        // Peek
        public bool Peek(out T value) {
            value = source.Value;
            return source.IsFresh;
        }

        // Consume
        public bool Consume(out T value) {
            value = source.Value;
            var isFresh = source.IsFresh;
            source.IsFresh = false;
            return isFresh;
        }

        // Utils
        public override string ToString() {
            return "Trackable ({0}, {1})".Format( source.Value, source.IsFresh );
        }

    }
    public class TrackableSource<T> {

        internal T Value { get; private set; }
        internal bool IsFresh { get; set; }
        public Trackable<T> Trackable { get; }

        // Constructor
        public TrackableSource(T value) {
            Value = value;
            IsFresh = true;
            Trackable = new Trackable<T>( this );
        }

        // SetValue
        public void SetValue(T value) {
            Assert.Operation.Message( $"Value is already set" ).Valid( !IsFresh );
            Value = value;
            IsFresh = true;
        }

        // TrySetValue
        public bool TrySetValue(T value) {
            if (!IsFresh) {
                Value = value;
                IsFresh = true;
                return true;
            }
            return false;
        }

        // Utils
        public override string ToString() {
            return "TrackableSource ({0}, {1})".Format( Value, IsFresh );
        }

    }
}
