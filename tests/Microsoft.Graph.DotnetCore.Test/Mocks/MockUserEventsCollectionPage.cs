// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Mocks
{
    using System;
    using System.Collections.Generic;
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
