#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Scripting;

    public class ColumnGroup : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<ColumnGroup, UxmlTraits> { }

        public ColumnGroup() {
            AddToClassList( "unity-group" );
            AddToClassList( "unity-column-group" );
        }

    }
    public class RowGroup : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<RowGroup, UxmlTraits> { }

        public RowGroup() {
            AddToClassList( "unity-group" );
            AddToClassList( "unity-row-group" );
        }

    }
}
