// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    public partial class UserMessagesCollectionRequest
    {
        /// <summary>
        /// Adds the specified search value to the request.
        /// </summary>
        /// <param name="value">The search value.</param>
        /// <returns>The request object to send.</returns>
        public IUserMessagesCollectionRequest Search(string value)
        {
            this.QueryOptions.Add(new QueryOption("$search", value));
            return this;
        }
    }
}
