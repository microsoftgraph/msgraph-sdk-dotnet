using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values for pre-release features.</summary>
    public enum PrereleaseFeatures {
        /// <summary>Pre-release features not allowed.</summary>
        [EnumMember(Value = "notAllowed")]
        NotAllowed,
        /// <summary>Settings and experimentations pre-release features.</summary>
        [EnumMember(Value = "settingsAndExperimentations")]
        SettingsAndExperimentations,
        /// <summary>Settings only pre-release features.</summary>
        [EnumMember(Value = "settingsOnly")]
        SettingsOnly,
        /// <summary>User Defined, default value, no intent.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
