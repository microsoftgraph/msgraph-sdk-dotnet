// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    /// <summary>
    /// Represents a checklist item on a <see cref="PlannerTaskDetails"/>. 
    /// </summary>
    public partial class PlannerChecklistItem
    {
        /// <summary>
        /// Constructor for PlannerChecklistItem resource.
        /// </summary>
        public PlannerChecklistItem()
        {
            this.ODataType = ODataTypeName;
        }

        /// <summary>
        /// OData type name for PlannerChecklistItem resource.
        /// </summary>
        internal const string ODataTypeName = "#microsoft.graph.plannerChecklistItem";
    }
}
