using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CountryLookupMethodType {
        [EnumMember(Value = "authenticatorAppGps")]
        AuthenticatorAppGps,
        [EnumMember(Value = "clientIpAddress")]
        ClientIpAddress,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
