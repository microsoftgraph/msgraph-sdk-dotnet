// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: MethodRequestBuilder.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The type DirectoryObjectGetMemberObjectsRequestBuilder.
    /// </summary>
    public partial class DirectoryObjectGetMemberObjectsRequestBuilder : BaseActionMethodRequestBuilder<IDirectoryObjectGetMemberObjectsRequest>, IDirectoryObjectGetMemberObjectsRequestBuilder
    {
        /// <summary>
        /// Constructs a new <see cref="DirectoryObjectGetMemberObjectsRequestBuilder"/>.
        /// </summary>
        /// <param name="requestUrl">The URL for the request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="securityEnabledOnly">A securityEnabledOnly parameter for the OData method call.</param>
        public DirectoryObjectGetMemberObjectsRequestBuilder(
            string requestUrl,
            IBaseClient client,
            bool? securityEnabledOnly)
            : base(requestUrl, client)
        {
            this.SetParameter("securityEnabledOnly", securityEnabledOnly, true);
        }

        /// <summary>
        /// A method used by the base class to construct a request class instance.
        /// </summary>
        /// <param name="functionUrl">The request URL to </param>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>An instance of a specific request class.</returns>
        protected override IDirectoryObjectGetMemberObjectsRequest CreateRequest(string functionUrl, IEnumerable<Option> options)
        {
            var request = new DirectoryObjectGetMemberObjectsRequest(functionUrl, this.Client, options);

            if (this.HasParameter("securityEnabledOnly"))
            {
                request.RequestBody.SecurityEnabledOnly = this.GetParameter<bool?>("securityEnabledOnly");
            }

            return request;
        }
    }
}
