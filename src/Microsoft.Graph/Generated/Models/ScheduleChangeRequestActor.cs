using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ScheduleChangeRequestActor {
        [EnumMember(Value = "manager")]
        Manager,
        [EnumMember(Value = "recipient")]
        Recipient,
        [EnumMember(Value = "sender")]
        Sender,
        [EnumMember(Value = "system")]
        System,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
