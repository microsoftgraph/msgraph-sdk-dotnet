namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum WindowsUpdateForBusinessUpdateWeeks {
        /// <summary>Allow the user to set.</summary>
        UserDefined,
        /// <summary>Scheduled the update installation on the first week of the month</summary>
        FirstWeek,
        /// <summary>Scheduled the update installation on the second week of the month</summary>
        SecondWeek,
        /// <summary>Scheduled the update installation on the third week of the month</summary>
        ThirdWeek,
        /// <summary>Scheduled the update installation on the fourth week of the month</summary>
        FourthWeek,
        /// <summary>Scheduled the update installation on every week of the month</summary>
        EveryWeek,
        /// <summary>Evolvable enum member</summary>
        UnknownFutureValue,
    }
}
