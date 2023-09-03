#nullable enable
namespace PGT.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Unity.Services.Authentication;
    using Unity.Services.Lobbies;
    using Unity.Services.Qos;
    using UnityEngine;
    using UnityEngine.Framework.App;

    public class AppManager : AppManagerBase {

        public IAuthenticationService AuthenticationService => Unity.Services.Authentication.AuthenticationService.Instance;
        public ILobbyService LobbyService => Unity.Services.Lobbies.LobbyService.Instance;
        public IQosService QosService => Unity.Services.Qos.QosService.Instance;

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

    }
}
