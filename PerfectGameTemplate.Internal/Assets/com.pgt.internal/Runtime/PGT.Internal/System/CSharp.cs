#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static partial class CSharp {

        // Apply
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static T Apply<T>(this T value, Action<T> callback) {
            callback( value );
            return value;
        }
        // Apply/All
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static T[] ApplyAll<T>(this T[] values, Action<T> callback) {
            foreach (var value in values) callback( value );
            return values;
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static List<T> ApplyAll<T>(this List<T> values, Action<T> callback) {
            foreach (var value in values) callback( value );
            return values;
        }

        // Convert
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TOutput Convert<TInput, TOutput>(this TInput value, Converter<TInput, TOutput> converter) {
            return converter( value );
        }
        // Convert/All
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] values, Converter<TInput, TOutput> converter) {
            return Array.ConvertAll( values, converter );
        }
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static List<TOutput> ConvertAll<TInput, TOutput>(this List<TInput> values, Converter<TInput, TOutput> converter) {
            return values.Select( i => converter( i ) ).ToList();
        }

    }
}
