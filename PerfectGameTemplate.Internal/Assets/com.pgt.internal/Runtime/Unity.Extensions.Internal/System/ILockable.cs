#nullable enable
namespace System {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ILockable {
        bool IsLocked { get; set; }
    }
    public static class ILockableExtensions {
        public static bool IsLocked(this ILockable lockable) {
            return lockable.IsLocked;
        }
        public static LockScope Lock(this ILockable lockable) {
            return new LockScope( lockable );
        }
    }
    public readonly struct LockScope : IDisposable {

        private readonly ILockable lockable;

        internal LockScope(ILockable lockable) {
            Assert.Object.Message( $"Object {lockable} is already locked" ).Valid( !lockable.IsLocked );
            this.lockable = lockable;
            this.lockable.IsLocked = true;
        }

        public void Dispose() {
            lockable.IsLocked = false;
        }

    }
}
