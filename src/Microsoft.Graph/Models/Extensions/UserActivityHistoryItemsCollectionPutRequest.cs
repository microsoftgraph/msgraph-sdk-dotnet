namespace Microsoft.Graph.Models.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public partial class UserActivityHistoryItemsCollectionPutRequest : BaseRequest
    {
        /// <summary>
        /// Constructs a new UserActivitiesCollectionRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public UserActivityHistoryItemsCollectionPutRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

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
            this.Method = "PUT";
            this.AppendSegmentToRequestUrl(activityHistoryItem.Id ?? Guid.NewGuid().ToString());
            return this.SendAsync<ActivityHistoryItem>(activityHistoryItem, cancellationToken);
        }
    }
}
