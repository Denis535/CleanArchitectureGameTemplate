#nullable enable
namespace UnityEngine.ResourceManagement.AsyncOperations {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UnityEngine;

    public static class AsyncOperationExtensions {

        // Wait
        public static void Wait<T>(this AsyncOperationBase<T> operation) {
            operation.WaitForCompletion();
        }

        // GetResult
        public static T GetResult<T>(this AsyncOperationBase<T> operation) {
            operation.WaitForCompletion();
            return operation.Result;
        }

        // Wait/Async
        public static async Task WaitAsync<T>(this AsyncOperationBase<T> operation, CancellationToken cancellationToken) {
            cancellationToken.ThrowIfCancellationRequested();
            while (operation.IsRunning) {
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        // GetResult/Async
        public static async Task<T> GetResultAsync<T>(this AsyncOperationBase<T> operation, CancellationToken cancellationToken) {
            cancellationToken.ThrowIfCancellationRequested();
            while (operation.IsRunning) {
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
            }
            return operation.Result;
        }

    }
}
