// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The UploadSessionRequest class
    /// </summary>
    public class UploadSessionRequest : BaseRequest
    {
        private readonly UploadSession session;

        /// <summary>
        /// Create a new UploadSessionRequest
        /// </summary>
        /// <param name="session">The UploadSession to use in the request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UploadSessionRequest(UploadSession session, IBaseClient client, IEnumerable<Option> options)
            : base(session.UploadUrl, client, options)
        {
            this.session = session;
        }

        /// <summary>
        /// Deletes the specified Session
        /// </summary>
        /// <returns>The task to await.</returns>
        public Task<UploadSession> DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified Session
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async Task<UploadSession> DeleteAsync(CancellationToken cancellationToken)
        {
            this.Method = HttpMethods.DELETE;
            return await this.SendAsync<UploadSession>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified UploadSession.
        /// </summary>
        /// <returns>The Item.</returns>
        public Task<UploadSession> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified UploadSession.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The Item.</returns>
        public async Task<UploadSession> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = HttpMethods.GET;
            var retrievedEntity = await this.SendAsync<UploadSession>(null, cancellationToken).ConfigureAwait(false);
            return retrievedEntity;
        }
    }
}