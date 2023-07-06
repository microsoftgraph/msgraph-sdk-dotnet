using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageAssignmentState {
        [EnumMember(Value = "delivered")]
        Delivered,
        [EnumMember(Value = "delivering")]
        Delivering,
        [EnumMember(Value = "deliveryFailed")]
        DeliveryFailed,
        [EnumMember(Value = "expired")]
        Expired,
        [EnumMember(Value = "partiallyDelivered")]
        PartiallyDelivered,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
