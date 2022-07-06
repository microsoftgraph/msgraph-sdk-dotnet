namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum AndroidRequiredPasswordType {
        /// <summary>Device default value, no intent.</summary>
        DeviceDefault,
        /// <summary>Alphabetic password required.</summary>
        Alphabetic,
        /// <summary>Alphanumeric password required.</summary>
        Alphanumeric,
        /// <summary>Alphanumeric with symbols password required.</summary>
        AlphanumericWithSymbols,
        /// <summary>Low security biometrics based password required.</summary>
        LowSecurityBiometric,
        /// <summary>Numeric password required.</summary>
        Numeric,
        /// <summary>Numeric complex password required.</summary>
        NumericComplex,
        /// <summary>A password or pattern is required, and any is acceptable.</summary>
        Any,
    }
}
