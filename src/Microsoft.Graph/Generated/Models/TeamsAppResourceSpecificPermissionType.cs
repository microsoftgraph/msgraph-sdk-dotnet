using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamsAppResourceSpecificPermissionType {
        [EnumMember(Value = "application")]
        Application,
        [EnumMember(Value = "delegated")]
        Delegated,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
