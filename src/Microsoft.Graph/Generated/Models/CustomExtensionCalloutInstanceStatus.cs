using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CustomExtensionCalloutInstanceStatus {
        [EnumMember(Value = "callbackReceived")]
        CallbackReceived,
        [EnumMember(Value = "callbackTimedOut")]
        CallbackTimedOut,
        [EnumMember(Value = "calloutFailed")]
        CalloutFailed,
        [EnumMember(Value = "calloutSent")]
        CalloutSent,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "waitingForCallback")]
        WaitingForCallback,
    }
}
