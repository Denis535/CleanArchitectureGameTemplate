#nullable enable
namespace Project.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.UI.Common;
    using Project.UI.GameScreen;
    using Project.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.UIElements;

    public static class UIViewFactory {

        // Main
        public static MainWidgetView MainWidget() {
            var view = Create<MainWidgetView>();
            return view;
        }
        public static MainMenuWidgetView MainMenuWidget() {
            var view = Create<MainMenuWidgetView>();
            return view;
        }
        public static CreateGameWidgetView CreateGameWidget() {
            var view = Create<CreateGameWidgetView>( R.Project.UI.MainScreen.MainWidget.MainMenu.CreateGame.CreateGameWidgetView );
            return view;
        }
        public static CreateGameWidgetView2 CreateGameWidget2() {
            var view = Create<CreateGameWidgetView2>( R.Project.UI.MainScreen.MainWidget.MainMenu.CreateGame2.CreateGameWidgetView2 );
            return view;
        }
        public static JoinGameWidgetView JoinGameWidget() {
            var view = Create<JoinGameWidgetView>( R.Project.UI.MainScreen.MainWidget.MainMenu.JoinGame.JoinGameWidgetView );
            return view;
        }
        public static JoinGameWidgetView2 JoinGameWidget2() {
            var view = Create<JoinGameWidgetView2>( R.Project.UI.MainScreen.MainWidget.MainMenu.JoinGame2.JoinGameWidgetView2 );
            return view;
        }
        public static LoadingWidgetView LoadingWidget() {
            var view = Create<LoadingWidgetView>();
            return view;
        }

        // Game
        public static GameWidgetView GameWidget() {
            var view = Create<GameWidgetView>();
            return view;
        }
        public static GameMenuWidgetView GameMenuWidget() {
            var view = Create<GameMenuWidgetView>();
            return view;
        }

        // Settings
        public static SettingsWidgetView SettingsWidget() {
            var view = Create<SettingsWidgetView>();
            return view;
        }
        public static PlayerProfileWidgetView PlayerProfileWidget() {
            var view = Create<PlayerProfileWidgetView>();
            return view;
        }
        public static VideoSettingsWidgetView VideoSettingsWidget() {
            var view = Create<VideoSettingsWidgetView>();
            return view;
        }
        public static AudioSettingsWidgetView AudioSettingsWidget() {
            var view = Create<AudioSettingsWidgetView>();
            return view;
        }

        // Dialog
        public static DialogWidgetView DialogWidget() {
            var view = Create<DialogWidgetView>();
            return view;
        }
        public static InfoDialogWidgetView InfoDialogWidget() {
            var view = Create<InfoDialogWidgetView>();
            return view;
        }
        public static WarningDialogWidgetView WarningDialogWidget() {
            var view = Create<WarningDialogWidgetView>();
            return view;
        }
        public static ErrorDialogWidgetView ErrorDialogWidget() {
            var view = Create<ErrorDialogWidgetView>();
            return view;
        }

        // Helpers
        private static T Create<T>() where T : UIViewBase, new() {
            return UIViewBase.Create<T>();
        }
        private static T Create<T>(string key) where T : UIViewBase, new() {
            var asset = Addressables2.LoadAssetAsync<VisualTreeAsset>( key ).GetResult();
            return UIViewBase.Create<T>( asset! );
        }

    }
}
