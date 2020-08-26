// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: Templates\CSharp\Requests\EntityCollectionRequestBuilder.cs.tt
namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The type MobileAppContentFilesCollectionRequestBuilder.
    /// </summary>
    public partial class MobileAppContentFilesCollectionRequestBuilder : BaseRequestBuilder, IMobileAppContentFilesCollectionRequestBuilder
    {
        /// <summary>
        /// Constructs a new MobileAppContentFilesCollectionRequestBuilder.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public MobileAppContentFilesCollectionRequestBuilder(
            string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public IMobileAppContentFilesCollectionRequest Request()
        {
            return this.Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public IMobileAppContentFilesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new MobileAppContentFilesCollectionRequest(this.RequestUrl, this.Client, options);
        }

        /// <summary>
        /// Gets an <see cref="IMobileAppContentFileRequestBuilder"/> for the specified MobileAppContentMobileAppContentFile.
        /// </summary>
        /// <param name="id">The ID for the MobileAppContentMobileAppContentFile.</param>
        /// <returns>The <see cref="IMobileAppContentFileRequestBuilder"/>.</returns>
        public IMobileAppContentFileRequestBuilder this[string id]
        {
            get
            {
                return new MobileAppContentFileRequestBuilder(this.AppendSegmentToRequestUrl(id), this.Client);
            }
        }

        
    }
}