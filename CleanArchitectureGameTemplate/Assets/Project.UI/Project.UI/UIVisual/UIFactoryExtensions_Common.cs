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
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
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
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
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
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
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
                        VisualElementScope.Add( title = factory.Label( null ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope( out content )) {
                        using (factory.ColumnGroup().Classes( "gray", "medium", "grow-1", "justify-content-center", "align-items-center" ).AsScope()) {
                            VisualElementScope.Add( message = factory.Label( null ).Name( "message" ) );
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
                        VisualElementScope.Add( title = factory.Label( "Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.TabView().Classes( "no-outline", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( profileSettingsSlot = factory.Tab( "Profile Settings" ).Name( "profile-settings" ) );
                            VisualElementScope.Add( videoSettingsSlot = factory.Tab( "Video Settings" ).Name( "video-settings" ) );
                            VisualElementScope.Add( audioSettingsSlot = factory.Tab( "Audio Settings" ).Name( "audio-settings" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Submit( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Cancel( "Back" ).Name( "back" ) );
                    }
                }
            }
            return widget;
        }
        public static ColumnGroup ProfileSettingsWidget(this UIFactory factory, out ColumnGroup group, out TextField name) {
            using (factory.ColumnGroup().Classes( "light", "medium", "margin-0px", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( name = factory.TextField( "Name", null, 16 ).Name( "name" ).Classes( "label-width-25pc" ) );
            }
            return group;
        }
        public static ColumnGroup VideoSettingsWidget(this UIFactory factory, out ColumnGroup group, out Toggle isFullScreen, out PopupField<object?> screenResolution, out Toggle isVSync) {
            using (factory.ColumnGroup().Classes( "gray", "medium", "margin-0px", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( isFullScreen = factory.ToggleField( "Full Screen", false ).Name( "is-full-screen" ).Classes( "label-width-25pc" ) );
                VisualElementScope.Add( screenResolution = factory.PopupField( "Screen Resolution", null ).Name( "screen-resolution" ).Classes( "label-width-25pc" ) );
                VisualElementScope.Add( isVSync = factory.ToggleField( "V-Sync", false ).Name( "is-v-sync" ).Classes( "label-width-25pc" ) );
            }
            return group;
        }
        public static ColumnGroup AudioSettingsWidget(this UIFactory factory, out ColumnGroup group, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume) {
            using (factory.ColumnGroup().Classes( "dark", "medium", "margin-0px", "grow-1" ).AsScope( out group )) {
                VisualElementScope.Add( masterVolume = factory.SliderField( "Master Volume", 0, 0, 1 ).Name( "master-volume" ).Classes( "label-width-25pc" ) );
                VisualElementScope.Add( musicVolume = factory.SliderField( "Music Volume", 0, 0, 1 ).Name( "music-volume" ).Classes( "label-width-25pc" ) );
                VisualElementScope.Add( sfxVolume = factory.SliderField( "Sfx Volume", 0, 0, 1 ).Name( "sfx-volume" ).Classes( "label-width-25pc" ) );
                VisualElementScope.Add( gameVolume = factory.SliderField( "Game Volume", 0, 0, 1 ).Name( "game-volume" ).Classes( "label-width-25pc" ) );
            }
            return group;
        }

    }
}
