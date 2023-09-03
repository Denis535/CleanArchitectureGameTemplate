#nullable enable
namespace UnityEngine {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UnityEngine;

    public static class AsyncOperationExtensions {

        // Wait/Async
        public static Task WaitAsync(this AsyncOperation operation, CancellationToken cancellationToken) {
            var tcs = new TaskCompletionSource<object?>();
            operation.completed += i => {
                if (cancellationToken.IsCancellationRequested) {
                    tcs.SetCanceled();
                } else {
                    tcs.SetResult( null );
                }
            };
            return tcs.Task;
        }

    }
}
