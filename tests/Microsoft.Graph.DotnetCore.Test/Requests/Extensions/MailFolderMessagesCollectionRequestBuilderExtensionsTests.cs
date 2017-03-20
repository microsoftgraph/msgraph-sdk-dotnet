// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Extensions
{
    public class MailFolderMessagesCollectionRequestBuilderExtensionsTests : RequestTestBase
    {
        [Fact]
        public void DeletedItems()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/mailFolders/DeletedItems");
            var mailFolderRequestBuilder = this.graphServiceClient.Me.MailFolders.DeletedItems as MailFolderRequestBuilder;

            Assert.NotNull(mailFolderRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(mailFolderRequestBuilder.RequestUrl));
        }

        [Fact]
        public void Drafts()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/mailFolders/Drafts");
            var mailFolderRequestBuilder = this.graphServiceClient.Me.MailFolders.Drafts as MailFolderRequestBuilder;

            Assert.NotNull(mailFolderRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(mailFolderRequestBuilder.RequestUrl));
        }

        [Fact]
        public void Inbox()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/mailFolders/Inbox");
            var mailFolderRequestBuilder = this.graphServiceClient.Me.MailFolders.Inbox as MailFolderRequestBuilder;

            Assert.NotNull(mailFolderRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(mailFolderRequestBuilder.RequestUrl));
        }

        [Fact]
        public void SentItems()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/mailFolders/SentItems");
            var mailFolderRequestBuilder = this.graphServiceClient.Me.MailFolders.SentItems as MailFolderRequestBuilder;

            Assert.NotNull(mailFolderRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(mailFolderRequestBuilder.RequestUrl));
        }
    }
}
