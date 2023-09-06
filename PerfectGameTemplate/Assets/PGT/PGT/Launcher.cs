#nullable enable
namespace PGT {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PGT.UI;
    using UnityEngine;

    public class Launcher : MonoBehaviour {

        // Awake
        public void Awake() {
        }
        public void OnDestroy() {
        }

        // Start
        public async void Start() {
            await UIRouter.LoadProgramAsync();
        }
        public void Update() {
        }

    }
}
