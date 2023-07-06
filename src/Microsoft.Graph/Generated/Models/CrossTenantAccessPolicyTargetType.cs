using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CrossTenantAccessPolicyTargetType {
        [EnumMember(Value = "application")]
        Application,
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
