using System;
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
        private ICollectionPage<T> initialPage;
        private Func<T, bool> processPageItem;

        public string Deltalink { get; private set; }
        public string Nextlink { get; private set; }

        /// <summary>
        /// Creates the PageIterator with the results of an initial paged request. 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="processPageItems">A Func delegate that processes type T in the result set and should return false if the iterator should cancel processing.</param>
        /// <returns>A PageIterator&lt;T&gt; that will process additional result pages based on the rules specified in Func&lt;T,bool&gt; processPageItems</returns>
        public static PageIterator<T> CreatePageIterator(ICollectionPage<T> page, Func<T,bool> processPageItems)
        {
            if (page == null)
                throw new ArgumentNullException("page");

            if (processPageItems == null)
                throw new ArgumentNullException("processPageItems");

            return new PageIterator<T>()
            {
                initialPage = page,
                processPageItem = processPageItems
            };
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
        public async Task IterateAsync(CancellationToken token)
        {
            // TODO: Handle DeltaLink. We should probably return it as a string if the NextPageRequest 
            // returns @odata.deltalink. Q: should we have the customer specify whether they are iterating
            // based on a delta query, or do we always check for the value and return it when it is present?

            // We need access to the NextPageRequest to call and get the next page. ICollectionPage<T> doesn't define NextPageRequest.
            // We are making this dynamic so we can access NextPageRequest.
            dynamic page = initialPage;

            bool shouldFetchMorePages = true; // Set false if no more pages to fetch or if processPageItem() returns false

            do
            {
                // Process each item in a page.
                foreach (T item in page) // TODO: remove items from the current page collection as they are processed so that we resume from the same spot.
                {
                    bool shouldContinue = processPageItem(item);

                    // Cancel processing of items in the page and stop requesting more pages.
                    if (!shouldContinue)
                    {
                        shouldFetchMorePages = false;
                        break;
                    }
                }

                // Fetch the next page of results. RuntimeBinderException expection can be thrown if page is a base CollectionPage object.
                if (page.NextPageRequest != null && shouldFetchMorePages && !token.IsCancellationRequested)
                {
                    page = await page.NextPageRequest.GetAsync().ConfigureAwait(false);
                }
                else
                {
                    shouldFetchMorePages = false;
                }
            } while (shouldFetchMorePages);
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
}