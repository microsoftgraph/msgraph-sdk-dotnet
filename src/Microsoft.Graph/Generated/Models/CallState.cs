using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CallState {
        [EnumMember(Value = "established")]
        Established,
        [EnumMember(Value = "establishing")]
        Establishing,
        [EnumMember(Value = "hold")]
        Hold,
        [EnumMember(Value = "incoming")]
        Incoming,
        [EnumMember(Value = "redirecting")]
        Redirecting,
        [EnumMember(Value = "terminated")]
        Terminated,
        [EnumMember(Value = "terminating")]
        Terminating,
        [EnumMember(Value = "transferAccepted")]
        TransferAccepted,
        [EnumMember(Value = "transferring")]
        Transferring,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
