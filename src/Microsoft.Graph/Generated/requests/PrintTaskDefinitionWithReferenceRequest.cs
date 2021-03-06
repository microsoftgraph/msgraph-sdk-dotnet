// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: EntityWithReferenceRequest.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Linq.Expressions;

    /// <summary>
    /// The type PrintTaskDefinitionWithReferenceRequest.
    /// </summary>
    public partial class PrintTaskDefinitionWithReferenceRequest : BaseRequest, IPrintTaskDefinitionWithReferenceRequest
    {
        /// <summary>
        /// Constructs a new PrintTaskDefinitionWithReferenceRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public PrintTaskDefinitionWithReferenceRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Gets the specified PrintTaskDefinition.
        /// </summary>
        /// <returns>The PrintTaskDefinition.</returns>
        public System.Threading.Tasks.Task<PrintTaskDefinition> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified PrintTaskDefinition.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The PrintTaskDefinition.</returns>
        public async System.Threading.Tasks.Task<PrintTaskDefinition> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<PrintTaskDefinition>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }

		/// <summary>
        /// Creates the specified PrintTaskDefinition using POST.
        /// </summary>
        /// <param name="printTaskDefinitionToCreate">The PrintTaskDefinition to create.</param>
        /// <returns>The created PrintTaskDefinition.</returns>
        public System.Threading.Tasks.Task<PrintTaskDefinition> CreateAsync(PrintTaskDefinition printTaskDefinitionToCreate)
        {
            return this.CreateAsync(printTaskDefinitionToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified PrintTaskDefinition using POST.
        /// </summary>
        /// <param name="printTaskDefinitionToCreate">The PrintTaskDefinition to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created PrintTaskDefinition.</returns>
        public async System.Threading.Tasks.Task<PrintTaskDefinition> CreateAsync(PrintTaskDefinition printTaskDefinitionToCreate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "POST";
            var newEntity = await this.SendAsync<PrintTaskDefinition>(printTaskDefinitionToCreate, cancellationToken).ConfigureAwait(false);
            return newEntity;
        }

		/// <summary>
        /// Updates the specified PrintTaskDefinition using PATCH.
        /// </summary>
        /// <param name="printTaskDefinitionToUpdate">The PrintTaskDefinition to update.</param>
        /// <returns>The updated PrintTaskDefinition.</returns>
        public System.Threading.Tasks.Task<PrintTaskDefinition> UpdateAsync(PrintTaskDefinition printTaskDefinitionToUpdate)
        {
            return this.UpdateAsync(printTaskDefinitionToUpdate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified PrintTaskDefinition using PATCH.
        /// </summary>
        /// <param name="printTaskDefinitionToUpdate">The PrintTaskDefinition to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <exception cref="ClientException">Thrown when an object returned in a response is used for updating an object in Microsoft Graph.</exception>
        /// <returns>The updated PrintTaskDefinition.</returns>
        public async System.Threading.Tasks.Task<PrintTaskDefinition> UpdateAsync(PrintTaskDefinition printTaskDefinitionToUpdate, CancellationToken cancellationToken)
        {
			if (printTaskDefinitionToUpdate.AdditionalData != null)
			{
				if (printTaskDefinitionToUpdate.AdditionalData.ContainsKey(Constants.HttpPropertyNames.ResponseHeaders) ||
					printTaskDefinitionToUpdate.AdditionalData.ContainsKey(Constants.HttpPropertyNames.StatusCode))
				{
					throw new ClientException(
						new Error
						{
							Code = GeneratedErrorConstants.Codes.NotAllowed,
							Message = String.Format(GeneratedErrorConstants.Messages.ResponseObjectUsedForUpdate, printTaskDefinitionToUpdate.GetType().Name)
						});
				}
			}
            if (printTaskDefinitionToUpdate.AdditionalData != null)
            {
                if (printTaskDefinitionToUpdate.AdditionalData.ContainsKey(Constants.HttpPropertyNames.ResponseHeaders) ||
                    printTaskDefinitionToUpdate.AdditionalData.ContainsKey(Constants.HttpPropertyNames.StatusCode))
                {
                    throw new ClientException(
                        new Error
                        {
                            Code = GeneratedErrorConstants.Codes.NotAllowed,
                            Message = String.Format(GeneratedErrorConstants.Messages.ResponseObjectUsedForUpdate, printTaskDefinitionToUpdate.GetType().Name)
                        });
                }
            }
            this.ContentType = "application/json";
            this.Method = "PATCH";
            var updatedEntity = await this.SendAsync<PrintTaskDefinition>(printTaskDefinitionToUpdate, cancellationToken).ConfigureAwait(false);
            return updatedEntity;
        }

		/// <summary>
        /// Deletes the specified PrintTaskDefinition.
        /// </summary>
        /// <returns>The task to await.</returns>
        public System.Threading.Tasks.Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified PrintTaskDefinition.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async System.Threading.Tasks.Task DeleteAsync(CancellationToken cancellationToken)
        {
            this.Method = "DELETE";
            await this.SendAsync<PrintTaskDefinition>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        public IPrintTaskDefinitionWithReferenceRequest Expand(string value)
        {
            this.QueryOptions.Add(new QueryOption("$expand", value));
            return this;
        }

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="expandExpression">The expression from which to calculate the expand value.</param>
        /// <returns>The request object to send.</returns>
        public IPrintTaskDefinitionWithReferenceRequest Expand(Expression<Func<PrintTaskDefinition, object>> expandExpression)
        {
		    if (expandExpression == null)
            {
                throw new ArgumentNullException(nameof(expandExpression));
            }
            string error;
            string value = ExpressionExtractHelper.ExtractMembers(expandExpression, out error);
            if (value == null)
            {
                throw new ArgumentException(error, nameof(expandExpression));
            }
            else
            {
                this.QueryOptions.Add(new QueryOption("$expand", value));
            }
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IPrintTaskDefinitionWithReferenceRequest Select(string value)
        {
            this.QueryOptions.Add(new QueryOption("$select", value));
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="selectExpression">The expression from which to calculate the select value.</param>
        /// <returns>The request object to send.</returns>
        public IPrintTaskDefinitionWithReferenceRequest Select(Expression<Func<PrintTaskDefinition, object>> selectExpression)
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }
            string error;
            string value = ExpressionExtractHelper.ExtractMembers(selectExpression, out error);
            if (value == null)
            {
                throw new ArgumentException(error, nameof(selectExpression));
            }
            else
            {
                this.QueryOptions.Add(new QueryOption("$select", value));
            }
            return this;
        }

    }
}
