using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TemplateScenarios {
        [EnumMember(Value = "new")]
        @New,
        [EnumMember(Value = "emergingThreats")]
        EmergingThreats,
        [EnumMember(Value = "protectAdmins")]
        ProtectAdmins,
        [EnumMember(Value = "remoteWork")]
        RemoteWork,
        [EnumMember(Value = "secureFoundation")]
        SecureFoundation,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "zeroTrust")]
        ZeroTrust,
    }
}
