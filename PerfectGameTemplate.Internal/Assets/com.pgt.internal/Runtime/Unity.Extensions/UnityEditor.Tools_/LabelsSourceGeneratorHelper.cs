#if UNITY_EDITOR
#nullable enable
namespace UnityEditor.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    internal static class LabelsSourceGeneratorHelper {

        // GetTreeList
        public static KeyValueTreeList<string> GetTreeList(IEnumerable<string> labels) {
            var treeList = new KeyValueTreeList<string>();
            foreach (var label in labels) {
                var path = GetPath( label ).Select( Escape ).ToArray();
                treeList.AddValue( path.SkipLast( 1 ), path.Last(), label );
            }
            return treeList;
        }
        private static string[] GetPath(string label) {
            return label.Split( '/', '\\', '.' );
        }
        private static string Escape(string value) {
            var chars = value.ToCharArray();
            for (var i = 0; i < chars.Length; i++) {
                if (!char.IsLetterOrDigit( chars[ i ] )) chars[ i ] = '_';
            }
            return new string( chars );
        }

    }
}
#endif
