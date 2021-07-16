// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    /// <summary>
    /// Represents an assignment on a <see cref="PlannerTask"/>.
    /// </summary>
    public partial class PlannerAssignment
    {
        /// <summary>
        /// Constructor for PlannerAssignment resource.
        /// </summary>
        public PlannerAssignment()
        {
            this.ODataType = ODataTypeName;
        }

        /// <summary>
        /// OData type name for PlannerAssignment resource.
        /// </summary>
        internal const string ODataTypeName = "#microsoft.graph.plannerAssignment";
    }
}
