// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: IEntityRequestBuilder.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The interface IPlannerTaskRequestBuilder.
    /// </summary>
    public partial interface IPlannerTaskRequestBuilder : IEntityRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        new IPlannerTaskRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        new IPlannerTaskRequest Request(IEnumerable<Option> options);
    
        /// <summary>
        /// Gets the request builder for AssignedToTaskBoardFormat.
        /// </summary>
        /// <returns>The <see cref="IPlannerAssignedToTaskBoardTaskFormatRequestBuilder"/>.</returns>
        IPlannerAssignedToTaskBoardTaskFormatRequestBuilder AssignedToTaskBoardFormat { get; }

        /// <summary>
        /// Gets the request builder for BucketTaskBoardFormat.
        /// </summary>
        /// <returns>The <see cref="IPlannerBucketTaskBoardTaskFormatRequestBuilder"/>.</returns>
        IPlannerBucketTaskBoardTaskFormatRequestBuilder BucketTaskBoardFormat { get; }

        /// <summary>
        /// Gets the request builder for Details.
        /// </summary>
        /// <returns>The <see cref="IPlannerTaskDetailsRequestBuilder"/>.</returns>
        IPlannerTaskDetailsRequestBuilder Details { get; }

        /// <summary>
        /// Gets the request builder for ProgressTaskBoardFormat.
        /// </summary>
        /// <returns>The <see cref="IPlannerProgressTaskBoardTaskFormatRequestBuilder"/>.</returns>
        IPlannerProgressTaskBoardTaskFormatRequestBuilder ProgressTaskBoardFormat { get; }
    
    }
}
