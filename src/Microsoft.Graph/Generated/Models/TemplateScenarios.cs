using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TemplateScenarios {
        [EnumMember(Value = "new")]
        New,
        [EnumMember(Value = "secureFoundation")]
        SecureFoundation,
        [EnumMember(Value = "zeroTrust")]
        ZeroTrust,
        [EnumMember(Value = "remoteWork")]
        RemoteWork,
        [EnumMember(Value = "protectAdmins")]
        ProtectAdmins,
        [EnumMember(Value = "emergingThreats")]
        EmergingThreats,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
