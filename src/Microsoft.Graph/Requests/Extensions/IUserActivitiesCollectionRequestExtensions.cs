namespace Microsoft.Graph
{
    using System.Threading;

    public partial interface IUserActivitiesCollectionRequest
    {
        /// <summary>
        /// Adds the specified UserActivity to the collection via PUT.
        /// </summary>
        /// <param name="userActivity">The UserActivity to add.</param>
        /// <returns>The created UserActivity.</returns>
        System.Threading.Tasks.Task<UserActivity> AddUserActivityAsync(UserActivity userActivity);

        /// <summary>
        /// Adds or replaces the specified UserActivity to the collection via PUT.
        /// </summary>
        /// <param name="userActivity">The UserActivity to add.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created UserActivity.</returns>
        System.Threading.Tasks.Task<UserActivity> AddUserActivityAsync(UserActivity userActivity, CancellationToken cancellationToken);
    }
}
