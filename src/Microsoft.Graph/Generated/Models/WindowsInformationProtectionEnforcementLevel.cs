namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum WindowsInformationProtectionEnforcementLevel {
        /// <summary>No protection enforcement</summary>
        NoProtection,
        /// <summary>Encrypt and Audit only</summary>
        EncryptAndAuditOnly,
        /// <summary>Encrypt, Audit and Prompt</summary>
        EncryptAuditAndPrompt,
        /// <summary>Encrypt, Audit and Block</summary>
        EncryptAuditAndBlock,
    }
}
