#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class GameDescWidget : UIWidgetBase<GameDescWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // View
        public string Name => View.Name.Value!;
        public GameMode Mode => (GameMode) View.Mode.Value!;
        public GameWorld World => (GameWorld) View.World.Value!;
        public bool IsPrivate => View.IsPrivate.Value;

        // Constructor
        public GameDescWidget() {
            Factory = this.GetDependencyContainer().RequireDependency<UIFactory>( null );
            View = CreateView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
        }
        public override void OnDetach(object? argument) {
        }

        // Helpers
        private static GameDescWidgetView CreateView(UIFactory factory) {
            var view = new GameDescWidgetView( factory );
            view.Group.OnAttachToPanel( evt => {
                view.Name.Value = "Anonymous";
                view.Mode.ValueChoices = (GameMode._1x4, Enum2.GetValues<GameMode>().Cast<object?>().ToArray());
                view.World.ValueChoices = (GameWorld.World1, Enum2.GetValues<GameWorld>().Cast<object?>().ToArray());
                view.IsPrivate.Value = true;
            } );
            return view;
        }

    }
}
