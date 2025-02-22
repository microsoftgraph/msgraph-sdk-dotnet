// <auto-generated/>
using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public enum EnrollmentState
    #pragma warning restore CS1591
    {
        /// <summary>Device enrollment state is unknown</summary>
        [EnumMember(Value = "unknown")]
        Unknown,
        /// <summary>Device is Enrolled.</summary>
        [EnumMember(Value = "enrolled")]
        Enrolled,
        /// <summary>Enrolled but it&apos;s enrolled via enrollment profile and the enrolled profile is different from the assigned profile.</summary>
        [EnumMember(Value = "pendingReset")]
        PendingReset,
        /// <summary>Not enrolled and there is enrollment failure record.</summary>
        [EnumMember(Value = "failed")]
        Failed,
        /// <summary>Device is imported but not enrolled.</summary>
        [EnumMember(Value = "notContacted")]
        NotContacted,
    }
}
