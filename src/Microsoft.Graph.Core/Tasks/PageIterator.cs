using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/**

Spec
    https://github.com/microsoftgraph/msgraph-sdk-design/blob/master/tasks/PageIteratorTask.md
**/

namespace Microsoft.Graph
{
    /// <summary>
    /// Use PageIterator&lt;TEntity&gt; to automatically page through result sets across multiple calls 
    /// and process each item in the result set.
    /// </summary>
    /// <typeparam name="TEntity">The Microsoft Graph entity type returned in the result set.</typeparam>
    public class PageIterator<TEntity>
    {
        private IBaseClient client;
        private ICollectionPage<TEntity> currentPage;
        private Queue<TEntity> pageItemQueue;
        private Func<TEntity, bool> processPageItemCallback;
        
        /// <summary>
        /// The @odata.deltaLink returned from a delta query.
        /// </summary>
        public string Deltalink { get; private set; }
        /// <summary>
        /// The @odata.nextLink returned in a paged result.
        /// </summary>
        public string Nextlink { get; private set; }
        /// <summary>
        /// The PageIterator state.
        /// </summary>
        public PagingState State { get; set; }

        /// <summary>
        /// Creates the PageIterator with the results of an initial paged request. 
        /// </summary>
        /// <param name="client">The GraphServiceClient object used to create the NextPageRequest for a delta query.</param>
        /// <param name="page">A generated implementation of ICollectionPage.</param>
        /// <param name="callback">A Func delegate that processes type TEntity in the result set and should return false if the iterator should cancel processing.</param>
        /// <returns>A PageIterator&lt;TEntity&gt; that will process additional result pages based on the rules specified in Func&lt;TEntity,bool&gt; processPageItems</returns>
        public static PageIterator<TEntity> CreatePageIterator(IBaseClient client, ICollectionPage<TEntity> page, Func<TEntity,bool> callback)
        {
            if (page == null)
                throw new ArgumentNullException("page");

            if (callback == null)
                throw new ArgumentNullException("processPageItems");

            return new PageIterator<TEntity>()
            {
                client = client,
                currentPage = page,
                pageItemQueue = new Queue<TEntity>(page),
                processPageItemCallback = callback,
                State = PagingState.NotStarted
            };
        }

        /// <summary>
        /// Iterate across the content of a a single results page with the callback.
        /// </summary>
        /// <returns>A boolean value that indicates whether the callback cancelled 
        /// iterating across the page results. A value of false indicates that
        /// the iterator should stop iterating.</returns>
        private bool IntrapageIterate()
        {
            State = PagingState.IntrapageIteration;

            bool shouldContinue = true;

            while (pageItemQueue.Count != 0 && shouldContinue)
            {
                shouldContinue = processPageItemCallback(pageItemQueue.Dequeue());

                // Cancel processing of items in the page and stop requesting more pages.
                if (!shouldContinue)
                {
                    break;
                }
            }

            return shouldContinue;
        }

        /// <summary>
        /// Call the next page request when there is another page of data.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.Graph.ServiceException">Thrown when the service encounters an error with
        /// a request.</exception>
        private async Task InterpageIterateAsync(CancellationToken token)
        {
            State = PagingState.InterpageIteration;

            // We need access to the NextPageRequest to call and get the next page. ICollectionPage<TEntity> doesn't define NextPageRequest.
            // We are making this dynamic so we can access NextPageRequest.
            dynamic page = this.currentPage;

            if (page.NextPageRequest == null)
                return;

            this.currentPage = await page.NextPageRequest.GetAsync(token).ConfigureAwait(false);

            if (this.currentPage.Count > 0)
            {
                this.pageItemQueue = new Queue<TEntity>(this.currentPage);
                await IterateAsync(token);
            }
        }

