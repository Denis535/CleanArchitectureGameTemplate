#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Framework.App;

    public partial class Globals {
        public class AccountSettings : GlobalsBase {

            // Fields
            private string playerName = default!;

            // Props
            public string PlayerName {
                get => playerName;
                set {
                    Assert.Argument.Message( $"Argument 'value' ({value}) is invalid" ).Valid( IsNameValid( value ) );
                    playerName = value;
                }
            }

            // Constructor
            public AccountSettings() {
                Load();
            }

            // Save
            public void Save() {
                Save( "AccountSettings.PlayerName", PlayerName );
            }
            public void Load() {
                PlayerName = Load( "AccountSettings.PlayerName", "Anonymous" );
            }

            // Utils
            public static bool IsNameValid(string value) {
                return
                    value.Length >= 3 &&
                    char.IsLetterOrDigit( value.First() ) &&
                    char.IsLetterOrDigit( value.Last() ) &&
                    value.All( i => char.IsLetterOrDigit( i ) || (i is ' ' or '_' or '-') );
            }

        }
    }
}
