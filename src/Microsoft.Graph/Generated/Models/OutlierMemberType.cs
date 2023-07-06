using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum OutlierMemberType {
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
