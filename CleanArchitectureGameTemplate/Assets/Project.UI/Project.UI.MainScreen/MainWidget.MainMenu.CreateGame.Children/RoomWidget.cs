#nullable enable
namespace Project.UI.MainScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
            View = CreateView( Factory );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override async void OnAfterAttach() {
            base.OnAfterAttach();
            while (IsAttaching || IsAttached) {
                View.Players.Add( Factory.PlayerItem( $"Player: {View.Players.Children.Count + 1}", View.Players.Children.Count ) );
                await Task.Delay( 2000 );
            }
        }
        public override void OnBeforeDetach() {
            base.OnBeforeDetach();
        }
        public override void OnDetach() {
        }

        // Helpers
        private static RoomWidgetView CreateView(UIFactory factory) {
            var view = new RoomWidgetView( factory );
            return view;
        }

    }
}
