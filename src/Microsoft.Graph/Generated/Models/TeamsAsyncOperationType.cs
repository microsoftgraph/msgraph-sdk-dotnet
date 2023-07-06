using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamsAsyncOperationType {
        [EnumMember(Value = "archiveTeam")]
        ArchiveTeam,
        [EnumMember(Value = "cloneTeam")]
        CloneTeam,
        [EnumMember(Value = "createChannel")]
        CreateChannel,
        [EnumMember(Value = "createTeam")]
        CreateTeam,
        [EnumMember(Value = "invalid")]
        Invalid,
        [EnumMember(Value = "teamifyGroup")]
        TeamifyGroup,
        [EnumMember(Value = "unarchiveTeam")]
        UnarchiveTeam,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
