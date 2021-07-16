// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the categories applied for a <see cref="PlannerTask"/>. The category descriptions are defined for each Plan, in <see cref="PlannerPlanDetails" /> resource.
    /// </summary>
    public partial class PlannerAppliedCategories
    {
        /// <summary>
        /// Specifies if category1 is applied to a the task.
        /// </summary>
        [JsonPropertyName("category1")]
        public bool? Category1 { get; set; }

        /// <summary>
        /// Specifies if category2 is applied to a the task.
        /// </summary>
        [JsonPropertyName("category2")]
        public bool? Category2 { get; set; }

        /// <summary>
        /// Specifies if category3 is applied to a the task.
        /// </summary>
        [JsonPropertyName("category3")]
        public bool? Category3 { get; set; }

        /// <summary>
        /// Specifies if category4 is applied to a the task.
        /// </summary>
        [JsonPropertyName("category4")]
        public bool? Category4 { get; set; }

        /// <summary>
        /// Specifies if category5 is applied to a the task.
        /// </summary>
        [JsonPropertyName("category5")]
        public bool? Category5 { get; set; }

        /// <summary>
        /// Specifies if category6 is applied to a the task.
        /// </summary>
        [JsonPropertyName("category6")]
        public bool? Category6 { get; set; }
    }
}
