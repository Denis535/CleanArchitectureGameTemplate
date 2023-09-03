#nullable enable
namespace PGT {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.App;
    using Unity.Services.Authentication;
    using Unity.Services.Core;
    using Unity.Services.Qos;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Framework;

    public class Program : ProgramBase {

        private AppManager AppManager => Singleton.GetInstance<AppManager>();
        private IAuthenticationService AuthenticationService => AppManager.AuthenticationService;
        private IQosService QosService => AppManager.QosService;

        // Awake
        public new void Awake() {
            base.Awake();
        }
        public new void OnDestroy() {
            base.OnDestroy();
        }

        // Start
        public async void Start() {
#if UNITY_EDITOR
            if (string.IsNullOrWhiteSpace( CloudProjectSettings.projectId )) {
                Debug.LogWarning( "Project must be linked with unity gaming services" );
                return;
            }
#endif
            // UnityServices
            var options = new InitializationOptions();
            await UnityServices.InitializeAsync( options );
            destroyCancellationToken.ThrowIfCancellationRequested();
            // AuthenticationService
            await AuthenticationService.SignInAnonymouslyAsync();
            destroyCancellationToken.ThrowIfCancellationRequested();
            Debug.LogFormat( "Player: {0}", AuthenticationService.PlayerInfo?.Username );
            Debug.LogFormat( "Player Id: {0}", AuthenticationService.PlayerInfo?.Id );
            // QosService
            //var results = await QosService.GetSortedQosResultsAsync( "multiplay", null );
            //destroyCancellationToken.ThrowIfCancellationRequested();
            //foreach (var result in results) {
            //    Debug.LogFormat( "Qos: Region={0}, AverageLatencyMs={1}, PacketLossPercent={2}", result.Region, result.AverageLatencyMs, result.PacketLossPercent );
            //}
        }
        public void Update() {
        }

    }
}
