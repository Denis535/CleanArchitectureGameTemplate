//#nullable enable
//namespace System.Threading.Tasks {
//    using System;
//    using System.Collections;
//    using System.Collections.Generic;
//    using UnityEngine;

//    public static class Task2 {

//        // Create
//        public static Task Create(Action<TaskCompletionSource<object?>> initialize, CancellationToken cancellationToken) {
//            var tcs = new TaskCompletionSource<object?>();
//            initialize( tcs );
//            var cancellationTokenRegistration = default( CancellationTokenRegistration );
//            cancellationTokenRegistration = cancellationToken.Register( () => {
//                tcs.TrySetCanceled();
//                cancellationTokenRegistration.Dispose();
//            } );
//            return tcs.Task;
//        }
//        public static Task<T> Create<T>(Action<TaskCompletionSource<T>> initialize, CancellationToken cancellationToken) {
//            var tcs = new TaskCompletionSource<T>();
//            initialize( tcs );
//            var cancellationTokenRegistration = default( CancellationTokenRegistration );
//            cancellationTokenRegistration = cancellationToken.Register( () => {
//                tcs.TrySetCanceled();
//                cancellationTokenRegistration.Dispose();
//            } );
//            return tcs.Task;
//        }

//    }
//}
