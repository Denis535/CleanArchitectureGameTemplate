#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class AccountSettingsWidgetView : UIViewBase {

        // VisualElement
        protected override VisualElement VisualElement { get; }
        public ElementWrapper Scope { get; }
        public TextFieldWrapper<string> Name { get; }

        // Constructor
        public AccountSettingsWidgetView(UIFactory factory) {
            VisualElement = factory.AccountSettingsWidget( out var scope, out var name );
            Scope = scope.Wrap();
            Name = name.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
