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
        public static UIScreenView Screen() {
            return new UIScreenView();
        }

        // Main
        public static MainWidgetView MainWidget() {
            var view = new MainWidgetView();
            return view;
        }
        public static MainMenuWidgetView MainMenuWidget() {
            var view = new MainMenuWidgetView();
            return view;
        }
        public static CreateGameWidgetView CreateGameWidget() {
            var view = new CreateGameWidgetView();
            return view;
        }
        public static CreateGameWidgetView2 CreateGameWidget2() {
            var view = new CreateGameWidgetView2();
            return view;
        }
        public static JoinGameWidgetView JoinGameWidget() {
            var view = new JoinGameWidgetView();
            return view;
        }
        public static JoinGameWidgetView2 JoinGameWidget2() {
            var view = new JoinGameWidgetView2();
            return view;
        }
        public static LoadingWidgetView LoadingWidget() {
            var view = new LoadingWidgetView();
            return view;
        }

        // Game
        public static GameWidgetView GameWidget() {
            var view = new GameWidgetView();
            return view;
        }
        public static GameMenuWidgetView GameMenuWidget() {
            var view = new GameMenuWidgetView();
            return view;
        }

        // Settings
        public static SettingsWidgetView SettingsWidget() {
            var view = new SettingsWidgetView();
            return view;
        }
        public static PlayerProfileWidgetView PlayerProfileWidget() {
            var view = new PlayerProfileWidgetView();
            return view;
        }
        public static VideoSettingsWidgetView VideoSettingsWidget() {
            var view = new VideoSettingsWidgetView();
            return view;
        }
        public static AudioSettingsWidgetView AudioSettingsWidget() {
            var view = new AudioSettingsWidgetView();
            return view;
        }

        // Dialog
        public static DialogWidgetView DialogWidget() {
            var view = new DialogWidgetView();
            return view;
        }
        public static InfoDialogWidgetView InfoDialogWidget() {
            var view = new InfoDialogWidgetView();
            return view;
        }
        public static WarningDialogWidgetView WarningDialogWidget() {
            var view = new WarningDialogWidgetView();
            return view;
        }
        public static ErrorDialogWidgetView ErrorDialogWidget() {
            var view = new ErrorDialogWidgetView();
            return view;
        }

    }
}
