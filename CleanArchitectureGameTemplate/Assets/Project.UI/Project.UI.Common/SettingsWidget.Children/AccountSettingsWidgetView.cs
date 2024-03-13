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
        public ElementWrapper Group { get; }
        public TextFieldWrapper<string> Name { get; }

        // Constructor
        public AccountSettingsWidgetView(UIFactory factory) {
            VisualElement = factory.AccountSettingsWidget( out var group, out var name );
            Group = group.Wrap();
            Name = name.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
