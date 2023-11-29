#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class VisualElementScope : IDisposable {

        private static readonly Stack<VisualElement> stack = new Stack<VisualElement>();
        public static VisualElement? Current => stack.Count > 0 ? stack.Peek() : null;

        protected VisualElementScope(VisualElement visualElement) {
            stack.Push( visualElement );
        }
        public void Dispose() {
            stack.Pop();
        }

    }
    public class VisualElementScope<T> : VisualElementScope where T : VisualElement {

        public T VisualElement { get; }

        public VisualElementScope(T visualElement) : base( visualElement ) {
            VisualElement = visualElement;
        }

        public static implicit operator T(VisualElementScope<T> scope) {
            return scope.VisualElement;
        }

    }
    public static class VisualElementScopeExtensions {

        public static VisualElementScope<T> AsScope<T>(this T visualElement) where T : VisualElement {
            return new VisualElementScope<T>( visualElement );
        }
        public static VisualElementScope<T> AsScope<T>(this T visualElement, out T @out) where T : VisualElement {
            return new VisualElementScope<T>( @out = visualElement );
        }

    }
}
