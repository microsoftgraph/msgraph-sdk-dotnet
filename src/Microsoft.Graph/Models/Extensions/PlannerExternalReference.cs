// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents an external reference item on a <see cref="PlannerTaskDetails"/>. 
    /// </summary>
    public partial class PlannerExternalReference
    {
        ///<summary>
        /// Constructor for PlannerExternalReference resource.
        /// </summary>
        public PlannerExternalReference()
        {
            this.ODataType = ODataTypeName;
        }

        /// <summary>
        /// OData type name for PlannerExternalReference resource.
        /// </summary>
        internal const string ODataTypeName = "#microsoft.graph.plannerExternalReference";
    }
}
