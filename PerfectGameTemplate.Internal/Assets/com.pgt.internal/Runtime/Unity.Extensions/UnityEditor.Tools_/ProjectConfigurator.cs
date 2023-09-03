#if UNITY_EDITOR
#nullable enable
namespace UnityEditor.Tools_ {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Framework;
    using UnityEngine.Framework.App;
    using UnityEngine.Framework.Game;
    using UnityEngine.Framework.UI;

    public abstract class ProjectConfiguratorBase {

        // Configure
        public virtual void Configure() {
            foreach (var assembly in Compilation.CompilationPipeline.GetAssemblies().Where( IsSupported )) {
                Configure( assembly );
            }
            foreach (var script in MonoImporter.GetAllRuntimeMonoScripts().Where( IsSupported )) {
                Configure( script );
            }
        }
        public virtual void Configure(Compilation.Assembly assembly) {
        }
        public virtual void Configure(MonoScript script) {
            var order = GetExecutionOrder( script );
            SetExecutionOrder( script, order );
        }

        // GetExecutionOrder
        public abstract int? GetExecutionOrder(MonoScript script);
        public static void SetExecutionOrder(MonoScript script, int? order) {
            if (order.HasValue && order != MonoImporter.GetExecutionOrder( script )) {
                MonoImporter.SetExecutionOrder( script, order.Value );
            }
        }

        // IsSupported
        public virtual bool IsSupported(Compilation.Assembly assembly) {
            return
                !assembly.name.Equals( "Unity" ) && !assembly.name.StartsWith( "Unity." ) &&
                !assembly.name.Equals( "UnityEngine" ) && !assembly.name.StartsWith( "UnityEngine." ) &&
                !assembly.name.Equals( "UnityEditor" ) && !assembly.name.StartsWith( "UnityEditor." ) &&
                !assembly.name.Equals( "PPv2URPConverters" );
        }
        public virtual bool IsSupported(MonoScript script) {
            return AssetDatabase.GetAssetPath( script ).StartsWith( "Assets/" );
        }

    }
    public class ProjectConfigurator : ProjectConfiguratorBase {

        // Configure
        public override void Configure() {
            base.Configure();
        }
        public override void Configure(Compilation.Assembly assembly) {
            base.Configure( assembly );
        }
        public override void Configure(MonoScript script) {
            base.Configure( script );
        }

        // GetExecutionOrder
        public override int? GetExecutionOrder(MonoScript script) {
            return GetExecutionOrder_Program( script ) ?? GetExecutionOrder_UI( script ) ?? GetExecutionOrder_App( script ) ?? GetExecutionOrder_Game( script );
        }
        public virtual int? GetExecutionOrder_Program(MonoScript script) {
            // Program
            if (script.CanConfigure( typeof( ProgramBase ) )) return ScriptExecutionOrders.Program;
            return null;
        }
        public virtual int? GetExecutionOrder_UI(MonoScript script) {
            // Audio
            if (script.CanConfigure( typeof( UIAudioTheme ) )) return ScriptExecutionOrders.UI + 30;
            // Logical
            if (script.CanConfigure( typeof( UIScreen ) )) return ScriptExecutionOrders.UI + 20;
            // Misc
            if (script.CanConfigure( typeof( UIInfrastructure ) )) return ScriptExecutionOrders.UI + 10;
            if (script.CanConfigure( typeof( UIRouterBase ) )) return ScriptExecutionOrders.UI;
            return null;
        }
        public virtual int? GetExecutionOrder_App(MonoScript script) {
            // App
            if (script.CanConfigure( typeof( AppManagerBase ) )) return ScriptExecutionOrders.App + 10;
            // Game
            if (script.CanConfigure( typeof( GameManagerBase ) )) return ScriptExecutionOrders.App;
            return null;
        }
        public virtual int? GetExecutionOrder_Game(MonoScript script) {
            // Game
            if (script.CanConfigure( typeof( GameBase ) )) return ScriptExecutionOrders.Game;
            if (script.CanConfigure( typeof( PlayerBase ) )) return ScriptExecutionOrders.Game - 10;
            // World
            if (script.CanConfigure( typeof( WorldBase ) )) return ScriptExecutionOrders.Game_World;
            if (script.CanConfigure( typeof( WorldViewBase ) )) return ScriptExecutionOrders.Game_World - 10;
            // Entity
            if (script.CanConfigure( typeof( EntityBase ) )) return ScriptExecutionOrders.Game_Entity;
            if (script.CanConfigure( typeof( EntityViewBase ) )) return ScriptExecutionOrders.Game_Entity - 10;
            if (script.CanConfigure( typeof( EntityBodyBase ) )) return ScriptExecutionOrders.Game_Entity - 20;
            return null;
        }

    }
    public static class ProjectConfiguratorUtils {

        // CanConfigure
        public static bool CanConfigure(this MonoScript script, Type pattern) {
            if (script.GetClass() != null) {
                return script.GetClass().Is( pattern ) || script.GetClass().IsDescendentOf( pattern ) || script.GetClass().IsImplementationOf( pattern );
            }
            return false;
        }
        public static bool CanConfigure(this MonoScript script, string pattern) {
            if (script.GetClass() != null) {
                return script.GetClass().GetSimpleName().IsMatch( pattern );
            }
            return false;
        }
        // CanConfigure
        public static bool CanConfigure(this MonoScript script, params Type[] patterns) {
            return patterns.Any( pattern => script.CanConfigure( pattern ) );
        }
        public static bool CanConfigure(this MonoScript script, params string[] patterns) {
            return patterns.Any( pattern => script.CanConfigure( pattern ) );
        }

        // Helpers
        private static bool IsMatch(this string value, string pattern) {
            if (pattern.StartsWith( '*' ) && pattern.EndsWith( '*' )) {
                return value.Contains( pattern.Trim( '*' ) );
            }
            if (pattern.StartsWith( '*' )) {
                return value.EndsWith( pattern.TrimStart( '*' ) );
            }
            if (pattern.EndsWith( '*' )) {
                return value.StartsWith( pattern.TrimEnd( '*' ) );
            }
            {
                return value.Equals( pattern );
            }
        }

    }
}
#endif
