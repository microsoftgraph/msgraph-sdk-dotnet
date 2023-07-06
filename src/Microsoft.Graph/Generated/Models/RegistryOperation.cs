using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RegistryOperation {
        [EnumMember(Value = "create")]
        Create,
        [EnumMember(Value = "delete")]
        Delete,
        [EnumMember(Value = "modify")]
        Modify,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
