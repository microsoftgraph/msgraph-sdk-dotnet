// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: IEntityRequest.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Linq.Expressions;

    /// <summary>
    /// The interface IPrintUsageByUserRequest.
    /// </summary>
    public partial interface IPrintUsageByUserRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified PrintUsageByUser using POST.
        /// </summary>
        /// <param name="printUsageByUserToCreate">The PrintUsageByUser to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created PrintUsageByUser.</returns>
        System.Threading.Tasks.Task<PrintUsageByUser> CreateAsync(PrintUsageByUser printUsageByUserToCreate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates the specified PrintUsageByUser using POST and returns a <see cref="GraphResponse{PrintUsageByUser}"/> object.
        /// </summary>
        /// <param name="printUsageByUserToCreate">The PrintUsageByUser to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="GraphResponse{PrintUsageByUser}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<PrintUsageByUser>> CreateResponseAsync(PrintUsageByUser printUsageByUserToCreate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified PrintUsageByUser.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified PrintUsageByUser and returns a <see cref="GraphResponse"/> object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task of <see cref="GraphResponse"/> to await.</returns>
        System.Threading.Tasks.Task<GraphResponse> DeleteResponseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specified PrintUsageByUser.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The PrintUsageByUser.</returns>
        System.Threading.Tasks.Task<PrintUsageByUser> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specified PrintUsageByUser and returns a <see cref="GraphResponse{PrintUsageByUser}"/> object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="GraphResponse{PrintUsageByUser}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<PrintUsageByUser>> GetResponseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified PrintUsageByUser using PATCH.
        /// </summary>
        /// <param name="printUsageByUserToUpdate">The PrintUsageByUser to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The updated PrintUsageByUser.</returns>
        System.Threading.Tasks.Task<PrintUsageByUser> UpdateAsync(PrintUsageByUser printUsageByUserToUpdate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified PrintUsageByUser using PATCH and returns a <see cref="GraphResponse{PrintUsageByUser}"/> object.
        /// </summary>
        /// <param name="printUsageByUserToUpdate">The PrintUsageByUser to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The <see cref="GraphResponse{PrintUsageByUser}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<PrintUsageByUser>> UpdateResponseAsync(PrintUsageByUser printUsageByUserToUpdate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        IPrintUsageByUserRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        IPrintUsageByUserRequest Expand(Expression<Func<PrintUsageByUser, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IPrintUsageByUserRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        IPrintUsageByUserRequest Select(Expression<Func<PrintUsageByUser, object>> selectExpression);

    }
}