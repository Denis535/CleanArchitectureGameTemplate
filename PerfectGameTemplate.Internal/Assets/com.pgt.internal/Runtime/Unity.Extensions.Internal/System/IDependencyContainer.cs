#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;

    // todo: Make Resolve and TryResolve methods sealed. Now it doesn't work!!!
    public interface IDependencyContainer {

        // Resolve
        object? Resolve(Type type, string? name = null) {
            var result = GetDependency( type, name );
            return result ?? throw DependencyWasNotResolved( type, name );
        }
        T Resolve<T>(string? name = null) {
            var result = (T?) GetDependency( typeof( T ), name );
            return result ?? throw DependencyWasNotResolved( typeof( T ), name );
        }

        // TryResolve
        bool TryResolve(Type type, string? name, [NotNullWhen( true )] out object? result) {
            result = GetDependency( type, name );
            return result != null;
        }
        bool TryResolve<T>(Type type, string? name, [NotNullWhen( true )] out T? result) {
            result = (T?) GetDependency( type, name );
            return result != null;
        }

        // GetDependency
        protected object? GetDependency(Type type, string? name);

        // Helpers
        private static Exception DependencyWasNotResolved(Type type, string? name) {
            if (name == null) {
                return Exceptions.Internal.Exception( $"Dependency {type} was not resolved" );
            } else {
                return Exceptions.Internal.Exception( $"Dependency {type} ({name}) was not resolved" );
            }
        }

    }
}
