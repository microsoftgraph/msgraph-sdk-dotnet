using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values to specify which cookies are allowed in Microsoft Edge.</summary>
    public enum EdgeCookiePolicy {
        /// <summary>Allow.</summary>
        [EnumMember(Value = "allow")]
        Allow,
        /// <summary>Block all cookies.</summary>
        [EnumMember(Value = "blockAll")]
        BlockAll,
        /// <summary>Block only third party cookies.</summary>
        [EnumMember(Value = "blockThirdParty")]
        BlockThirdParty,
        /// <summary>Allow the user to set.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
