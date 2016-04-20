// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Mocks
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Graph.Core;
    using Moq;

    public class MockAuthenticationProvider : Mock<IAuthenticationProvider>
    {
        public MockAuthenticationProvider()
            : base(MockBehavior.Strict)
        {
            this.SetupAllProperties();

            this.Setup(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>())).Returns(Task.FromResult(0));
        }
    }
}
