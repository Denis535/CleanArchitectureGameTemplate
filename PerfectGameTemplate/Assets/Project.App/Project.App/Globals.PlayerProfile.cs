#nullable enable
namespace Project.App {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Framework.App;

    public partial class Globals {
        public class PlayerProfile : GlobalsBase {

            // Fields
            private string playerName = default!;

            // Props
            public string PlayerName {
                get => playerName;
                set {
                    Assert.Argument.Message( $"Argument 'value' ({value}) is invalid" ).Valid( IsNameValid( value ) );
                    playerName = value;
#if DEBUG
                    //SetWindowText( $"{Application.productName} ({value})" );
#endif
                }
            }

            // Constructor
            public PlayerProfile() {
                Load();
            }

            // Load
            public void Load() {
                PlayerName = Load( "PlayerProfile.PlayerName", "Anonymous" );
            }
            public void Save() {
                Save( "PlayerProfile.PlayerName", PlayerName );
            }

            // Utils
            public static bool IsNameValid(string value) {
                return
                    value.Length >= 3 &&
                    char.IsLetterOrDigit( value.First() ) &&
                    char.IsLetterOrDigit( value.Last() ) &&
                    value.All( i => char.IsLetterOrDigit( i ) || (i is ' ' or '_' or '-') );
            }
#if DEBUG
            // Helpers
            //private static void SetWindowText(string value) {
            //    SetWindowText( GetActiveWindow(), value );
            //}
            //[DllImport( "user32.dll" )]
            //private static extern IntPtr GetActiveWindow();
            //[DllImport( "user32.dll", EntryPoint = "SetWindowText" )]
            //private static extern bool SetWindowText(IntPtr hwnd, string value);
#endif

        }
    }
}
