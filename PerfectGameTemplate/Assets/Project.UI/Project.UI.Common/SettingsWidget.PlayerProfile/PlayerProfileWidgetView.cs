#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class PlayerProfileWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public PlayerProfileWidgetView(PlayerProfileWidget widget, UIFactory factory) : base( widget ) {
            VisualElement = factory.PlayerProfileWidget( out var view, out var title, out var name, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
