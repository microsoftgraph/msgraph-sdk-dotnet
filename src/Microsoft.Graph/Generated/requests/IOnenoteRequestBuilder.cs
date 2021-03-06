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
    /// The interface IOnenoteRequestBuilder.
    /// </summary>
    public partial interface IOnenoteRequestBuilder : IEntityRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        new IOnenoteRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        new IOnenoteRequest Request(IEnumerable<Option> options);
    
        /// <summary>
        /// Gets the request builder for Notebooks.
        /// </summary>
        /// <returns>The <see cref="IOnenoteNotebooksCollectionRequestBuilder"/>.</returns>
        IOnenoteNotebooksCollectionRequestBuilder Notebooks { get; }

        /// <summary>
        /// Gets the request builder for Operations.
        /// </summary>
        /// <returns>The <see cref="IOnenoteOperationsCollectionRequestBuilder"/>.</returns>
        IOnenoteOperationsCollectionRequestBuilder Operations { get; }

        /// <summary>
        /// Gets the request builder for Pages.
        /// </summary>
        /// <returns>The <see cref="IOnenotePagesCollectionRequestBuilder"/>.</returns>
        IOnenotePagesCollectionRequestBuilder Pages { get; }

        /// <summary>
        /// Gets the request builder for Resources.
        /// </summary>
        /// <returns>The <see cref="IOnenoteResourcesCollectionRequestBuilder"/>.</returns>
        IOnenoteResourcesCollectionRequestBuilder Resources { get; }

        /// <summary>
        /// Gets the request builder for SectionGroups.
        /// </summary>
        /// <returns>The <see cref="IOnenoteSectionGroupsCollectionRequestBuilder"/>.</returns>
        IOnenoteSectionGroupsCollectionRequestBuilder SectionGroups { get; }

        /// <summary>
        /// Gets the request builder for Sections.
        /// </summary>
        /// <returns>The <see cref="IOnenoteSectionsCollectionRequestBuilder"/>.</returns>
        IOnenoteSectionsCollectionRequestBuilder Sections { get; }
    
    }
}
