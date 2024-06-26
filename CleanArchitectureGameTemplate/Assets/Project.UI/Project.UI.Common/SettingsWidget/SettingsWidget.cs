﻿#nullable enable
namespace Project.UI.Common {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Framework.UI;
    using UnityEngine.UIElements;

    public class SettingsWidget : UIWidgetBase<SettingsWidgetView> {

        // Globals
        private UIFactory Factory { get; }
        // Children
        private ProfileSettingsWidget ProfileSettingsWidget => View.ProfileSettingsSlot.Child!;
        private VideoSettingsWidget VideoSettingsWidget => View.VideoSettingsSlot.Child!;
        private AudioSettingsWidget AudioSettingsWidget => View.AudioSettingsSlot.Child!;

        // Constructor
        public SettingsWidget() {
            Factory = Utils.Container.RequireDependency<UIFactory>( null );
            View = CreateView( this, Factory );
            this.AttachChild( new ProfileSettingsWidget() );
            this.AttachChild( new VideoSettingsWidget() );
            this.AttachChild( new AudioSettingsWidget() );
        }
        public override void Dispose() {
            base.Dispose();
        }

        // OnAttach
        public override void OnAttach(object? argument) {
        }
        public override void OnDetach(object? argument) {
        }

        // ShowWidget
        public override void ShowWidget(UIWidgetBase widget) {
            if (widget is ProfileSettingsWidget profileSettingsWidget) {
                View.ProfileSettingsSlot.Set( profileSettingsWidget );
                return;
            }
            if (widget is VideoSettingsWidget videoSettingsWidget) {
                View.VideoSettingsSlot.Set( videoSettingsWidget );
                return;
            }
            if (widget is AudioSettingsWidget audioSettingsWidget) {
                View.AudioSettingsSlot.Set( audioSettingsWidget );
                return;
            }
            base.ShowWidget( widget );
        }
        public override void HideWidget(UIWidgetBase widget) {
            if (widget is ProfileSettingsWidget profileSettingsWidget) {
                View.ProfileSettingsSlot.Clear( profileSettingsWidget );
                return;
            }
            if (widget is VideoSettingsWidget videoSettingsWidget) {
                View.VideoSettingsSlot.Clear( videoSettingsWidget );
                return;
            }
            if (widget is AudioSettingsWidget audioSettingsWidget) {
                View.AudioSettingsSlot.Clear( audioSettingsWidget );
                return;
            }
            base.HideWidget( widget );
        }

        // Helpers
        private static SettingsWidgetView CreateView(SettingsWidget widget, UIFactory factory) {
            var view = new SettingsWidgetView( factory );
            view.Widget.OnChangeAny( evt => {
                view.Okey.SetValid( view.TabView.__GetVisualElement__().IsContentValid() );
            } );
            view.Okey.OnClick( evt => {
                if (view.Okey.IsValid()) {
                    widget.DetachSelf( DetachReason.Submit );
                }
            } );
            view.Back.OnClick( evt => {
                widget.DetachSelf( DetachReason.Cancel );
            } );
            return view;
        }

    }
}
