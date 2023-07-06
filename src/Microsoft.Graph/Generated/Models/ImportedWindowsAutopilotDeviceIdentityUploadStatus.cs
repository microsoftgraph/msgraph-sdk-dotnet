using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ImportedWindowsAutopilotDeviceIdentityUploadStatus {
        /// <summary>Complete status.</summary>
        [EnumMember(Value = "complete")]
        Complete,
        /// <summary>Error status.</summary>
        [EnumMember(Value = "error")]
        Error,
        /// <summary>No upload status.</summary>
        [EnumMember(Value = "noUpload")]
        NoUpload,
        /// <summary>Pending status.</summary>
        [EnumMember(Value = "pending")]
        Pending,
    }
}
