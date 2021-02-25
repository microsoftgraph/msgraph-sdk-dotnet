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
    /// The interface ITermsOfUseContainerRequest.
    /// </summary>
    public partial interface ITermsOfUseContainerRequest : IBaseRequest
    {
        /// <summary>
        /// Creates the specified TermsOfUseContainer using POST.
        /// </summary>
        /// <param name="termsOfUseContainerToCreate">The TermsOfUseContainer to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created TermsOfUseContainer.</returns>
        System.Threading.Tasks.Task<TermsOfUseContainer> CreateAsync(TermsOfUseContainer termsOfUseContainerToCreate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates the specified TermsOfUseContainer using POST and returns a <see cref="GraphResponse{TermsOfUseContainer}"/> object.
        /// </summary>
        /// <param name="termsOfUseContainerToCreate">The TermsOfUseContainer to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="GraphResponse{TermsOfUseContainer}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<TermsOfUseContainer>> CreateResponseAsync(TermsOfUseContainer termsOfUseContainerToCreate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified TermsOfUseContainer.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified TermsOfUseContainer and returns a <see cref="GraphResponse"/> object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task of <see cref="GraphResponse"/> to await.</returns>
        System.Threading.Tasks.Task<GraphResponse> DeleteResponseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specified TermsOfUseContainer.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The TermsOfUseContainer.</returns>
        System.Threading.Tasks.Task<TermsOfUseContainer> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the specified TermsOfUseContainer and returns a <see cref="GraphResponse{TermsOfUseContainer}"/> object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="GraphResponse{TermsOfUseContainer}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<TermsOfUseContainer>> GetResponseAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified TermsOfUseContainer using PATCH.
        /// </summary>
        /// <param name="termsOfUseContainerToUpdate">The TermsOfUseContainer to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The updated TermsOfUseContainer.</returns>
        System.Threading.Tasks.Task<TermsOfUseContainer> UpdateAsync(TermsOfUseContainer termsOfUseContainerToUpdate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified TermsOfUseContainer using PATCH and returns a <see cref="GraphResponse{TermsOfUseContainer}"/> object.
        /// </summary>
        /// <param name="termsOfUseContainerToUpdate">The TermsOfUseContainer to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The <see cref="GraphResponse{TermsOfUseContainer}"/> object of the request.</returns>
        System.Threading.Tasks.Task<GraphResponse<TermsOfUseContainer>> UpdateResponseAsync(TermsOfUseContainer termsOfUseContainerToUpdate, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        ITermsOfUseContainerRequest Expand(string value);

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        ITermsOfUseContainerRequest Expand(Expression<Func<TermsOfUseContainer, object>> expandExpression);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        ITermsOfUseContainerRequest Select(string value);

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        ITermsOfUseContainerRequest Select(Expression<Func<TermsOfUseContainer, object>> selectExpression);

    }
}