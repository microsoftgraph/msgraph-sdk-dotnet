using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum AccessType {
        [EnumMember(Value = "deny")]
        Deny,
        [EnumMember(Value = "grant")]
        Grant,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
