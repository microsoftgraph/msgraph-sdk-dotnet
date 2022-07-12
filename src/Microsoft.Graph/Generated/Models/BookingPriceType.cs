namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum BookingPriceType {
        /// <summary>The price of the service is not defined.</summary>
        Undefined,
        /// <summary>The price of the service is fixed.</summary>
        FixedPrice,
        /// <summary>The price of the service starts with a particular value, but can be higher based on the final services performed.</summary>
        StartingAt,
        /// <summary>The price of the service depends on the number of hours a staff member works on the service.</summary>
        Hourly,
        /// <summary>The service is free.</summary>
        Free,
        /// <summary>The price of the service varies.</summary>
        PriceVaries,
        /// <summary>The price of the service is not listed.</summary>
        CallUs,
        /// <summary>The price of the service is not set.</summary>
        NotSet,
        UnknownFutureValue,
    }
}
