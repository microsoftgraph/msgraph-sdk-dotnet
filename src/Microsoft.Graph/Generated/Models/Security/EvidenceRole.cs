using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum EvidenceRole {
        [EnumMember(Value = "added")]
        Added,
        [EnumMember(Value = "attacked")]
        Attacked,
        [EnumMember(Value = "attacker")]
        Attacker,
        [EnumMember(Value = "commandAndControl")]
        CommandAndControl,
        [EnumMember(Value = "compromised")]
        Compromised,
        [EnumMember(Value = "contextual")]
        Contextual,
        [EnumMember(Value = "created")]
        Created,
        [EnumMember(Value = "destination")]
        Destination,
        [EnumMember(Value = "edited")]
        Edited,
        [EnumMember(Value = "loaded")]
        Loaded,
        [EnumMember(Value = "policyViolator")]
        PolicyViolator,
        [EnumMember(Value = "scanned")]
        Scanned,
        [EnumMember(Value = "source")]
        Source,
        [EnumMember(Value = "suspicious")]
        Suspicious,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
