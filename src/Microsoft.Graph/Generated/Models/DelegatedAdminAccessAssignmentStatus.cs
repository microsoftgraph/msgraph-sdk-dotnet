using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DelegatedAdminAccessAssignmentStatus {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "deleted")]
        Deleted,
        [EnumMember(Value = "deleting")]
        Deleting,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
