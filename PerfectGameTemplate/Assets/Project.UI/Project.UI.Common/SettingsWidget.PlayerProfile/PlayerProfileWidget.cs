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

        // Constructor
        public PlayerProfileWidget() {
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>( null );
            View = CreateView();
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
        private PlayerProfileWidgetView CreateView() {
            var view = UIViewFactory.PlayerProfileWidget();
            view.OnEvent( (PlayerProfileWidgetView.NameEvent evt) => {
                view.Name.IsValid = Globals.PlayerProfile.IsNameValid( evt.Name );
                view.Okey.IsValid = view.Name.IsValid;
            } );
            view.OnCommand( (PlayerProfileWidgetView.OkeyCommand cmd) => {
                if (!cmd.IsValid) {
                    if (string.IsNullOrWhiteSpace( cmd.Sender.Name.Value )) {
                        var dialog = UIWidgetFactory.WarningDialogWidget( "Warning", $"Name is empty" ).OnSubmit( "Ok", null );
                        this.AttachChild( dialog );
                        return;
                    } else {
                        var dialog = UIWidgetFactory.WarningDialogWidget( "Warning", $"Name \"{cmd.Sender.Name.Value}\" is invalid" ).OnSubmit( "Ok", null );
                        this.AttachChild( dialog );
                        return;
                    }
                }
                PlayerProfile.PlayerName = cmd.Sender.Name.Value!;
                PlayerProfile.Save();
                this.DetachSelf();
            } );
            view.OnCommand( (PlayerProfileWidgetView.BackCommand cmd) => {
                this.DetachSelf();
            } );
            return view;
        }

    }
}
