#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class PlayerView : UIViewBase {

        // VisualElement
        public override VisualElement VisualElement { get; }
        public ElementWrapper Group { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public PopupFieldWrapper<object> Role { get; }
        public ToggleFieldWrapper<bool> IsReady { get; }

        // Constructor
        public PlayerView(UIFactory factory) {
            VisualElement = factory.PlayerGroup( out var group, out var title, out var name, out var role, out var isReady );
            Group = group.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Role = role.Wrap();
            IsReady = isReady.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
