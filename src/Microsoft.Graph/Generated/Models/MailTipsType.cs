using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MailTipsType {
        [EnumMember(Value = "automaticReplies")]
        AutomaticReplies,
        [EnumMember(Value = "mailboxFullStatus")]
        MailboxFullStatus,
        [EnumMember(Value = "customMailTip")]
        CustomMailTip,
        [EnumMember(Value = "externalMemberCount")]
        ExternalMemberCount,
        [EnumMember(Value = "totalMemberCount")]
        TotalMemberCount,
        [EnumMember(Value = "maxMessageSize")]
        MaxMessageSize,
        [EnumMember(Value = "deliveryRestriction")]
        DeliveryRestriction,
        [EnumMember(Value = "moderationStatus")]
        ModerationStatus,
        [EnumMember(Value = "recipientScope")]
        RecipientScope,
        [EnumMember(Value = "recipientSuggestions")]
        RecipientSuggestions,
    }
}
