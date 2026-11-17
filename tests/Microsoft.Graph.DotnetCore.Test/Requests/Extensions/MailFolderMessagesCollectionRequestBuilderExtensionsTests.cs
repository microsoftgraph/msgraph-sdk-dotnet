// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph.DotnetCore.Test.Mocks;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Extensions
{
    using System;
    using Xunit;
    public class MailFolderMessagesCollectionRequestBuilderExtensionsTests
    {
        [Fact]
        public void DeletedItems()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/users/TokenToReplace/mailFolders/DeletedItems");
            var mailFolderRequestInformation = graphServiceClient.Me.MailFolders["DeletedItems"].ToGetRequestInformation();
            
            Assert.NotNull(mailFolderRequestInformation);
            Assert.Equal(expectedRequestUri, mailFolderRequestInformation.URI);
        }

        [Fact]
        public void Drafts()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/users/TokenToReplace/mailFolders/Drafts");
            var mailFolderRequestInformation = graphServiceClient.Me.MailFolders["Drafts"].ToGetRequestInformation();
            
            Assert.NotNull(mailFolderRequestInformation);
            Assert.Equal(expectedRequestUri, mailFolderRequestInformation.URI);
        }

        [Fact]
        public void Inbox()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/users/TokenToReplace/mailFolders/Inbox");
            var mailFolderRequestInformation = graphServiceClient.Me.MailFolders["Inbox"].ToGetRequestInformation();
            
            Assert.NotNull(mailFolderRequestInformation);
            Assert.Equal(expectedRequestUri, mailFolderRequestInformation.URI);
        }

        [Fact]
        public void SentItems()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/users/TokenToReplace/mailFolders/SentItems");
            var mailFolderRequestInformation = graphServiceClient.Me.MailFolders["SentItems"].ToGetRequestInformation();
            
            Assert.NotNull(mailFolderRequestInformation);
            Assert.Equal(expectedRequestUri, mailFolderRequestInformation.URI);
        }
    }
}
