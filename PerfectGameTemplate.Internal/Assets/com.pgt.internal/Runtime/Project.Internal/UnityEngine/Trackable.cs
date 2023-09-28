#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public struct Trackable<T> {

        private readonly TrackableSource<T> source;

        public T Value => source.Value;
        public int Frame => source.Frame;

        // Constructor
        internal Trackable(TrackableSource<T> source) {
            this.source = source;
        }

        // IsFresh
        public bool IsFresh() {
            if (source.Frame == Time.frameCount) {
                return true;
            }
            return false;
        }
        public bool IsFresh(out T value) {
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
        public Trackable<T> Trackable {
            get {
                Assert.Object.Message( $"Trackable {this} must be initialized" ).Valid( Frame != -1 );
                return new Trackable<T>( this );
            }
        }

        // Constructor
        public TrackableSource() {
            this.Value = default!;
            this.Frame = -1;
        }

        // SetValue
        public void SetValue(T value) {
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
