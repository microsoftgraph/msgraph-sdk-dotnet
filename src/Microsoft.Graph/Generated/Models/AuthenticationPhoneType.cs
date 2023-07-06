using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationPhoneType {
        [EnumMember(Value = "alternateMobile")]
        AlternateMobile,
        [EnumMember(Value = "mobile")]
        Mobile,
        [EnumMember(Value = "office")]
        Office,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
