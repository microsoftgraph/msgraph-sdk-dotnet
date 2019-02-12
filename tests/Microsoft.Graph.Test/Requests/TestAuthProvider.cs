// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    public class TestAuthProvider : IAuthenticationProvider
    {
        public string CloudName { get; private set; }

        public TestAuthProvider(string cloudName)
        {
            CloudName = cloudName;
        }
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            await Task.FromResult(0);
        }
    }
}
