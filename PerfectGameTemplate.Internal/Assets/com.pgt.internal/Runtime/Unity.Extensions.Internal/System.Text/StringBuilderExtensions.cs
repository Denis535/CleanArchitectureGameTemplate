#nullable enable
namespace System.Text {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class StringBuilderExtensions {

        public static int IndentSize { get; set; } = 4;

        public static StringBuilder AppendHierarchy<T>(this StringBuilder builder, T @object, int indent, Func<T, string> textSelector, Func<T, IEnumerable<T>> childrenSelector) {
            var text = textSelector( @object );
            var children = childrenSelector( @object );
            builder.AppendIndent( indent ).Append( text );
            foreach (var child in children) {
                builder.AppendLine();
                builder.AppendHierarchy( child, indent + 1, textSelector, childrenSelector );
            }
            return builder;
        }

        public static StringBuilder AppendIndent(this StringBuilder builder, int indent) {
            return builder.Append( ' ', indent * IndentSize );
        }

        public static StringBuilder AppendLineFormat(this StringBuilder builder, string format, object?[] args) {
            return builder.AppendFormat( format, args ).AppendLine();
        }

    }
}
