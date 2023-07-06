using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationProtocol {
        [EnumMember(Value = "saml")]
        Saml,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "wsFed")]
        WsFed,
    }
}
