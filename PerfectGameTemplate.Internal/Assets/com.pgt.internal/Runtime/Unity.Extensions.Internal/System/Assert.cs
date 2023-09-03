#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    public static class Assert {
        public static class Argument {
            public static Assertation.Message<Assertation.Argument> Message(FormattableString text) => new( text );
        }
        public static class Operation {
            public static Assertation.Message<Assertation.Operation> Message(FormattableString text) => new( text );
        }
        public static class Object {
            public static Assertation.Message<Assertation.Object> Message(FormattableString text) => new( text );
        }
        public static class Internal {
            public static Assertation.Message<Assertation.Internal> Message(FormattableString text) => new( text );
        }
    }
    public static class Assertation {
        public abstract class Message {
            private FormattableString Text { get; }

            public Message(FormattableString text) {
                Text = text;
            }
            public override string ToString() {
                return Format( Text );
            }

            // Helpers/Format
            private static string Format(FormattableString @string) {
                return Format( @string.Format, @string.GetArguments() );
            }
            private static string Format(string format, object?[] args) {
                for (var i = 0; i < args.Length; i++) {
                    format = format.Replace( $" {{{i}}} ", $" '{{{i}}}' " );
                }
                return string.Format( format, args );
            }
        }
        public class Message<T> : Message {
            public Message(FormattableString text) : base( text ) {
            }
        }
        public class Argument {
        }
        public class Operation {
        }
        public class Object {
        }
        public class Internal {
        }
    }
    public static class Assertations {

        // Argument
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Valid(this Assertation.Message<Assertation.Argument> message, [DoesNotReturnIf( false )] bool isValid) {
            Throw<ArgumentException>( message, isValid );
        }
        // Argument/InRange
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void InRange(this Assertation.Message<Assertation.Argument> message, [DoesNotReturnIf( false )] bool isInRange) {
            Throw<ArgumentOutOfRangeException>( message, isInRange );
        }
        // Argument/NotNull
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void NotNull(this Assertation.Message<Assertation.Argument> message, [DoesNotReturnIf( false )] bool isNotNull) {
            Throw<ArgumentNullException>( message, isNotNull );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void NotNull(this Assertation.Message<Assertation.Argument> message, object? argument) {
            Throw<ArgumentNullException>( message, argument != null );
        }
        // Operation
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Valid(this Assertation.Message<Assertation.Operation> message, [DoesNotReturnIf( false )] bool isValid) {
            Throw<InvalidOperationException>( message, isValid );
        }
        // Object
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Valid(this Assertation.Message<Assertation.Object> message, [DoesNotReturnIf( false )] bool isValid) {
            Throw<ObjectInvalidException>( message, isValid );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Alive(this Assertation.Message<Assertation.Object> message, [DoesNotReturnIf( false )] bool isAlive) {
            Throw<ObjectDisposedException>( message, isAlive );
        }
        // Internal
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Valid(this Assertation.Message<Assertation.Internal> message, [DoesNotReturnIf( false )] bool isValid) {
            Throw<Exception>( message, isValid );
        }

        // Helpers/Throw
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private static void Throw<T>(Assertation.Message message, [DoesNotReturnIf( false )] bool isValid) where T : Exception {
            if (!isValid) throw Create<T>( message );
        }
        // Helpers/Create
        private static T Create<T>(Assertation.Message message) where T : Exception {
            return Create<T>( message.ToString() );
        }
        private static T Create<T>(string message) where T : Exception {
            var type = typeof( T );
            var constructor = type.GetConstructor( new Type[] { typeof( string ), typeof( Exception ) } );
            return (T) constructor.Invoke( new object?[] { message, (Exception?) null } );
        }

    }
}
