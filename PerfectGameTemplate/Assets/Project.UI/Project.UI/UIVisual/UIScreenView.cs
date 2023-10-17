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

        // Assets
        private readonly AudioClip window;
        private readonly AudioClip infoWindow;
        private readonly AudioClip warningWindow;
        private readonly AudioClip errorWindow;
        private readonly AudioClip focus;
        private readonly AudioClip click;
        private readonly AudioClip select;
        private readonly AudioClip confirmSelect;
        private readonly AudioClip cancelSelect;
        private readonly AudioClip invalidSelect;
        private readonly AudioClip tik;
        // View
        private readonly VisualElement visualElement;
        private readonly VisualElement viewsContainer;
        private readonly VisualElement modalViewsContainer;
        // View
        public override VisualElement VisualElement => visualElement;
        // View
        public ElementWrapper View => visualElement.Wrap();
        public ElementWrapper ViewsContainer => viewsContainer.Wrap();
        public ElementWrapper ModalViewsContainer => modalViewsContainer.Wrap();

        // Constructor
        public UIScreenView(UIScreen screen) : base( screen ) {
            // Assets
            window = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window ).GetResult();
            infoWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Info ).GetResult();
            warningWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Warning ).GetResult();
            errorWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Error ).GetResult();
            focus = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Focus ).GetResult();
            click = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Click ).GetResult();
            select = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select ).GetResult();
            confirmSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Confirm ).GetResult();
            cancelSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Cancel ).GetResult();
            invalidSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Invalid ).GetResult();
            tik = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Tick ).GetResult();
            // View
            visualElement = CreateVisualElement( out viewsContainer, out modalViewsContainer );
        }
        public override void Dispose() {
            Addressables2.Release( window );
            Addressables2.Release( infoWindow );
            Addressables2.Release( warningWindow );
            Addressables2.Release( errorWindow );
            Addressables2.Release( focus );
            Addressables2.Release( click );
            Addressables2.Release( select );
            Addressables2.Release( confirmSelect );
            Addressables2.Release( cancelSelect );
            Addressables2.Release( invalidSelect );
            Addressables2.Release( tik );
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
                this.PlayClip( select );
            } else
            if (target.name == "dialog-widget-view") {
                this.PlayClip( infoWindow );
            } else
            if (target.name == "info-dialog-widget-view") {
                this.PlayClip( infoWindow );
            } else
            if (target.name == "warning-dialog-widget-view") {
                this.PlayClip( warningWindow );
            } else
            if (target.name == "error-dialog-widget-view") {
                this.PlayClip( errorWindow );
            }
        }
        private void PlayFocus(FocusEvent evt) {
            if (evt.direction != FocusChangeDirection.none && evt.direction != FocusChangeDirection.unspecified) {
                this.PlayClip( focus );
            }
        }
        private void PlayClick(ClickEvent evt) {
            if (evt.target is Button button) {
                if (!button.IsValid()) {
                    this.PlayClip( invalidSelect );
                } else
                if (button.IsSubmit()) {
                    this.PlayClip( confirmSelect );
                } else
                if (button.IsCancel()) {
                    this.PlayClip( cancelSelect );
                } else {
                    this.PlayClip( select );
                }
            }
        }
        private void PlayChange<T>(ChangeEvent<T> evt) {
            if (evt.target is BaseField<T> && evt.target.GetType().Name != "ScrollerSlider") {
                if (evt is ChangeEvent<int> evt_int) {
                    if (evt_int.newValue != evt_int.previousValue) {
                        if (!this.IsClipPlaying( tik, out var time ) || time > 0.025f) {
                            this.PlayClip( tik );
                        }
                    }
                } else
                if (evt is ChangeEvent<float> evt_float) {
                    if (Mathf.RoundToInt( evt_float.newValue * 200 ) != Mathf.RoundToInt( evt_float.previousValue * 200 )) {
                        if (!this.IsClipPlaying( tik, out var time ) || time > 0.025f) {
                            this.PlayClip( tik );
                        }
                    }
                } else {
                    this.PlayClip( tik );
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
