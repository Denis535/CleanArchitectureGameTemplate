﻿#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Framework.App;

    public partial class Globals {
        public class VideoSettings : GlobalsBase {

            // Fields
            private bool isVSync;

            // Props
            public bool IsFullScreen {
                get => Screen.fullScreen;
                set {
                    Screen.fullScreen = value;
                }
            }
            public Resolution ScreenResolution {
                get => Screen.currentResolution;
                set {
                    Screen.SetResolution( value.width, value.height, Screen.fullScreenMode, value.refreshRateRatio );
                }
            }
            public Resolution[] ScreenResolutions {
                //get => Screen.resolutions.SkipWhile( i => i.width < 1000 ).Reverse().ToArray();
                get => Screen.resolutions.Reverse().ToArray();
            }
            public bool IsVSync {
                get => isVSync;
                set {
                    isVSync = value;
                    QualitySettings.vSyncCount = value == true ? 1 : 0;
                }
            }

            // Constructor
            public VideoSettings() {
                Load();
            }

            // Load
            public void Load() {
                IsVSync = Load( "VideoSettings.IsVSync", true );
            }
            public void Save() {
                Save( "VideoSettings.IsVSync", IsVSync );
            }

        }
    }
}