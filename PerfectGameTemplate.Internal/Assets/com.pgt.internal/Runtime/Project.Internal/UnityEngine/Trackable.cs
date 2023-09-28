#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;

    public struct Trackable<T> {

        private T value;
        private int frame;

        public T Value {
            get => value;
            set {
                Assert.Operation.Message( $"Value is already set in this frame" ).Valid( frame != Time.frameCount );
                this.value = value;
                this.frame = Time.frameCount;
            }
        }

        // Constructor
        public Trackable(T value) {
            this.value = value;
            this.frame = Time.frameCount;
        }

        // IsFresh
        public bool IsFresh() {
            if (frame == Time.frameCount) {
                return true;
            }
            return false;
        }
        public bool IsFresh([MaybeNullWhen( false )] out T value) {
            if (frame == Time.frameCount) {
                value = this.value;
                return true;
            }
            value = default;
            return false;
        }

        // Utils
        public override string ToString() {
            return value?.ToString() ?? "Null";
        }

    }
}
