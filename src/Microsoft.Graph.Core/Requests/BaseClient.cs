// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System.Threading.Tasks;

    /// <summary>
    /// A default <see cref="IBaseClient"/> implementation.
    /// </summary>
    public class BaseClient : IBaseClient
    {
        private string baseUrl;
        
        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0."</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        public BaseClient(
            string baseUrl,
            IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null)
        {
            this.BaseUrl = baseUrl;
            this.AuthenticationProvider = authenticationProvider;
            this.HttpProvider = httpProvider ?? new HttpProvider(new Serializer());
        }

        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating requests.
        /// </summary>
        public IAuthenticationProvider AuthenticationProvider { get; set; }

        /// <summary>
        /// Gets or sets the base URL for requests of the client.
        /// </summary>
        public string BaseUrl
        {
            get { return this.baseUrl; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.InvalidRequest,
                            Message = ErrorConstants.Messages.BaseUrlMissing,
                        });
                }

                this.baseUrl = value.TrimEnd('/');
            }
        }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        public IHttpProvider HttpProvider { get; private set; }
    }
}
