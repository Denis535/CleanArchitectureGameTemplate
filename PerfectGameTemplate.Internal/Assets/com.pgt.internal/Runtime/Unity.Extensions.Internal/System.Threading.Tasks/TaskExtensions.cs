﻿#nullable enable
namespace System.Threading.Tasks {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class TaskExtensions {

        // WithCancellation
        public static async Task WithCancellation(this Task task, CancellationToken cancellationToken) {
            if (task.IsCompleted) {
                await task.ConfigureAwait( false );
                return;
            }
            if (!cancellationToken.CanBeCanceled) {
                await task.ConfigureAwait( false );
                return;
            }
            if (cancellationToken.IsCancellationRequested) {
                throw new OperationCanceledException( cancellationToken );
            }
            var tcs = new TaskCompletionSource<object?>();
            using (cancellationToken.Register( () => tcs.TrySetResult( null ) )) {
                if (await Task.WhenAny( task, tcs.Task ).ConfigureAwait( false ) != task) {
                    throw new OperationCanceledException( cancellationToken );
                }
            }
            await task.ConfigureAwait( false );
        }
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken) {
            if (task.IsCompleted) {
                return await task.ConfigureAwait( false );
            }
            if (!cancellationToken.CanBeCanceled) {
                return await task.ConfigureAwait( false );
            }
            if (cancellationToken.IsCancellationRequested) {
                throw new OperationCanceledException( cancellationToken );
            }
            var tcs = new TaskCompletionSource<object?>();
            using (cancellationToken.Register( () => tcs.TrySetResult( null ) )) {
                if (await Task.WhenAny( task, tcs.Task ).ConfigureAwait( false ) != task) {
                    throw new OperationCanceledException( cancellationToken );
                }
            }
            return await task.ConfigureAwait( false );
        }

    }
}
