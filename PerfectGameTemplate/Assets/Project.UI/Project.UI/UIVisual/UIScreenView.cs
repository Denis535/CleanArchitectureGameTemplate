#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.UIElements;

    public class UIScreenView : UIScreenViewBase {

        // View
        private readonly VisualElement visualElement;
        private readonly VisualElement viewsContainer = default!;
        private readonly VisualElement modalViewsContainer = default!;
        // View
        public override VisualElement VisualElement => visualElement;
        // Assets
        private AudioClip Window = default!;
        private AudioClip InfoWindow = default!;
        private AudioClip WarningWindow = default!;
        private AudioClip ErrorWindow = default!;
        private AudioClip Focus = default!;
        private AudioClip Click = default!;
        private AudioClip Select = default!;
        private AudioClip ConfirmSelect = default!;
        private AudioClip CancelSelect = default!;
        private AudioClip InvalidSelect = default!;
        private AudioClip Tik = default!;

        // Constructor
        public UIScreenView(UIScreen screen) : base( screen ) {
            visualElement = CreateVisualElement( out viewsContainer, out modalViewsContainer );
            // Assets
            Window = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window ).GetResult();
            InfoWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Info ).GetResult();
            WarningWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Warning ).GetResult();
            ErrorWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Error ).GetResult();
            Focus = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Focus ).GetResult();
            Click = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Click ).GetResult();
            Select = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select ).GetResult();
            ConfirmSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Confirm ).GetResult();
            CancelSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Cancel ).GetResult();
            InvalidSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Invalid ).GetResult();
            Tik = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Tick ).GetResult();
        }
        public override void Dispose() {
            Addressables2.Release( Window );
            Addressables2.Release( InfoWindow );
            Addressables2.Release( WarningWindow );
            Addressables2.Release( ErrorWindow );
            Addressables2.Release( Focus );
            Addressables2.Release( Click );
            Addressables2.Release( Select );
            Addressables2.Release( ConfirmSelect );
            Addressables2.Release( CancelSelect );
            Addressables2.Release( InvalidSelect );
            Addressables2.Release( Tik );
            base.Dispose();
        }

        // ShowView
        public override void ShowView(UIWidgetViewBase view, UIWidgetViewBase[] shadowed) {
            view.VisualElement.OnEvent<AttachToPanelEvent>( PlayAttach );
            view.VisualElement.OnEventTrickleDown<FocusEvent>( PlayFocus );
            view.VisualElement.OnEventTrickleDown<ClickEvent>( PlayClick );
            view.VisualElement.OnEventTrickleDown<ChangeEvent<object>>( PlayChange );
            view.VisualElement.OnEventTrickleDown<ChangeEvent<string>>( PlayChange );
            view.VisualElement.OnEventTrickleDown<ChangeEvent<int>>( PlayChange );
            view.VisualElement.OnEventTrickleDown<ChangeEvent<float>>( PlayChange );
            view.VisualElement.OnEventTrickleDown<ChangeEvent<bool>>( PlayChange );
            view.VisualElement.OnEventTrickleDown<NavigationSubmitEvent>( OnSubmit );
            view.VisualElement.OnEventTrickleDown<NavigationCancelEvent>( OnCancel );
            var shadowed_ = shadowed.LastOrDefault();
            if (shadowed_ is MainWidgetView or GameWidgetView || shadowed_.IsModal()) {
                ShowView( view, null );
            } else {
                ShowView( view, shadowed_ );
            }
        }
        public override void HideView(UIWidgetViewBase view, UIWidgetViewBase[] unshadowed) {
            var unshadowed_ = unshadowed.LastOrDefault();
            if (unshadowed_ is MainWidgetView or GameWidgetView || unshadowed_.IsModal()) {
                HideView( view, null );
            } else {
                HideView( view, unshadowed_ );
            }
        }

        // ShowView
        private void ShowView(UIWidgetViewBase view, UIWidgetViewBase? shadowed) {
            if (shadowed != null) {
                SaveFocus( shadowed );
            }
            if (!view.IsModal()) {
                AddView( viewsContainer, view, shadowed );
            } else {
                AddModalView( modalViewsContainer, view, shadowed );
            }
            SetFocus( view );
        }
        private void HideView(UIWidgetViewBase view, UIWidgetViewBase? unshadowed) {
            if (!view.IsModal()) {
                RemoveView( viewsContainer, view, unshadowed );
            } else {
                RemoveModalView( modalViewsContainer, view, unshadowed );
            }
            if (unshadowed != null) {
                LoadFocus( unshadowed );
            }
        }

        // PlaySfx
        private void PlayAttach(AttachToPanelEvent evt) {
            var target = (VisualElement) evt.target;
            if (target.name == "game-menu-widget-view") {
                this.PlayClip( Select );
            } else
            if (target.name == "dialog-widget-view") {
                this.PlayClip( InfoWindow );
            } else
            if (target.name == "info-dialog-widget-view") {
                this.PlayClip( InfoWindow );
            } else
            if (target.name == "warning-dialog-widget-view") {
                this.PlayClip( WarningWindow );
            } else
            if (target.name == "error-dialog-widget-view") {
                this.PlayClip( ErrorWindow );
            }
        }
        private void PlayFocus(FocusEvent evt) {
            if (evt.direction != FocusChangeDirection.none && evt.direction != FocusChangeDirection.unspecified) {
                this.PlayClip( Focus );
            }
        }
        private void PlayClick(ClickEvent evt) {
            if (evt.target is Button button) {
                if (!button.IsValid()) {
                    this.PlayClip( InvalidSelect );
                } else
                if (button.IsSubmit()) {
                    this.PlayClip( ConfirmSelect );
                } else
                if (button.IsCancel()) {
                    this.PlayClip( CancelSelect );
                } else {
                    this.PlayClip( Select );
                }
            }
        }
        private void PlayChange<T>(ChangeEvent<T> evt) {
            if (evt.target is BaseField<T> && evt.target.GetType().Name != "ScrollerSlider") {
                if (evt is ChangeEvent<int> evt_int) {
                    if (evt_int.newValue != evt_int.previousValue) {
                        if (!this.IsClipPlaying( Tik, out var time ) || time > 0.025f) {
                            this.PlayClip( Tik );
                        }
                    }
                } else
                if (evt is ChangeEvent<float> evt_float) {
                    if (Mathf.RoundToInt( evt_float.newValue * 200 ) != Mathf.RoundToInt( evt_float.previousValue * 200 )) {
                        if (!this.IsClipPlaying( Tik, out var time ) || time > 0.025f) {
                            this.PlayClip( Tik );
                        }
                    }
                } else {
                    this.PlayClip( Tik );
                }
            }
        }

        // OnSubmit
        private void OnSubmit(NavigationSubmitEvent evt) {
            if (evt.target is Button button) {
                using (var click = ClickEvent.GetPooled()) {
                    click.target = button;
                    button.SendEvent( click );
                }
                evt.StopPropagation();
            }
        }
        private void OnCancel(NavigationCancelEvent evt) {
            var view = (UIWidgetViewBase) evt.currentTarget;
            var button = view.VisualElement.Query<Button>().Where( i => i.IsCancel() || i.IsQuit() || i.name == "resume" ).First();
            if (button != null) {
                using (var click = ClickEvent.GetPooled()) {
                    click.target = button;
                    button.SendEvent( click );
                }
                evt.StopPropagation();
            }
        }

    }
}
