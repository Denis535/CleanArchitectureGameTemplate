#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;

    public static class StringExtensions {

        // LeftRightOf
        public static (string Left, string Right) LeftRightOf(this string value, char separator) {
            var i = value.IndexOf( separator );
            Assert.Argument.Message( $"Argument 'value' ({value}) is invalid" ).Valid( i != -1 );
            var left = value.Substring( 0, i );
            var right = value.Substring( i + 1 );
            return (left, right);
        }
        public static (string Left, string Right) LeftRightOf(this string value, string separator) {
            var i = value.IndexOf( separator );
            Assert.Argument.Message( $"Argument 'value' ({value}) is invalid" ).Valid( i != -1 );
            var left = value.Substring( 0, i );
            var right = value.Substring( i + 1 );
            return (left, right);
        }

        // Join
        public static string Join(this IEnumerable<string> values, char separator) {
            return string.Join( separator, values );
        }
        public static string Join(this IEnumerable<string> values, string separator) {
            return string.Join( separator, values );
        }

        // Format
        public static string Format(this string format, params object?[] args) {
            return string.Format( format, args );
        }
        public static string Format(this string format, CultureInfo culture, params object?[] args) {
            return string.Format( culture, format, args );
        }

        // Trim
        public static string Trim(this string value, string prefix, string suffix) {
            return value.TrimStart( prefix ).TrimEnd( suffix );
        }
        public static string TrimStart(this string value, string prefix) {
            if (value.StartsWith( prefix )) return value.Remove( 0, prefix.Length );
            return value;
        }
        public static string TrimEnd(this string value, string suffix) {
            if (value.EndsWith( suffix )) return value.Remove( value.Length - suffix.Length, suffix.Length );
            return value;
        }

        // NullIf
        public static string? NullIfEmpty(this string value) {
            return !string.IsNullOrEmpty( value ) ? value : null;
        }
        public static string? NullIfWhiteSpace(this string value) {
            return !string.IsNullOrWhiteSpace( value ) ? value : null;
        }

    }
}
