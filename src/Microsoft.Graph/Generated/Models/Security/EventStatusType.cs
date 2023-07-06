using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum EventStatusType {
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "notAvaliable")]
        NotAvaliable,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
