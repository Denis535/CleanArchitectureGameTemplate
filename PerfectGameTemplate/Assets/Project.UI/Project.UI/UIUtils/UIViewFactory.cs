#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.Common;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;

    public static class UIViewFactory {

        // Screen
        public static UIScreenView Screen(UIScreen screen) {
            return new UIScreenView( screen );
        }

        // Main
        public static MainWidgetView MainWidget(MainWidget widget) {
            var view = new MainWidgetView( widget );
            return view;
        }
        public static MainMenuWidgetView MainMenuWidget(MainMenuWidget widget) {
            var view = new MainMenuWidgetView( widget );
            return view;
        }
        public static CreateGameWidgetView CreateGameWidget(CreateGameWidget widget) {
            var view = new CreateGameWidgetView( widget );
            return view;
        }
        public static JoinGameWidgetView JoinGameWidget(JoinGameWidget widget) {
            var view = new JoinGameWidgetView( widget );
            return view;
        }
        public static LoadingWidgetView LoadingWidget(LoadingWidget widget) {
            var view = new LoadingWidgetView( widget );
            return view;
        }

        // Game
        public static GameWidgetView GameWidget(GameWidget widget) {
            var view = new GameWidgetView( widget );
            return view;
        }
        public static GameMenuWidgetView GameMenuWidget(GameMenuWidget widget) {
            var view = new GameMenuWidgetView( widget );
            return view;
        }

        // Settings
        public static SettingsWidgetView SettingsWidget(SettingsWidget widget) {
            var view = new SettingsWidgetView( widget );
            return view;
        }
        public static PlayerProfileWidgetView PlayerProfileWidget(PlayerProfileWidget widget) {
            var view = new PlayerProfileWidgetView( widget );
            return view;
        }
        public static VideoSettingsWidgetView VideoSettingsWidget(VideoSettingsWidget widget) {
            var view = new VideoSettingsWidgetView( widget );
            return view;
        }
        public static AudioSettingsWidgetView AudioSettingsWidget(AudioSettingsWidget widget) {
            var view = new AudioSettingsWidgetView( widget );
            return view;
        }

        // Dialog
        public static DialogWidgetView DialogWidget(DialogWidget widget) {
            var view = new DialogWidgetView( widget );
            return view;
        }
        public static InfoDialogWidgetView InfoDialogWidget(InfoDialogWidget widget) {
            var view = new InfoDialogWidgetView( widget );
            return view;
        }
        public static WarningDialogWidgetView WarningDialogWidget(WarningDialogWidget widget) {
            var view = new WarningDialogWidgetView( widget );
            return view;
        }
        public static ErrorDialogWidgetView ErrorDialogWidget(ErrorDialogWidget widget) {
            var view = new ErrorDialogWidgetView( widget );
            return view;
        }

    }
}
