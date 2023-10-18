#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class PlayerProfileWidgetView : UIWidgetViewBase {

        // View
        public override VisualElement VisualElement { get; }
        public ElementWrapper View { get; }
        public LabelWrapper Title { get; }
        public TextWrapper<string> Name { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public PlayerProfileWidgetView(PlayerProfileWidget widget) : base( widget ) {
            VisualElement = CreateVisualElement( out var view, out var title, out var name, out var okey, out var back );
            View = view.Wrap();
            Title = title.Wrap();
            Name = name.Wrap();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

        // Helpers
        private static View CreateVisualElement(out View view, out Label title, out TextField name, out Button okey, out Button back) {
            return view = UIFactory.MediumWidget( "player-profile-widget-view" ).Children(
                UIFactory.Card().Children(
                    UIFactory.Header().Children(
                        title = UIFactory.Label( "Player Profile" ).Name( "title" )
                    ),
                    UIFactory.Content().Children(
                        UIFactory.ColumnGroup().Classes( "dark2", "large", "grow-1" ).Children(
                            name = UIFactory.TextField( "Name", 16, false ).Name( "name" ).Classes( "label-width-25" )
                        )
                    ),
                    UIFactory.Footer().Children(
                        okey = UIFactory.Button( "Ok" ).Name( "okey" ),
                        back = UIFactory.Button( "Back" ).Name( "back" )
                    )
                )
            );
        }

    }
}
