#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class PlayerProfileWidget : UIWidgetBase<PlayerProfileWidgetView> {

        // Globals
        private Globals.PlayerProfile PlayerProfile { get; }
        // View
        public override PlayerProfileWidgetView View { get; }

        // Constructor
        public PlayerProfileWidget() {
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            View = CreateView( this, PlayerProfile );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnBeforeAttach() {
            View.Name.Value = PlayerProfile.PlayerName;
            View.Name.IsValid = Globals.PlayerProfile.IsNameValid( View.Name.Value );
            View.Okey.IsValid = Globals.PlayerProfile.IsNameValid( View.Name.Value );
        }
        public override void OnAttach() {
        }
        public override void OnDetach() {
        }
        public override void OnAfterDetach() {
            PlayerProfile.Load();
        }

        // Helpers
        private static PlayerProfileWidgetView CreateView(PlayerProfileWidget widget, Globals.PlayerProfile playerProfile) {
            var view = new PlayerProfileWidgetView( widget );
            view.Name.OnChange( (i, name) => {
                view.Name.IsValid = Globals.PlayerProfile.IsNameValid( name! );
                view.Okey.IsValid = Globals.PlayerProfile.IsNameValid( name! );
            } );
            view.Okey.OnClick( i => {
                if (i.IsValid) {
                    playerProfile.PlayerName = view.Name.Value!;
                    playerProfile.Save();
                    widget.DetachSelf();
                } else {
                    if (string.IsNullOrWhiteSpace( view.Name.Value )) {
                        var dialog = new WarningDialogWidget( "Warning", $"Name is empty" ).OnSubmit( "Ok", null );
                        widget.AttachChild( dialog );
                    } else {
                        var dialog = new WarningDialogWidget( "Warning", $"Name \"{view.Name.Value}\" is invalid" ).OnSubmit( "Ok", null );
                        widget.AttachChild( dialog );
                    }
                }
            } );
            view.Back.OnClick( i => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
