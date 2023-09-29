#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    // One producer, one consumer
    public class Trackable<T> {

        private readonly TrackableSource<T> source;

        public T Value => source.Value;
        public bool IsChanged => source.IsChanged;

        // Constructor
        internal Trackable(TrackableSource<T> source) {
            this.source = source;
        }

        // Peek
        public bool Peek(out T value) {
            value = source.Value;
            return source.IsChanged;
        }

        // Consume
        public bool Consume(out T value) {
            value = source.Value;
            var isChanged = source.IsChanged;
            source.IsChanged = false;
            return isChanged;
        }

        // Utils
        public override string ToString() {
            return "Trackable ({0}, {1})".Format( source.Value, source.IsChanged );
        }

    }
    public class TrackableSource<T> {

        internal T Value { get; private set; }
        internal bool IsChanged { get; set; }
        public Trackable<T> Trackable { get; }

        // Constructor
        public TrackableSource(T value) {
            Value = value;
            IsChanged = true;
            Trackable = new Trackable<T>( this );
        }

        // SetValue
        public void SetValue(T value) {
            Assert.Operation.Message( $"Value is already set" ).Valid( !IsChanged );
            (Value, IsChanged) = (value, true);
        }

        // TrySetValue
        public bool TrySetValue(T value) {
            if (!IsChanged) {
                (Value, IsChanged) = (value, true);
                return true;
            }
            return false;
        }

        // Utils
        public override string ToString() {
            return "TrackableSource ({0}, {1})".Format( Value, IsChanged );
        }

    }
}
