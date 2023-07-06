using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum Label {
        [EnumMember(Value = "authors")]
        Authors,
        [EnumMember(Value = "createdBy")]
        CreatedBy,
        [EnumMember(Value = "createdDateTime")]
        CreatedDateTime,
        [EnumMember(Value = "fileExtension")]
        FileExtension,
        [EnumMember(Value = "fileName")]
        FileName,
        [EnumMember(Value = "lastModifiedBy")]
        LastModifiedBy,
        [EnumMember(Value = "lastModifiedDateTime")]
        LastModifiedDateTime,
        [EnumMember(Value = "title")]
        Title,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "url")]
        Url,
    }
}
