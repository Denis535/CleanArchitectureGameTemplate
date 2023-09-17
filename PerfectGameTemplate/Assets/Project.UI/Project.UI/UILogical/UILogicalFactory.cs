#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.Common;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;

    public static class UILogicalFactory {

        // Main
        public static MainWidget MainWidget() {
            return new MainWidget();
        }
        public static MainMenuWidget MainMenuWidget() {
            return new MainMenuWidget();
        }
        public static CreateGameWidget CreateGameWidget() {
            return new CreateGameWidget();
        }
        public static CreateGameWidget2 CreateGameWidget2() {
            return new CreateGameWidget2();
        }
        public static JoinGameWidget JoinGameWidget() {
            return new JoinGameWidget();
        }
        public static JoinGameWidget2 JoinGameWidget2() {
            return new JoinGameWidget2();
        }
        public static LoadingWidget LoadingWidget() {
            return new LoadingWidget();
        }

        // Game
        public static GameWidget GameWidget() {
            return new GameWidget();
        }
        public static GameMenuWidget GameMenuWidget() {
            return new GameMenuWidget();
        }

        // Settings
        public static SettingsWidget SettingsWidget() {
            return new SettingsWidget();
        }
        public static PlayerProfileWidget PlayerProfileWidget() {
            return new PlayerProfileWidget();
        }
        public static VideoSettingsWidget VideoSettingsWidget() {
            return new VideoSettingsWidget();
        }
        public static AudioSettingsWidget AudioSettingsWidget() {
            return new AudioSettingsWidget();
        }

        // Dialog
        public static DialogWidget DialogWidget(string? title, string? message) {
            return new DialogWidget( title, message );
        }
        public static InfoDialogWidget InfoDialogWidget(string? title, string? message) {
            return new InfoDialogWidget( title, message );
        }
        public static WarningDialogWidget WarningDialogWidget(string? title, string? message) {
            return new WarningDialogWidget( title, message );
        }
        public static ErrorDialogWidget ErrorDialogWidget(string? title, string? message) {
            return new ErrorDialogWidget( title, message );
        }

    }
}
