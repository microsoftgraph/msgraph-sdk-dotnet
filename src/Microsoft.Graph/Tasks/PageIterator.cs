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
    /// Use PageIterator&lt;T&gt; to automatically page through result sets across multiple calls 
    /// and process each item in the result set.
    /// </summary>
    /// <typeparam name="T">The common entity type returned in the result set.</typeparam>
    public class PageIterator<T> where T : Entity
    {
        private ICollectionPage<T> currentPage;
        private Queue<T> pageItemQueue;
        private Func<T, bool> processPageItemCallback;

        // Allow dev to restart paging after PageIterator<T> with these properties and the InitializeNextPage method on descendents of ICollectionPage<T>.
        public string Deltalink { get; private set; }
        public string Nextlink { get; private set; }
        public PagingState State { get; set; }

        /// <summary>
        /// Creates the PageIterator with the results of an initial paged request. 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="callback">A Func delegate that processes type T in the result set and should return false if the iterator should cancel processing.</param>
        /// <returns>A PageIterator&lt;T&gt; that will process additional result pages based on the rules specified in Func&lt;T,bool&gt; processPageItems</returns>
        public static PageIterator<T> CreatePageIterator(ICollectionPage<T> page, Func<T,bool> callback)
        {
            if (page == null)
                throw new ArgumentNullException("page");

            if (callback == null)
                throw new ArgumentNullException("processPageItems");

            return new PageIterator<T>()
            {
                currentPage = page,
                pageItemQueue = new Queue<T>(page),
                State = PagingState.NotStarted,
                processPageItemCallback = callback
            };
        }

        /// <summary>
        /// Iterate across the content of a a single results page.
        /// </summary>
        /// <returns>A boolean that indicates whether to stop iterating.</returns>
        private bool IntrapageIterate()
        {
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

        private async Task InterpageIterateAsync(CancellationToken token)
        {
            // Now iterate over the result pages.
            // We need access to the NextPageRequest to call and get the next page. ICollectionPage<T> doesn't define NextPageRequest.
            // We are making this dynamic so we can access NextPageRequest.
            dynamic page = this.currentPage;

            this.currentPage = await page.NextPageRequest.GetAsync(token).ConfigureAwait(false);
            this.pageItemQueue = new Queue<T>(this.currentPage);


            await IterateAsync(token);
        }
        
        /// <summary>
        /// Fetches page collections and iterates through each page of items and processes it according to the Func&lt;T, bool&gt; set in <see cref="CreatePageIterator"/>. 
        /// </summary>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when a base CollectionPage does not implement NextPageRequest.
        /// is provided to the PageIterator</exception>
        public async Task IterateAsync()
        {
            await IterateAsync(new CancellationToken());
        }

        /// <summary>
        /// Fetches page collections and iterates through each page of items and processes it according to the Func&lt;T, bool&gt; set in <see cref="CreatePageIterator"/>. 
        /// </summary>
        /// <param name="token">The CancellationToken used to stop iterating calls for more pages.</param>
        /// <returns>The task object that represents the results of this asynchronous operation.</returns>
        /// <exception cref="Microsoft.CSharp.RuntimeBinder.RuntimeBinderException">Thrown when a base CollectionPage does not implement NextPageRequest.
        /// is provided to the PageIterator</exception>
        /// <exception cref="Microsoft.Graph.ServiceException">Thrown when the service encounters an error with
        /// a request.</exception>
        public async Task IterateAsync(CancellationToken token)
        {
            // TODO: Handle DeltaLink. We should probably return it as a string if the NextPageRequest 
            // returns @odata.deltalink. Q: should we have the customer specify whether they are iterating
            // based on a delta query, or do we always check for the value and return it when it is present?


            // Iterate over the contents of the current page with the callback.
            bool advance = this.IntrapageIterate();
            if (advance)
            {
                // Capture the nextLink and deltaLink in case we need to restart iteration. 
                // Optimize for nextLink, no link, and then deltalink.
                object deltalink, nextlink;

                if (currentPage.AdditionalData != null && currentPage.AdditionalData.TryGetValue("@odata.nextlink", out nextlink))
                {
                    this.Nextlink = nextlink.ToString();
                    // TODO: get the nextlink and continue inter page iteration.

                    await InterpageIterateAsync(token);

                }
                else if (currentPage.AdditionalData != null && currentPage.AdditionalData.TryGetValue("@odata.deltalink", out deltalink))
                {
                    this.Deltalink = deltalink.ToString();
                    // TODO: InitializeNextPageRequest with the deltalink and stop iterating.
                    // Customer determines when to resume iterating.
                    advance = false;
                    this.State = PagingState.Delta;
                }
                else
                {
                    // Do nothing since there is nothing more to iterate.
                    this.State = PagingState.Complete;
                }
            }
            else
            {
                // intrapage iteration was cancelled by the callback. The iterator is in a resumeable state.
                this.State = PagingState.Paused;
            }
        }

        // TODO: Add paging completeness state.
        // TODO: if page.NextPageRequest is null, then we need to check for a deltalink and save that. 

        public async Task ResumeAsync()
        {
            await ResumeAsync(new CancellationToken());
        }

        public async Task ResumeAsync(CancellationToken token)
        {
            // TODO: when resuming, we first attempt to go through the current collection page. Next, we try to 
            // get the NextPageRequest. Then, when page.NextPageRequest is exhausted, we check whether there is 
            // deltalink. With DeltaLink set, we set state to complete. If ResumeAsnc is called with deltalink set,
            // we set page.InitializeNextPage with deltaLInk, delete that deltalink property, set state to iterating,
            // and call page.NextPageRequest(), looping until we are back here again.
            // Or do I just set DeltaLink and let customer submit a CollectionPage with Deltalink set on it.
            await IterateAsync(token);
        }
    }

    public enum PagingState
    {
        NotStarted,
        Paused,
        IntrapageIteration,
        InterpageIteration,
        Delta,
        Complete
    }

}