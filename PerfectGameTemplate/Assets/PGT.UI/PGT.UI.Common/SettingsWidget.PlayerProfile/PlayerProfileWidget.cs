#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using UnityEngine;
    using UnityEngine.Framework.UI;

    public class PlayerProfileWidget : UIWidget2<PlayerProfileWidgetView> {

        private Globals.PlayerProfile PlayerProfile => Singleton.GetInstance<Globals.PlayerProfile>();

        // Constructor
        public PlayerProfileWidget() {
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
        }
        public override void OnShow() {
        }
        public override void OnHide() {
        }
        public override void OnDetach() {
            PlayerProfile.Load();
        }

        // Helpers/View
        private PlayerProfileWidgetView CreateView() {
            var view = UIVisualFactory.PlayerProfileWidget( PlayerProfile );
            view.OnEvent( (PlayerProfileWidgetView.NameEvent evt) => {
                view.Name.IsValid = Globals.PlayerProfile.IsNameValid( evt.Name );
                view.Okey.IsValid = view.Name.IsValid;
            } );
            view.OnCommand( (PlayerProfileWidgetView.OkeyCommand cmd) => {
                if (!cmd.IsValid) {
                    if (string.IsNullOrWhiteSpace( cmd.Sender.Name.Value )) {
                        var dialog = UILogicalFactory.WarningDialogWidget( "Warning", $"Name is empty" ).SetConfirm( "Ok", null );
                        Router.AttachChild( dialog );
                        return;
                    } else {
                        var dialog = UILogicalFactory.WarningDialogWidget( "Warning", $"Name \"{cmd.Sender.Name.Value}\" is invalid" ).SetConfirm( "Ok", null );
                        Router.AttachChild( dialog );
                        return;
                    }
                }
                PlayerProfile.PlayerName = cmd.Sender.Name.Value;
                PlayerProfile.Save();
                Router.DetachSelf();
            } );
            view.OnCommand( (PlayerProfileWidgetView.BackCommand cmd) => {
                Router.DetachSelf();
            } );
            view.OnCommand( (PlayerProfileWidgetView.SubmitCommand cmd) => {
            } );
            view.OnCommand( (PlayerProfileWidgetView.CancelCommand cmd) => {
                Router.DetachSelf();
            } );
            return view;
        }

    }
}
