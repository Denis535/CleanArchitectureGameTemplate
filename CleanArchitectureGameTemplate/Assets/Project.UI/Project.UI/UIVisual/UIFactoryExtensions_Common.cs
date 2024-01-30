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
        public static Widget SettingsWidget(this UIFactory factory, out Widget widget, out Label title, out Button playerProfile, out Button videoSettings, out Button audioSettings, out Button back) {
            using (factory.MediumWidget( "settings-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( playerProfile = factory.Select( "Player Profile" ).Name( "player-profile" ).Classes( "width-50pc", "align-self-center" ) );
                            VisualElementScope.Add( videoSettings = factory.Select( "Video Settings" ).Name( "video-settings" ).Classes( "width-50pc", "align-self-center" ) );
                            VisualElementScope.Add( audioSettings = factory.Select( "Audio Settings" ).Name( "audio-settings" ).Classes( "width-50pc", "align-self-center" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( back = factory.Cancel( "Back" ).Name( "back" ) );
                    }
                }
            }
            return widget;
        }

        // PlayerProfileWidget
        public static Widget PlayerProfileWidget(this UIFactory factory, out Widget widget, out Label title, out TextField name, out Button okey, out Button back) {
            using (factory.MediumWidget( "player-profile-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Player Profile" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( name = factory.TextField( "Name", null, 16 ).Name( "name" ).Classes( "label-width-25pc" ) );
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

        // VideoSettingsWidget
        public static Widget VideoSettingsWidget(this UIFactory factory, out Widget widget, out Label title, out Toggle isFullScreen, out PopupField<object?> screenResolution, out Toggle isVSync, out Button okey, out Button back) {
            using (factory.MediumWidget( "video-settings-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Video Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( isFullScreen = factory.ToggleField( "Full Screen", false ).Name( "is-full-screen" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( screenResolution = factory.PopupField( "Screen Resolution", null ).Name( "screen-resolution" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( isVSync = factory.ToggleField( "V-Sync", false ).Name( "is-v-sync" ).Classes( "label-width-25pc" ) );
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

        // AudioSettingsWidget
        public static Widget AudioSettingsWidget(this UIFactory factory, out Widget widget, out Label title, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume, out Button okey, out Button back) {
            using (factory.MediumWidget( "audio-settings-widget" ).AsScope( out widget )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Audio Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( masterVolume = factory.SliderField( "Master Volume", 0, 0, 1 ).Name( "master-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( musicVolume = factory.SliderField( "Music Volume", 0, 0, 1 ).Name( "music-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( sfxVolume = factory.SliderField( "Sfx Volume", 0, 0, 1 ).Name( "sfx-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( gameVolume = factory.SliderField( "Game Volume", 0, 0, 1 ).Name( "game-volume" ).Classes( "label-width-25pc" ) );
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

    }
}
