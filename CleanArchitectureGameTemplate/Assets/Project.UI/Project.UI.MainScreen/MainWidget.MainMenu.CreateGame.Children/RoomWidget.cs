#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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
            View = CreateView( this, Factory );
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
        private static RoomWidgetView CreateView(RoomWidget widget, UIFactory factory) {
            var view = new RoomWidgetView( factory );
            view.Group.OnAttachToPanel( evt => {
                for (var i = 1; i <= 32; i++) {
                    view.Players.Add( factory.PlayerItem( $"Player: {view.Players.Children.Count() + 1}", view.Players.Children.Count() ) );
                }
            } );
            return view;
        }

    }
}
