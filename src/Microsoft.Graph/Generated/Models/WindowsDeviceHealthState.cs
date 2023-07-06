using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Computer endpoint protection state</summary>
    public enum WindowsDeviceHealthState {
        /// <summary>Computer is clean and no action is required</summary>
        [EnumMember(Value = "clean")]
        Clean,
        /// <summary>Computer is in critical failure state</summary>
        [EnumMember(Value = "critical")]
        Critical,
        /// <summary>Computer is in pending full scan state</summary>
        [EnumMember(Value = "fullScanPending")]
        FullScanPending,
        /// <summary>Computer is in pending manual steps state</summary>
        [EnumMember(Value = "manualStepsPending")]
        ManualStepsPending,
        /// <summary>Computer is in pending offline scan state</summary>
        [EnumMember(Value = "offlineScanPending")]
        OfflineScanPending,
        /// <summary>Computer is in pending reboot state</summary>
        [EnumMember(Value = "rebootPending")]
        RebootPending,
    }
}
