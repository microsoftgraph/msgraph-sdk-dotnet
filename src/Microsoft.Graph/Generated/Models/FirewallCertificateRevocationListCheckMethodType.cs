namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum FirewallCertificateRevocationListCheckMethodType {
        /// <summary>No value configured by Intune, do not override the user-configured device default value</summary>
        DeviceDefault,
        /// <summary>Do not check certificate revocation list</summary>
        None,
        /// <summary>Attempt CRL check and allow a certificate only if the certificate is confirmed by the check</summary>
        Attempt,
        /// <summary>Require a successful CRL check before allowing a certificate</summary>
        Require,
    }
}
