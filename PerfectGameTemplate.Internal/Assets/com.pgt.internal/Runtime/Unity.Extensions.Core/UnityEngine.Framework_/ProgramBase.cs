namespace UnityEngine.Framework {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class ProgramBase : MonoBehaviour {

        // Awake
        public void Awake() {
            Singleton.Register( this );
        }
        public void OnDestroy() {
            Singleton.Unregister( this );
        }

    }
}
