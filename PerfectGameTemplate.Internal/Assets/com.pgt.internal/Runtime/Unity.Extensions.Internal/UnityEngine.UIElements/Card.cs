#nullable enable
namespace UnityEngine.UIElements {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Scripting;

    public class Card : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<Card, UxmlTraits> { }

        public Card() {
            AddToClassList( "unity-card" );
        }

    }
    // Header
    public class Header : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<Header, UxmlTraits> { }

        public Header() {
            AddToClassList( "unity-header" );
        }

    }
    // Content
    public class Content : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<Content, UxmlTraits> { }

        public Content() {
            AddToClassList( "unity-content" );
        }

    }
    // Footer
    public class Footer : VisualElement {
        [Preserve]
        public new class UxmlFactory : UxmlFactory<Footer, UxmlTraits> { }

        public Footer() {
            AddToClassList( "unity-footer" );
        }

    }
}
