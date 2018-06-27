// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System.Collections.Generic;
    using System.Threading;

    public partial class UserActivitiesCollectionRequestExtensions : BaseRequest
    {
        /// <summary>
        /// Constructs a new UserActivitiesCollectionRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UserActivitiesCollectionRequestExtensions(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Adds the specified UserActivity to the collection via PUT.
        /// </summary>
        /// <param name="userActivity">The UserActivity to add.</param>
        /// <returns>The created UserActivity.</returns>
        public System.Threading.Tasks.Task<UserActivity> AddUserActivityAsync(UserActivity userActivity)
        {
            return this.AddUserActivityAsync(userActivity, CancellationToken.None);
        }

        /// <summary>
        /// Adds or replaces the specified UserActivity to the collection via PUT.
        /// </summary>
        /// <param name="userActivity">The UserActivity to add.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created UserActivity.</returns>
        public System.Threading.Tasks.Task<UserActivity> AddUserActivityAsync(UserActivity userActivity, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "PUT";
            this.AppendSegmentToRequestUrl(userActivity.AppActivityId);
            return this.SendAsync<UserActivity>(userActivity, cancellationToken);
        }
    }
}
