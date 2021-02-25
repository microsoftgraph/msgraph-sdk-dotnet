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
    /// The interface IPrintServiceEndpointRequest.
    /// </summary>
    public partial interface IPrintServiceEndpointRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified PrintServiceEndpoint using POST.
        /// </summary>
        /// <param name="printServiceEndpointToCreate">The PrintServiceEndpoint to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created PrintServiceEndpoint.</returns>
        System.Threading.Tasks.Task<PrintServiceEndpoint> CreateAsync(PrintServiceEndpoint printServiceEndpointToCreate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates the specified PrintServiceEndpoint using POST and returns a <see cref="GraphResponse{PrintServiceEndpoint}"/> object.
        /// </summary>
        /// <param name="printServiceEndpointToCreate">The PrintServiceEndpoint to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="GraphResponse{PrintServiceEndpoint}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<PrintServiceEndpoint>> CreateResponseAsync(PrintServiceEndpoint printServiceEndpointToCreate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified PrintServiceEndpoint.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified PrintServiceEndpoint and returns a <see cref="GraphResponse"/> object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task of <see cref="GraphResponse"/> to await.</returns>
        System.Threading.Tasks.Task<GraphResponse> DeleteResponseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specified PrintServiceEndpoint.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The PrintServiceEndpoint.</returns>
        System.Threading.Tasks.Task<PrintServiceEndpoint> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specified PrintServiceEndpoint and returns a <see cref="GraphResponse{PrintServiceEndpoint}"/> object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="GraphResponse{PrintServiceEndpoint}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<PrintServiceEndpoint>> GetResponseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified PrintServiceEndpoint using PATCH.
        /// </summary>
        /// <param name="printServiceEndpointToUpdate">The PrintServiceEndpoint to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The updated PrintServiceEndpoint.</returns>
        System.Threading.Tasks.Task<PrintServiceEndpoint> UpdateAsync(PrintServiceEndpoint printServiceEndpointToUpdate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified PrintServiceEndpoint using PATCH and returns a <see cref="GraphResponse{PrintServiceEndpoint}"/> object.
        /// </summary>
        /// <param name="printServiceEndpointToUpdate">The PrintServiceEndpoint to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The <see cref="GraphResponse{PrintServiceEndpoint}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<PrintServiceEndpoint>> UpdateResponseAsync(PrintServiceEndpoint printServiceEndpointToUpdate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        IPrintServiceEndpointRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        IPrintServiceEndpointRequest Expand(Expression<Func<PrintServiceEndpoint, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        IPrintServiceEndpointRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        IPrintServiceEndpointRequest Select(Expression<Func<PrintServiceEndpoint, object>> selectExpression);

    }
}