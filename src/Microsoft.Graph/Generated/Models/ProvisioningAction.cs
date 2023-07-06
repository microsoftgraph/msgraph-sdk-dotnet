using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ProvisioningAction {
        [EnumMember(Value = "create")]
        Create,
        [EnumMember(Value = "delete")]
        Delete,
        [EnumMember(Value = "disable")]
        Disable,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "stagedDelete")]
        StagedDelete,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "update")]
        Update,
    }
}
