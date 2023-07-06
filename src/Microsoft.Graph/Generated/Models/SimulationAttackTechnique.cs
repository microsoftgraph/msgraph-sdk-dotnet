using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SimulationAttackTechnique {
        [EnumMember(Value = "attachmentMalware")]
        AttachmentMalware,
        [EnumMember(Value = "credentialHarvesting")]
        CredentialHarvesting,
        [EnumMember(Value = "driveByUrl")]
        DriveByUrl,
        [EnumMember(Value = "linkInAttachment")]
        LinkInAttachment,
        [EnumMember(Value = "linkToMalwareFile")]
        LinkToMalwareFile,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
