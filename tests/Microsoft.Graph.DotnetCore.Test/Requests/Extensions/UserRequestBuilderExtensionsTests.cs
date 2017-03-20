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
    public class UserRequestBuilderExtensionsTests : RequestTestBase
    {
        [Fact]
        public void ItemWithPath()
        {
            var graphBaseUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0");
            var itemPath = "/drive/root:/path/to/item";
            var expectedRequestUri = new Uri(string.Format("{0}/me{1}:", graphBaseUrl, itemPath));

            var driveItemRequestBuilder = this.graphServiceClient.Me.ItemWithPath(itemPath) as DriveItemRequestBuilder;

            Assert.NotNull(driveItemRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(driveItemRequestBuilder.RequestUrl));
        }
    }
}
