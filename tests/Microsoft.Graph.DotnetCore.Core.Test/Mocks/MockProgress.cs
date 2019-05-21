// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Mocks
{
    using Moq;
    using System;
    public class MockProgress : Mock<IProgress<AsyncOperationStatus>>
    {
        public MockProgress()
            : base(MockBehavior.Strict)
        {
            this.Setup(mockProgress => mockProgress.Report(It.IsAny<AsyncOperationStatus>()));
        }
    }
}
