using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MailDestinationRoutingReason {
        [EnumMember(Value = "advancedSpamFiltering")]
        AdvancedSpamFiltering,
        [EnumMember(Value = "autoPurgeToDeleted")]
        AutoPurgeToDeleted,
        [EnumMember(Value = "autoPurgeToInbox")]
        AutoPurgeToInbox,
        [EnumMember(Value = "autoPurgeToJunk")]
        AutoPurgeToJunk,
        [EnumMember(Value = "blockedSender")]
        BlockedSender,
        [EnumMember(Value = "domainAllowList")]
        DomainAllowList,
        [EnumMember(Value = "domainBlockList")]
        DomainBlockList,
        [EnumMember(Value = "firstTimeSender")]
        FirstTimeSender,
        [EnumMember(Value = "junk")]
        Junk,
        [EnumMember(Value = "mailFlowRule")]
        MailFlowRule,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "notInAddressBook")]
        NotInAddressBook,
        [EnumMember(Value = "notJunk")]
        NotJunk,
        [EnumMember(Value = "outbound")]
        Outbound,
        [EnumMember(Value = "safeSender")]
        SafeSender,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
