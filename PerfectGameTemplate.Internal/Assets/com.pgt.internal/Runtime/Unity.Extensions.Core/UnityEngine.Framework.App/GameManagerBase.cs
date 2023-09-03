#nullable enable
namespace UnityEngine.Framework.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class GameManagerBase : MonoBehaviour {

        // Awake
        public void Awake() {
            Singleton.Register( this );
        }
        public void OnDestroy() {
            Singleton.Unregister( this );
        }

    }
}
