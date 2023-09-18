#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    // Message
    public abstract record UIMessage {
        public bool IsReceived { get; internal set; }
    }
    // Command
    public abstract record UICommand : UIMessage {
    }
    public abstract record UICommand<TSender> : UICommand {
        public TSender Sender { get; internal set; } = default!;
    }
    // Event
    public abstract record UIEvent : UIMessage {
    }
    public abstract record UIEvent<TSender> : UIEvent {
        public TSender Sender { get; internal set; } = default!;
    }
}
