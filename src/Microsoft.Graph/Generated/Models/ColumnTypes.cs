using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ColumnTypes {
        [EnumMember(Value = "approvalStatus")]
        ApprovalStatus,
        [EnumMember(Value = "boolean")]
        Boolean,
        [EnumMember(Value = "calculated")]
        Calculated,
        [EnumMember(Value = "choice")]
        Choice,
        [EnumMember(Value = "currency")]
        Currency,
        [EnumMember(Value = "dateTime")]
        DateTime,
        [EnumMember(Value = "geolocation")]
        Geolocation,
        [EnumMember(Value = "location")]
        Location,
        [EnumMember(Value = "lookup")]
        Lookup,
        [EnumMember(Value = "multichoice")]
        Multichoice,
        [EnumMember(Value = "multiterm")]
        Multiterm,
        [EnumMember(Value = "note")]
        Note,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "term")]
        Term,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "thumbnail")]
        Thumbnail,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "url")]
        Url,
        [EnumMember(Value = "user")]
        User,
    }
}
