#if DEBUG
#nullable enable
namespace PGT.UI.DebugScreen {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DebugScreen : MonoBehaviour {

        // OnGUI
        public void OnGUI() {
            using (new GUILayout.VerticalScope( GUI.skin.box )) {
                //GUILayout.Label( "Resolution: " + Screen.currentResolution ); // it always returns full hd resolution
                //GUILayout.Label( "Resolution: " + Screen.width + " x " + Screen.height );
                GUILayout.Label( "Fps: " + (1f / Time.smoothDeltaTime).ToString( "000." ) );
            }
        }

    }
}
#endif
