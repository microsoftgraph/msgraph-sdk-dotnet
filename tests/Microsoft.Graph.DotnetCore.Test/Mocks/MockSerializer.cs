// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;

namespace Microsoft.Graph.DotnetCore.Test.Mocks
{
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
