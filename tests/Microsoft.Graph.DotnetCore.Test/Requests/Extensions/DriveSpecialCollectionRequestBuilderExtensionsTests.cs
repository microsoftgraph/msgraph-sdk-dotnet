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
    public class DriveSpecialCollectionRequestBuilderExtensionsTests : RequestTestBase
    {
        [Fact]
        public void AppRoot()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/special/approot");
            var driveItemRequestBuilder = this.graphServiceClient.Me.Drive.Special.AppRoot as DriveItemRequestBuilder;

            Assert.NotNull(driveItemRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(driveItemRequestBuilder.RequestUrl));
        }
    }
}
