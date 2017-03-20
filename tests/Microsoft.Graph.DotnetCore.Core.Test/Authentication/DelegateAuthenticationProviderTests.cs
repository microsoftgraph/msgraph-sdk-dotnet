// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Authentication
{
    public class DelegateAuthenticationProviderTests
    {
        [Fact]
        public async Task AppendAuthenticationHeaderAsync()
        {
            var authenticationToken = "token";

            var authenticationProvider = new DelegateAuthenticationProvider(
                (requestMessage) =>
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue(CoreConstants.Headers.Bearer, authenticationToken);
                    return Task.FromResult(0);
                });

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await authenticationProvider.AuthenticateRequestAsync(httpRequestMessage);
                Assert.Equal(
                    string.Format("{0} {1}", CoreConstants.Headers.Bearer, authenticationToken),
                    httpRequestMessage.Headers.Authorization.ToString());
            }
        }

        [Fact]
        public async Task AppendAuthenticationHeaderAsync_DelegateNotSet()
        {
            var authenticationProvider = new DelegateAuthenticationProvider(null);

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await authenticationProvider.AuthenticateRequestAsync(httpRequestMessage);
                Assert.Null(httpRequestMessage.Headers.Authorization);
            }
        }
    }
}
