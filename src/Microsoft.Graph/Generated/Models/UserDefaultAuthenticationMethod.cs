using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum UserDefaultAuthenticationMethod {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "oath")]
        Oath,
        [EnumMember(Value = "push")]
        Push,
        [EnumMember(Value = "sms")]
        Sms,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "voiceAlternateMobile")]
        VoiceAlternateMobile,
        [EnumMember(Value = "voiceMobile")]
        VoiceMobile,
        [EnumMember(Value = "voiceOffice")]
        VoiceOffice,
    }
}
