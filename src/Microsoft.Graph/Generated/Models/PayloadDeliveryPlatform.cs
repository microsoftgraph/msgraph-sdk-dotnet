using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PayloadDeliveryPlatform {
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "sms")]
        Sms,
        [EnumMember(Value = "teams")]
        Teams,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
