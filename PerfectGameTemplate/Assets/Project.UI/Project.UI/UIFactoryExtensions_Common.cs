namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;
    
    public static class UIFactoryExtensions_Common {

        // DialogWidgetView
        public static View DialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.DialogWidget().AsScope( out view )) {
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
            return view;
        }
        public static View InfoDialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.InfoDialogWidget().AsScope( out view )) {
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
            return view;
        }
        public static View WarningDialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.WarningDialogWidget().AsScope( out view )) {
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
            return view;
        }
        public static View ErrorDialogWidgetView(this UIFactory factory, out View view, out Card card, out Header header, out Content content, out Footer footer, out Label title, out Label message) {
            using (factory.ErrorDialogWidget().AsScope( out view )) {
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
            return view;
        }

        // SettingsView
        public static View SettingsView(this UIFactory factory, out View view, out Label title, out Button playerProfile, out Button videoSettings, out Button audioSettings, out Button back) {
            using (factory.MediumWidget( "settings-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( playerProfile = factory.Button( "Player Profile" ).Name( "player-profile" ).Classes( "width-50pc", "align-self-center" ) );
                            VisualElementScope.Add( videoSettings = factory.Button( "Video Settings" ).Name( "video-settings" ).Classes( "width-50pc", "align-self-center" ) );
                            VisualElementScope.Add( audioSettings = factory.Button( "Audio Settings" ).Name( "audio-settings" ).Classes( "width-50pc", "align-self-center" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

        // PlayerProfileView
        public static View PlayerProfileView(this UIFactory factory, out View view, out Label title, out TextField name, out Button okey, out Button back) {
            using (factory.MediumWidget( "player-profile-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Player Profile" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( name = factory.TextField( "Name", 16, false ).Name( "name" ).Classes( "label-width-25pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

        // VideoSettingsView
        public static View VideoSettingsView(this UIFactory factory, out View view, out Label title, out Toggle isFullScreen, out PopupField<object?> screenResolution, out Toggle isVSync, out Button okey, out Button back) {
            using (factory.MediumWidget( "video-settings-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Video Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( isFullScreen = factory.Toggle( "Full Screen" ).Name( "is-full-screen" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( screenResolution = factory.PopupField( "Screen Resolution" ).Name( "screen-resolution" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( isVSync = factory.Toggle( "V-Sync" ).Name( "is-v-sync" ).Classes( "label-width-25pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

        // AudioSettingsView
        public static View AudioSettingsView(this UIFactory factory, out View view, out Label title, out Slider masterVolume, out Slider musicVolume, out Slider sfxVolume, out Slider gameVolume, out Button okey, out Button back) {
            using (factory.MediumWidget( "audio-settings-widget-view" ).AsScope( out view )) {
                using (factory.Card().AsScope()) {
                    using (factory.Header().AsScope()) {
                        VisualElementScope.Add( title = factory.Label( "Audio Settings" ).Name( "title" ) );
                    }
                    using (factory.Content().AsScope()) {
                        using (factory.ColumnGroup().Classes( "gray", "large", "grow-1" ).AsScope()) {
                            VisualElementScope.Add( masterVolume = factory.Slider( "Master Volume" ).Name( "master-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( musicVolume = factory.Slider( "Music Volume" ).Name( "music-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( sfxVolume = factory.Slider( "Sfx Volume" ).Name( "sfx-volume" ).Classes( "label-width-25pc" ) );
                            VisualElementScope.Add( gameVolume = factory.Slider( "Game Volume" ).Name( "game-volume" ).Classes( "label-width-25pc" ) );
                        }
                    }
                    using (factory.Footer().AsScope()) {
                        VisualElementScope.Add( okey = factory.Button( "Ok" ).Name( "okey" ) );
                        VisualElementScope.Add( back = factory.Button( "Back" ).Name( "back" ) );
                    }
                }
            }
            return view;
        }

    }
}
