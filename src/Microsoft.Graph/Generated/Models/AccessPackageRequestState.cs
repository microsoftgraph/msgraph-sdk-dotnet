using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageRequestState {
        [EnumMember(Value = "canceled")]
        Canceled,
        [EnumMember(Value = "delivered")]
        Delivered,
        [EnumMember(Value = "delivering")]
        Delivering,
        [EnumMember(Value = "deliveryFailed")]
        DeliveryFailed,
        [EnumMember(Value = "denied")]
        Denied,
        [EnumMember(Value = "partiallyDelivered")]
        PartiallyDelivered,
        [EnumMember(Value = "pendingApproval")]
        PendingApproval,
        [EnumMember(Value = "scheduled")]
        Scheduled,
        [EnumMember(Value = "submitted")]
        Submitted,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
