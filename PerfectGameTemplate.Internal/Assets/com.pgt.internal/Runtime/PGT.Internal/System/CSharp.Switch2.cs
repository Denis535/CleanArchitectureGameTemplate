#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class CSharp {

        // Switch/16
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T11, TResult> case_11,
            Func<T12, TResult> case_12,
            Func<T13, TResult> case_13,
            Func<T14, TResult> case_14,
            Func<T15, TResult> case_15,
            Func<T16, TResult> case_16,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T
            where T11 : T
            where T12 : T
            where T13 : T
            where T14 : T
            where T15 : T
            where T16 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                case T11: return case_11( (T11) value );
                case T12: return case_12( (T12) value );
                case T13: return case_13( (T13) value );
                case T14: return case_14( (T14) value );
                case T15: return case_15( (T15) value );
                case T16: return case_16( (T16) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/15
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T11, TResult> case_11,
            Func<T12, TResult> case_12,
            Func<T13, TResult> case_13,
            Func<T14, TResult> case_14,
            Func<T15, TResult> case_15,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T
            where T11 : T
            where T12 : T
            where T13 : T
            where T14 : T
            where T15 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                case T11: return case_11( (T11) value );
                case T12: return case_12( (T12) value );
                case T13: return case_13( (T13) value );
                case T14: return case_14( (T14) value );
                case T15: return case_15( (T15) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/14
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T11, TResult> case_11,
            Func<T12, TResult> case_12,
            Func<T13, TResult> case_13,
            Func<T14, TResult> case_14,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T
            where T11 : T
            where T12 : T
            where T13 : T
            where T14 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                case T11: return case_11( (T11) value );
                case T12: return case_12( (T12) value );
                case T13: return case_13( (T13) value );
                case T14: return case_14( (T14) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/13
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T11, TResult> case_11,
            Func<T12, TResult> case_12,
            Func<T13, TResult> case_13,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T
            where T11 : T
            where T12 : T
            where T13 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                case T11: return case_11( (T11) value );
                case T12: return case_12( (T12) value );
                case T13: return case_13( (T13) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/12
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T11, TResult> case_11,
            Func<T12, TResult> case_12,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T
            where T11 : T
            where T12 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                case T11: return case_11( (T11) value );
                case T12: return case_12( (T12) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/11
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T11, TResult> case_11,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T
            where T11 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                case T11: return case_11( (T11) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/10
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T10, TResult> case_10,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T
            where T10 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                case T10: return case_10( (T10) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/9
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T9, TResult> case_9,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T
            where T9 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                case T9: return case_9( (T9) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/8
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7, T8>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T8, TResult> case_8,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                case T8: return case_8( (T8) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/7
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6, T7>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T7, TResult> case_7,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                case T7: return case_7( (T7) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/6
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5, T6>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T6, TResult> case_6,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                case T6: return case_6( (T6) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/5
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4, T5>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T5, TResult> case_5,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                case T5: return case_5( (T5) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/4
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3, T4>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T4, TResult> case_4,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                case T4: return case_4( (T4) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/3
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2, T3>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T3, TResult> case_3,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                case T3: return case_3( (T3) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/2
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1, T2>
            (this T value,
            Func<T1, TResult> case_1,
            Func<T2, TResult> case_2,
            Func<T, TResult>? @default = null)
            where T1 : T
            where T2 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                case T2: return case_2( (T2) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

        // Switch/1
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static TResult? Switch<T, TResult, T1>(this T value, Func<T1, TResult> case_1, Func<T, TResult>? @default = null) where T1 : T {
            switch (value) {
                case T1: return case_1( (T1) value );
                default: return (@default != null) ? @default( value ) : default;
            }
        }

    }
}
