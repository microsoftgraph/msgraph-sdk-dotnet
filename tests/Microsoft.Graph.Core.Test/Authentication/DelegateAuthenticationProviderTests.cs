// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Authentication
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Microsoft.Graph.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthenticationProviderTests
    {
        [TestMethod]
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
                Assert.AreEqual(
                    string.Format("{0} {1}", CoreConstants.Headers.Bearer, authenticationToken),
                    httpRequestMessage.Headers.Authorization.ToString(),
                    "Unexpected authorization header set.");
            }
        }

        [TestMethod]
        public async Task AppendAuthenticationHeaderAsync_DelegateNotSet()
        {
            var authenticationProvider = new DelegateAuthenticationProvider(null);

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                await authenticationProvider.AuthenticateRequestAsync(httpRequestMessage);
                Assert.IsNull(httpRequestMessage.Headers.Authorization, "Unexpected authorization header set.");
            }
        }
    }
}
