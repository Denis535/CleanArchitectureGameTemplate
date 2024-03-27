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
        private IReadOnlyList<RoomWidgetView_PlayerView> Players => View.PlayersSlot.Views;

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
                for (var i = 0; i <= 60; i++) {
                    var player = new RoomWidgetView_PlayerView( factory, $"Player: {view.PlayersSlot.Views.Count}", view.PlayersSlot.Views.Count );
                    view.PlayersSlot.Add( player );
                }
            } );
            return view;
        }

    }
}
