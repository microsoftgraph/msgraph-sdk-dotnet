// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: EntityCollectionRequestBuilder.cs.tt
namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The type EducationRootClassesCollectionRequestBuilder.
    /// </summary>
    public partial class EducationRootClassesCollectionRequestBuilder : BaseRequestBuilder, IEducationRootClassesCollectionRequestBuilder
    {
        /// <summary>
        /// Constructs a new EducationRootClassesCollectionRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public EducationRootClassesCollectionRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IEducationRootClassesCollectionRequest Request()
        {
            return this.Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IEducationRootClassesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new EducationRootClassesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        /// <summary>
        /// Gets an <see cref="IEducationClassRequestBuilder"/> for the specified EducationRootEducationClass.
        /// </summary>
        /// <param name="id">The ID for the EducationRootEducationClass.</param>
        /// <returns>The <see cref="IEducationClassRequestBuilder"/>.</returns>
        public IEducationClassRequestBuilder this[string id]
        {
            get
            {
                return new EducationClassRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        /// <summary>
        /// Gets the request builder for EducationClassDelta.
        /// </summary>
        /// <returns>The <see cref="IEducationClassDeltaRequestBuilder"/>.</returns>
        public IEducationClassDeltaRequestBuilder Delta()
        {
            return new EducationClassDeltaRequestBuilder(
                this.AppendSegmentToRequestUrl("microsoft.graph.delta"),
                this.Client);
        }
    }
}
