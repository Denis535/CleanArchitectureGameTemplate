#if UNITY_EDITOR
#nullable enable
namespace UnityEditor.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using UnityEditor;
    using UnityEditor.AddressableAssets.Settings;
    using UnityEngine;

    public class LabelsSourceGenerator {

        // Generate
        public void Generate(string path, string @namespace, string @class, AddressableAssetSettings settings) {
            var builder = new StringBuilder();
            var treeList = LabelsSourceGeneratorHelper.GetTreeList( settings.GetLabels().Where( IsSupported ) );
            AppendCompilationUnit( builder, @namespace, @class, treeList );
            WriteText( path, builder.ToString() );
        }

        // AppendCompilationUnit
        private static void AppendCompilationUnit(StringBuilder builder, string @namespace, string @class, KeyValueTreeList<string> treeList) {
            builder.AppendLine( $"namespace {@namespace} {{" );
            {
                AppendClass( builder, 1, @class, treeList.Items.ToArray() );
            }
            builder.AppendLine( "}" );
        }
        private static void AppendClass(StringBuilder builder, int indent, string @class, KeyValueTreeList<string>.Item[] items) {
            builder.AppendIndent( indent ).AppendLine( $"public static class {@class} {{" );
            foreach (var item in items) {
                AppendValueOrScope( builder, indent + 1, item );
            }
            builder.AppendIndent( indent ).AppendLine( "}" );
        }
        private static void AppendValueOrScope(StringBuilder builder, int indent, KeyValueTreeList<string>.Item item) {
            if (item is KeyValueTreeList<string>.ValueItem value) {
                var name = value.Key;
                var label = value.Value;
                builder.AppendIndent( indent ).AppendLine( $"public const string @{name} = \"{label}\";" );
            } else
            if (item is KeyValueTreeList<string>.ListItem scope) {
                var name = scope.Key;
                var items = scope.Items;
                builder.AppendIndent( indent ).AppendLine( $"public static class @{name} {{" );
                foreach (var i in items) {
                    AppendValueOrScope( builder, indent + 1, i );
                }
                builder.AppendIndent( indent ).AppendLine( "}" );
            }
        }

        // IsSupported
        public virtual bool IsSupported(string label) {
            return true;
        }

        // Helpers
        private static void WriteText(string path, string text) {
            if (!File.Exists( path ) || File.ReadAllText( path ) != text) {
                File.WriteAllText( path, text );
                AssetDatabase.ImportAsset( path, ImportAssetOptions.Default );
            }
        }

    }
}
#endif
