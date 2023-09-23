﻿#if UNITY_EDITOR
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
        private void AppendCompilationUnit(StringBuilder builder, string @namespace, string @class, KeyValueTreeList<string> treeList) {
            builder.AppendLine( $"namespace {@namespace} {{" );
            {
                AppendClass( builder, 1, @class, treeList.Items.ToArray() );
            }
            builder.AppendLine( "}" );
        }
        private void AppendClass(StringBuilder builder, int indent, string name, KeyValueTreeList<string>.Item[] items) {
            builder.AppendIndent( indent ).AppendLine( $"public static class @{Escape( name )} {{" );
            foreach (var item in items) {
                if (item is KeyValueTreeList<string>.ValueItem value) {
                    AppendConst( builder, indent + 1, value.Key, value );
                } else
                if (item is KeyValueTreeList<string>.ListItem list) {
                    AppendClass( builder, indent + 1, list.Key, list.Items.ToArray() );
                }
            }
            builder.AppendIndent( indent ).AppendLine( "}" );
        }
        private void AppendConst(StringBuilder builder, int indent, string name, KeyValueTreeList<string>.ValueItem item) {
            builder.AppendIndent( indent ).AppendLine( $"public const string @{Escape( name )} = \"{item.Value}\";" );
        }

        // IsSupported
        public virtual bool IsSupported(string label) {
            return true;
        }

        // Helpers
        private static string Escape(string value) {
            var chars = value.ToCharArray();
            for (var i = 0; i < chars.Length; i++) {
                if (!char.IsLetterOrDigit( chars[ i ] )) chars[ i ] = '_';
            }
            return new string( chars );
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
