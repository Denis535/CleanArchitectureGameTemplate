#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class Exceptions {
        // Argument
        public static class Argument {
            public static ArgumentException Invalid(FormattableString message) => Create<ArgumentException>( message );
            public static ArgumentOutOfRangeException OutOfRange(FormattableString message) => Create<ArgumentOutOfRangeException>( message );
            public static ArgumentNullException Null(FormattableString message) => Create<ArgumentNullException>( message );
        }
        // Operation
        public static class Operation {
            public static InvalidOperationException Invalid(FormattableString message) => Create<InvalidOperationException>( message );
        }
        // Object
        public static class Object {
            public static ObjectInvalidException Invalid(FormattableString message) => Create<ObjectInvalidException>( message );
            public static ObjectDisposedException Disposed(FormattableString message) => Create<ObjectDisposedException>( message );
        }
        // Internal
        public static class Internal {
            public static Exception Exception(FormattableString message) => Create<Exception>( message );
            public static NullReferenceException NullReference(FormattableString message) => Create<NullReferenceException>( message );
            public static NotSupportedException NotSupported(FormattableString message) => Create<NotSupportedException>( message );
            public static NotImplementedException NotImplemented(FormattableString message) => Create<NotImplementedException>( message );
        }

        // Helpers/Create
        private static T Create<T>(FormattableString message) where T : Exception {
            return Create<T>( Format( message.Format, message.GetArguments() ) );
        }
        private static T Create<T>(string message) where T : Exception {
            var type = typeof( T );
            var constructor = type.GetConstructor( new Type[] { typeof( string ), typeof( Exception ) } );
            return (T) constructor.Invoke( new object?[] { message, (Exception?) null } );
        }
        // Helpers/Format
        private static string Format(string format, object?[] args) {
            for (var i = 0; i < args.Length; i++) {
                format = format.Replace( $" {{{i}}} ", $" '{{{i}}}' " );
            }
            for (var i = 0; i < args.Length; i++) {
                args[ i ] = args[ i ] ?? "Null";
            }
            return string.Format( format, args );
        }

    }
    // ObjectInvalidException
    public class ObjectInvalidException : InvalidOperationException {
        public ObjectInvalidException(string message) : base( message ) {
        }
        public ObjectInvalidException(string message, Exception? innerException) : base( message, innerException ) {
        }
    }
}
