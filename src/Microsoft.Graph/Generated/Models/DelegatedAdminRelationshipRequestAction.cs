using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DelegatedAdminRelationshipRequestAction {
        [EnumMember(Value = "approve")]
        Approve,
        [EnumMember(Value = "lockForApproval")]
        LockForApproval,
        [EnumMember(Value = "terminate")]
        Terminate,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
