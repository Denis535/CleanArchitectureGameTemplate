#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public static class TransformExtensions {

        // Require
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Transform Require(this Transform transform, string path) {
            return transform.Find( path ) ?? throw Exceptions.Internal.Exception( $"Transform {path} was not found" );
        }

    }
}
