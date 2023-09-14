#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class Exceptions {
        //public static class Argument {
        //    public static ArgumentException Invalid(FormattableString message) => Exception<ArgumentException>( message.GetDisplayString() );
        //    public static ArgumentOutOfRangeException OutOfRange(FormattableString message) => Exception<ArgumentOutOfRangeException>( message.GetDisplayString() );
        //    public static ArgumentNullException Null(FormattableString message) => Exception<ArgumentNullException>( message.GetDisplayString() );
        //}
        //public static class Operation {
        //    public static InvalidOperationException Invalid(FormattableString message) => Exception<InvalidOperationException>( message.GetDisplayString() );
        //}
        //public static class Object {
        //    public static ObjectInvalidException Invalid(FormattableString message) => Exception<ObjectInvalidException>( message.GetDisplayString() );
        //    public static ObjectDisposedException Disposed(FormattableString message) => Exception<ObjectDisposedException>( message.GetDisplayString() );
        //}
        public static class Internal {
            public static Exception Exception(FormattableString message) => Exception<Exception>( message.GetDisplayString() );
            public static NullReferenceException NullReference(FormattableString message) => Exception<NullReferenceException>( message.GetDisplayString() );
            public static NotSupportedException NotSupported(FormattableString message) => Exception<NotSupportedException>( message.GetDisplayString() );
            public static NotImplementedException NotImplemented(FormattableString message) => Exception<NotImplementedException>( message.GetDisplayString() );
        }

        // Helpers
        internal static T Exception<T>(string message) where T : Exception {
            var type = typeof( T );
            var constructor = type.GetConstructor( new Type[] { typeof( string ), typeof( Exception ) } );
            return (T) constructor.Invoke( new object?[] { message, null } );
        }
        internal static string GetDisplayString(this FormattableString message) {
            var format = message.Format;
            var args = message.GetArguments();
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
