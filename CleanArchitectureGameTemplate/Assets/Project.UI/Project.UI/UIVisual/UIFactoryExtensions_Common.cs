#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public static class UIFactoryExtensions_Common {

        // DialogWidget
        public static Widget DialogWidget(this UIFactory factory, out Widget widget, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.DialogWidget().AsScope( out widget )) {
                using (factory.DialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        factory.Label( null ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            factory.Label( null ).Name( "message" ).AddToScope( out message );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return widget;
        }
        public static Widget InfoDialogWidget(this UIFactory factory, out Widget widget, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.InfoDialogWidget().AsScope( out widget )) {
                using (factory.InfoDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        factory.Label( null ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            factory.Label( null ).Name( "message" ).AddToScope( out message );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return widget;
        }
        public static Widget WarningDialogWidget(this UIFactory factory, out Widget widget, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.WarningDialogWidget().AsScope( out widget )) {
                using (factory.WarningDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        factory.Label( null ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            factory.Label( null ).Name( "message" ).AddToScope( out message );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return widget;
        }
        public static Widget ErrorDialogWidget(this UIFactory factory, out Widget widget, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.ErrorDialogWidget().AsScope( out widget )) {
                using (factory.ErrorDialogCard().AsScope( out card )) {
                    using (factory.Header().AsScope( out header )) {
                        factory.Label( null ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            factory.Label( null ).Name( "message" ).AddToScope( out message );
                        }
                    }
                    using (factory.Footer().AsScope( out footer )) {
                    }
                }
            }
            return widget;
        }

        // SettingsWidget
        public static Widget SettingsWidget(this UIFactory factory, out Widget widget, out Label title, out Tab profileSettingsSlot, out Tab videoSettingsSlot, out Tab audioSettingsSlot, out Button okey, out Button back) {
            using (factory.MediumWidget( "settings-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        factory.Label( "Settings" ).Name( "title" ).AddToScope( out title );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.TabView().Classes( "no-outline", "grow-1" ).AsScope()) {
                            factory.Tab( "Profile Settings" ).Name( "profile-settings" ).AddToScope( out profileSettingsSlot );
                            factory.Tab( "Video Settings" ).Name( "video-settings" ).AddToScope( out videoSettingsSlot );
                            factory.Tab( "Audio Settings" ).Name( "audio-settings" ).AddToScope( out audioSettingsSlot );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        factory.Submit( "Ok" ).Name( "okey" ).AddToScope( out okey );
                        factory.Cancel( "Back" ).Name( "back" ).AddToScope( out back );
                    }
                }
            }
            return widget;
        }
        public static ColumnGroup ProfileSettingsWidget(this UIFactory factory, out ColumnGroup group, out TextField name) {
            using (factory.ColumnGroup().Classes( "gray", "medium", "margin-0px", "grow-1" ).AsScope( out group )) {
                factory.TextField( "Name", null, 16 ).Name( "name" ).Classes( "label-width-25pc" ).AddToScope( out name );
            }
            return group;
        }
        public static ColumnGroup VideoSettingsWidget(this UIFactory factory, out ColumnGroup group, out Toggle isFullScreen, out PopupField<object?> screenResolution, out Toggle isVSync) {
            using (factory.ColumnGroup().Classes( "gray", "medium", "margin-0px", "grow-1" ).AsScope( out group )) {
                factory.ToggleField( "Full Screen", false ).Name( "is-full-screen" ).Classes( "label-width-25pc" ).AddToScope( out isFullScreen );
                factory.PopupField( "Screen Resolution", null ).Name( "screen-resolution" ).Classes( "label-width-25pc" ).AddToScope( out screenResolution );
                factory.ToggleField( "V-Sync", false ).Name( "is-v-sync" ).Classes( "label-width-25pc" ).AddToScope( out isVSync );
            }
            return group;
        }
        public static ColumnGroup AudioSettingsWidget(this UIFactory factory, out ColumnGroup group, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume) {
            using (factory.ColumnGroup().Classes( "gray", "medium", "margin-0px", "grow-1" ).AsScope( out group )) {
                factory.SliderField( "Master Volume", 0, 0, 1 ).Name( "master-volume" ).Classes( "label-width-25pc" ).AddToScope( out masterVolume );
                factory.SliderField( "Music Volume", 0, 0, 1 ).Name( "music-volume" ).Classes( "label-width-25pc" ).AddToScope( out musicVolume );
                factory.SliderField( "Sfx Volume", 0, 0, 1 ).Name( "sfx-volume" ).Classes( "label-width-25pc" ).AddToScope( out sfxVolume );
                factory.SliderField( "Game Volume", 0, 0, 1 ).Name( "game-volume" ).Classes( "label-width-25pc" ).AddToScope( out gameVolume );
            }
            return group;
        }

    }
}
