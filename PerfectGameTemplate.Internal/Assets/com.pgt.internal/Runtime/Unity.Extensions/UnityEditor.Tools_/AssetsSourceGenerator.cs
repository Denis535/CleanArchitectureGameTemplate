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

    public class AssetsSourceGenerator {

        // Generate
        public void Generate(string path, string @namespace, string @class, AddressableAssetSettings settings) {
            var builder = new StringBuilder();
            var treeList = AssetsSourceGeneratorHelper.GetTreeList( settings.GetEntries().Where( IsSupported ) );
            AppendCompilationUnit( builder, @namespace, @class, treeList );
            WriteText( path, builder.ToString() );
        }

        // AppendCompilationUnit
        private static void AppendCompilationUnit(StringBuilder builder, string @namespace, string @class, KeyValueTreeList<AddressableAssetEntry> treeList) {
            builder.AppendLine( $"namespace {@namespace} {{" );
            {
                AppendClass( builder, 1, @class, treeList.Items.ToArray() );
            }
            builder.AppendLine( "}" );
        }
        private static void AppendClass(StringBuilder builder, int indent, string @class, KeyValueTreeList<AddressableAssetEntry>.Item[] items) {
            builder.AppendIndent( indent ).AppendLine( $"public static class {@class} {{" );
            foreach (var item in Sort( items )) {
                AppendValueOrScope( builder, indent + 1, item );
            }
            builder.AppendIndent( indent ).AppendLine( "}" );
        }
        private static void AppendValueOrScope(StringBuilder builder, int indent, KeyValueTreeList<AddressableAssetEntry>.Item item) {
            if (item is KeyValueTreeList<AddressableAssetEntry>.ValueItem value) {
                var name = value.Key;
                var address = value.Value.address;
                if (value.Value.IsAsset()) {
                    builder.AppendIndent( indent ).AppendLine( $"public const string @{name} = \"{address}\";" );
                } else {
                    throw Exceptions.Internal.NotSupported( $"Entry {value.Value} is not supported" );
                }
            } else
            if (item is KeyValueTreeList<AddressableAssetEntry>.ListItem scope) {
                var name = scope.Key;
                var items = scope.Items;
                builder.AppendIndent( indent ).AppendLine( $"public static class @{name} {{" );
                foreach (var i in Sort( items )) {
                    AppendValueOrScope( builder, indent + 1, i );
                }
                builder.AppendIndent( indent ).AppendLine( "}" );
            }
        }

        // IsSupported
        public virtual bool IsSupported(AddressableAssetEntry entry) {
            return entry.MainAssetType != typeof( DefaultAsset );
        }

        // Helpers
        private static IEnumerable<KeyValueTreeList<AddressableAssetEntry>.Item> Sort(IEnumerable<KeyValueTreeList<AddressableAssetEntry>.Item> items) {
            return items
                .OrderByDescending( i => i.Key.Equals( "EditorSceneList" ) )
                .ThenByDescending( i => i.Key.Equals( "Resources" ) )

                .ThenByDescending( i => i.Key.Equals( "UnityEngine" ) )
                .ThenByDescending( i => i.Key.Equals( "UnityEditor" ) )

                .ThenByDescending( i => i.Key.Equals( "Scenes" ) )
                .ThenByDescending( i => i.Key.Equals( "Launcher" ) )
                .ThenByDescending( i => i.Key.Equals( "LauncherScene" ) )
                .ThenByDescending( i => i.Key.Equals( "Startup" ) )
                .ThenByDescending( i => i.Key.Equals( "StartupScene" ) )
                .ThenByDescending( i => i.Key.Equals( "Program" ) )
                .ThenByDescending( i => i.Key.Equals( "ProgramScene" ) )
                .ThenByDescending( i => i.Key.Equals( "MainScene" ) )
                .ThenByDescending( i => i.Key.Equals( "GameScene" ) )

                .ThenByDescending( i => i.Key.Equals( "Program" ) )
                .ThenByDescending( i => i.Key.Equals( "Presentation" ) )
                .ThenByDescending( i => i.Key.Equals( "UI" ) )
                .ThenByDescending( i => i.Key.Equals( "App" ) )
                .ThenByDescending( i => i.Key.Equals( "Game" ) )
                .ThenByDescending( i => i.Key.Equals( "Core" ) )
                .ThenByDescending( i => i.Key.Equals( "Internal" ) )

                .ThenByDescending( i => i.Key.Equals( "MainScreen" ) )
                .ThenByDescending( i => i.Key.Equals( "GameScreen" ) )

                .ThenByDescending( i => i.Key.Equals( "Objects" ) )
                .ThenByDescending( i => i.Key.Equals( "Subjects" ) )
                .ThenByDescending( i => i.Key.Equals( "World" ) )
                .ThenByDescending( i => i.Key.Equals( "Levels" ) )

                .ThenBy( i => i.Key );
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
