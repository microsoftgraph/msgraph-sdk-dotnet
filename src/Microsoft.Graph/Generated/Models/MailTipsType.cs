using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MailTipsType {
        [EnumMember(Value = "automaticReplies")]
        AutomaticReplies,
        [EnumMember(Value = "customMailTip")]
        CustomMailTip,
        [EnumMember(Value = "deliveryRestriction")]
        DeliveryRestriction,
        [EnumMember(Value = "externalMemberCount")]
        ExternalMemberCount,
        [EnumMember(Value = "mailboxFullStatus")]
        MailboxFullStatus,
        [EnumMember(Value = "maxMessageSize")]
        MaxMessageSize,
        [EnumMember(Value = "moderationStatus")]
        ModerationStatus,
        [EnumMember(Value = "recipientScope")]
        RecipientScope,
        [EnumMember(Value = "recipientSuggestions")]
        RecipientSuggestions,
        [EnumMember(Value = "totalMemberCount")]
        TotalMemberCount,
    }
}
