#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static partial class CSharp {

        // Switch/16
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T11> case_11,
            Action<T12> case_12,
            Action<T13> case_13,
            Action<T14> case_14,
            Action<T15> case_15,
            Action<T16> case_16,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                case T11: case_11( (T11) value ); break;
                case T12: case_12( (T12) value ); break;
                case T13: case_13( (T13) value ); break;
                case T14: case_14( (T14) value ); break;
                case T15: case_15( (T15) value ); break;
                case T16: case_16( (T16) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/15
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T11> case_11,
            Action<T12> case_12,
            Action<T13> case_13,
            Action<T14> case_14,
            Action<T15> case_15,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                case T11: case_11( (T11) value ); break;
                case T12: case_12( (T12) value ); break;
                case T13: case_13( (T13) value ); break;
                case T14: case_14( (T14) value ); break;
                case T15: case_15( (T15) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/14
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T11> case_11,
            Action<T12> case_12,
            Action<T13> case_13,
            Action<T14> case_14,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                case T11: case_11( (T11) value ); break;
                case T12: case_12( (T12) value ); break;
                case T13: case_13( (T13) value ); break;
                case T14: case_14( (T14) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/13
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T11> case_11,
            Action<T12> case_12,
            Action<T13> case_13,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                case T11: case_11( (T11) value ); break;
                case T12: case_12( (T12) value ); break;
                case T13: case_13( (T13) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/12
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T11> case_11,
            Action<T12> case_12,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                case T11: case_11( (T11) value ); break;
                case T12: case_12( (T12) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/11
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T11> case_11,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                case T11: case_11( (T11) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/10
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T10> case_10,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                case T10: case_10( (T10) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/9
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T9> case_9,
            Action<T>? @default = null)
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
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                case T9: case_9( (T9) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/8
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7, T8>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T8> case_8,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T
            where T8 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                case T8: case_8( (T8) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/7
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6, T7>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T7> case_7,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T
            where T7 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                case T7: case_7( (T7) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/6
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5, T6>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T6> case_6,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T
            where T6 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                case T6: case_6( (T6) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/5
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4, T5>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T5> case_5,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T
            where T5 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                case T5: case_5( (T5) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/4
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3, T4>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T4> case_4,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T
            where T4 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                case T4: case_4( (T4) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/3
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2, T3>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T3> case_3,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T
            where T3 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                case T3: case_3( (T3) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/2
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1, T2>
            (this T value,
            Action<T1> case_1,
            Action<T2> case_2,
            Action<T>? @default = null)
            where T1 : T
            where T2 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                case T2: case_2( (T2) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

        // Switch/1
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Switch<T, T1>(this T value, Action<T1> case_1, Action<T>? @default = null) where T1 : T {
            switch (value) {
                case T1: case_1( (T1) value ); break;
                default: @default?.Invoke( value ); break;
            }
        }

    }
}
