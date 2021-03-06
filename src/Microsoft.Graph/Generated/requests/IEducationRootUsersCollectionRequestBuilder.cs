// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: IEntityCollectionRequestBuilder.cs.tt
namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The interface IEducationRootUsersCollectionRequestBuilder.
    /// </summary>
    public partial interface IEducationRootUsersCollectionRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IEducationRootUsersCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IEducationRootUsersCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IEducationUserRequestBuilder"/> for the specified EducationUser.
        /// </summary>
        /// <param name="id">The ID for the EducationUser.</param>
        /// <returns>The <see cref="IEducationUserRequestBuilder"/>.</returns>
        IEducationUserRequestBuilder this[string id] { get; }

        /// <summary>
        /// Gets the request builder for EducationUserDelta.
        /// </summary>
        /// <returns>The <see cref="IEducationUserDeltaRequestBuilder"/>.</returns>
        IEducationUserDeltaRequestBuilder Delta();
    }
}
