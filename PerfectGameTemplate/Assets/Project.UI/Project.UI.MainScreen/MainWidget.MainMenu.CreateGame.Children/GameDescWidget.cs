#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.Entities.GameScene;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

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
            View.Name.Value = "Anonymous";
            View.Mode.ValueChoices = (GameMode._1x4, Enum2.GetValues<GameMode>().Cast<object?>().ToArray());
            View.World.ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>().Cast<object?>().ToArray());
            View.IsPrivate.Value = true;
        }
        public override void OnDetach() {
        }

    }
}
