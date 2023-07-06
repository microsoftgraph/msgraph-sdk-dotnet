using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Type of managed browser</summary>
    public enum ManagedBrowserType {
        /// <summary>Microsoft Edge</summary>
        [EnumMember(Value = "microsoftEdge")]
        MicrosoftEdge,
        /// <summary>Not configured</summary>
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
    }
}
