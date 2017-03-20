// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Graph.DotnetCore.Core.Test.Mocks
{
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
