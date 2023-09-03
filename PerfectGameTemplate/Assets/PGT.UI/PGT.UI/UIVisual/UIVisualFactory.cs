namespace PGT.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
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
        public static CreateGameWidgetView CreateGameWidget(Globals.PlayerProfile playerProfile) {
            var view = Create<CreateGameWidgetView>( R.PGT.UI.MainScreen.CreateGameWidgetView );
            view.Game.GameName.Value = "Anonymous";
            view.Game.GameMode.As<GameMode>().ValueChoices = (GameMode._1x3, Enum2.GetValues<GameMode>());
            view.Game.GameWorld.As<GameWorld>().ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>());
            view.Game.IsGamePrivate.Value = true;
            view.Player.PlayerName.Value = playerProfile.PlayerName;
            view.Player.PlayerRole.As<PlayerRole>().ValueChoices = (PlayerRole.Master, Enum2.GetValues<PlayerRole>());
            return view;
        }
        public static CreateGameWidgetView2 CreateGameWidget2(CreateGameWidgetView createGameWidgetView) {
            var view = Create<CreateGameWidgetView2>( R.PGT.UI.MainScreen.CreateGameWidgetView2 );
            view.Game.GameName.Value = createGameWidgetView.Game.GameName.Value;
            view.Game.GameMode.As<GameMode>().ValueChoices = createGameWidgetView.Game.GameMode.As<GameMode>().ValueChoices;
            view.Game.GameWorld.As<GameWorld>().ValueChoices = createGameWidgetView.Game.GameWorld.As<GameWorld>().ValueChoices;
            view.Game.IsGamePrivate.Value = createGameWidgetView.Game.IsGamePrivate.Value;
            view.Player.PlayerName.Value = createGameWidgetView.Player.PlayerName.Value;
            view.Player.PlayerRole.As<PlayerRole>().ValueChoices = createGameWidgetView.Player.PlayerRole.As<PlayerRole>().ValueChoices;
            return view;
        }
        public static JoinGameWidgetView JoinGameWidget(Globals.PlayerProfile playerProfile) {
            var view = Create<JoinGameWidgetView>( R.PGT.UI.MainScreen.JoinGameWidgetView );
            view.Game.GameName.Value = "Anonymous";
            view.Game.GameMode.As<GameMode>().ValueChoices = (GameMode._1x3, Enum2.GetValues<GameMode>());
            view.Game.GameWorld.As<GameWorld>().ValueChoices = (GameWorld.TestWorld1, Enum2.GetValues<GameWorld>());
            view.Game.IsGamePrivate.Value = true;
            view.Player.PlayerName.Value = playerProfile.PlayerName;
            view.Player.PlayerRole.As<PlayerRole>().ValueChoices = (PlayerRole.Master, Enum2.GetValues<PlayerRole>());
            return view;
        }
        public static JoinGameWidgetView2 JoinGameWidget2(JoinGameWidgetView joinGameWidgetView) {
            var view = Create<JoinGameWidgetView2>( R.PGT.UI.MainScreen.JoinGameWidgetView2 );
            view.Game.GameName.Value = joinGameWidgetView.Game.GameName.Value;
            view.Game.GameMode.As<GameMode>().ValueChoices = joinGameWidgetView.Game.GameMode.As<GameMode>().ValueChoices;
            view.Game.GameWorld.As<GameWorld>().ValueChoices = joinGameWidgetView.Game.GameWorld.As<GameWorld>().ValueChoices;
            view.Game.IsGamePrivate.Value = joinGameWidgetView.Game.IsGamePrivate.Value;
            view.Player.PlayerName.Value = joinGameWidgetView.Player.PlayerName.Value;
            view.Player.PlayerRole.As<PlayerRole>().ValueChoices = joinGameWidgetView.Player.PlayerRole.As<PlayerRole>().ValueChoices;
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
        public static PlayerProfileWidgetView PlayerProfileWidget(Globals.PlayerProfile playerProfile) {
            var view = Create<PlayerProfileWidgetView>( R.PGT.UI.Common.PlayerProfileWidgetView );
            view.Name.Value = playerProfile.PlayerName;
            return view;
        }
        public static VideoSettingsWidgetView VideoSettingsWidget(Globals.VideoSettings videoSettings) {
            var view = Create<VideoSettingsWidgetView>( R.PGT.UI.Common.VideoSettingsWidgetView );
            view.IsFullScreen.Value = videoSettings.IsFullScreen;
            view.ScreenResolution.As<Resolution>().ValueChoices = (videoSettings.ScreenResolution, videoSettings.ScreenResolutions);
            view.IsVSync.Value = videoSettings.IsVSync;
            return view;
        }
        public static AudioSettingsWidgetView AudioSettingsWidget(Globals.AudioSettings audioSettings) {
            var view = Create<AudioSettingsWidgetView>( R.PGT.UI.Common.AudioSettingsWidgetView );
            view.MasterVolume.Value = audioSettings.MasterVolume;
            view.MusicVolume.Value = audioSettings.MusicVolume;
            view.SfxVolume.Value = audioSettings.SfxVolume;
            view.GameVolume.Value = audioSettings.GameVolume;
            return view;
        }

        // Dialog
        public static DialogWidgetView DialogWidget(string title, string message) {
            var view = Create<DialogWidgetView>();
            view.Title.Text = title;
            view.Message.Text = message;
            return view;
        }
        public static InfoDialogWidgetView InfoDialogWidget(string title, string message) {
            var view = Create<InfoDialogWidgetView>();
            view.Title.Text = title;
            view.Message.Text = message;
            return view;
        }
        public static WarningDialogWidgetView WarningDialogWidget(string title, string message) {
            var view = Create<WarningDialogWidgetView>();
            view.Title.Text = title;
            view.Message.Text = message;
            return view;
        }
        public static ErrorDialogWidgetView ErrorDialogWidget(string title, string message) {
            var view = Create<ErrorDialogWidgetView>();
            view.Title.Text = title;
            view.Message.Text = message;
            return view;
        }

        // Helpers
        private static T Create<T>() where T : UIView, new() {
            return UIView.Create<T>();
        }
        private static T Create<T>(string key) where T : UIView, new() {
            var asset = Addressables2.LoadAssetAsync<VisualTreeAsset>( key ).GetResult();
            return UIView.Create<T>( asset! );
        }

    }
}
