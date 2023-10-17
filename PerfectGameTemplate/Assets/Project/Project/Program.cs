#nullable enable
namespace Project {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Project.App;
    using Project.Entities.GameScene;
    using Project.UI;
    using UnityEngine;
    using UnityEngine.Framework;

    // Ideally leave this blank
    public class Program : ProgramBase {

        // Globals
        private UIRouter Router { get; set; } = default!;
        private Application2 Application { get; set; } = default!;

        // OnLoad
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
        internal static void OnLoad() {
            UnityEngine.Application.logMessageReceived += OnLog;
            //if (Debug.isDebugBuild) {
            //    Screen.fullScreen = false;
            //    Screen.SetResolution( 1280, 720, false );
            //}
        }

        // OnLog
        private static void OnLog(string message, string stackTrace, LogType type) {
#if RELEASE
            if (type is LogType.Error or LogType.Assert or LogType.Exception) {
                UnityEngine.Application.Quit( 1 );
            }
#endif
        }

        // Awake
        public new void Awake() {
            base.Awake();
            Router = this.GetDependencyContainer().Resolve<UIRouter>( null );
            Application = this.GetDependencyContainer().Resolve<Application2>( null );
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public async void Start() {
            await Router.LoadMainSceneAsync( default );
        }
        public void Update() {
        }

    }
}
