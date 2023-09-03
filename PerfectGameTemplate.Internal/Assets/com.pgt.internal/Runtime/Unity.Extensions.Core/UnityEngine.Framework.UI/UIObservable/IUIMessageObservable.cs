#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IUIMessageObservable {

        Action<UIMessage>? OnMessageEvent { get; set; }

    }
}
