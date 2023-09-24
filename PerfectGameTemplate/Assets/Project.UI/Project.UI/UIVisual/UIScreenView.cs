#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Project.UI.Common;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.UIElements;
    using UnityEngine.UIElements.Experimental;

    public class UIScreenView : UIScreenViewBase {

        // Content
        private VisualElement viewsContainer = default!;
        private VisualElement modalViewsContainer = default!;
        // Assets
        private AudioClip Window = default!;
        private AudioClip InfoWindow = default!;
        private AudioClip WarningWindow = default!;
        private AudioClip ErrorWindow = default!;
        private new AudioClip Focus = default!;
        private AudioClip Click = default!;
        private AudioClip Select = default!;
        private AudioClip ConfirmSelect = default!;
        private AudioClip CancelSelect = default!;
        private AudioClip InvalidSelect = default!;
        private AudioClip Tik = default!;

        // Constructor
        public UIScreenView() {
            Add( viewsContainer = CreateViewsContainer() );
            Add( modalViewsContainer = CreateModalViewsContainer() );
        }
        public override void Initialize() {
            base.Initialize();
            Window = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window ).GetResult()!;
            InfoWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Info ).GetResult()!;
            WarningWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Warning ).GetResult()!;
            ErrorWindow = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Window_Error ).GetResult()!;
            Focus = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Focus ).GetResult()!;
            Click = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Click ).GetResult()!;
            Select = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select ).GetResult()!;
            ConfirmSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Confirm ).GetResult()!;
            CancelSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Cancel ).GetResult()!;
            InvalidSelect = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Select_Invalid ).GetResult()!;
            Tik = Addressables2.LoadAssetAsync<AudioClip>( R.Project.UI.Sounds.Tick ).GetResult()!;
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
            view.OnEventTrickleDown<NavigationSubmitEvent>( evt => {
                if (evt.target is Button button) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            } );
            view.OnEventTrickleDown<NavigationCancelEvent>( evt => {
                var button = view.Query<Button>().Where( i => i.IsCancel() || i.IsQuit() || i.name == "resume" ).First();
                if (button != null) {
                    using (var click = ClickEvent.GetPooled()) {
                        click.target = button;
                        button.SendEvent( click );
                    }
                    evt.StopPropagation();
                }
            } );
            view.OnAttachToPanel( PlayAttach );
            view.OnEventTrickleDown<FocusEvent>( PlayFocus );
            view.OnEventTrickleDown<ClickEvent>( PlayClick );
            view.OnEventTrickleDown<ChangeEvent<object>>( PlayChange );
            view.OnEventTrickleDown<ChangeEvent<string>>( PlayChange );
            view.OnEventTrickleDown<ChangeEvent<int>>( PlayChange );
            view.OnEventTrickleDown<ChangeEvent<float>>( PlayChange );
            view.OnEventTrickleDown<ChangeEvent<bool>>( PlayChange );
            if (shadowed.LastOrDefault() is not MainWidgetView or GameWidgetView) {
                ShowView( view, shadowed.LastOrDefault() );
            } else {
                ShowView( view, null );
            }
        }
        public override void HideView(UIWidgetViewBase view, UIWidgetViewBase[] unshadowed) {
            if (unshadowed.LastOrDefault() is not MainWidgetView or GameWidgetView) {
                HideView( view, unshadowed.LastOrDefault() );
            } else {
                HideView( view, null );
            }
        }

        // ShowView
        private void ShowView(UIWidgetViewBase view, UIWidgetViewBase? shadowed) {
            if (shadowed != null) {
                SaveFocus( shadowed );
            }
            if (!view.IsModal()) {
                shadowed?.SetDisplayed( false );
                shadowed?.SetEnabled( false );
                viewsContainer.Add( view );
            } else {
                shadowed?.SetEnabled( false );
                modalViewsContainer.Add( view );
            }
            SetFocus( view );
        }
        private void HideView(UIWidgetViewBase view, UIWidgetViewBase? unshadowed) {
            if (!view.IsModal()) {
                viewsContainer.Remove( view );
                unshadowed?.SetEnabled( true );
                unshadowed?.SetDisplayed( true );
            } else {
                modalViewsContainer.Remove( view );
                unshadowed?.SetEnabled( true );
            }
            if (unshadowed != null) {
                LoadFocus( unshadowed );
            }
        }

        // Helpers
        private void PlayAttach(AttachToPanelEvent evt) {
            if (evt.target is GameMenuWidgetView) {
                this.PlayAudioClip( Select );
            } else
            if (evt.target is DialogWidgetView dialog) {
                PlayWindowAnimation( dialog );
                this.PlayAudioClip( Window );
            } else
            if (evt.target is InfoDialogWidgetView infoDialog) {
                PlayWindowAnimation( infoDialog );
                this.PlayAudioClip( InfoWindow );
            } else
            if (evt.target is WarningDialogWidgetView warningDialog) {
                PlayWindowAnimation( warningDialog );
                this.PlayAudioClip( WarningWindow );
            } else
            if (evt.target is ErrorDialogWidgetView errorDialog) {
                PlayWindowAnimation( errorDialog );
                this.PlayAudioClip( ErrorWindow );
            }
        }
        private void PlayFocus(FocusEvent evt) {
            if (evt.direction != FocusChangeDirection.none && evt.direction != FocusChangeDirection.unspecified) {
                this.PlayAudioClip( Focus );
            }
        }
        private void PlayClick(ClickEvent evt) {
            if (evt.target is Button button) {
                if (!button.IsValid()) {
                    this.PlayAudioClip( InvalidSelect );
                } else
                if (button.IsSubmit()) {
                    this.PlayAudioClip( ConfirmSelect );
                } else
                if (button.IsCancel()) {
                    this.PlayAudioClip( CancelSelect );
                } else {
                    this.PlayAudioClip( Select );
                }
            }
        }
        private void PlayChange<T>(ChangeEvent<T> evt) {
            if (evt.target is BaseField<T> && evt.target.GetType().Name != "ScrollerSlider") {
                if (evt is ChangeEvent<int> evt_int) {
                    if (evt_int.newValue != evt_int.previousValue) {
                        if (!this.IsAudioClipPlaying( Tik, out var time ) || time > 0.025f) {
                            this.PlayAudioClip( Tik );
                        }
                    }
                } else
                if (evt is ChangeEvent<float> evt_float) {
                    if (Mathf.RoundToInt( evt_float.newValue * 200 ) != Mathf.RoundToInt( evt_float.previousValue * 200 )) {
                        if (!this.IsAudioClipPlaying( Tik, out var time ) || time > 0.025f) {
                            this.PlayAudioClip( Tik );
                        }
                    }
                } else {
                    this.PlayAudioClip( Tik );
                }
            }
        }
        // Helpers
        private static void PlayWindowAnimation(UIWidgetViewBase view) {
            var animation = ValueAnimation<float>.Create( view, Mathf.LerpUnclamped );
            animation.valueUpdated = (view, t) => {
                var tx = Easing.OutBack( Easing.InPower( t, 2 ), 4 );
                var ty = Easing.OutBack( Easing.OutPower( t, 2 ), 4 );
                var x = Mathf.LerpUnclamped( 0.8f, 1f, tx );
                var y = Mathf.LerpUnclamped( 0.8f, 1f, ty );
                view.transform.scale = new Vector3( x, y, 1 );
            };
            animation.from = 0;
            animation.to = 1;
            animation.durationMs = 500;
            animation.Start();
        }

    }
}
