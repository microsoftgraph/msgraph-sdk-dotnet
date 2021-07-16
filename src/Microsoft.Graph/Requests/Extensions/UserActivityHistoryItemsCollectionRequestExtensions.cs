// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public partial class UserActivityHistoryItemsCollectionRequest
    {
        /// <summary>
        /// Adds the specified ActivityHistoryItem to the collection via PUT.
        /// </summary>
        /// <param name="activityHistoryItem">The ActivityHistoryItem to add.</param>
        /// <returns>The created ActivityHistoryItem.</returns>
        public System.Threading.Tasks.Task<ActivityHistoryItem> AddActivityHistoryAsync(ActivityHistoryItem activityHistoryItem)
        {
            return this.AddActivityHistoryAsync(activityHistoryItem, CancellationToken.None);
        }

        /// <summary>
        /// Adds the specified ActivityHistoryItem to the collection via PUT.
        /// </summary>
        /// <param name="activityHistoryItem">The ActivityHistoryItem to add.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created ActivityHistoryItem.</returns>
        public System.Threading.Tasks.Task<ActivityHistoryItem> AddActivityHistoryAsync(ActivityHistoryItem activityHistoryItem, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = HttpMethods.PUT;
            this.AppendSegmentToRequestUrl(activityHistoryItem.Id ?? Guid.NewGuid().ToString());
            return this.SendAsync<ActivityHistoryItem>(activityHistoryItem, cancellationToken);
        }
    }
}
