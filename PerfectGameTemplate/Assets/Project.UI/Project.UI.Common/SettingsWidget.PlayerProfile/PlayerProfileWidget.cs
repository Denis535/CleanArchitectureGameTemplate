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
            var view = UIViewFactory.PlayerProfileWidget( widget );
            view.OnEvent( (PlayerProfileWidgetView.NameEvent evt) => {
                view.Name.IsValid = Globals.PlayerProfile.IsNameValid( evt.Name );
                view.Okey.IsValid = view.Name.IsValid;
            } );
            view.OnCommand( (PlayerProfileWidgetView.OkeyCommand cmd) => {
                if (!cmd.IsValid) {
                    if (string.IsNullOrWhiteSpace( cmd.Sender.Name.Value )) {
                        var dialog = UIWidgetFactory.WarningDialogWidget( "Warning", $"Name is empty" ).OnSubmit( "Ok", null );
                        widget.AttachChild( dialog );
                        return;
                    } else {
                        var dialog = UIWidgetFactory.WarningDialogWidget( "Warning", $"Name \"{cmd.Sender.Name.Value}\" is invalid" ).OnSubmit( "Ok", null );
                        widget.AttachChild( dialog );
                        return;
                    }
                }
                playerProfile.PlayerName = cmd.Sender.Name.Value!;
                playerProfile.Save();
                widget.DetachSelf();
            } );
            view.OnCommand( (PlayerProfileWidgetView.BackCommand cmd) => {
                widget.DetachSelf();
            } );
            return view;
        }

    }
}
