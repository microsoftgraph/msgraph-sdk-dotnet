using System;
using System.Collections.Generic;

namespace Microsoft.Graph.DotnetCore.Test.Mocks
{
    public class MockUserEventsCollectionPage : CollectionPage<Event>, IUserEventsCollectionPage
    {

        public MockUserEventsCollectionPage(IList<Event> currentPage, MockUserEventsCollectionRequest nextPageRequest, string linkType = "") : base(currentPage)
        {
            this.AdditionalData = new Dictionary<string, object>();

            if (linkType == "nextlink")
                AdditionalData.Add("@odata.nextlink", "testNextlink");
            else if (linkType == "deltalink")
                AdditionalData.Add("@odata.deltalink", "testDeltalink");

            NextPageRequest = nextPageRequest;
        }

        public IUserEventsCollectionRequest NextPageRequest { get; private set; }

        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            throw new NotImplementedException();
        }
    }
}
