#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UIRouterBase : MonoBehaviour {

        // Awake
        public void Awake() {
            Singleton.Register( this );
        }
        public void OnDestroy() {
            Singleton.Unregister( this );
        }

    }
}
