#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Trackable<T> {

        private readonly TrackableSource<T> source;

        public T Value {
            get {
                Assert.Object.Message( $"Trackable {this} must be initialized" ).Valid( source.Frame != -1 );
                return source.Value;
            }
        }

        // Constructor
        internal Trackable(TrackableSource<T> source) {
            this.source = source;
        }

        // IsFresh
        public bool IsFresh() {
            Assert.Object.Message( $"Trackable {this} must be initialized" ).Valid( source.Frame != -1 );
            if (source.Frame == Time.frameCount) {
                return true;
            }
            return false;
        }
        public bool IsFresh(out T value) {
            Assert.Object.Message( $"Trackable {this} must be initialized" ).Valid( source.Frame != -1 );
            if (source.Frame == Time.frameCount) {
                value = source.Value;
                return true;
            }
            value = source.Value;
            return false;
        }

        // Utils
        public override string ToString() {
            return Value?.ToString() ?? "Null";
        }

    }
    public class TrackableSource<T> {

        internal T Value { get; private set; }
        internal int Frame { get; private set; }
        public Trackable<T> Trackable { get; }

        // Constructor
        public TrackableSource() {
            this.Value = default!;
            this.Frame = -1;
            Trackable = new Trackable<T>( this );
        }

        // SetValue
        public void SetValue(T value) {
            // you should use it only within update
            // todo: restrict use it from end of frame
            Assert.Operation.Message( $"Value is already set in this frame" ).Valid( Frame != Time.frameCount );
            this.Value = value;
            this.Frame = Time.frameCount;
        }

        // Utils
        public override string ToString() {
            return Value?.ToString() ?? "Null";
        }

    }
}
