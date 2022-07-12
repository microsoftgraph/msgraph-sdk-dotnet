namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum MailDestinationRoutingReason {
        None,
        MailFlowRule,
        SafeSender,
        BlockedSender,
        AdvancedSpamFiltering,
        DomainAllowList,
        DomainBlockList,
        NotInAddressBook,
        FirstTimeSender,
        AutoPurgeToInbox,
        AutoPurgeToJunk,
        AutoPurgeToDeleted,
        Outbound,
        NotJunk,
        Junk,
        UnknownFutureValue,
    }
}
