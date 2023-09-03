#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Scripting;

    public class ColumnScope : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<ColumnScope, UxmlTraits> { }

        public ColumnScope() {
            AddToClassList( "unity-scope" );
            AddToClassList( "unity-column-scope" );
        }

    }
    public class RowScope : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<RowScope, UxmlTraits> { }

        public RowScope() {
            AddToClassList( "unity-scope" );
            AddToClassList( "unity-row-scope" );
        }

    }
}
