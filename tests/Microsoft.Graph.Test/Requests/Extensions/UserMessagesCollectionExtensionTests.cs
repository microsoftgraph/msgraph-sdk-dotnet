// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Extensions
{
    using System;

    using Microsoft.Graph;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserMessagesCollectionExtensionTests : RequestTestBase
    {

        [TestMethod]
        public void Search()
        {
            var expectedRequestUrl = string.Format("{0}/me/messages", this.graphBaseUrl);

            var userMessagesCollectionRequest = this.graphServiceClient.Me.Messages.Request().Search("\"to:user@mail.com\"") as UserMessagesCollectionRequest;

            Assert.IsNotNull(userMessagesCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(userMessagesCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, userMessagesCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$search", userMessagesCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("\"to:user@mail.com\"", userMessagesCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
    }
}
