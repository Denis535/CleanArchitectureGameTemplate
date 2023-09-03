#nullable enable
namespace UnityEngine.ResourceManagement.AsyncOperations {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UnityEngine;

    public static class AsyncOperationHandleExtensions {

        // IsSucceeded
        public static bool IsSucceeded(this AsyncOperationHandle handle) {
            return handle.Status == AsyncOperationStatus.Succeeded;
        }
        public static bool IsSucceeded<T>(this AsyncOperationHandle<T> handle) {
            return handle.Status == AsyncOperationStatus.Succeeded;
        }

        // IsFailed
        public static bool IsFailed(this AsyncOperationHandle handle) {
            return handle.Status == AsyncOperationStatus.Failed;
        }
        public static bool IsFailed<T>(this AsyncOperationHandle<T> handle) {
            return handle.Status == AsyncOperationStatus.Failed;
        }

        // GetResult
        public static object? GetResult(this AsyncOperationHandle handle) {
            return handle.WaitForCompletion();
        }
        public static T? GetResult<T>(this AsyncOperationHandle<T> handle) {
            return handle.WaitForCompletion();
        }

        // GetResult/Async
        public static Task<object?> GetResultAsync(this AsyncOperationHandle handle, CancellationToken cancellationToken) {
            var tcs = new TaskCompletionSource<object?>();
            handle.Completed += i => {
                if (cancellationToken.IsCancellationRequested) {
                    tcs.SetCanceled();
                } else {
                    tcs.SetResult( i.Result );
                }
            };
            return tcs.Task;
        }
        public static Task<T?> GetResultAsync<T>(this AsyncOperationHandle<T> handle, CancellationToken cancellationToken) {
            var tcs = new TaskCompletionSource<T?>();
            handle.Completed += i => {
                if (cancellationToken.IsCancellationRequested) {
                    tcs.SetCanceled();
                } else {
                    tcs.SetResult( i.Result );
                }
            };
            return tcs.Task;
        }

    }
}
