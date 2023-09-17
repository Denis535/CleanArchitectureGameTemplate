#nullable enable
namespace NUnit.Framework {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public abstract class ApiReferenceBase {

        // Validate
        public abstract void Validate();

        // GetReference
        public abstract object[] GetReference();

        // Heleprs
        protected static void AssertThatTypesAreEqual(Type[] actual, Type[] expected) {
            var missing = expected.Except( actual ).ToArray();
            var extra = actual.Except( expected ).ToArray();
            if (missing.Any()) {
                TestContext.WriteLine( "Missing: " );
                foreach (var missing_ in missing) {
                    TestContext.WriteLine( missing_ );
                }
                Assert.Fail( "Actual types has '{0}' missing types", missing.Length );
            }
            if (extra.Any()) {
                TestContext.WriteLine( "Extra: " );
                foreach (var extra_ in extra) {
                    TestContext.WriteLine( extra_ );
                }
                Assert.Fail( "Actual types has '{0}' extra types", extra.Length );
            }
        }
        protected static bool IsObsolete(Type type) {
            if (type.GetCustomAttribute<ObsoleteAttribute>() != null) return true;
            if (type.DeclaringType != null) return IsObsolete( type.DeclaringType );
            return false;
        }
        protected static bool IsCompilerGenerated(Type type) {
            if (type.GetCustomAttribute<CompilerGeneratedAttribute>() != null) return true;
            if (type.DeclaringType != null) return IsCompilerGenerated( type.DeclaringType );
            return false;
        }

    }
}
