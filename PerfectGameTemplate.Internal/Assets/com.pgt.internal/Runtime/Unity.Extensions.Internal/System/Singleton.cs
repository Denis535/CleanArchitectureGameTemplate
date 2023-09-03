#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;

    public static class Singleton {
        private static class Storage<T> {
            public static T? Value { get; set; }
            [MemberNotNullWhen( true, "Value" )] public static bool HasValue => Value != null;
        }

        // Register
        //public static void Register<T>(T value) where T : class {
        //    Assert.Argument.Message( $"Argument 'value' must be non-null" ).NotNull( value );
        //    Assert.Operation.Message( $"Singleton {typeof( T ).Name} is already registered" ).Valid( !Storage<T>.HasValue );
        //    Storage<T>.Value = value;
        //}
        //public static void Unregister<T>(T value) where T : class {
        //    Assert.Argument.Message( $"Argument 'value' must be non-null" ).NotNull( value );
        //    Assert.Operation.Message( $"Singleton {typeof( T ).Name} must be registered" ).Valid( Storage<T>.HasValue );
        //    Assert.Operation.Message( $"Singleton {typeof( T ).Name} must be registered" ).Valid( Storage<T>.Value == value );
        //    Storage<T>.Value = null;
        //}

        // Register
        public static void Register(object value) {
            Register( value, value.GetType() );
        }
        public static void Unregister(object value) {
            Unregister( value, value.GetType() );
        }

        // Register
        public static void Register(object value, Type type) {
            var storageType = typeof( Storage<> ).MakeGenericType( type );
            var valuetProperty = storageType.GetProperty( "Value" );
            var oldValue = valuetProperty.GetValue( null );
            Assert.Argument.Message( $"Argument 'value' must be non-null" ).NotNull( value );
            Assert.Operation.Message( $"Singleton {type.Name} is already registered" ).Valid( oldValue == null );
            valuetProperty.SetValue( null, value );
        }
        public static void Unregister(object value, Type type) {
            var storageType = typeof( Storage<> ).MakeGenericType( type );
            var valuetProperty = storageType.GetProperty( "Value" );
            var oldValue = valuetProperty.GetValue( null );
            Assert.Argument.Message( $"Argument 'value' must be non-null" ).NotNull( value );
            Assert.Operation.Message( $"Singleton {type.Name} must be registered" ).Valid( oldValue != null );
            Assert.Operation.Message( $"Singleton {type.Name} must be registered" ).Valid( oldValue == value );
            valuetProperty.SetValue( null, null );
        }

        // GetInstance
        public static T GetInstance<T>() {
            Assert.Operation.Message( $"Singleton {typeof( T ).Name} must be registered" ).Valid( Storage<T>.HasValue );
            return Storage<T>.Value;
        }
        public static bool TryGetInstance<T>(out T? result) {
            result = Storage<T>.Value;
            return Storage<T>.HasValue;
        }
        public static bool HasInstance<T>() where T : class {
            return Storage<T>.HasValue;
        }

    }
}
