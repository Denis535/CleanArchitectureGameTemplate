#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public static class GameObject2 {

        // Require
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static GameObject Require(string name) {
            return GameObject.Find( name ) ?? throw Exceptions.Internal.Exception( $"GameObject {name} was not found" );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static GameObject RequireGameObjectWithTag(string tag) {
            return GameObject.FindGameObjectWithTag( tag ) ?? throw Exceptions.Internal.Exception( $"GameObject (with tag {tag}) was not found" );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static T RequireFirstObjectByType<T>(FindObjectsInactive findObjectsInactive) where T : Object {
            return GameObject.FindFirstObjectByType<T>( findObjectsInactive ) ?? throw Exceptions.Internal.Exception( $"Object {typeof( T )} was not found" );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static T RequireAnyObjectByType<T>(FindObjectsInactive findObjectsInactive) where T : Object {
            return GameObject.FindAnyObjectByType<T>( findObjectsInactive ) ?? throw Exceptions.Internal.Exception( $"Object {typeof( T )} was not found" );
        }

        // Require
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static GameObject[] RequireGameObjectsWithTag<T>(string tag) {
            return GameObject.FindGameObjectsWithTag( tag ).NullIfEmpty() ?? throw Exceptions.Internal.Exception( $"GameObjects (with tag {tag}) was not found" );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static T[] RequireObjectsByType<T>(FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) where T : Object {
            return GameObject.FindObjectsByType<T>( findObjectsInactive, sortMode ).NullIfEmpty() ?? throw Exceptions.Internal.Exception( $"Objects {typeof( T )} was not found" );
        }

    }
}
