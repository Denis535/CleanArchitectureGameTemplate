#nullable enable
namespace System.Collections.Generic {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class KeyValueTreeList {

        // Create
        public static KeyValueTreeList<T> Create<T>(IEnumerable<(string[] Dir, string Key, T Value)> items) {
            var treeList = new KeyValueTreeList<T>();
            foreach (var (keys, key, value) in items) {
                treeList.AddValue( keys, key, value );
            }
            return treeList;
        }
        public static KeyValueTreeList<T> Create<T>(IEnumerable<(string[] Dir, T Value)> items) {
            var treeList = new KeyValueTreeList<T>();
            foreach (var (keys, value) in items) {
                treeList.AddValue( keys.SkipLast( 1 ), keys.Last(), value );
            }
            return treeList;
        }

    }
    public partial class KeyValueTreeList<T> {
        internal interface IList {
            List<KeyValueTreeList<T>.Item> Items { get; }
        }
        public abstract class Item {
            public string Key { get; }
            public Item(string key) {
                Key = key;
            }
        }
        public class ValueItem : Item {
            public T Value { get; }
            public ValueItem(string key, T value) : base( key ) {
                Value = value;
            }
        }
        public class ListItem : Item, IList {
            public List<KeyValueTreeList<T>.Item> Items { get; } = new List<KeyValueTreeList<T>.Item>( 0 );
            public ListItem(string key) : base( key ) {
            }
        }
    }
    public partial class KeyValueTreeList<T> : KeyValueTreeList<T>.IList {

        public List<KeyValueTreeList<T>.Item> Items { get; } = new List<Item>();

        // Constructor
        public KeyValueTreeList() {
        }

        // GetValue
        public T? GetValue(IEnumerable<string> keys, string key) {
            var list = this.GetList( keys );
            if (list != null) {
                return list.Items.OfType<ValueItem>().Where( i => i.Key == key ).Select( i => i.Value ).FirstOrDefault();
            }
            return default;
        }
        public T[]? GetValues(IEnumerable<string> keys, string key) {
            var list = this.GetList( keys );
            if (list != null) {
                return list.Items.OfType<ValueItem>().Where( i => i.Key == key ).Select( i => i.Value ).ToArray().NullIfEmpty();
            }
            return default;
        }
        // AddValue
        public void AddValue(IEnumerable<string> keys, string key, T value) {
            var list = this.GetOrAddList( keys );
            list.Items.Add( new ValueItem( key, value ) );
        }
        public void AddValues(IEnumerable<string> keys, string key, params T[] values) {
            var list = this.GetOrAddList( keys );
            foreach (var value in values) {
                list.Items.Add( new ValueItem( key, value ) );
            }
        }
        // RemoveAll
        public int RemoveAll(IEnumerable<string> keys, string key) {
            var list = this.GetList( keys );
            if (list != null) {
                return list.Items.RemoveAll( i => i.Key == key );
            }
            return 0;
        }

        // Sort
        public void Sort(Comparison<Item> comparison) {
            this.Sort_( comparison );
        }

        // Utils
        public override string ToString() {
            var builder = new StringBuilder();
            builder.AppendObject( this );
            return builder.ToString();
        }

    }
    internal static class KeyValueTreeListHelper {

        // GetList
        public static KeyValueTreeList<T>.IList? GetList<T>(this KeyValueTreeList<T>.IList list, IEnumerable<string> keys) {
            var result = list;
            foreach (var key in keys) {
                result = result.GetList( key );
                if (result == null) break;
            }
            return result;
        }
        public static KeyValueTreeList<T>.IList GetOrAddList<T>(this KeyValueTreeList<T>.IList list, IEnumerable<string> keys) {
            var result = list;
            foreach (var key in keys) {
                result = result.GetOrAddList( key );
            }
            return result;
        }

        // GetList
        private static KeyValueTreeList<T>.ListItem? GetList<T>(this KeyValueTreeList<T>.IList list, string key) {
            var result = list.Items.OfType<KeyValueTreeList<T>.ListItem>().Where( i => i.Key == key ).FirstOrDefault();
            return result;
        }
        private static KeyValueTreeList<T>.ListItem GetOrAddList<T>(this KeyValueTreeList<T>.IList list, string key) {
            var result = list.Items.OfType<KeyValueTreeList<T>.ListItem>().Where( i => i.Key == key ).FirstOrDefault();
            if (result == null) {
                result = new KeyValueTreeList<T>.ListItem( key );
                list.Items.Add( result );
            }
            return result;
        }

        // Sort
        public static void Sort_<T>(this KeyValueTreeList<T>.IList list, Comparison<KeyValueTreeList<T>.Item> comparison) {
            list.Items.Sort( comparison );
            foreach (var item in list.Items.OfType<KeyValueTreeList<T>.ListItem>()) {
                item.Sort_( comparison );
            }
        }

        // AppendObject
        public static void AppendObject<T>(this StringBuilder builder, KeyValueTreeList<T> list) {
            builder.Append( "KeyValueTreeList:" );
            foreach (var item in list.Items) {
                builder.AppendObject( item.Key, item );
            }
        }
        public static void AppendObject<T>(this StringBuilder builder, string path, KeyValueTreeList<T>.Item item) {
            if (item is KeyValueTreeList<T>.ValueItem value) {
                builder.AppendLine();
                builder.Append( path ).Append( ": " ).Append( value.Value );
            } else
            if (item is KeyValueTreeList<T>.ListItem list) {
                foreach (var i in list.Items) {
                    builder.AppendObject( $"{path}/{i.Key}", i );
                }
            }
        }

    }
}
