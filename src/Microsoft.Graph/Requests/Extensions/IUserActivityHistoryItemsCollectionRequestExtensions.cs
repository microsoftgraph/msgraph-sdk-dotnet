namespace Microsoft.Graph
{
    using System.Threading;

    public partial interface IUserActivityHistoryItemsCollectionRequest
    {
        /// <summary>
        /// Adds the specified ActivityHistoryItem to the collection via PUT.
        /// </summary>
        /// <param name="activityHistoryItem">The ActivityHistoryItem to add.</param>
        /// <returns>The created ActivityHistoryItem.</returns>
        System.Threading.Tasks.Task<ActivityHistoryItem> AddActivityHistoryAsync(ActivityHistoryItem activityHistoryItem);

        /// <summary>
        /// Adds the specified ActivityHistoryItem to the collection via PUT.
        /// </summary>
        /// <param name="activityHistoryItem">The ActivityHistoryItem to add.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created ActivityHistoryItem.</returns>
        System.Threading.Tasks.Task<ActivityHistoryItem> AddActivityHistoryAsync(ActivityHistoryItem activityHistoryItem, CancellationToken cancellationToken);
    }
}
