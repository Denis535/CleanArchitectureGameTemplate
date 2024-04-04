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

    public class PlayerDescWidget : UIWidgetBase<PlayerDescWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        private Globals.ProfileSettings ProfileSettings { get; }
        // View
        public string Name => View.Name.Value!;
        public PlayerRole Role => (PlayerRole) View.Role.Value!;
        public bool IsReady => View.IsReady.Value;

        // Constructor
        public PlayerDescWidget() {
            Factory = this.GetDependencyContainer().RequireDependency<UIFactory>( null );
            ProfileSettings = this.GetDependencyContainer().RequireDependency<Globals.ProfileSettings>( null );
            View = CreateView( Factory, ProfileSettings );
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
        private static PlayerDescWidgetView CreateView(UIFactory factory, Globals.ProfileSettings profileSettings) {
            var view = new PlayerDescWidgetView( factory );
            view.Group.OnAttachToPanel( evt => {
                view.Name.Value = profileSettings.Name;
                view.Role.ValueChoices = (PlayerRole.Human, Enum2.GetValues<PlayerRole>().Cast<object?>().ToArray());
                view.IsReady.Value = false;
            } );
            return view;
        }

    }
}
