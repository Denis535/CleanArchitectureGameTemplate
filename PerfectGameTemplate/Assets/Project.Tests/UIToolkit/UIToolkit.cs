#nullable enable
namespace UIToolkit {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class UIToolkit : ApiReferenceBase {

        // Validate
        [Test]
        public override void Validate() {
            var actual = GetReference().OfType<Type>().ToArray();
            var expected = typeof( VisualElement ).Assembly.GetExportedTypes().Where( i => typeof( VisualElement ).IsAssignableFrom( i ) ).ToArray();
            AssertThatTypesAreEqual( actual, expected );
        }

        // GetReference
        public override object[] GetReference() {
            return new object[] {
                "UnityEngine.UIElements",
                // Base
                typeof( VisualElement ),
                typeof( BindableElement ),
                typeof( ImmediateModeElement ),

                // Text
                typeof( TextElement ),
                typeof( PopupWindow ),
                typeof( Button ),
                typeof( RepeatButton ),
                typeof( Label ),
                // Image
                typeof( Image ),
                // Field
                typeof( BaseField<> ),
                typeof( EnumField ),
                typeof( BoundsField ),
                typeof( BoundsIntField ),
                typeof( RadioButtonGroup ),
                // Field/Text
                typeof( TextInputBaseField<> ),
                typeof( TextField ),
                typeof( Hash128Field ),
                // Field/Text/Value
                typeof( TextValueField<> ),
                typeof( IntegerField ),
                typeof( LongField ),
                typeof( FloatField ),
                typeof( DoubleField ),
                // Field/Bool
                typeof( BaseBoolField ),
                typeof( RadioButton ),
                typeof( Toggle ),
                // Field/Slider
                typeof( BaseSlider<> ),
                typeof( Slider ),
                typeof( MinMaxSlider ),
                typeof( SliderInt ),
                // Field/Popup
                typeof( BasePopupField<,> ),
                typeof( PopupField<> ),
                typeof( DropdownField ),
                // Field/Composite
                typeof( BaseCompositeField<,,> ),
                typeof( Vector2Field ),
                typeof( Vector2IntField ),
                typeof( Vector3Field ),
                typeof( Vector3IntField ),
                typeof( Vector4Field ),
                typeof( RectField ),
                typeof( RectIntField ),
                // Foldout
                typeof( Foldout ),
                // ProgressBar
                typeof( AbstractProgressBar ),
                typeof( ProgressBar ),

                // Container
                typeof( TemplateContainer ),
                typeof( IMGUIContainer ),
                // View/Scroll
                typeof( ScrollView ),
                typeof( Scroller ),
                // View/Split
                typeof( TwoPaneSplitView ),
                // View/Collection
                typeof( BaseVerticalCollectionView ),
                // View/Collection/List
                typeof( BaseListView ),
                typeof( ListView ),
                typeof( MultiColumnListView ),
                // View/Collection/Tree
                typeof( BaseTreeView ),
                typeof( TreeView ),
                typeof( MultiColumnTreeView ),
                // Box
                typeof( Box ),
                typeof( GroupBox ),
                typeof( HelpBox ),
            };
        }

    }
}
