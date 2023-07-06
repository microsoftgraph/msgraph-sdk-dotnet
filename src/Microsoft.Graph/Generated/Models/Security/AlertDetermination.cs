using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum AlertDetermination {
        [EnumMember(Value = "apt")]
        Apt,
        [EnumMember(Value = "compromisedAccount")]
        CompromisedAccount,
        [EnumMember(Value = "confirmedActivity")]
        ConfirmedActivity,
        [EnumMember(Value = "lineOfBusinessApplication")]
        LineOfBusinessApplication,
        [EnumMember(Value = "maliciousUserActivity")]
        MaliciousUserActivity,
        [EnumMember(Value = "malware")]
        Malware,
        [EnumMember(Value = "multiStagedAttack")]
        MultiStagedAttack,
        [EnumMember(Value = "notEnoughDataToValidate")]
        NotEnoughDataToValidate,
        [EnumMember(Value = "notMalicious")]
        NotMalicious,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "phishing")]
        Phishing,
        [EnumMember(Value = "securityPersonnel")]
        SecurityPersonnel,
        [EnumMember(Value = "securityTesting")]
        SecurityTesting,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "unwantedSoftware")]
        UnwantedSoftware,
    }
}
