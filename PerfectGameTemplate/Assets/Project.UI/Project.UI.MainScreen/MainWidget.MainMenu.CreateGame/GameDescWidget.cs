#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class GameDescWidget : UIWidgetBase<GameDescWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // View
        public override GameDescWidgetView View { get; }

        // Constructor
        public GameDescWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = new GameDescWidgetView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }

    }
    public class GameDescWidgetView : UIViewBase {

        // VisualElement
        public override VisualElement VisualElement { get; }
        public ElementWrapper Group { get; }
        public LabelWrapper Title { get; }
        public TextFieldWrapper<string> Name { get; }
        public PopupFieldWrapper<object> Mode { get; }
        public PopupFieldWrapper<object> World { get; }
        public ToggleFieldWrapper<bool> IsPrivate { get; }

        // Constructor
        public GameDescWidgetView(UIFactory factory) {
            VisualElement = factory.GameDescWidget( out var group, out var title, out var name, out var mode, out var world, out var isPrivate );
            Group = group.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Mode = mode.Wrap();
            World = world.Wrap();
            IsPrivate = isPrivate.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
