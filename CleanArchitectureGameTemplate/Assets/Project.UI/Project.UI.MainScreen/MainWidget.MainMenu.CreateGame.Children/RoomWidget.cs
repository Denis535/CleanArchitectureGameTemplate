#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class RoomWidget : UIWidgetBase<RoomWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // View
        protected override RoomWidgetView View { get; }

        // Constructor
        public RoomWidget() {
            Factory = this.GetDependencyContainer().Resolve<UIFactory>( null );
            View = new RoomWidgetView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            for (var i = 1; i <= 32; i++) {
                View.Players.Add( Factory.PlayerItem( $"Player: {i}", i - 1 ) );
            }
        }
        public override void OnDetach() {
        }

    }
}