        /// <summary>
        /// Fetches page collections and iterates through each page of items and processes it according to the Func&lt;TEntity, bool&gt; set in <see cref="CreatePageIterator"/>. 
        /// </summary>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when a base CollectionPage that does not implement NextPageRequest
        /// is provided to the PageIterator</exception>
        /// <exception cref="Microsoft.Graph.ServiceException">Thrown when the service encounters an error with
        /// a request.</exception>
        public async Task IterateAsync()
        {
            await IterateAsync(new CancellationToken());
        }

        /// <summary>
        /// Fetches page collections and iterates through each page of items and processes it according to the Func&lt;TEntity, bool&gt; set in <see cref="CreatePageIterator"/>. 
        /// </summary>
        /// <param name="token">The CancellationToken used to stop iterating calls for more pages.</param>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when a base CollectionPage that does not implement NextPageRequest
        /// is provided to the PageIterator</exception>
        /// <exception cref="Microsoft.Graph.ServiceException">Thrown when the service encounters an error with
        /// a request.</exception>
        public async Task IterateAsync(CancellationToken token)
        {
            // Iterate over the contents of the current page with the callback.
            bool requestMorePages = IntrapageIterate();

            // Request more pages if they are available.
            if (requestMorePages && !token.IsCancellationRequested)
            {
                dynamic page = this.currentPage;
                
                // Capture the nextLink and deltaLink in case we need to restart iteration. 
                object nextlink;
                currentPage.AdditionalData.TryGetValue("@odata.nextLink", out nextlink);
                Nextlink = nextlink as string;

                object deltalink;
                currentPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltalink);
                Deltalink = deltalink as string;

                if (page.NextPageRequest != null)
                {
                    await InterpageIterateAsync(token);
                }
                else if (deltalink != null)
                {
                    page.InitializeNextPageRequest(this.client, Deltalink);
                    this.currentPage = page;

                    State = PagingState.Delta;
                }
                else
                {
                    // Do nothing since there is nothing more to iterate.
                    State = PagingState.Complete;
                }
            }
            else
            {
                // intrapage iteration was cancelled by the callback. The iterator is in a resumeable state.
                State = PagingState.Paused;
            }
        }

        /// <summary>
        /// Resumes iterating through each page of items and processes it according to the Func&lt;TEntity, bool&gt; set in <see cref="CreatePageIterator"/>. 
        /// </summary>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when a base CollectionPage that does not implement NextPageRequest
        /// is provided to the PageIterator</exception>
        public async Task ResumeAsync()
        {
            await ResumeAsync(new CancellationToken());
        }

        /// <summary>
        /// Resumes iterating through each page of items and processes it according to the Func&lt;TEntity, bool&gt; set in <see cref="CreatePageIterator"/>. 
        /// </summary>
        /// <param name="token">The CancellationToken used to stop iterating calls for more pages.</param>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when a base CollectionPage that does not implement NextPageRequest
        /// is provided to the PageIterator</exception>
        /// <exception cref="Microsoft.Graph.ServiceException">Thrown when the service encounters an error with
        /// a request.</exception>
        public async Task ResumeAsync(CancellationToken token)
        {
            await IterateAsync(token);
        }
    }

    /// <summary>
    /// Specifies the state of the PageIterator.
    /// </summary>
    public enum PagingState
    {
        /// <summary>
        /// The iterator has neither started iterating thorugh the initial page nor request more pages.
        /// </summary>
        NotStarted,
        /// <summary>
        /// The callback returned false or a cancellation token was set. The iterator is resumeable.
        /// </summary>
        Paused,
        /// <summary>
        /// Iterating across the contents of page.
        /// </summary>
        IntrapageIteration,
        /// <summary>
        /// Iterating across paged requests.
        /// </summary>
        InterpageIteration,
        /// <summary>
        /// A deltaToken was returned. The iterator is resumeable.
        /// </summary>
        Delta,
        /// <summary>
        /// Reached the end of a non-deltaLink paged result set.
        /// </summary>
        Complete
    }
}