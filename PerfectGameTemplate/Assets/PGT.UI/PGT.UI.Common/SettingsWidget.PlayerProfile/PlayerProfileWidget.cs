#nullable enable
namespace PGT.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.UI;

    public class PlayerProfileWidget : UIWidget2<PlayerProfileWidgetView> {

        // Globals
        private Globals.PlayerProfile PlayerProfile { get; }

        // Constructor
        public PlayerProfileWidget() {
            PlayerProfile = this.GetDependencyContainer().Resolve<Globals.PlayerProfile>();
            View = CreateView();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach() {
            View.Name.Value = PlayerProfile.PlayerName;
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
            var view = UIVisualFactory.PlayerProfileWidget();
            view.OnEvent( (PlayerProfileWidgetView.NameEvent evt) => {
                view.Name.IsValid = Globals.PlayerProfile.IsNameValid( evt.Name );
                view.Okey.IsValid = view.Name.IsValid;
            } );
            view.OnCommand( (PlayerProfileWidgetView.OkeyCommand cmd) => {
                if (!cmd.IsValid) {
                    if (string.IsNullOrWhiteSpace( cmd.Sender.Name.Value )) {
                        var dialog = UILogicalFactory.WarningDialogWidget( "Warning", $"Name is empty" ).Submit( "Ok", null );
                        this.AttachChild( dialog );
                        return;
                    } else {
                        var dialog = UILogicalFactory.WarningDialogWidget( "Warning", $"Name \"{cmd.Sender.Name.Value}\" is invalid" ).Submit( "Ok", null );
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
