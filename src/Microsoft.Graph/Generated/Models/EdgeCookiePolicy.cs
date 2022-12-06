namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum EdgeCookiePolicy {
        /// <summary>Allow the user to set.</summary>
        UserDefined,
        /// <summary>Allow.</summary>
        Allow,
        /// <summary>Block only third party cookies.</summary>
        BlockThirdParty,
        /// <summary>Block all cookies.</summary>
        BlockAll,
    }
}
