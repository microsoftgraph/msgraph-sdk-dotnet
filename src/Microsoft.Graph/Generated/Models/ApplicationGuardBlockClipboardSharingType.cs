namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum ApplicationGuardBlockClipboardSharingType {
        /// <summary>Not Configured</summary>
        NotConfigured,
        /// <summary>Block clipboard to share data both from Host to Container and from Container to Host</summary>
        BlockBoth,
        /// <summary>Block clipboard to share data from Host to Container</summary>
        BlockHostToContainer,
        /// <summary>Block clipboard to share data from Container to Host</summary>
        BlockContainerToHost,
        /// <summary>Block clipboard to share data neither from Host to Container nor from Container to Host</summary>
        BlockNone,
    }
}
