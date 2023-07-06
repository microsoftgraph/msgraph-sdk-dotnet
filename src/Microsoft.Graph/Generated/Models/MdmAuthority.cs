using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Mobile device management authority.</summary>
    public enum MdmAuthority {
        /// <summary>Intune</summary>
        [EnumMember(Value = "intune")]
        Intune,
        /// <summary>Office365</summary>
        [EnumMember(Value = "office365")]
        Office365,
        /// <summary>SCCM</summary>
        [EnumMember(Value = "sccm")]
        Sccm,
        /// <summary>Unknown</summary>
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
