#nullable enable
#if !UNITY_EDITOR
#define NOT_UNITY_EDITOR
#endif
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    public static class Release {

        // Log
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Log(object message) {
            Debug.Log( message );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Log(object message, Object context) {
            Debug.Log( message, context );
        }
        // Log
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogFormat(string format, params object[] args) {
            Debug.LogFormat( format, args );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogFormat(Object context, string format, params object[] args) {
            Debug.LogFormat( context, format, args );
        }

        // Log/Warning
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogWarning(object message) {
            Debug.LogWarning( message );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogWarning(object message, Object context) {
            Debug.LogWarning( message, context );
        }
        // Log/Warning
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogWarningFormat(string format, params object[] args) {
            Debug.LogWarningFormat( format, args );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogWarningFormat(Object context, string format, params object[] args) {
            Debug.LogWarningFormat( context, format, args );
        }

        // Log/Error
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogError(object message) {
            Debug.LogError( message );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogError(object message, Object context) {
            Debug.LogError( message, context );
        }
        // Log/Error
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogErrorFormat(string format, params object[] args) {
            Debug.LogErrorFormat( format, args );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogErrorFormat(Object context, string format, params object[] args) {
            Debug.LogErrorFormat( context, format, args );
        }

        // Log/Assertion
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogAssertion(object message) {
            Debug.LogAssertion( message );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogAssertion(object message, Object context) {
            Debug.LogAssertion( message, context );
        }
        // Log/Assertion
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogAssertionFormat(string format, params object[] args) {
            Debug.LogAssertionFormat( format, args );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void LogAssertionFormat(Object context, string format, params object[] args) {
            Debug.LogAssertionFormat( context, format, args );
        }

        // Assert
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Assert(bool condition) {
            Debug.Assert( condition );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Assert(bool condition, Object context) {
            Debug.Assert( condition, context );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Assert(bool condition, object message) {
            Debug.Assert( condition, message );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Assert(bool condition, string message) {
            Debug.Assert( condition, message );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Assert(bool condition, object message, Object context) {
            Debug.Assert( condition, message, context );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void Assert(bool condition, string message, Object context) {
            Debug.Assert( condition, message, context );
        }
        // Assert
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void AssertFormat(bool condition, string format, params object[] args) {
            Debug.AssertFormat( condition, format, args );
        }
        [Conditional( "NOT_UNITY_EDITOR" )]
        public static void AssertFormat(bool condition, Object context, string format, params object[] args) {
            Debug.AssertFormat( condition, context, format, args );
        }

    }
}
