using System;
using System.Collections.Generic;

namespace Microsoft.Graph.DotnetCore.Test.Mocks
{
    public class MockUserEventsCollectionPage : CollectionPage<Event>, IUserEventsCollectionPage
    {

        public MockUserEventsCollectionPage(IList<Event> currentPage, MockUserEventsCollectionRequest nextPageRequest) : base(currentPage)
        {
            NextPageRequest = nextPageRequest;
        }

        public IUserEventsCollectionRequest NextPageRequest { get; private set; }

        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            throw new NotImplementedException();
        }
    }
}
