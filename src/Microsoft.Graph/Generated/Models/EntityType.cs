using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EntityType {
        [EnumMember(Value = "event")]
        @Event,
        [EnumMember(Value = "acronym")]
        Acronym,
        [EnumMember(Value = "bookmark")]
        Bookmark,
        [EnumMember(Value = "chatMessage")]
        ChatMessage,
        [EnumMember(Value = "drive")]
        Drive,
        [EnumMember(Value = "driveItem")]
        DriveItem,
        [EnumMember(Value = "externalItem")]
        ExternalItem,
        [EnumMember(Value = "list")]
        List,
        [EnumMember(Value = "listItem")]
        ListItem,
        [EnumMember(Value = "message")]
        Message,
        [EnumMember(Value = "person")]
        Person,
        [EnumMember(Value = "site")]
        Site,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
