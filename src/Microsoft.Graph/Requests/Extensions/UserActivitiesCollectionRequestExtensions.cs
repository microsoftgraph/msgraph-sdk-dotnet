// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System.Collections.Generic;
    using System.Threading;

    public partial class UserActivitiesCollectionRequest
    {
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
