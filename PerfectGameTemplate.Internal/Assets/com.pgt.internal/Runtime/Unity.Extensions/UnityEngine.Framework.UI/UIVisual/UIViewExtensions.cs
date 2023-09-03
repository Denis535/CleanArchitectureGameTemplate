#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class UIViewExtensions {

        // IsModal
        public static bool IsModal(this UIView view) {
            return view is IUIModalWidgetView;
        }

        // GetAudioSource
        public static AudioSource? GetAudioSource(this UIView view) {
            if (view is UIScreenView screenView) {
                return screenView.Screen?.AudioSource;
            }
            if (view is UIWidgetView widgetView) {
                return widgetView.Widget?.Screen?.AudioSource;
            }
            if (view is UISubView subView) {
                var ancestor = subView.GetFirstAncestorOfType<UIView>();
                if (ancestor != null) return GetAudioSource( ancestor );
                return null;
            }
            throw Exceptions.Internal.NotSupported( $"View {view} not supported" );
        }

        // IsAudioClipPlaying
        public static bool IsAudioClipPlaying(this UIView view, AudioClip clip) {
            if (view.GetAudioSource()!.isPlaying && view.GetAudioSource()!.clip == clip) {
                return true;
            }
            return false;
        }
        public static bool IsAudioClipPlaying(this UIView view, AudioClip clip, out float time) {
            if (view.GetAudioSource()!.isPlaying && view.GetAudioSource()!.clip == clip) {
                time = view.GetAudioSource()!.time;
                return true;
            }
            time = 0;
            return false;
        }

        // PlayAudioClip
        public static void PlayAudioClip(this UIView view, AudioClip clip, float volume = 1) {
            view.GetAudioSource()!.clip = clip;
            view.GetAudioSource()!.volume = volume;
            view.GetAudioSource()!.Play();
        }
        public static void StopAudioClip(this UIView view) {
            view.GetAudioSource()!.Stop();
        }

    }
}
