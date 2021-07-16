// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------


namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Linq.Expressions;
    using System.IO;

    /// <summary>
    /// The type OnenoteSectionPagesCollectionRequest.
    /// </summary>
    public partial class OnenoteSectionPagesCollectionRequest : BaseRequest, IOnenoteSectionPagesCollectionRequest
    {
        /// <summary>
        /// Adds the specified OnenotePage to the collection via POST.
        /// </summary>
        /// <param name="onenotePage">The OnenotePage to add in stream form.</param>
        /// <returns>The created OnenotePage.</returns>
        public System.Threading.Tasks.Task<OnenotePage> AddAsync(MultipartContent onenotePage)
        {
            return this.AddAsync(onenotePage, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified OnenotePage to the collection via POST.
        /// </summary>
        /// <param name="onenotePage">The OnenotePage to add in stream form.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created OnenotePage.</returns>
        public System.Threading.Tasks.Task<OnenotePage> AddAsync(MultipartContent onenotePage, CancellationToken cancellationToken)
        {
            //this.ContentType = contentType;
            this.Method = HttpMethods.POST;
            return this.SendMultiPartAsync<OnenotePage>(onenotePage, cancellationToken);
        }
        
        /// <summary>
        /// Adds the specified OnenotePage to the collection via POST.
        /// </summary>
        /// <param name="onenotePage">The OnenotePage to add in stream form.</param>
        /// <param name="contentType">The content type of the stream. Values can be text/html or application/xhtml+xml.</param>
        /// <returns>The created OnenotePage.</returns>
        public System.Threading.Tasks.Task<OnenotePage> AddAsync(Stream onenotePage, string contentType)
        {
            return this.AddAsync(onenotePage, contentType, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified OnenotePage to the collection via POST.
        /// </summary>
        /// <param name="onenotePage">The OnenotePage to add in stream form.</param>
        /// <param name="contentType">The content type of the stream. Values can be text/html or application/xhtml+xml.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created OnenotePage.</returns>
        public System.Threading.Tasks.Task<OnenotePage> AddAsync(Stream onenotePage, string contentType, CancellationToken cancellationToken)
        {
            this.ContentType = contentType;
            this.Method = HttpMethods.POST;
            return this.SendAsync<OnenotePage>(onenotePage, cancellationToken);
        }

        /// <summary>
        /// Adds the specified OnenotePage to the collection via POST.
        /// </summary>
        /// <param name="onenotePage">The OnenotePage to add.</param>
        /// <param name="contentType">The content type of the stream. Values can be text/html or application/xhtml+xml.</param>
        /// <returns>The created OnenotePage.</returns>
        public System.Threading.Tasks.Task<OnenotePage> AddAsync(string onenotePage, string contentType = "text/html")
        {
            return this.AddAsync(onenotePage, contentType, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified OnenotePage to the collection via POST.
        /// </summary>
        /// <param name="onenotePage">The OnenotePage to add.</param>
        /// <param name="contentType">The content type of the stream. Values can be text/html or application/xhtml+xml.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created OnenotePage.</returns>
        public System.Threading.Tasks.Task<OnenotePage> AddAsync(string onenotePage, string contentType, CancellationToken cancellationToken)
        {
            this.ContentType = contentType;
            this.Method = HttpMethods.POST;
            return this.SendAsync<OnenotePage>(onenotePage, cancellationToken);
        }
    }
}
