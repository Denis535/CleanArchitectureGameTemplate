#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class RootWidget2 : RootWidget {

        // Constructor
        public RootWidget2() {
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
            base.OnAttach( argument );
        }
        public override void OnDetach(object? argument) {
            base.OnDetach( argument );
        }

        // RecalcVisibility
        protected override void RecalcVisibility() {
            base.RecalcVisibility();
        }
        protected override void RecalcWidgetVisibility(UIWidgetBase widget, bool isLast) {
            if (!isLast) {
                // hide covered widgets
                widget.SetEnabled( true );
                if (widget is not MainWidget and not GameWidget) {
                    widget.SetDisplayed( false );
                }
            } else {
                // show new widget or unhide uncovered widget
                widget.SetEnabled( !View.ModalWidgetSlot.Any() );
                widget.SetDisplayed( true );
            }
        }
        protected override void RecalcModalWidgetVisibility(UIWidgetBase widget, bool isLast) {
            base.RecalcModalWidgetVisibility( widget, isLast );
        }

    }
}
