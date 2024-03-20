﻿#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class SettingsWidgetView : UIViewBase {

        // VisualElement
        protected override VisualElement VisualElement { get; }
        public ElementWrapper Widget { get; }
        public LabelWrapper Title { get; }
        public SlotWrapper ProfileSettingsSlot { get; }
        public SlotWrapper VideoSettingsSlot { get; }
        public SlotWrapper AudioSettingsSlot { get; }
        public ButtonWrapper Okey { get; }
        public ButtonWrapper Back { get; }

        // Constructor
        public SettingsWidgetView(UIFactory factory) {
            VisualElement = factory.SettingsWidget( out var widget, out var title, out var profileSettingsSlot, out var videoSettingsSlot, out var audioSettingsSlot, out var okey, out var back );
            Widget = widget.Wrap();
            Title = title.Wrap();
            ProfileSettingsSlot = profileSettingsSlot.AsSlot();
            VideoSettingsSlot = videoSettingsSlot.AsSlot();
            AudioSettingsSlot = audioSettingsSlot.AsSlot();
            Okey = okey.Wrap();
            Back = back.Wrap();
        }
        public override void Dispose() {
            base.Dispose();
        }

    }
}
