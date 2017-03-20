// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Exceptions
{
    public class ErrorTests
    {
        [Fact]
        public void VerifyToString()
        {
            var error = new Error
            {
                Code = "code",
                Message = "message",
                ThrowSite = "throwSite",
                InnerError = new Error
                {
                    Code = "innerCode",
                },
            };

            var errorStringBuilder = new StringBuilder();
            errorStringBuilder.Append("Code: code");
            errorStringBuilder.Append(Environment.NewLine);
            errorStringBuilder.Append("Throw site: throwSite");
            errorStringBuilder.Append(Environment.NewLine);
            errorStringBuilder.Append("Message: message");
            errorStringBuilder.Append(Environment.NewLine);
            errorStringBuilder.Append(Environment.NewLine);
            errorStringBuilder.Append("Inner error");
            errorStringBuilder.Append(Environment.NewLine);
            errorStringBuilder.Append("Code: innerCode");
            errorStringBuilder.Append(Environment.NewLine);

            var serviceException = new ServiceException(error);

            Assert.Equal(errorStringBuilder.ToString(), serviceException.ToString());
        }
    }
}
