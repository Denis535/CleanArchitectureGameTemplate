#nullable enable
namespace PGT.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.UI.Common;
    using PGT.UI.GameScreen;
    using PGT.UI.MainScreen;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Framework.UI;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.UIElements;

    public static class UIVisualFactory {

        // Main
        public static MainScreenView MainScreen() {
            var view = Create<MainScreenView>();
            return view;
        }
        public static MainWidgetView MainWidget() {
            var view = Create<MainWidgetView>( R.PGT.UI.MainScreen.MainWidgetView );
            return view;
        }
        public static MainMenuWidgetView MainMenuWidget() {
            var view = Create<MainMenuWidgetView>( R.PGT.UI.MainScreen.MainMenuWidgetView );
            return view;
        }
        public static CreateGameWidgetView CreateGameWidget() {
            var view = Create<CreateGameWidgetView>( R.PGT.UI.MainScreen.CreateGameWidgetView );
            return view;
        }
        public static CreateGameWidgetView2 CreateGameWidget2() {
            var view = Create<CreateGameWidgetView2>( R.PGT.UI.MainScreen.CreateGameWidgetView2 );
            return view;
        }
        public static JoinGameWidgetView JoinGameWidget() {
            var view = Create<JoinGameWidgetView>( R.PGT.UI.MainScreen.JoinGameWidgetView );
            return view;
        }
        public static JoinGameWidgetView2 JoinGameWidget2() {
            var view = Create<JoinGameWidgetView2>( R.PGT.UI.MainScreen.JoinGameWidgetView2 );
            return view;
        }
        public static LoadingWidgetView LoadingWidget() {
            var view = Create<LoadingWidgetView>( R.PGT.UI.MainScreen.LoadingWidgetView );
            return view;
        }

        // Game
        public static GameScreenView GameScreen() {
            var view = Create<GameScreenView>();
            return view;
        }
        public static GameWidgetView GameWidget() {
            var view = Create<GameWidgetView>( R.PGT.UI.GameScreen.GameWidgetView );
            return view;
        }
        public static GameMenuWidgetView GameMenuWidget() {
            var view = Create<GameMenuWidgetView>( R.PGT.UI.GameScreen.GameMenuWidgetView );
            return view;
        }

        // Settings
        public static SettingsWidgetView SettingsWidget() {
            var view = Create<SettingsWidgetView>( R.PGT.UI.Common.SettingsWidgetView );
            return view;
        }
        public static PlayerProfileWidgetView PlayerProfileWidget() {
            var view = Create<PlayerProfileWidgetView>( R.PGT.UI.Common.PlayerProfileWidgetView );
            return view;
        }
        public static VideoSettingsWidgetView VideoSettingsWidget() {
            var view = Create<VideoSettingsWidgetView>( R.PGT.UI.Common.VideoSettingsWidgetView );
            return view;
        }
        public static AudioSettingsWidgetView AudioSettingsWidget() {
            var view = Create<AudioSettingsWidgetView>( R.PGT.UI.Common.AudioSettingsWidgetView );
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
