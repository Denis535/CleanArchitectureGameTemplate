#nullable enable
namespace UnityEngine.Framework.UI {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    // Message
    public record UIMessage {
        public bool IsReceived { get; internal set; } = false;
    }
    // Command
    public abstract record UICommand : UIMessage {
    }
    public abstract record UICommand<TSender> : UICommand {
        public TSender Sender { get; internal set; } = default!;
        public abstract record Validatable : UICommand<TSender> {
            public bool IsValid { get; set; }
        }
    }
    // Event
    public abstract record UIEvent : UIMessage {
    }
    public abstract record UIEvent<TSender> : UIEvent {
        public TSender Sender { get; internal set; } = default!;
        public abstract record Validatable : UIEvent<TSender> {
            public bool IsValid { get; set; }
        }
    }
}
