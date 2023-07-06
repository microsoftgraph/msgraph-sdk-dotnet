using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageCustomExtensionStage {
        [EnumMember(Value = "assignmentFourteenDaysBeforeExpiration")]
        AssignmentFourteenDaysBeforeExpiration,
        [EnumMember(Value = "assignmentOneDayBeforeExpiration")]
        AssignmentOneDayBeforeExpiration,
        [EnumMember(Value = "assignmentRequestApproved")]
        AssignmentRequestApproved,
        [EnumMember(Value = "assignmentRequestCreated")]
        AssignmentRequestCreated,
        [EnumMember(Value = "assignmentRequestGranted")]
        AssignmentRequestGranted,
        [EnumMember(Value = "assignmentRequestRemoved")]
        AssignmentRequestRemoved,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
