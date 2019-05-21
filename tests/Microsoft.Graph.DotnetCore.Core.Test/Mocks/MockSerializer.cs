// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Mocks
{
    using Moq;
    public class MockSerializer : Mock<ISerializer>
    {
        public MockSerializer()
            : base(MockBehavior.Strict)
        {
            this.Setup(
                provider => provider.SerializeObject(It.IsAny<object>()))
                .Returns("{\"key\": \"value\"}");
        }
    }
}
