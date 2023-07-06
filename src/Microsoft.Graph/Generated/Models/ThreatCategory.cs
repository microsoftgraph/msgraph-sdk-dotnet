using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ThreatCategory {
        [EnumMember(Value = "malware")]
        Malware,
        [EnumMember(Value = "phishing")]
        Phishing,
        [EnumMember(Value = "spam")]
        Spam,
        [EnumMember(Value = "undefined")]
        Undefined,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
