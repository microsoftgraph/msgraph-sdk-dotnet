using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ActivityType {
        [EnumMember(Value = "servicePrincipal")]
        ServicePrincipal,
        [EnumMember(Value = "signin")]
        Signin,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
