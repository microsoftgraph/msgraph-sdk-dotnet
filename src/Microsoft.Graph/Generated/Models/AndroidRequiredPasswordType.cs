using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Android required password type.</summary>
    public enum AndroidRequiredPasswordType {
        /// <summary>Alphabetic password required.</summary>
        [EnumMember(Value = "alphabetic")]
        Alphabetic,
        /// <summary>Alphanumeric password required.</summary>
        [EnumMember(Value = "alphanumeric")]
        Alphanumeric,
        /// <summary>Alphanumeric with symbols password required.</summary>
        [EnumMember(Value = "alphanumericWithSymbols")]
        AlphanumericWithSymbols,
        /// <summary>A password or pattern is required, and any is acceptable.</summary>
        [EnumMember(Value = "any")]
        Any,
        /// <summary>Device default value, no intent.</summary>
        [EnumMember(Value = "deviceDefault")]
        DeviceDefault,
        /// <summary>Low security biometrics based password required.</summary>
        [EnumMember(Value = "lowSecurityBiometric")]
        LowSecurityBiometric,
        /// <summary>Numeric password required.</summary>
        [EnumMember(Value = "numeric")]
        Numeric,
        /// <summary>Numeric complex password required.</summary>
        [EnumMember(Value = "numericComplex")]
        NumericComplex,
    }
}
